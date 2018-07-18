using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace obracun_placa
{
    public partial class frmUnosSati : Form
    {
        radnik noviRadnik;
        public frmUnosSati()
        {
            InitializeComponent();
        }

        public frmUnosSati(radnik novi) {

            InitializeComponent();
            noviRadnik = novi;

        }

        private void frmUnosSati_Load(object sender, EventArgs e)
        {

        }

        private void btnOdustaniSati_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnosRadnihSati_Click(object sender, EventArgs e)
        {
            int rad;
            bool testNazivRada = int.TryParse(txtNazivRada.Text, out rad);
            int sati;
            bool testSati = int.TryParse(txtBrojSati.Text, out sati);

            using (var db = new PlaceEntities4()) {
                if(testNazivRada==false && testSati && !string.IsNullOrEmpty(txtNazivRada.Text) && !string.IsNullOrEmpty(txtBrojSati.Text)) {
                    if (noviRadnik != null)
                    {

                        db.radnik.Attach(noviRadnik);
                        radniSati noviSati = new radniSati()
                        {
                            vrsta_rada = txtNazivRada.Text,
                            broj_sati = int.Parse(txtBrojSati.Text),
                            radnik = noviRadnik,
                            datum=dtpDatumSati.Value.Date

                        };
                        db.radniSati.Add(noviSati);
                        db.SaveChanges();
                        Close();

                    }
                    
                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke!");

            }
        }
    }
}
