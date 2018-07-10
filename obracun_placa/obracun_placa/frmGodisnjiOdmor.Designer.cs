namespace obracun_placa
{
    partial class frmGodisnjiOdmor
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
            this.lblSati = new System.Windows.Forms.Label();
            this.txtSati = new System.Windows.Forms.TextBox();
            this.btnSpremiGodisnji = new System.Windows.Forms.Button();
            this.btnOdustaniGodisnji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSati
            // 
            this.lblSati.AutoSize = true;
            this.lblSati.Location = new System.Drawing.Point(25, 63);
            this.lblSati.Name = "lblSati";
            this.lblSati.Size = new System.Drawing.Size(64, 13);
            this.lblSati.TabIndex = 3;
            this.lblSati.Text = "Ukupno sati";
            // 
            // txtSati
            // 
            this.txtSati.Location = new System.Drawing.Point(116, 60);
            this.txtSati.Name = "txtSati";
            this.txtSati.Size = new System.Drawing.Size(100, 20);
            this.txtSati.TabIndex = 5;
            // 
            // btnSpremiGodisnji
            // 
            this.btnSpremiGodisnji.Location = new System.Drawing.Point(28, 112);
            this.btnSpremiGodisnji.Name = "btnSpremiGodisnji";
            this.btnSpremiGodisnji.Size = new System.Drawing.Size(81, 34);
            this.btnSpremiGodisnji.TabIndex = 6;
            this.btnSpremiGodisnji.Text = "Spremi";
            this.btnSpremiGodisnji.UseVisualStyleBackColor = true;
            this.btnSpremiGodisnji.Click += new System.EventHandler(this.btnSpremiGodisnji_Click);
            // 
            // btnOdustaniGodisnji
            // 
            this.btnOdustaniGodisnji.Location = new System.Drawing.Point(135, 112);
            this.btnOdustaniGodisnji.Name = "btnOdustaniGodisnji";
            this.btnOdustaniGodisnji.Size = new System.Drawing.Size(81, 34);
            this.btnOdustaniGodisnji.TabIndex = 7;
            this.btnOdustaniGodisnji.Text = "Odustani";
            this.btnOdustaniGodisnji.UseVisualStyleBackColor = true;
            this.btnOdustaniGodisnji.Click += new System.EventHandler(this.btnOdustaniGodisnji_Click);
            // 
            // frmGodisnjiOdmor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 216);
            this.Controls.Add(this.btnOdustaniGodisnji);
            this.Controls.Add(this.btnSpremiGodisnji);
            this.Controls.Add(this.txtSati);
            this.Controls.Add(this.lblSati);
            this.Name = "frmGodisnjiOdmor";
            this.Text = "Godisnji odmor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSati;
        private System.Windows.Forms.TextBox txtSati;
        private System.Windows.Forms.Button btnSpremiGodisnji;
        private System.Windows.Forms.Button btnOdustaniGodisnji;
    }
}