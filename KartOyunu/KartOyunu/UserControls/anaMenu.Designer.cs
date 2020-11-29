namespace KartOyunu.UserControls
{
    partial class anaMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.lblMenuBaslik = new System.Windows.Forms.Label();
            this.lblKullaniciBaslik = new System.Windows.Forms.Label();
            this.lblBilgisayarBaslik = new System.Windows.Forms.Label();
            this.tbxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.tbxBilgisayarAdi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBaslat
            // 
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(290, 177);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(185, 55);
            this.btnBaslat.TabIndex = 0;
            this.btnBaslat.Text = "Oyunu Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(290, 267);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(185, 55);
            this.btnCikis.TabIndex = 0;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // lblMenuBaslik
            // 
            this.lblMenuBaslik.AutoSize = true;
            this.lblMenuBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMenuBaslik.Location = new System.Drawing.Point(275, 97);
            this.lblMenuBaslik.Name = "lblMenuBaslik";
            this.lblMenuBaslik.Size = new System.Drawing.Size(217, 42);
            this.lblMenuBaslik.TabIndex = 1;
            this.lblMenuBaslik.Text = "Kart Oyunu";
            // 
            // lblKullaniciBaslik
            // 
            this.lblKullaniciBaslik.AutoSize = true;
            this.lblKullaniciBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciBaslik.Location = new System.Drawing.Point(44, 11);
            this.lblKullaniciBaslik.Name = "lblKullaniciBaslik";
            this.lblKullaniciBaslik.Size = new System.Drawing.Size(106, 20);
            this.lblKullaniciBaslik.TabIndex = 2;
            this.lblKullaniciBaslik.Text = "Kullanıcı Adı";
            // 
            // lblBilgisayarBaslik
            // 
            this.lblBilgisayarBaslik.AutoSize = true;
            this.lblBilgisayarBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgisayarBaslik.Location = new System.Drawing.Point(568, 11);
            this.lblBilgisayarBaslik.Name = "lblBilgisayarBaslik";
            this.lblBilgisayarBaslik.Size = new System.Drawing.Size(117, 20);
            this.lblBilgisayarBaslik.TabIndex = 2;
            this.lblBilgisayarBaslik.Text = "Bilgisayar Adı";
            // 
            // tbxKullaniciAdi
            // 
            this.tbxKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxKullaniciAdi.Location = new System.Drawing.Point(48, 34);
            this.tbxKullaniciAdi.Multiline = true;
            this.tbxKullaniciAdi.Name = "tbxKullaniciAdi";
            this.tbxKullaniciAdi.Size = new System.Drawing.Size(148, 32);
            this.tbxKullaniciAdi.TabIndex = 3;
            // 
            // tbxBilgisayarAdi
            // 
            this.tbxBilgisayarAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxBilgisayarAdi.Location = new System.Drawing.Point(572, 34);
            this.tbxBilgisayarAdi.Multiline = true;
            this.tbxBilgisayarAdi.Name = "tbxBilgisayarAdi";
            this.tbxBilgisayarAdi.Size = new System.Drawing.Size(148, 32);
            this.tbxBilgisayarAdi.TabIndex = 3;
            // 
            // anaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxBilgisayarAdi);
            this.Controls.Add(this.tbxKullaniciAdi);
            this.Controls.Add(this.lblBilgisayarBaslik);
            this.Controls.Add(this.lblKullaniciBaslik);
            this.Controls.Add(this.lblMenuBaslik);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnBaslat);
            this.Name = "anaMenu";
            this.Size = new System.Drawing.Size(776, 426);
            this.Load += new System.EventHandler(this.anaMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label lblMenuBaslik;
        private System.Windows.Forms.Label lblKullaniciBaslik;
        private System.Windows.Forms.Label lblBilgisayarBaslik;
        private System.Windows.Forms.TextBox tbxKullaniciAdi;
        private System.Windows.Forms.TextBox tbxBilgisayarAdi;
    }
}
