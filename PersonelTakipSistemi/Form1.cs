using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace PersonelTakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=personel.accdb");
        public static string tcno, adi, soyadi, yetki;


        int hak = 3;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            parolatextbox.PasswordChar = '*';
        }
        bool durum = false;
        private void girisbuton_Click(object sender, EventArgs e)
        {
            durum = false;

            // Yetki seçilmemişse uyarı ver
            if (kullaniciradio.Checked == false && yoneticiradio.Checked == false)
            {
                MessageBox.Show("Lütfen giriş yetkinizi (Yönetici/Kullanıcı) seçiniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kullaniciaditextbox.Text != "" && parolatextbox.Text != "")
            {
                try
                {
                    string secilen_yetki = (yoneticiradio.Checked) ? "Yönetici" : "Kullanıcı";

                    baglantim.Open();
                    string sorgu = "SELECT * FROM kullanicilar WHERE kullaniciadi = @kulAdi AND parola = @sifre AND yetki = @yetki";
                    OleDbCommand selectsorgu = new OleDbCommand(sorgu, baglantim);

                    selectsorgu.Parameters.AddWithValue("@kulAdi", kullaniciaditextbox.Text);
                    selectsorgu.Parameters.AddWithValue("@sifre", parolatextbox.Text);
                    selectsorgu.Parameters.AddWithValue("@yetki", secilen_yetki);

                    OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                    if (kayitokuma.Read())
                    {
                        durum = true;
                        tcno = kayitokuma["tcno"].ToString();
                        adi = kayitokuma["ad"].ToString();
                        soyadi = kayitokuma["soyad"].ToString();
                        yetki = kayitokuma["yetki"].ToString();
                    }
                    baglantim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + hatamsj.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (baglantim.State == ConnectionState.Open) baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre alanlarını boş bırakmayınız!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // --- GİRİŞ BAŞARILI / BAŞARISIZ KONTROLÜ VE HAK DÜŞÜRME EKRANI ---

            if (durum == true)
            {
                MessageBox.Show("Giriş Başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (yoneticiradio.Checked == true)
                {
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                else if (kullaniciradio.Checked == true)
                {
                    Form3 frm3 = new Form3();
                    frm3.Show();
                }
                this.Hide();
            }
            else
            {
                hak--;
                if (hak == 2)
                {
                    rbHak1.Visible = false; // İlk yanlışta 3. hak yandı
                }
                else if (hak == 1)
                {
                    rbHak2.Visible = false; // İkinci yanlışta 2. hak yandı
                }
                else if (hak == 0)
                {
                    rbHak3.Visible = false; // Son hak yandı

                    girisbuton.Enabled = false;
                    MessageBox.Show("Giriş hakkınız kalmadı! Program kapatılıyor.", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                // Eğer hala hakkı varsa uyarı verip sadece şifre ve id kutularını temizlesin
                if (hak > 0)
                {
                    MessageBox.Show("Kullanıcı Adı, Şifre veya Yetki Yanlış!\nKalan Hakkınız: " + hak, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    kullaniciaditextbox.Clear();
                    parolatextbox.Clear();
                    kullaniciaditextbox.Focus();
                }
            }
        }
        private void cikisbuton_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Programdan çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}