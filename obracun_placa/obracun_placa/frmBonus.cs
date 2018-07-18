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
        DateTime trenutno = DateTime.Now;
        DateTime datumNovi;
        DateTime datumPorez;
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
        private void ProvjeraOporezivo(bonus b)
        {
            datumNovi = b.datum.Value.Date;
            DateTime datumGodina = new DateTime(trenutno.Year, 12, 31);
            DateTime datumPocetni = new DateTime(trenutno.Year, 1, 1);
            datumPorez = datumPocetni.AddYears(1);
            var datumP = datumPocetni.ToShortDateString();
            var d = datumGodina.ToShortDateString();
            radnikBonus.bozicnica = b.bozicnica;
            radnikBonus.uskrsnica = b.uskrsnica;
            radnikBonus.regres = b.regres;


            /*if (datumNovi < DateTime.Parse(datumP) || datumNovi > DateTime.Parse(d))
            {
                MessageBox.Show("Usli ste u novu godinu oporezivanja, odaberite datum za tekuću godinu!", "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                txtRegres.Clear();
                txtBozic.Clear();
                txtUskrs.Clear();
                radnikBonus.ukupno_bonus = null;
                radnikBonus.razlika = null;
                radnikBonus.regres = 0;
                radnikBonus.uskrsnica = 0;
                radnikBonus.bozicnica = 0;
            }*/
            if (datumNovi >= DateTime.Parse(datumP) && datumNovi <= DateTime.Parse(d))
            {
                
                if (radnikBonus.ukupno_bonus == null)
                {
                    radnikBonus.ukupno_bonus = radnikBonus.bozicnica + radnikBonus.uskrsnica + radnikBonus.regres;
                    txtUkupno.Text = (radnikBonus.ukupno_bonus).ToString();
                    b.ukupno = radnikBonus.ukupno_bonus;
                }
                else
                {
                    radnikBonus.ukupno_bonus += radnikBonus.bozicnica + radnikBonus.uskrsnica + radnikBonus.regres;
                    txtUkupno.Text = (radnikBonus.ukupno_bonus).ToString();
                    b.ukupno = radnikBonus.ukupno_bonus;

                }


                if (radnikBonus.ukupno_bonus <= 2500)
                {

                    double rezultat = (double)(2500 - radnikBonus.ukupno_bonus);
                    MessageBox.Show("Ostalo Vam je još:" + " " + rezultat + " " + "HRK" + " " + "neoporezivo", "");

                }

                else if (radnikBonus.ukupno_bonus > 2500)
                {
                    double razlika = (double)radnikBonus.ukupno_bonus - 2500;
                    radnikBonus.razlika = razlika;

                }


            }
            else {

                MessageBox.Show("Usli ste u novu godinu oporezivanja, odaberite datum za tekuću godinu!", "", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                txtRegres.Clear();
                txtBozic.Clear();
                txtUskrs.Clear();
                txtUkupno.Clear();
                radnikBonus.razlika = null;
               /* radnikBonus.ukupno_bonus = null;
                radnikBonus.regres = 0;
                radnikBonus.uskrsnica = 0;
                radnikBonus.bozicnica = 0;*/
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

            using (var db = new PlaceEntities4())
            {

                if (testBozic && testRegres && testUskrs)
                {
                    if (radnikBonus != null)
                    {
                        bonus b = new bonus()
                        {
                            regres = double.Parse(txtRegres.Text),
                            bozicnica = double.Parse(txtBozic.Text),
                            uskrsnica = double.Parse(txtUskrs.Text),
                            datum = dtpBonus.Value.Date,
                            radnik = radnikBonus

                        };
                        db.radnik.Attach(radnikBonus);
                        db.bonus.Add(b);              
                        ProvjeraOporezivo(b);
                        db.SaveChanges();
                        txtBozic.Clear();
                        txtRegres.Clear();
                        txtUskrs.Clear();
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