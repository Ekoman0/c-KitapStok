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
    public partial class FormKitapDuzenle : Form
    {
        public FormKitapDuzenle()
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update Kitaplar set KitapAdı='"+textBox1.Text+ "',KitapYazarı='" + textBox2.Text + "',KitapTürü='" + textBox3.Text + "',BasımTarihi='" + textBox4.Text + "',Fiyat='" + textBox5.Text + "' where KitapAdı='"+ textBox1.Text+"'";
            komut.ExecuteNonQuery();
            baglanti.Close();

            verilerigöruntule();
            
        }


        private void metroListView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            {
                if (metroListView2.SelectedItems.Count > 0)
                {
                    ListViewItem itm = metroListView2.SelectedItems[0];
                    textBox1.Text = itm.SubItems[0].Text;
                    textBox2.Text = itm.SubItems[1].Text;
                    textBox3.Text = itm.SubItems[2].Text;
                    textBox4.Text = itm.SubItems[3].Text;
                    textBox5.Text = itm.SubItems[4].Text;
                }
            }
        }

        private void FormKitapDuzenle_Load(object sender, EventArgs e)
        {
            verilerigöruntule();
        }
    }
    
}
