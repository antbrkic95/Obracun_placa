namespace obracun_placa
{
    partial class frmUnosBolovanja
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
            this.txtRazlogBolovanja = new System.Windows.Forms.TextBox();
            this.txtBrojSati = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSpremiBolovanje = new System.Windows.Forms.Button();
            this.btnOdustaniBolovanje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRazlogBolovanja
            // 
            this.txtRazlogBolovanja.Location = new System.Drawing.Point(108, 38);
            this.txtRazlogBolovanja.Name = "txtRazlogBolovanja";
            this.txtRazlogBolovanja.Size = new System.Drawing.Size(100, 20);
            this.txtRazlogBolovanja.TabIndex = 0;
            // 
            // txtBrojSati
            // 
            this.txtBrojSati.Location = new System.Drawing.Point(108, 76);
            this.txtBrojSati.Name = "txtBrojSati";
            this.txtBrojSati.Size = new System.Drawing.Size(100, 20);
            this.txtBrojSati.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razlog bolovanja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Broj sati";
            // 
            // btnSpremiBolovanje
            // 
            this.btnSpremiBolovanje.Location = new System.Drawing.Point(32, 133);
            this.btnSpremiBolovanje.Name = "btnSpremiBolovanje";
            this.btnSpremiBolovanje.Size = new System.Drawing.Size(70, 32);
            this.btnSpremiBolovanje.TabIndex = 4;
            this.btnSpremiBolovanje.Text = "Spremi";
            this.btnSpremiBolovanje.UseVisualStyleBackColor = true;
            this.btnSpremiBolovanje.Click += new System.EventHandler(this.btnSpremiBolovanje_Click);
            // 
            // btnOdustaniBolovanje
            // 
            this.btnOdustaniBolovanje.Location = new System.Drawing.Point(124, 133);
            this.btnOdustaniBolovanje.Name = "btnOdustaniBolovanje";
            this.btnOdustaniBolovanje.Size = new System.Drawing.Size(70, 32);
            this.btnOdustaniBolovanje.TabIndex = 5;
            this.btnOdustaniBolovanje.Text = "Odustani";
            this.btnOdustaniBolovanje.UseVisualStyleBackColor = true;
            this.btnOdustaniBolovanje.Click += new System.EventHandler(this.btnOdustaniBolovanje_Click);
            // 
            // frmUnosBolovanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 246);
            this.Controls.Add(this.btnOdustaniBolovanje);
            this.Controls.Add(this.btnSpremiBolovanje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBrojSati);
            this.Controls.Add(this.txtRazlogBolovanja);
            this.Name = "frmUnosBolovanja";
            this.Text = "Unos bolovanja";
            this.Load += new System.EventHandler(this.frmUnosBolovanja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazlogBolovanja;
        private System.Windows.Forms.TextBox txtBrojSati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSpremiBolovanje;
        private System.Windows.Forms.Button btnOdustaniBolovanje;
    }
}