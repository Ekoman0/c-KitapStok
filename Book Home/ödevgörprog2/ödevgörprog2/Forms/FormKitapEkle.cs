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
    public partial class FormKitapEkle : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kitap1.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigöruntule()
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
                metroListView2.Items.Add(ekle);
            }
            baglanti.Close();

        }

        public FormKitapEkle()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Doldurun");
                
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("insert into Kitaplar(KitapAdı,KitapYazarı,KitapTürü,BasımTarihi,Fiyat)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigöruntule();
                MessageBox.Show("kitap eklendi");
            }
        }

        private void metroListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormKitapEkle_Load(object sender, EventArgs e)
        {
            verilerigöruntule();
            
        }   }
}
