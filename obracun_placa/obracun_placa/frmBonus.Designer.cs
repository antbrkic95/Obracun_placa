namespace obracun_placa
{
    partial class frmBonus
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRegres = new System.Windows.Forms.TextBox();
            this.txtUskrs = new System.Windows.Forms.TextBox();
            this.txtBozic = new System.Windows.Forms.TextBox();
            this.dtpBonus = new System.Windows.Forms.DateTimePicker();
            this.btnSpremiBonus = new System.Windows.Forms.Button();
            this.btnZatvori = new System.Windows.Forms.Button();
            this.lblRegres = new System.Windows.Forms.Label();
            this.lblUskrs = new System.Windows.Forms.Label();
            this.lblBozic = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegres
            // 
            this.txtRegres.Location = new System.Drawing.Point(92, 43);
            this.txtRegres.Name = "txtRegres";
            this.txtRegres.Size = new System.Drawing.Size(100, 20);
            this.txtRegres.TabIndex = 0;
            // 
            // txtUskrs
            // 
            this.txtUskrs.Location = new System.Drawing.Point(92, 114);
            this.txtUskrs.Name = "txtUskrs";
            this.txtUskrs.Size = new System.Drawing.Size(100, 20);
            this.txtUskrs.TabIndex = 1;
            // 
            // txtBozic
            // 
            this.txtBozic.Location = new System.Drawing.Point(92, 78);
            this.txtBozic.Name = "txtBozic";
            this.txtBozic.Size = new System.Drawing.Size(100, 20);
            this.txtBozic.TabIndex = 2;
            // 
            // dtpBonus
            // 
            this.dtpBonus.CustomFormat = "";
            this.dtpBonus.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBonus.Location = new System.Drawing.Point(92, 150);
            this.dtpBonus.Name = "dtpBonus";
            this.dtpBonus.Size = new System.Drawing.Size(200, 20);
            this.dtpBonus.TabIndex = 3;
            // 
            // btnSpremiBonus
            // 
            this.btnSpremiBonus.Location = new System.Drawing.Point(81, 239);
            this.btnSpremiBonus.Name = "btnSpremiBonus";
            this.btnSpremiBonus.Size = new System.Drawing.Size(79, 35);
            this.btnSpremiBonus.TabIndex = 4;
            this.btnSpremiBonus.Text = "Dodaj";
            this.btnSpremiBonus.UseVisualStyleBackColor = true;
            this.btnSpremiBonus.Click += new System.EventHandler(this.btnSpremiBonus_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Location = new System.Drawing.Point(180, 239);
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(79, 35);
            this.btnZatvori.TabIndex = 5;
            this.btnZatvori.Text = "Odustani";
            this.btnZatvori.UseVisualStyleBackColor = true;
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // lblRegres
            // 
            this.lblRegres.AutoSize = true;
            this.lblRegres.Location = new System.Drawing.Point(12, 43);
            this.lblRegres.Name = "lblRegres";
            this.lblRegres.Size = new System.Drawing.Size(41, 13);
            this.lblRegres.TabIndex = 6;
            this.lblRegres.Text = "Regres";
            // 
            // lblUskrs
            // 
            this.lblUskrs.AutoSize = true;
            this.lblUskrs.Location = new System.Drawing.Point(13, 114);
            this.lblUskrs.Name = "lblUskrs";
            this.lblUskrs.Size = new System.Drawing.Size(54, 13);
            this.lblUskrs.TabIndex = 7;
            this.lblUskrs.Text = "Uskrsnica";
            // 
            // lblBozic
            // 
            this.lblBozic.AutoSize = true;
            this.lblBozic.Location = new System.Drawing.Point(12, 78);
            this.lblBozic.Name = "lblBozic";
            this.lblBozic.Size = new System.Drawing.Size(53, 13);
            this.lblBozic.TabIndex = 8;
            this.lblBozic.Text = "Bozicnica";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(12, 156);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(38, 13);
            this.lblDatum.TabIndex = 9;
            this.lblDatum.Text = "Datum";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(92, 193);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(100, 20);
            this.txtUkupno.TabIndex = 10;
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(13, 200);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(45, 13);
            this.lblUkupno.TabIndex = 11;
            this.lblUkupno.Text = "Ukupno";
            // 
            // frmBonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 332);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblBozic);
            this.Controls.Add(this.lblUskrs);
            this.Controls.Add(this.lblRegres);
            this.Controls.Add(this.btnZatvori);
            this.Controls.Add(this.btnSpremiBonus);
            this.Controls.Add(this.dtpBonus);
            this.Controls.Add(this.txtBozic);
            this.Controls.Add(this.txtUskrs);
            this.Controls.Add(this.txtRegres);
            this.Name = "frmBonus";
            this.Text = "Bonusi";
            this.Load += new System.EventHandler(this.frmBonus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRegres;
        private System.Windows.Forms.TextBox txtUskrs;
        private System.Windows.Forms.TextBox txtBozic;
        private System.Windows.Forms.DateTimePicker dtpBonus;
        private System.Windows.Forms.Button btnSpremiBonus;
        private System.Windows.Forms.Button btnZatvori;
        private System.Windows.Forms.Label lblRegres;
        private System.Windows.Forms.Label lblUskrs;
        private System.Windows.Forms.Label lblBozic;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label lblUkupno;
    }
}