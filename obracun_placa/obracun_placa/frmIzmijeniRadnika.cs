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
    public partial class frmIzmijeniRadnika : Form
    {
        radnik radnikIzmjena ;
        poslodavac izmjenaPoslodavac;
        public frmIzmijeniRadnika()
        {
            InitializeComponent();
        }

        public frmIzmijeniRadnika(radnik izmjenjeni) {

            InitializeComponent();
            radnikIzmjena = izmjenjeni;
           
        }
        private void frmIzmijeniRadnika_Load(object sender, EventArgs e)
        {
            txtIzmjenaIme.Focus();
            if (radnikIzmjena != null) {

                txtIzmjenaIme.Text = radnikIzmjena.ime;
                txtIzmjenaPrezime.Text = radnikIzmjena.prezime;
                txtIzmjenaOIB.Text = radnikIzmjena.OIB;
                txtIzmjenaAdresa.Text = radnikIzmjena.adresa;
                txtIzmjenaTelefon.Text = radnikIzmjena.broj_telefona;
                txtIzmjenaRacun.Text = radnikIzmjena.broj_racuna;
                txtIzmjenaBanka.Text = radnikIzmjena.banka;
            }
            //OsvjeziPoslodavce();
        }
        /*private void OsvjeziPoslodavce()
        {
            BindingList<poslodavac> poslodavciIzmjena = null;
            using (var db = new PlaceEntities1())
            {

                poslodavciIzmjena = new BindingList<poslodavac>(db.poslodavac.ToList());
            }
            poslodavacBindingSource.DataSource = poslodavciIzmjena;
        }*/
        private void btnSpremiIzmjene_Click(object sender, EventArgs e)
        {
            using (var db = new PlaceEntities4())
            {
                int oib;
                int brojtelefona;
                int ime;
                int prezime;
                int banka;
                int racun;
                int adresa;
                bool oibTest = int.TryParse(txtIzmjenaOIB.Text, out oib);
                bool testTelefon = int.TryParse(txtIzmjenaTelefon.Text, out brojtelefona);
                bool testIme = int.TryParse(txtIzmjenaIme.Text, out ime);
                bool testPrezime = int.TryParse(txtIzmjenaPrezime.Text, out prezime);
                bool testBanka = int.TryParse(txtIzmjenaBanka.Text, out banka);
                //bool testracun = int.TryParse(txtIzmjenaRacun.Text, out racun);
                bool testadresa = int.TryParse(txtIzmjenaAdresa.Text, out adresa);
                if (oibTest && testTelefon && testIme==false && testPrezime==false && testBanka==false && testadresa==false)
                {
                    if (radnikIzmjena == null)
                    {

                        radnik izmjenjeni = new radnik
                        {
                            ime = txtIzmjenaIme.Text,
                            prezime = txtIzmjenaPrezime.Text,
                            OIB = txtIzmjenaOIB.Text,
                            adresa = txtIzmjenaAdresa.Text,
                            broj_racuna = txtIzmjenaRacun.Text,
                            broj_telefona = txtIzmjenaTelefon.Text,
                            banka = txtIzmjenaBanka.Text,
                            poslodavac = izmjenaPoslodavac
                        };
                        db.radnik.Add(izmjenjeni);
                        db.SaveChanges();
                    }


                    else
                    {
                        db.radnik.Attach(radnikIzmjena);
                        radnikIzmjena.ime = txtIzmjenaIme.Text;
                        radnikIzmjena.prezime = txtIzmjenaPrezime.Text;
                        radnikIzmjena.OIB = txtIzmjenaOIB.Text;
                        radnikIzmjena.adresa = txtIzmjenaAdresa.Text;
                        radnikIzmjena.broj_racuna = txtIzmjenaRacun.Text;
                        radnikIzmjena.broj_telefona = txtIzmjenaTelefon.Text;
                        radnikIzmjena.banka = txtIzmjenaBanka.Text;
                        // radnikIzmjena.poslodavac = izmjenaPoslodavac;
                        /*  if (izmjenaPoslodavac.naziv == "HeliozTehnologies") {
                              radnikIzmjena.poslodavac = izmjenaPoslodavac;

                          }
                          if (izmjenaPoslodavac.naziv == "BrodBot") {
                              radnikIzmjena.poslodavac = izmjenaPoslodavac;

                          }*/
                        db.SaveChanges();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Morate unijeti pravilan tip podatka!");
                }
           
              
            }

        private void bntOdustaniIzmjena_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

