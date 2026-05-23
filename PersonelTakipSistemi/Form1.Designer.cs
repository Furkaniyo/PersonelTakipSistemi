namespace PersonelTakipSistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.girisbuton = new System.Windows.Forms.Button();
            this.rbHak3 = new System.Windows.Forms.RadioButton();
            this.rbHak2 = new System.Windows.Forms.RadioButton();
            this.rbHak1 = new System.Windows.Forms.RadioButton();
            this.kullaniciradio = new System.Windows.Forms.RadioButton();
            this.yoneticiradio = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cikisbuton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kullaniciaditextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.parolatextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.girisbuton);
            this.panel1.Controls.Add(this.rbHak3);
            this.panel1.Controls.Add(this.rbHak2);
            this.panel1.Controls.Add(this.rbHak1);
            this.panel1.Controls.Add(this.kullaniciradio);
            this.panel1.Controls.Add(this.yoneticiradio);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cikisbuton);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.kullaniciaditextbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.parolatextbox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Location = new System.Drawing.Point(222, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 365);
            this.panel1.TabIndex = 0;
            // 
            // girisbuton
            // 
            this.girisbuton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("girisbuton.BackgroundImage")));
            this.girisbuton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.girisbuton.FlatAppearance.BorderSize = 0;
            this.girisbuton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.girisbuton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.girisbuton.Location = new System.Drawing.Point(29, 255);
            this.girisbuton.Name = "girisbuton";
            this.girisbuton.Size = new System.Drawing.Size(92, 77);
            this.girisbuton.TabIndex = 25;
            this.girisbuton.UseVisualStyleBackColor = true;
            this.girisbuton.Click += new System.EventHandler(this.girisbuton_Click);
            // 
            // rbHak3
            // 
            this.rbHak3.AutoCheck = false;
            this.rbHak3.AutoSize = true;
            this.rbHak3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbHak3.Location = new System.Drawing.Point(322, 271);
            this.rbHak3.Name = "rbHak3";
            this.rbHak3.Size = new System.Drawing.Size(14, 13);
            this.rbHak3.TabIndex = 24;
            this.rbHak3.TabStop = true;
            this.rbHak3.UseVisualStyleBackColor = true;
            // 
            // rbHak2
            // 
            this.rbHak2.AutoCheck = false;
            this.rbHak2.AutoSize = true;
            this.rbHak2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbHak2.Location = new System.Drawing.Point(302, 271);
            this.rbHak2.Name = "rbHak2";
            this.rbHak2.Size = new System.Drawing.Size(14, 13);
            this.rbHak2.TabIndex = 23;
            this.rbHak2.TabStop = true;
            this.rbHak2.UseVisualStyleBackColor = true;
            // 
            // rbHak1
            // 
            this.rbHak1.AutoCheck = false;
            this.rbHak1.AutoSize = true;
            this.rbHak1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbHak1.Location = new System.Drawing.Point(282, 271);
            this.rbHak1.Name = "rbHak1";
            this.rbHak1.Size = new System.Drawing.Size(14, 13);
            this.rbHak1.TabIndex = 22;
            this.rbHak1.TabStop = true;
            this.rbHak1.UseVisualStyleBackColor = true;
            // 
            // kullaniciradio
            // 
            this.kullaniciradio.AutoSize = true;
            this.kullaniciradio.BackColor = System.Drawing.Color.Transparent;
            this.kullaniciradio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciradio.ForeColor = System.Drawing.Color.White;
            this.kullaniciradio.Location = new System.Drawing.Point(233, 196);
            this.kullaniciradio.Name = "kullaniciradio";
            this.kullaniciradio.Size = new System.Drawing.Size(93, 24);
            this.kullaniciradio.TabIndex = 21;
            this.kullaniciradio.TabStop = true;
            this.kullaniciradio.Text = "Kullanıcı";
            this.kullaniciradio.UseVisualStyleBackColor = false;
            // 
            // yoneticiradio
            // 
            this.yoneticiradio.AutoSize = true;
            this.yoneticiradio.BackColor = System.Drawing.Color.Transparent;
            this.yoneticiradio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yoneticiradio.ForeColor = System.Drawing.Color.White;
            this.yoneticiradio.Location = new System.Drawing.Point(68, 196);
            this.yoneticiradio.Name = "yoneticiradio";
            this.yoneticiradio.Size = new System.Drawing.Size(92, 24);
            this.yoneticiradio.TabIndex = 20;
            this.yoneticiradio.TabStop = true;
            this.yoneticiradio.Text = "Yönetici";
            this.yoneticiradio.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(268, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Kalan Hak";
            // 
            // cikisbuton
            // 
            this.cikisbuton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cikisbuton.BackgroundImage")));
            this.cikisbuton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cikisbuton.FlatAppearance.BorderSize = 0;
            this.cikisbuton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cikisbuton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cikisbuton.Location = new System.Drawing.Point(146, 255);
            this.cikisbuton.Name = "cikisbuton";
            this.cikisbuton.Size = new System.Drawing.Size(92, 77);
            this.cikisbuton.TabIndex = 17;
            this.cikisbuton.UseVisualStyleBackColor = true;
            this.cikisbuton.Click += new System.EventHandler(this.cikisbuton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(194, 189);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(29, 189);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // kullaniciaditextbox
            // 
            this.kullaniciaditextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kullaniciaditextbox.Location = new System.Drawing.Point(52, 58);
            this.kullaniciaditextbox.Multiline = true;
            this.kullaniciaditextbox.Name = "kullaniciaditextbox";
            this.kullaniciaditextbox.Size = new System.Drawing.Size(186, 32);
            this.kullaniciaditextbox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Parola";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // parolatextbox
            // 
            this.parolatextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.parolatextbox.Location = new System.Drawing.Point(52, 131);
            this.parolatextbox.Multiline = true;
            this.parolatextbox.Name = "parolatextbox";
            this.parolatextbox.PasswordChar = '*';
            this.parolatextbox.Size = new System.Drawing.Size(186, 32);
            this.parolatextbox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Kullanıcı Adı";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(13, 58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personel Takip";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(56, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hoş Geldiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(52, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sistemi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 389);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Takip Sistemi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox parolatextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox kullaniciaditextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cikisbuton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton kullaniciradio;
        private System.Windows.Forms.RadioButton yoneticiradio;
        private System.Windows.Forms.RadioButton rbHak1;
        private System.Windows.Forms.RadioButton rbHak3;
        private System.Windows.Forms.RadioButton rbHak2;
        private System.Windows.Forms.Button girisbuton;
    }
}

