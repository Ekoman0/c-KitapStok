using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ödevgörprog2.Forms
{
    public partial class FormKitaplar : Form
    {

      

        public FormKitaplar()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kitap1.accdb");
        OleDbCommand komut = new OleDbCommand();
        public void  verilerigöuntule()
        {
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
                metroListView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void FormKitaplar_Load(object sender, EventArgs e)
        {
            verilerigöuntule();
          

        }
    }
}
