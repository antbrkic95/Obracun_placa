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
    public partial class frmUnosBolovanja : Form
    {
        radnik odabraniBolovanje;
        public frmUnosBolovanja()
        {
            InitializeComponent();
        }

        public frmUnosBolovanja(radnik odabrani) {

            InitializeComponent();
            odabraniBolovanje = odabrani;
        }

        private void frmUnosBolovanja_Load(object sender, EventArgs e)
        {

        }

        private void btnSpremiBolovanje_Click(object sender, EventArgs e)
        {
            int bolovanje;
            bool testBolovanje = int.TryParse(txtRazlogBolovanja.Text, out bolovanje);
            int sati;
            bool testSati = int.TryParse(txtBrojSati.Text, out sati);

            using (var db = new PlaceEntities4())
            {
                if (testBolovanje == false && testSati && !string.IsNullOrEmpty(txtBrojSati.Text) && !string.IsNullOrEmpty(txtRazlogBolovanja.Text))
                {
                    if (odabraniBolovanje != null)
                    {

                        db.radnik.Attach(odabraniBolovanje);
                        sati_bolovanje noviSati = new sati_bolovanje()
                        {
                            razlog_bolovanja = txtRazlogBolovanja.Text,
                            broj_sati = int.Parse(txtBrojSati.Text),
                            radnik = odabraniBolovanje

                        };
                        db.sati_bolovanje.Add(noviSati);
                        db.SaveChanges();
                        Close();

                    }

                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke!");

            }
        }

        private void btnOdustaniBolovanje_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
