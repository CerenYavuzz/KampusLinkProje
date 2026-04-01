using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KampusLinkProje
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

       // private void guna2Button3_Click(object sender, EventArgs e)
       // {
            private void btnKayitOl_Click(object sender, EventArgs e)
        {
            string ad = txtAdSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string fakulte = comboFakulte.Text;

            // BOŞ KONTROL
            if (string.IsNullOrWhiteSpace(ad) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(sifre) ||
                comboFakulte.SelectedIndex == 0)
            {
                MessageBox.Show("Tüm alanları doldur!");
                return;
            }

            // EMAIL KONTROL
            if (!email.Contains("@"))
            {
                MessageBox.Show("Geçerli email gir!");
                return;
            }

            // DAHA ÖNCE VAR MI
            var mevcut = DataStore.Users
                .FirstOrDefault(x => x.Email == email);

            if (mevcut != null)
            {
                MessageBox.Show("Bu email zaten kayıtlı!");
                return;
            }

            // USER OLUŞTUR
            User yeni = new User()
            {
                AdSoyad = ad,
                Email = email,
                Sifre = sifre,
                Fakulte = fakulte
            };

            // DERSLERİ EKLE
            foreach (Control item in flowDersler.Controls)
            {
                Label lbl = item.Controls[0] as Label;

                if (lbl != null)
                    yeni.VerdigiDersler.Add(lbl.Text);
            }

            // KAYDET
            DataStore.Users.Add(yeni);

            MessageBox.Show("Kayıt başarılı!");

            // LOGIN'E DÖN
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

      //  }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ders = txtDers.Text.Trim();

            if (ders == "")
            {
                MessageBox.Show("Ders gir!");
                return;
            }

            // TAG PANEL
            Panel tagPanel = new Panel();
            tagPanel.Height = 30;
            tagPanel.AutoSize = true;
            tagPanel.BackColor = Color.LightGray;
            tagPanel.Margin = new Padding(5);

            // DERS LABEL
            Label lbl = new Label();
            lbl.Text = ders;
            lbl.AutoSize = true;
            lbl.Location = new Point(5, 7);

            // X BUTONU
            Button btnX = new Button();
            btnX.Text = "X";
            btnX.Size = new Size(25, 25);
            btnX.Location = new Point(lbl.Width + 10, 2);
            btnX.BackColor = Color.Red;
            btnX.ForeColor = Color.White;

            // X'e basınca sil
            btnX.Click += (s, ev) =>
            {
                flowDersler.Controls.Remove(tagPanel);
            };

            // ekle
            tagPanel.Controls.Add(lbl);
            tagPanel.Controls.Add(btnX);

            flowDersler.Controls.Add(tagPanel);

            txtDers.Clear();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            comboFakulte.Items.Insert(0, "Fakülte Seçiniz");
            comboFakulte.SelectedIndex = 0;
            comboFakulte.ForeColor = Color.Gray;

        }

        private void comboFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFakulte.SelectedIndex != 0)
            {
                comboFakulte.ForeColor = Color.Black;
            }

        }

        private void txtDers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEkle.PerformClick();
            }
        }
    }
}
