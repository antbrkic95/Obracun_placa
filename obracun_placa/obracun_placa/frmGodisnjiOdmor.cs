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
    public partial class frmGodisnjiOdmor : Form
    {
        radnik radnikGodisnji;
        public frmGodisnjiOdmor()
        {
            InitializeComponent();
        }

        public frmGodisnjiOdmor(radnik radnik)
        {
            InitializeComponent();
            radnikGodisnji = radnik;
        }

        private void btnSpremiGodisnji_Click(object sender, EventArgs e)
        {
            int sati;
            bool testSati = int.TryParse(txtSati.Text, out sati);
            using (var db = new PlaceEntities1())
            {
                if (testSati)
                {
                    if (radnikGodisnji != null)
                    {

                        db.radnik.Attach(radnikGodisnji);
                        sati_godisnji noviSati = new sati_godisnji()
                        {
                            //pocetak = dtpPocetak.Value.Date.ToString(),
                            //kraj = dtpKraj.Value.Date.ToString(),
                            broj_sati = int.Parse(txtSati.Text),
                            radnik = radnikGodisnji
                        };
                        db.sati_godisnji.Add(noviSati);
                        db.SaveChanges();
                        Close();

                    }
                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke!");


            }
        }

        private void btnOdustaniGodisnji_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
