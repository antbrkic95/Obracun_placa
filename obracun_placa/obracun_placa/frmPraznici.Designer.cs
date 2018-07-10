namespace obracun_placa
{
    partial class frmPraznici
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
            this.lblPraznik = new System.Windows.Forms.Label();
            this.lblBrojSati = new System.Windows.Forms.Label();
            this.txtPraznik = new System.Windows.Forms.TextBox();
            this.txtBrojSati = new System.Windows.Forms.TextBox();
            this.btnSpremiPraznik = new System.Windows.Forms.Button();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPraznik
            // 
            this.lblPraznik.AutoSize = true;
            this.lblPraznik.Location = new System.Drawing.Point(36, 35);
            this.lblPraznik.Name = "lblPraznik";
            this.lblPraznik.Size = new System.Drawing.Size(42, 13);
            this.lblPraznik.TabIndex = 0;
            this.lblPraznik.Text = "Praznik";
            // 
            // lblBrojSati
            // 
            this.lblBrojSati.AutoSize = true;
            this.lblBrojSati.Location = new System.Drawing.Point(36, 77);
            this.lblBrojSati.Name = "lblBrojSati";
            this.lblBrojSati.Size = new System.Drawing.Size(44, 13);
            this.lblBrojSati.TabIndex = 1;
            this.lblBrojSati.Text = "Broj sati";
            // 
            // txtPraznik
            // 
            this.txtPraznik.Location = new System.Drawing.Point(107, 35);
            this.txtPraznik.Name = "txtPraznik";
            this.txtPraznik.Size = new System.Drawing.Size(100, 20);
            this.txtPraznik.TabIndex = 2;
            // 
            // txtBrojSati
            // 
            this.txtBrojSati.Location = new System.Drawing.Point(107, 77);
            this.txtBrojSati.Name = "txtBrojSati";
            this.txtBrojSati.Size = new System.Drawing.Size(100, 20);
            this.txtBrojSati.TabIndex = 3;
            // 
            // btnSpremiPraznik
            // 
            this.btnSpremiPraznik.Location = new System.Drawing.Point(39, 137);
            this.btnSpremiPraznik.Name = "btnSpremiPraznik";
            this.btnSpremiPraznik.Size = new System.Drawing.Size(78, 34);
            this.btnSpremiPraznik.TabIndex = 4;
            this.btnSpremiPraznik.Text = "Spremi";
            this.btnSpremiPraznik.UseVisualStyleBackColor = true;
            this.btnSpremiPraznik.Click += new System.EventHandler(this.btnSpremiPraznik_Click);
            // 
            // btnOdustani
            // 
            this.btnOdustani.Location = new System.Drawing.Point(129, 137);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(78, 34);
            this.btnOdustani.TabIndex = 5;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani_Click);
            // 
            // frmPraznici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 206);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.btnSpremiPraznik);
            this.Controls.Add(this.txtBrojSati);
            this.Controls.Add(this.txtPraznik);
            this.Controls.Add(this.lblBrojSati);
            this.Controls.Add(this.lblPraznik);
            this.Name = "frmPraznici";
            this.Text = "Unos praznika/blagdana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPraznik;
        private System.Windows.Forms.Label lblBrojSati;
        private System.Windows.Forms.TextBox txtPraznik;
        private System.Windows.Forms.TextBox txtBrojSati;
        private System.Windows.Forms.Button btnSpremiPraznik;
        private System.Windows.Forms.Button btnOdustani;
    }
}