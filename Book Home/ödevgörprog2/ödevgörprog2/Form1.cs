using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ödevgörprog2
{
    public partial class Form1 : Form
    {

        private Form activeForm;



        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void OpenChildForm(Form childForm, object btnSender) 
        {
            if(activeForm!= null )
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktoPanel.Controls.Add(childForm);
            this.panelDesktoPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void panelDesktoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKitaplar(), sender);
            lbltitle.Text = "KİTAPLAR";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKitapEkle(), sender);
            lbltitle.Text = "KİTAP EKLE";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKitapSil(), sender);
            lbltitle.Text = "KİTAP SİL";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKitapDuzenle(), sender);
            lbltitle.Text = "KİTAP DÜZENLE";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormKitapAra(), sender);
            lbltitle.Text = "KİTAP ARA";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void paneltitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        
    }
}
