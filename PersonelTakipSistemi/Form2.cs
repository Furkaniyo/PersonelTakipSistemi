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
using System.Text.RegularExpressions;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PersonelTakipSistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection(@"Provider=Microsoft.Ace.OleDb.12.0;Data Source=|DataDirectory|\personel.accdb");

        private void KullanicilariListele()
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;

                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("SELECT * FROM kullanicilar ORDER BY ad ASC", baglantim);
                DataSet verikumesi = new DataSet();
                listele.Fill(verikumesi);

                dataGridView1.Columns.Add("tcno", "TC Kimlik No");
                dataGridView1.Columns["tcno"].DataPropertyName = "tcno";

                dataGridView1.Columns.Add("ad", "Adı");
                dataGridView1.Columns["ad"].DataPropertyName = "ad";

                dataGridView1.Columns.Add("soyad", "Soyadı");
                dataGridView1.Columns["soyad"].DataPropertyName = "soyad";

                dataGridView1.Columns.Add("yetki", "Yetkisi");
                dataGridView1.Columns["yetki"].DataPropertyName = "yetki";

                dataGridView1.Columns.Add("kullaniciadi", "Kullanıcı Adı");
                dataGridView1.Columns["kullaniciadi"].DataPropertyName = "kullaniciadi";

                dataGridView1.Columns.Add("parola", "Parola");
                dataGridView1.Columns["parola"].DataPropertyName = "parola";
                dataGridView1.Columns["parola"].Visible = false;

                dataGridView1.DataSource = verikumesi.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show("Kullanıcılar listelenirken hata oluştu: " + hatamsj.Message, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglantim.State == ConnectionState.Open) baglantim.Close();
            }
        }

        private void PersonelleriListele()
        {
            try
            {
                dataGridView2.Columns.Clear();
                dataGridView2.AutoGenerateColumns = false;

                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("SELECT * FROM personeller ORDER BY ad ASC", baglantim);
                DataSet verikumesi = new DataSet();
                listele.Fill(verikumesi);

                dataGridView2.Columns.Add("tcno", "TC Kimlik No");
                dataGridView2.Columns["tcno"].DataPropertyName = "tcno";

                dataGridView2.Columns.Add("ad", "Adı");
                dataGridView2.Columns["ad"].DataPropertyName = "ad";

                dataGridView2.Columns.Add("soyad", "Soyadı");
                dataGridView2.Columns["soyad"].DataPropertyName = "soyad";

                dataGridView2.Columns.Add("cinsiyet", "Cinsiyeti");
                dataGridView2.Columns["cinsiyet"].DataPropertyName = "cinsiyet";

                dataGridView2.Columns.Add("mezuniyet", "Mezuniyet");
                dataGridView2.Columns["mezuniyet"].DataPropertyName = "mezuniyet";

                dataGridView2.Columns.Add("dogumtarihi", "Doğum Tarihi");
                dataGridView2.Columns["dogumtarihi"].DataPropertyName = "dogumtarihi";

                dataGridView2.Columns.Add("gorevi", "Görevi");
                dataGridView2.Columns["gorevi"].DataPropertyName = "gorevi";

                dataGridView2.Columns.Add("gorevyeri", "Görev Yeri");
                dataGridView2.Columns["gorevyeri"].DataPropertyName = "gorevyeri";

                dataGridView2.Columns.Add("maasi", "Maaşı");
                dataGridView2.Columns["maasi"].DataPropertyName = "maasi";

                dataGridView2.Columns.Add("giristarihi", "Giriş Tarihi");
                dataGridView2.Columns["giristarihi"].DataPropertyName = "giristarihi";

                dataGridView2.DataSource = verikumesi.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show("Personeller listelenirken hata oluştu: " + hatamsj.Message, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglantim.State == ConnectionState.Open) baglantim.Close();
            }
        }

        private void topPage1_temizle()
        {
            tcnotextbox.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            errorProvider1.Clear();
            progressBar1.Value = 0;
        }

        private void topPage2_temizle()
        {
            pictureBox2.Image = null;
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;

            pictureBox1.Height = 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                using (Image img = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg"))
                {
                    pictureBox1.Image = new Bitmap(img);
                }
            }
            catch
            {
                try
                {
                    using (Image img = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg"))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
                catch { pictureBox1.Image = null; }
            }

            this.Text = "YÖNETİCİ İŞLEMLERİ";
            label11.ForeColor = Color.DarkRed;
            label11.Text = Form1.adi + " " + Form1.soyadi;
            tcnotextbox.MaxLength = 11;
            textBox4.MaxLength = 8;
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 10;
            toolTip1.SetToolTip(this.tcnotextbox, "TC Kimlik No 11 Karakter Olmalı!");
            radioButton1.Checked = true;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            KullanicilariListele();
            PersonelleriListele();

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Width = 100;
            pictureBox2.Height = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            maskedTextBox1.Mask = "00000000000";
            maskedTextBox2.Mask = "LL????????????????????";
            maskedTextBox3.Mask = "LL????????????????????";
            maskedTextBox4.Mask = "0000";
            maskedTextBox4.Text = "0";
            maskedTextBox3.Text.ToUpper();
            maskedTextBox2.Text.ToUpper();

            comboBox1.Items.Add("İlköğretim");
            comboBox1.Items.Add("Ortaöğretim");
            comboBox1.Items.Add("Lise");
            comboBox1.Items.Add("Üniversite");

            comboBox2.Items.Add("Yönetici");
            comboBox2.Items.Add("Memur");
            comboBox2.Items.Add("Şöför");
            comboBox2.Items.Add("İşçi");

            comboBox3.Items.Add("ARGE");
            comboBox3.Items.Add("Bilgi İşlem");
            comboBox3.Items.Add("Muhasebe");
            comboBox3.Items.Add("Üretim");
            comboBox3.Items.Add("Paketleme");
            comboBox3.Items.Add("Nakliye");

            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(1960, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(yil - 18, ay, gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short;

            // Geçmiş tarihi seçmeyi engelliyorum
            dateTimePicker2.MinDate = DateTime.Today;

            radioButton3.Checked = true;
            PersonelleriListele();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "Yönetici Paneli...";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //Tc Kimlik No Textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tcnotextbox.Text.Length < 11)
            {
                errorProvider1.SetError(tcnotextbox, "TC Kimlik No 11 karakter olmalıdır!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Ad Textbox
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Soyad Textbox
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Kullanıcı Adı Textbox
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 8)
                errorProvider1.SetError(textBox4, "Kullanıcı Adı 8 Karakter Olmalı!");
            else
                errorProvider1.Clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Parola Textbox 
        int parola_skoru = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string parola_seviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBox5.Text;
            string duzeltilmis_sifre = sifre;

            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I').Replace('ı', 'i')
                                                 .Replace('Ç', 'C').Replace('ç', 'c')
                                                 .Replace('Ş', 'S').Replace('ş', 's')
                                                 .Replace('Ğ', 'G').Replace('ğ', 'g')
                                                 .Replace('Ü', 'U').Replace('ü', 'u')
                                                 .Replace('Ö', 'O').Replace('ö', 'o');

            if (sifre != duzeltilmis_sifre)
            {
                sifre = duzeltilmis_sifre;
                textBox5.Text = sifre;
                textBox5.SelectionStart = textBox5.Text.Length;
            }

            int az_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;

            int AZ_karakter_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            buyuk_harf_skoru = Math.Min(2, AZ_karakter_sayisi) * 10;

            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;

            int sembol_sayisi = sifre.Length - az_karakter_sayisi - AZ_karakter_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;
            if (sifre.Length == 9)
                parola_skoru += 10;
            else if (sifre.Length >= 10)
                parola_skoru += 20;

            if (kucuk_harf_skoru == 0 || buyuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
                label22.Text = "Şifreni Güçlendir";
            if (kucuk_harf_skoru != 0 && buyuk_harf_skoru != 0 && rakam_skoru != 0 && sembol_skoru != 0)
                label22.Text = "";

            if (parola_skoru < 70)
                parola_seviyesi = "Kabul Edilemez!";
            else if (parola_skoru == 70 || parola_skoru == 80)
                parola_seviyesi = "Güçlü";
            else if (parola_skoru == 90 || parola_skoru == 100)
                parola_seviyesi = "Çok Güçlü";

            label9.Text = "%" + Convert.ToString(parola_skoru);
            label10.Text = parola_seviyesi;
            progressBar1.Value = parola_skoru;
        }

        //Parola Tekrar Textbox
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox5.Text)
                errorProvider1.SetError(textBox6, "Parola Tekrarı Eşleşmiyor!");
            else
                errorProvider1.Clear();
        }

        // Kaydet Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string yetki = "";
            bool kayitkontrol = false;

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + tcnotextbox.Text + "'", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglantim.Close();

            if (kayitkontrol == false)
            {
                if (tcnotextbox.Text.Length < 11 || tcnotextbox.Text == "") label1.ForeColor = Color.Red; else label1.ForeColor = Color.FromArgb(226, 232, 240);
                if (textBox2.Text.Length < 2 || textBox2.Text == "") label2.ForeColor = Color.Red; else label2.ForeColor = Color.FromArgb(226, 232, 240);
                if (textBox3.Text.Length < 2 || textBox3.Text == "") label3.ForeColor = Color.Red; else label3.ForeColor = Color.FromArgb(226, 232, 240);
                if (textBox4.Text.Length < 8 || textBox4.Text == "") label5.ForeColor = Color.Red; else label5.ForeColor = Color.FromArgb(226, 232, 240);
                if (textBox5.Text == "" || parola_skoru < 70) label6.ForeColor = Color.Red; else label6.ForeColor = Color.FromArgb(226, 232, 240);
                if (textBox6.Text == "" || textBox5.Text != textBox6.Text) label7.ForeColor = Color.Red; else label7.ForeColor = Color.FromArgb(226, 232, 240);

                if (tcnotextbox.Text.Length == 11 && tcnotextbox.Text != "" &&
                    textBox2.Text != "" && textBox2.Text.Length > 1 &&
                    textBox3.Text != "" && textBox3.Text.Length > 1 &&
                    textBox4.Text != "" && textBox4.Text.Length >= 8 &&
                    textBox5.Text != "" && textBox6.Text != "" &&
                    textBox5.Text == textBox6.Text && parola_skoru >= 70)
                {
                    if (radioButton1.Checked == true) yetki = "Kullanıcı";
                    else if (radioButton2.Checked == true) yetki = "Yönetici";

                    try
                    {
                        baglantim.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("insert into kullanicilar (tcno, ad, soyad, yetki, kullaniciadi, parola) values ('" + tcnotextbox.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + yetki + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", baglantim);
                        eklekomutu.ExecuteNonQuery();
                        baglantim.Close();
                        MessageBox.Show("Yeni Kullanıcı Kaydı Oluşturuldu!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        topPage1_temizle();
                        KullanicilariListele();
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message);
                        baglantim.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girilen TC Kimlik Numarası Kayıtlıdır!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Güncelle Butonu
        private void button2_Click(object sender, EventArgs e)
        {
            string yetki = "";
            if (tcnotextbox.Text.Length < 11 || tcnotextbox.Text == "") label1.ForeColor = Color.Red; else label1.ForeColor = Color.FromArgb(226, 232, 240);
            if (textBox2.Text.Length < 2 || textBox2.Text == "") label2.ForeColor = Color.Red; else label2.ForeColor = Color.FromArgb(226, 232, 240);
            if (textBox3.Text.Length < 2 || textBox3.Text == "") label3.ForeColor = Color.Red; else label3.ForeColor = Color.FromArgb(226, 232, 240);
            if (textBox4.Text.Length < 8 || textBox4.Text == "") label5.ForeColor = Color.Red; else label5.ForeColor = Color.FromArgb(226, 232, 240);
            if (textBox5.Text == "" || parola_skoru < 70) label6.ForeColor = Color.Red; else label6.ForeColor = Color.FromArgb(226, 232, 240);
            if (textBox6.Text == "" || textBox5.Text != textBox6.Text) label7.ForeColor = Color.Red; else label7.ForeColor = Color.FromArgb(226, 232, 240);

            if (tcnotextbox.Text.Length == 11 && tcnotextbox.Text != "" && textBox2.Text != "" && textBox2.Text.Length > 1 &&
                textBox3.Text != "" && textBox3.Text.Length > 1 && textBox4.Text != "" && textBox5.Text != "" &&
                textBox6.Text != "" && textBox5.Text == textBox6.Text && parola_skoru >= 70)
            {
                if (radioButton1.Checked == true) yetki = "Kullanıcı";
                else if (radioButton2.Checked == true) yetki = "Yönetici";

                try
                {
                    baglantim.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("update kullanicilar set ad='" + textBox2.Text + "' , soyad='" + textBox3.Text + "' ,yetki='" + yetki + "' ,kullaniciadi='" + textBox4.Text + "' ,parola='" + textBox5.Text + "' where tcno='" + tcnotextbox.Text + "'", baglantim);
                    guncellekomutu.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show("Kullanıcı Bilgileri Güncellendi!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    KullanicilariListele();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sil Butonu
        private void button3_Click(object sender, EventArgs e)
        {
            if (tcnotextbox.Text.Length == 11)
            {
                bool kayit_arama_durumu = false;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + tcnotextbox.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    break;
                }
                kayitokuma.Close();

                if (kayit_arama_durumu == true)
                {
                    OleDbCommand deletesorgu = new OleDbCommand("delete from kullanicilar where tcno='" + tcnotextbox.Text + "'", baglantim);
                    deletesorgu.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Kaydı Silindi!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Silinecek Kayıt Bulunamadı!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                baglantim.Close();
                KullanicilariListele();
                topPage1_temizle();
            }
            else
            {
                MessageBox.Show("Lütfen 11 karakterden oluşan TC Kimlik No giriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Formu Temizle Butonu
        private void button4_Click(object sender, EventArgs e)
        {
            topPage1_temizle();
        }

        //Ara Butonu
        private void button5_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (tcnotextbox.Text.Length == 11)
            {
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + tcnotextbox.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    textBox2.Text = kayitokuma.GetValue(1).ToString();
                    textBox3.Text = kayitokuma.GetValue(2).ToString();
                    if (kayitokuma.GetValue(3).ToString() == "Yönetici") radioButton2.Checked = true;
                    else radioButton1.Checked = true;

                    textBox4.Text = kayitokuma.GetValue(4).ToString();
                    textBox5.Text = kayitokuma.GetValue(5).ToString();
                    textBox6.Text = kayitokuma.GetValue(5).ToString();
                    break;
                }
                baglantim.Close();

                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Lütfen 11 haneli bir Tc Kimlik No giriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage1_temizle();
            }
        }

        //-----------------------Personel İşlemleri--------------------------------//

        //Gözat Butonu
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimsec = new OpenFileDialog();
            resimsec.Title = "Personel Resmi Seçiniz.";
            resimsec.Filter = "JPG Dosyalar (*.jpg) | *.jpg";
            if (resimsec.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox2.Image = new Bitmap(resimsec.OpenFile());
            }
        }

        //Ara Butonu
        private void button7_Click(object sender, EventArgs e)
        {
            bool kayit_arama_durumu = false;
            if (maskedTextBox1.Text.Length == 11)
            {
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    try
                    {
                        using (Image img = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + kayitokuma.GetValue(0).ToString() + ".jpg"))
                        {
                            pictureBox2.Image = new Bitmap(img);
                        }
                    }
                    catch
                    {
                        try
                        {
                            using (Image img = Image.FromFile(Application.StartupPath + "\\personelresimler\\resimyok.jpg"))
                            {
                                pictureBox2.Image = new Bitmap(img);
                            }
                        }
                        catch { pictureBox2.Image = null; }
                    }

                    if (kayitokuma.GetValue(3).ToString() == "Bay") radioButton3.Checked = true; else radioButton4.Checked = true;

                    dateTimePicker1.Text = kayitokuma.GetValue(5).ToString();

                    DateTime girisTarihi;
                    if (DateTime.TryParse(kayitokuma.GetValue(9).ToString(), out girisTarihi))
                    {
                        if (girisTarihi < DateTime.Today)
                            dateTimePicker2.MinDate = girisTarihi;
                        else
                            dateTimePicker2.MinDate = DateTime.Today;
                    }
                    dateTimePicker2.Text = kayitokuma.GetValue(9).ToString();

                    maskedTextBox2.Text = kayitokuma.GetValue(1).ToString();
                    maskedTextBox3.Text = kayitokuma.GetValue(2).ToString();

                    comboBox1.Text = kayitokuma.GetValue(4).ToString();
                    comboBox2.Text = kayitokuma.GetValue(6).ToString();
                    comboBox3.Text = kayitokuma.GetValue(7).ToString();

                    maskedTextBox4.Text = kayitokuma.GetValue(8).ToString();
                    break;
                }
                baglantim.Close();

                if (kayit_arama_durumu == false)
                {
                    MessageBox.Show("Aranan kayıt bulunamadı!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("11 Haneli TC no giriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Güncelle Butonu
        private void button8_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";

            if (maskedTextBox1.MaskCompleted == false) label13.ForeColor = Color.Red; else label13.ForeColor = Color.FromArgb(226, 232, 240);
            if (maskedTextBox2.MaskCompleted == false) label14.ForeColor = Color.Red; else label14.ForeColor = Color.FromArgb(226, 232, 240);
            if (maskedTextBox3.MaskCompleted == false) label15.ForeColor = Color.Red; else label15.ForeColor = Color.FromArgb(226, 232, 240);
            if (comboBox1.Text == "") label17.ForeColor = Color.Red; else label17.ForeColor = Color.FromArgb(226, 232, 240);
            if (comboBox2.Text == "") label19.ForeColor = Color.Red; else label19.ForeColor = Color.FromArgb(226, 232, 240);
            if (comboBox3.Text == "") label20.ForeColor = Color.Red; else label20.ForeColor = Color.FromArgb(226, 232, 240);

            if (maskedTextBox4.MaskCompleted == false || (maskedTextBox4.Text != "" && int.Parse(maskedTextBox4.Text) < 1000))
                label21.ForeColor = Color.Red;
            else
                label21.ForeColor = Color.FromArgb(226, 232, 240);

            if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && label21.ForeColor == Color.FromArgb(226, 232, 240))
            {
                if (radioButton3.Checked == true) cinsiyet = "Bay";
                else if (radioButton4.Checked == true) cinsiyet = "Bayan";

                try
                {
                    baglantim.Open();
                    OleDbCommand guncellekomutu = new OleDbCommand("update personeller set ad='" +
                        maskedTextBox2.Text + "',soyad='" + maskedTextBox3.Text + "',cinsiyet='" +
                        cinsiyet + "',mezuniyet='" + comboBox1.Text + "',dogumtarihi='" +
                        dateTimePicker1.Text + "',gorevi='" + comboBox2.Text + "',gorevyeri='" +
                        comboBox3.Text + "',maasi='" + maskedTextBox4.Text + "', giristarihi='" +
                        dateTimePicker2.Text + "' where tcno='" + maskedTextBox1.Text + "'", baglantim);
                    guncellekomutu.ExecuteNonQuery();
                    baglantim.Close();

                    if (!Directory.Exists(Application.StartupPath + "\\personelresimler"))
                        Directory.CreateDirectory(Application.StartupPath + "\\personelresimler");

                    string dosyaYolu = Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg";

                    try
                    {
                        if (System.IO.File.Exists(dosyaYolu))
                        {
                            System.IO.File.Delete(dosyaYolu);
                        }
                        pictureBox2.Image.Save(dosyaYolu);
                    }
                    catch (Exception imageHata)
                    {
                        MessageBox.Show("Resim güncellenirken hata oluştu: " + imageHata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("Personel Bilgileri Güncellendi!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PersonelleriListele();
                    topPage2_temizle();
                    maskedTextBox4.Text = "0";
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Yazı rengi kırmızı olan alanları yeniden gözden geçiriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Kaydet Butonu
        private void button9_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            bool kayitkontrol = false;

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
            while (kayitokuma.Read())
            {
                kayitkontrol = true;
                break;
            }
            baglantim.Close();

            if (kayitkontrol == false)
            {
                if (pictureBox2.Image == null)
                    button6.ForeColor = Color.Red;
                else
                    button6.ForeColor = Color.Black;

                if (maskedTextBox1.MaskCompleted == false)
                    label13.ForeColor = Color.Red;
                else
                    label13.ForeColor = Color.FromArgb(226, 232, 240);

                if (maskedTextBox2.MaskCompleted == false)
                    label14.ForeColor = Color.Red;
                else
                    label14.ForeColor = Color.FromArgb(226, 232, 240);

                if (maskedTextBox3.MaskCompleted == false)
                    label15.ForeColor = Color.Red;
                else
                    label15.ForeColor = Color.FromArgb(226, 232, 240);

                if (comboBox1.Text == "")
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.FromArgb(226, 232, 240);

                if (comboBox2.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.FromArgb(226, 232, 240);

                if (comboBox3.Text == "")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.FromArgb(226, 232, 240);

                if (dateTimePicker2.Value.Date < DateTime.Today)
                    label23.ForeColor = Color.Red;
                else
                    label23.ForeColor = Color.FromArgb(226, 232, 240);

                if (maskedTextBox4.Text == "" || (maskedTextBox4.Text != "" && int.Parse(maskedTextBox4.Text) < 1000))
                    label21.ForeColor = Color.Red;
                else
                    label21.ForeColor = Color.FromArgb(226, 232, 240);

                if (pictureBox2.Image != null && maskedTextBox1.MaskCompleted != false && maskedTextBox2.MaskCompleted != false && maskedTextBox3.MaskCompleted != false && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && label21.ForeColor != Color.Red)
                {
                    if (radioButton3.Checked == true) cinsiyet = "Bay";
                    else if (radioButton4.Checked == true) cinsiyet = "Bayan";

                    try
                    {
                        baglantim.Open();
                        OleDbCommand eklekomutu = new OleDbCommand("insert into personeller (tcno, ad, soyad, cinsiyet, mezuniyet, dogumtarihi, gorevi, gorevyeri, maasi, giristarihi) values('" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + cinsiyet + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + maskedTextBox4.Text + "','" + dateTimePicker2.Text + "')", baglantim);
                        eklekomutu.ExecuteNonQuery();
                        baglantim.Close();

                        if (!Directory.Exists(Application.StartupPath + "\\personelresimler"))
                            Directory.CreateDirectory(Application.StartupPath + "\\personelresimler");

                        pictureBox2.Image.Save(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg");

                        MessageBox.Show("Yeni personel kaydı oluşturuldu.", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PersonelleriListele();
                        topPage2_temizle();
                        maskedTextBox4.Text = "0";
                    }
                    catch (Exception hatamsj)
                    {
                        MessageBox.Show(hatamsj.Message, "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglantim.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Yazı rengi kırmızı olan alanları veya boş alanları yeniden gözden geçiriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Girilen TC Kimlik Numarası daha önceden kayıtlıdır!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sil Butonu
        private void button10_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskCompleted == true)
            {
                bool kayit_arama_durumu = false;
                baglantim.Open();
                OleDbCommand arama_sorgusu = new OleDbCommand("select * from personeller where tcno='" + maskedTextBox1.Text + "'", baglantim);
                OleDbDataReader kayitokuma = arama_sorgusu.ExecuteReader();

                while (kayitokuma.Read())
                {
                    kayit_arama_durumu = true;
                    break;
                }
                kayitokuma.Close();

                if (kayit_arama_durumu == true)
                {
                    OleDbCommand deletesorgu = new OleDbCommand("delete from personeller where tcno='" + maskedTextBox1.Text + "'", baglantim);
                    deletesorgu.ExecuteNonQuery();
                    MessageBox.Show("Personel Kaydı Silindi!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                baglantim.Close();
                PersonelleriListele();
                topPage2_temizle();
                maskedTextBox4.Text = "0";
            }
            else
            {
                MessageBox.Show("Lütfen 11 karakterden oluşan bir TC Kimlik No giriniz!", "Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                topPage2_temizle();
                maskedTextBox4.Text = "0";
            }
        }

        //Temizle Butonu
        private void button11_Click(object sender, EventArgs e)
        {
            topPage2_temizle();
        }

        //Giriş Ekranı Butonu
        private void button12_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Form1"].Show();
            this.Close();
        }

        //Excel'e Aktar Butonu
        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak personel kaydı bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Excel uygulamasını başlat
            Excel.Application excelDosya = new Excel.Application();
            excelDosya.Visible = true;
            object Missing = Type.Missing;

            // Yeni bir çalışma kitabı ve sayfası oluştur
            Excel.Workbook calismaKitabi = excelDosya.Workbooks.Add(Missing);
            Excel.Worksheet calismaSayfasi = (Excel.Worksheet)calismaKitabi.Worksheets[1];

            // DataGridView'deki Sütun Başlıklarını Excel'e Yazdır
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                calismaSayfasi.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    Excel.Range alan = (Excel.Range)calismaSayfasi.Cells[i + 2, j + 1];
                    alan.NumberFormat = "@";

                    // Veriyi Excel hücresine yazdır
                    alan.Value2 = dataGridView2.Rows[i].Cells[j].Value == null ? "" : dataGridView2.Rows[i].Cells[j].Value.ToString();
                }
            }
            // Yazılar hücrelere sığsın diye sütun genişliklerini otomatik ayarlıyo
            calismaSayfasi.Columns.AutoFit();
        }

        //Kullanıcı DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                tcnotextbox.Text = satir.Cells[0].Value.ToString();
                textBox2.Text = satir.Cells[1].Value.ToString();
                textBox3.Text = satir.Cells[2].Value.ToString();

                string yetki = satir.Cells[3].Value.ToString();
                if (yetki == "Kullanıcı")
                {
                    radioButton1.Checked = true;
                }
                else if (yetki == "Yönetici")
                {
                    radioButton2.Checked = true;
                }

                textBox4.Text = satir.Cells[4].Value.ToString();
                textBox5.Text = satir.Cells[5].Value.ToString();
                textBox6.Text = satir.Cells[5].Value.ToString();
            }
        }

        //Personel DataGridView
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView2.Rows[e.RowIndex];
                maskedTextBox1.Text = satir.Cells[0].Value.ToString();
                maskedTextBox2.Text = satir.Cells[1].Value.ToString();
                maskedTextBox3.Text = satir.Cells[2].Value.ToString();

                string cinsiyet = satir.Cells[3].Value.ToString();
                if (cinsiyet == "Bay")
                    radioButton3.Checked = true;
                else if (cinsiyet == "Bayan")
                    radioButton4.Checked = true;

                comboBox1.Text = satir.Cells[4].Value.ToString();
                dateTimePicker1.Text = satir.Cells[5].Value.ToString();

                DateTime girisTarihi;
                if (DateTime.TryParse(satir.Cells[9].Value.ToString(), out girisTarihi))
                {
                    if (girisTarihi < DateTime.Today)
                        dateTimePicker2.MinDate = girisTarihi;
                    else
                        dateTimePicker2.MinDate = DateTime.Today;
                }
                dateTimePicker2.Text = satir.Cells[9].Value.ToString();

                comboBox2.Text = satir.Cells[6].Value.ToString();
                comboBox3.Text = satir.Cells[7].Value.ToString();
                maskedTextBox4.Text = satir.Cells[8].Value.ToString();

                try
                {
                    using (Image img = Image.FromFile(Application.StartupPath + "\\personelresimler\\" + maskedTextBox1.Text + ".jpg"))
                    {
                        pictureBox2.Image = new Bitmap(img);
                    }
                }
                catch
                {
                    try
                    {
                        using (Image img = Image.FromFile(Application.StartupPath + "\\personelresimler\\resimyok.jpg"))
                        {
                            pictureBox2.Image = new Bitmap(img);
                        }
                    }
                    catch { pictureBox2.Image = null; }
                }
            }
        }
    }
}