namespace obracun_placa
{
    partial class frmUnosSati
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
            this.txtNazivRada = new System.Windows.Forms.TextBox();
            this.txtBrojSati = new System.Windows.Forms.TextBox();
            this.btnUnosRadnihSati = new System.Windows.Forms.Button();
            this.lblNazivRada = new System.Windows.Forms.Label();
            this.lblBrojSati = new System.Windows.Forms.Label();
            this.btnOdustaniSati = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNazivRada
            // 
            this.txtNazivRada.Location = new System.Drawing.Point(77, 26);
            this.txtNazivRada.Name = "txtNazivRada";
            this.txtNazivRada.Size = new System.Drawing.Size(100, 20);
            this.txtNazivRada.TabIndex = 0;
            // 
            // txtBrojSati
            // 
            this.txtBrojSati.Location = new System.Drawing.Point(77, 64);
            this.txtBrojSati.Name = "txtBrojSati";
            this.txtBrojSati.Size = new System.Drawing.Size(100, 20);
            this.txtBrojSati.TabIndex = 1;
            // 
            // btnUnosRadnihSati
            // 
            this.btnUnosRadnihSati.Location = new System.Drawing.Point(16, 108);
            this.btnUnosRadnihSati.Name = "btnUnosRadnihSati";
            this.btnUnosRadnihSati.Size = new System.Drawing.Size(75, 39);
            this.btnUnosRadnihSati.TabIndex = 2;
            this.btnUnosRadnihSati.Text = "Spremi";
            this.btnUnosRadnihSati.UseVisualStyleBackColor = true;
            this.btnUnosRadnihSati.Click += new System.EventHandler(this.btnUnosRadnihSati_Click);
            // 
            // lblNazivRada
            // 
            this.lblNazivRada.AutoSize = true;
            this.lblNazivRada.Location = new System.Drawing.Point(13, 29);
            this.lblNazivRada.Name = "lblNazivRada";
            this.lblNazivRada.Size = new System.Drawing.Size(58, 13);
            this.lblNazivRada.TabIndex = 3;
            this.lblNazivRada.Text = "Naziv rada";
            // 
            // lblBrojSati
            // 
            this.lblBrojSati.AutoSize = true;
            this.lblBrojSati.Location = new System.Drawing.Point(13, 71);
            this.lblBrojSati.Name = "lblBrojSati";
            this.lblBrojSati.Size = new System.Drawing.Size(44, 13);
            this.lblBrojSati.TabIndex = 4;
            this.lblBrojSati.Text = "Broj sati";
            // 
            // btnOdustaniSati
            // 
            this.btnOdustaniSati.Location = new System.Drawing.Point(102, 108);
            this.btnOdustaniSati.Name = "btnOdustaniSati";
            this.btnOdustaniSati.Size = new System.Drawing.Size(75, 39);
            this.btnOdustaniSati.TabIndex = 5;
            this.btnOdustaniSati.Text = "Odustani";
            this.btnOdustaniSati.UseVisualStyleBackColor = true;
            this.btnOdustaniSati.Click += new System.EventHandler(this.btnOdustaniSati_Click);
            // 
            // frmUnosSati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 205);
            this.Controls.Add(this.btnOdustaniSati);
            this.Controls.Add(this.lblBrojSati);
            this.Controls.Add(this.lblNazivRada);
            this.Controls.Add(this.btnUnosRadnihSati);
            this.Controls.Add(this.txtBrojSati);
            this.Controls.Add(this.txtNazivRada);
            this.Name = "frmUnosSati";
            this.Text = "Unos sati";
            this.Load += new System.EventHandler(this.frmUnosSati_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNazivRada;
        private System.Windows.Forms.TextBox txtBrojSati;
        private System.Windows.Forms.Button btnUnosRadnihSati;
        private System.Windows.Forms.Label lblNazivRada;
        private System.Windows.Forms.Label lblBrojSati;
        private System.Windows.Forms.Button btnOdustaniSati;
    }
}