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
    public partial class frmPraznici : Form
    {
        radnik odabraniRadnikPraznik;
        public frmPraznici()
        {
            InitializeComponent();
        }

        public frmPraznici(radnik radnik)
        {
            InitializeComponent();
            odabraniRadnikPraznik = radnik;
        }

        private void btnSpremiPraznik_Click(object sender, EventArgs e)
        {
            int praznik;
            bool testNazivPraznika = int.TryParse(txtPraznik.Text, out praznik);
            int sati;
            bool testSati = int.TryParse(txtBrojSati.Text, out sati);

            using (var db = new PlaceEntities1())
            {
                if (testNazivPraznika == false && testSati)
                {
                    if (odabraniRadnikPraznik != null)
                    {

                        db.radnik.Attach(odabraniRadnikPraznik);
                        sati_blagdani noviSati = new sati_blagdani()
                        {
                            naziv = txtPraznik.Text,
                            broj_sati = int.Parse(txtBrojSati.Text),
                            radnik = odabraniRadnikPraznik

                        };
                        db.sati_blagdani.Add(noviSati);
                        db.SaveChanges();
                        Close();

                    }

                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke!");
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
