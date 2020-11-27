namespace KartOyunu.UserControls
{
    partial class futbolcuKart
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
            this.lblSporcuAdi = new System.Windows.Forms.Label();
            this.lblPenaltiBaslik = new System.Windows.Forms.Label();
            this.lblPenalti = new System.Windows.Forms.Label();
            this.lblSerbestBaslik = new System.Windows.Forms.Label();
            this.lblSerbestVurus = new System.Windows.Forms.Label();
            this.lblKarsiKarsiyaBaslik = new System.Windows.Forms.Label();
            this.lblKarsiKarsiya = new System.Windows.Forms.Label();
            this.lblSporBaslik = new System.Windows.Forms.Label();
            this.btnSec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSporcuAdi
            // 
            this.lblSporcuAdi.AutoSize = true;
            this.lblSporcuAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSporcuAdi.Location = new System.Drawing.Point(3, 32);
            this.lblSporcuAdi.Name = "lblSporcuAdi";
            this.lblSporcuAdi.Size = new System.Drawing.Size(29, 20);
            this.lblSporcuAdi.TabIndex = 0;
            this.lblSporcuAdi.Text = "ad";
            // 
            // lblPenaltiBaslik
            // 
            this.lblPenaltiBaslik.AutoSize = true;
            this.lblPenaltiBaslik.Location = new System.Drawing.Point(5, 69);
            this.lblPenaltiBaslik.Name = "lblPenaltiBaslik";
            this.lblPenaltiBaslik.Size = new System.Drawing.Size(42, 13);
            this.lblPenaltiBaslik.TabIndex = 1;
            this.lblPenaltiBaslik.Text = "Penaltı:";
            // 
            // lblPenalti
            // 
            this.lblPenalti.AutoSize = true;
            this.lblPenalti.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPenalti.Location = new System.Drawing.Point(138, 69);
            this.lblPenalti.Name = "lblPenalti";
            this.lblPenalti.Size = new System.Drawing.Size(19, 20);
            this.lblPenalti.TabIndex = 2;
            this.lblPenalti.Text = "0";
            // 
            // lblSerbestBaslik
            // 
            this.lblSerbestBaslik.AutoSize = true;
            this.lblSerbestBaslik.Location = new System.Drawing.Point(5, 96);
            this.lblSerbestBaslik.Name = "lblSerbestBaslik";
            this.lblSerbestBaslik.Size = new System.Drawing.Size(76, 13);
            this.lblSerbestBaslik.TabIndex = 1;
            this.lblSerbestBaslik.Text = "Serbest Vuruş:";
            // 
            // lblSerbestVurus
            // 
            this.lblSerbestVurus.AutoSize = true;
            this.lblSerbestVurus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSerbestVurus.Location = new System.Drawing.Point(138, 96);
            this.lblSerbestVurus.Name = "lblSerbestVurus";
            this.lblSerbestVurus.Size = new System.Drawing.Size(19, 20);
            this.lblSerbestVurus.TabIndex = 2;
            this.lblSerbestVurus.Text = "0";
            // 
            // lblKarsiKarsiyaBaslik
            // 
            this.lblKarsiKarsiyaBaslik.AutoSize = true;
            this.lblKarsiKarsiyaBaslik.Location = new System.Drawing.Point(4, 124);
            this.lblKarsiKarsiyaBaslik.Name = "lblKarsiKarsiyaBaslik";
            this.lblKarsiKarsiyaBaslik.Size = new System.Drawing.Size(70, 13);
            this.lblKarsiKarsiyaBaslik.TabIndex = 1;
            this.lblKarsiKarsiyaBaslik.Text = "Karşı Karşıya:";
            // 
            // lblKarsiKarsiya
            // 
            this.lblKarsiKarsiya.AutoSize = true;
            this.lblKarsiKarsiya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKarsiKarsiya.Location = new System.Drawing.Point(138, 124);
            this.lblKarsiKarsiya.Name = "lblKarsiKarsiya";
            this.lblKarsiKarsiya.Size = new System.Drawing.Size(19, 20);
            this.lblKarsiKarsiya.TabIndex = 2;
            this.lblKarsiKarsiya.Text = "0";
            // 
            // lblSporBaslik
            // 
            this.lblSporBaslik.AutoSize = true;
            this.lblSporBaslik.Location = new System.Drawing.Point(3, 6);
            this.lblSporBaslik.Name = "lblSporBaslik";
            this.lblSporBaslik.Size = new System.Drawing.Size(48, 13);
            this.lblSporBaslik.TabIndex = 3;
            this.lblSporBaslik.Text = "Futbolcu";
            // 
            // btnSec
            // 
            this.btnSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSec.Location = new System.Drawing.Point(115, 3);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(62, 25);
            this.btnSec.TabIndex = 4;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            // 
            // futbolcuKart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.lblSporBaslik);
            this.Controls.Add(this.lblKarsiKarsiya);
            this.Controls.Add(this.lblSerbestVurus);
            this.Controls.Add(this.lblPenalti);
            this.Controls.Add(this.lblKarsiKarsiyaBaslik);
            this.Controls.Add(this.lblSerbestBaslik);
            this.Controls.Add(this.lblPenaltiBaslik);
            this.Controls.Add(this.lblSporcuAdi);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "futbolcuKart";
            this.Size = new System.Drawing.Size(180, 158);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPenaltiBaslik;
        private System.Windows.Forms.Label lblSerbestBaslik;
        private System.Windows.Forms.Label lblKarsiKarsiyaBaslik;
        public System.Windows.Forms.Label lblSporcuAdi;
        public System.Windows.Forms.Label lblPenalti;
        public System.Windows.Forms.Label lblSerbestVurus;
        public System.Windows.Forms.Label lblKarsiKarsiya;
        public System.Windows.Forms.Label lblSporBaslik;
        public System.Windows.Forms.Button btnSec;
    }
}
