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
    public partial class frmBonus : Form
    {
        radnik radnikBonus;
        public frmBonus()
        {
            InitializeComponent();
        }
        public frmBonus(radnik radnik)
        {
            InitializeComponent();
            radnikBonus = radnik;
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ProvjeraOporezivo(bonus b) {
            DateTime datumNovi = b.datum.Value.AddYears(1);
            DateTime trenutno = DateTime.Now;
            radnikBonus.bozicnica = b.bozicnica;
            radnikBonus.uskrsnica = b.uskrsnica;
            radnikBonus.regres = b.regres;
            radnikBonus.ukupno_bonus += radnikBonus.bozicnica + radnikBonus.uskrsnica + radnikBonus.regres;
            txtUkupno.Text = (radnikBonus.ukupno_bonus).ToString();
            if (trenutno > datumNovi)
            {
                MessageBox.Show("Prosla je godina dana neoporezivanja!");
            }
            else if (trenutno<datumNovi) {
                if (radnikBonus.ukupno_bonus <= 2500)
                {

                    double rezultat = (double)(2500 - radnikBonus.ukupno_bonus);
                    MessageBox.Show("Ostalo Vam je još:" + " " + rezultat + " " + "HRK" + " " + "neoporezivo");

                }
                else if (radnikBonus.ukupno_bonus > 2500)
                {
                    double razlika = (double)radnikBonus.ukupno_bonus - 2500;
                    radnikBonus.razlika = razlika;
                }
            }
                       

        }
        private void btnSpremiBonus_Click(object sender, EventArgs e)
        {
            double regres;
            double bozicnica;
            double uskrsnica;
            bool testRegres = double.TryParse(txtRegres.Text, out regres);
            bool testBozic = double.TryParse(txtBozic.Text, out bozicnica);
            bool testUskrs = double.TryParse(txtUskrs.Text, out uskrsnica);

            using (var db = new PlaceEntities4()) {
                
                if (testBozic && testRegres && testUskrs)
                {
                    if (radnikBonus != null)
                    {
                        bonus b = new bonus()
                        {
                            regres = double.Parse(txtRegres.Text),
                            bozicnica = double.Parse(txtBozic.Text),
                            uskrsnica = double.Parse(txtUskrs.Text),
                            datum=dtpBonus.Value.Date,
                            radnik=radnikBonus

                        };
                        db.radnik.Attach(radnikBonus);
                        ProvjeraOporezivo(b);
                        db.SaveChanges();
                        //Close();
                    }
                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke i za svaku vrstu bonusa je potrebno unijeti pripadajući iznos!");

            }
        }

        private void frmBonus_Load(object sender, EventArgs e)
        {
            //txtUkupno.Text = 0.ToString();
            txtUkupno.Text = radnikBonus.ukupno_bonus.ToString();
        }
    }
}
