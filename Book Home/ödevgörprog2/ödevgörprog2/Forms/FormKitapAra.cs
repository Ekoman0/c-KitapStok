using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödevgörprog2.Forms
{
    public partial class FormKitapAra : Form
    {
        public FormKitapAra()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kitap1.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigöruntule()
        {
            metroListView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Kitaplar");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["KitapAdı"].ToString();
                ekle.SubItems.Add(oku["KitapYazarı"].ToString());
                ekle.SubItems.Add(oku["KitapTürü"].ToString());
                ekle.SubItems.Add(oku["BasımTarihi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                metroListView2.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from Kitaplar where KitapAdı like '" + textBox1.Text + "%' order by KitapAdı", baglanti);
            metroListView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("select * from Kitaplar where KitapAdı like '" + textBox1.Text + "%' order by KitapAdı");
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["KitapAdı"].ToString();
                ekle.SubItems.Add(oku["KitapYazarı"].ToString());
                ekle.SubItems.Add(oku["KitapTürü"].ToString());
                ekle.SubItems.Add(oku["BasımTarihi"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                metroListView2.Items.Add(ekle);
            }
            baglanti.Close();



        }

        private void FormKitapAra_Load(object sender, EventArgs e)
        {
            verilerigöruntule();
        }
    }


}

