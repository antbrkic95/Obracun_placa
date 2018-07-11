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
    public partial class frmGlavna : Form
    {
        private radnik radnikPlaca;
        private prirez odabraniPrirez;
        private poslodavac odabrani;
        odbitakZaDjecu odabraniOdbitakDjeca;
        odbitakClan odabraniOdbitakČlan;
        public frmGlavna()
        {
            InitializeComponent();
            // odabraniOdbitakDjeca = new odbitakZaDjecu();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new PlaceEntities4())
            {
                odabrani = cmbPoslodavci.SelectedItem as poslodavac;
                db.poslodavac.Attach(odabrani);
                odabraniOdbitakDjeca = cmbOdbitakDjeca.SelectedItem as odbitakZaDjecu;
                db.odbitakZaDjecu.Attach(odabraniOdbitakDjeca);
                odabraniOdbitakČlan = cmbOdbitakClan.SelectedItem as odbitakClan;
                db.odbitakClan.Attach(odabraniOdbitakČlan);
                int oib;
                int ime;
                int prez;
                int brojTelefona;
                int banka;
                int adresa;
                radnik noviRadnik;
                //bool test = int.TryParse(txtOIB.Text, out oib);
                bool imetest = int.TryParse(txtIme.Text, out ime);
                bool prezimeTest = int.TryParse(txtPrezime.Text, out prez);
                bool telefonTest = int.TryParse(txtBrojTelefona.Text, out brojTelefona);
                bool bankaTest = int.TryParse(txtBanka.Text, out banka);
                bool testoib = int.TryParse(txtOIB.Text, out oib);
                bool testadrese = int.TryParse(txtAdresa.Text, out adresa);

                if (testoib && testadrese == false && imetest == false && prezimeTest == false && telefonTest && bankaTest == false && !string.IsNullOrEmpty(txtAdresa.Text) && (!string.IsNullOrEmpty(txtIme.Text) &&
                   !string.IsNullOrEmpty(txtPrezime.Text) && !string.IsNullOrEmpty(txtOIB.Text) && !string.IsNullOrEmpty(txtBrojTelefona.Text) && !string.IsNullOrEmpty(txtBrojRacuna.Text) && !string.IsNullOrEmpty(txtBanka.Text)))

                {
                    noviRadnik = new radnik()
                    {

                        ime = txtIme.Text,
                        prezime = txtPrezime.Text,
                        OIB = txtOIB.Text,
                        broj_racuna = txtBrojRacuna.Text,
                        broj_telefona = txtBrojTelefona.Text,
                        adresa = txtAdresa.Text,
                        banka = txtBanka.Text,
                        poslodavac = odabrani,
                        odbitakClan = odabraniOdbitakČlan,
                        odbitakZaDjecu = odabraniOdbitakDjeca


                    };
                    db.radnik.Add(noviRadnik);
                    db.SaveChanges();
                    txtIme.Clear();
                    txtPrezime.Clear();
                    txtOIB.Clear();
                    txtBrojRacuna.Clear();
                    txtBrojTelefona.Clear();
                    txtAdresa.Clear();
                    txtBanka.Clear();
                }
                else
                    MessageBox.Show("Morate unijeti pravilne podatke za radnika-provjerite tipove unesenih podataka i obavezan je unos svih potrebnih podataka !");

            }
            //Close();
            OsvjeziRadnike();
            

        }

        private void lblBrojRacuna_Click(object sender, EventArgs e)
        {

        }

        private void frmGlavna_Load(object sender, EventArgs e)
        {
            DohvatiPoslodavce();
            OsvjeziRadnike();
            OsvjeziOdbitakDjeca();
            OsvjeziOdbitakClanovi();
            lblUkupanOdbitak.Text = "3800,00 ";
            /*cmbPrirez.Items.Add("0%");
            cmbPrirez.Items.Add("Slavonski Brod (12%)");
            cmbPrirez.Items.Add("Sibinj (10%)");*/
            OsvjeziPrireze();
        }



        private void OsvjeziOdbitakDjeca()
        {

            odbitakZaDjecu novi = new odbitakZaDjecu();
            odbitakZaDjecuBindingSource.DataSource = novi.vratiDjecu();
        }

        private void OsvjeziOdbitakClanovi()
        {

            odbitakClan noviOdbitak = new odbitakClan();
            odbitakClanBindingSource.DataSource = noviOdbitak.vratiClan();
        }
        private void OsvjeziPrireze()
        {

            prirez noviPrirez = new prirez();
            prirezBindingSource.DataSource = noviPrirez.vratiPrirez();

        }
       private void DohvatiPoslodavce()
        {

            BindingList<poslodavac> poslodavci = null;
            using (var db = new PlaceEntities4())
            {

                poslodavci = new BindingList<poslodavac>(db.poslodavac.ToList());
            }
            poslodavacBindingSource1.DataSource = poslodavci;
        }


        private void OsvjeziRadnikePoslodavac(poslodavac odabraniPoslodavac)
        {

            BindingList<radnik> radnici = null;
            using (var db = new PlaceEntities4())
            {
                db.poslodavac.Attach(odabraniPoslodavac);

                radnici = new BindingList<radnik>(odabraniPoslodavac.radnik.ToList<radnik>());
            }
            radnikBindingSource.DataSource = radnici;

        }
        private void OsvjeziRadnike()
        {

            BindingList<radnik> radnici = null;
            using (var db = new PlaceEntities4())
            {
                radnici = new BindingList<radnik>(db.radnik.ToList());
            }
            radnikBindingSource.DataSource = radnici;

        }


        private void btnObrisi_Click_2(object sender, EventArgs e)
        {
            radnik odabrani = radnikBindingSource.Current as radnik;
            if (odabrani != null)
            {
                if (MessageBox.Show("Jeste li sigurni da želite obrisati radnika?", "Upozorenje!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var db = new PlaceEntities4())
                    {

                        db.radnik.Attach(odabrani);
                        db.radnik.Remove(odabrani);
                        db.SaveChanges();
                    }

                }
            }
            OsvjeziRadnike();
        }

        private void btnZavrsi_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            OsvjeziRadnike();
        }

       /* private void cmbOdbitakDjeca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

        private void btnIzmijeni_Click(object sender, EventArgs e)
        {
            radnik odabraniZaIzmjenu = radnikBindingSource.Current as radnik;
            if (odabraniZaIzmjenu != null)
            {
                frmIzmijeniRadnika novaFormaZaIzmjenu = new frmIzmijeniRadnika(odabraniZaIzmjenu);
                novaFormaZaIzmjenu.ShowDialog();
                OsvjeziRadnike();
            }
        }

        private void btnUnosSati_Click(object sender, EventArgs e)
        {
            radnik odabraniUnosRadnik = radnikBindingSource.Current as radnik;
            if (odabraniUnosRadnik != null)
            {

                frmUnosSati formaUnosSati = new frmUnosSati(odabraniUnosRadnik);
                formaUnosSati.ShowDialog();
            }
        }

        /*private void dgvRadnik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void btnUnosBolovanja_Click(object sender, EventArgs e)
        {
            radnik odabraniUnosBolovanja = radnikBindingSource.Current as radnik;
            if (odabraniUnosBolovanja != null)
            {

                frmUnosBolovanja formaBolovanja = new frmUnosBolovanja(odabraniUnosBolovanja);
                formaBolovanja.ShowDialog();
            }
            
        }

        private void btnUnosPraznika_Click(object sender, EventArgs e)
        {
            radnik odabraniRadnikPraznici = radnikBindingSource.Current as radnik;
            if (odabraniRadnikPraznici != null)
            {

                frmPraznici formaPraznici = new frmPraznici(odabraniRadnikPraznici);
                formaPraznici.ShowDialog();
            }
        }

        private void btnUnosGodisnjeg_Click(object sender, EventArgs e)
        {
            radnik odabrani = radnikBindingSource.Current as radnik;
            if (odabrani != null)
            {
                frmGodisnjiOdmor formaGodisnji = new frmGodisnjiOdmor(odabrani);
                formaGodisnji.ShowDialog();
            }
        }

        private void btnKraj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* private void ProvjeriObracun(obracun_placa o) {

             if (cbStandardni.Checked == true)
             {

                 //o.placa = placa;
                 o.vrsta_obracuna = "Standardni obracun";
             }
             else if (cbPrvoZaposlenje.Checked == true)
             {

                 o.vrsta_obracuna = "Prvo zaposlenje";
                // o.placa = placa;
             }
             else if (cbOsoba.Checked == true) {
                 o.vrsta_obracuna = "Osoba mladja od 30 godina";
                // o.placa = placa;
             }
             else if(cbMinimalnaPLaća.Checked==true){
                 o.vrsta_obracuna = "Minimalna placa";
                 //o.placa = placa;

             }

         }*/

        private void dodajObracun(placa p) {

            if (cbOsoba.Checked == true || cbMinimalna.Checked == true || cbStandardni.Checked == true || cbZaposlenje.Checked == true)
            {
                if (cbStandardni.Checked == true)
                {
                    p.obracun = "Standardni obracun";
                }
                else if (cbZaposlenje.Checked == true)
                {
                    p.obracun = "Prvo zaposlenje";
                }
                else if (cbOsoba.Checked == true)
                {
                    p.obracun = "Osoba mladja od 30 godina";
                }
                else if (cbMinimalna.Checked == true) {
                    p.obracun = "Minimalna placa";
                }

            }
            else
                MessageBox.Show("Potrebno je odabrati vrstu obracuna!");

        }
        

        
        private void btnIzracunaj_Click(object sender, EventArgs e)
        {
            int placa;
            bool testPlaca = int.TryParse(txtPlaca.Text, out placa);
            placa novaPlaca;
            radnikPlaca = radnikBindingSource.Current as radnik;
            odabraniPrirez = cmbPrirez.SelectedItem as prirez;
           
            using (var db = new PlaceEntities4())
            {
                if (radnikPlaca != null && odabraniPrirez != null && testPlaca)
                {
                    db.radnik.Attach(radnikPlaca);
                    db.prirez.Attach(odabraniPrirez);
                    novaPlaca = new placa()
                    {
                         visina = int.Parse(txtPlaca.Text),
                        /* FORMULE ZA IZRACUN!!!
                         ukupno_bruto,
                         ukupno_neto,
                         ukupno_trosak
                         dohodak
                         */
                        radnik = radnikPlaca,
                        prirez = odabraniPrirez,
                                            
                    };
                   // DodajObracun(novaPlaca);


                    if (rbBruto.Checked == true || rbNeto.Checked == true || rbUkupanTrosak.Checked == true)
                    {
                        dodajObracun(novaPlaca);
                        ProvjeriRadioButtone(novaPlaca);
                        db.placa.Add(novaPlaca);
                        db.SaveChanges();
                    }
                    else
                        MessageBox.Show("Morate odabrati vrstu plaće!");
                    //Close();    
                }
                else
                    MessageBox.Show("Za svakog radnika potrebno je unijeti pripadujuću plaću te plaća mora biti napisana u obliku cjelobrojne vrijednosti!");
            }
           


        }
        private void ProvjeriRadioButtone(placa p)
        {

            if (rbBruto.Checked == true)
            {
                p.vrsta = "Bruto";
            }
            else if (rbNeto.Checked == true)
            {
                p.vrsta = "Neto";
            }
            else if (rbUkupanTrosak.Checked == true)
            {
                p.vrsta = "Ukupan trosak";
            }
            
        }

        private void cbStandardni_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStandardni.Checked == true) {
                cbOsoba.Checked = false;
                cbMinimalna.Checked = false;
                cbZaposlenje.Checked = false;
            }
        }

        private void cbZaposlenje_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZaposlenje.Checked == true) {

                cbOsoba.Checked = false;
                cbMinimalna.Checked = false;
                cbStandardni.Checked = false;
            }
        }

        private void cbOsoba_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOsoba.Checked == true)
            {

                cbZaposlenje.Checked = false;
                cbMinimalna.Checked = false;
                cbStandardni.Checked = false;
            }
        }

        private void racunajOdbitak(odbitakZaDjecu o)
        {

            if (o.broj_djece == "Dvoje djece")
                lblUkupanOdbitak.Text = (5550 +  (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Jedno dijete")
                lblUkupanOdbitak.Text = (3800+ (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Troje djece")
                lblUkupanOdbitak.Text = (8050 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Četvero djece")
                lblUkupanOdbitak.Text = (11550 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Petero djece")
                lblUkupanOdbitak.Text = (16300 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Šestero djece")
                lblUkupanOdbitak.Text = (22550 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Sedmero djece")
                lblUkupanOdbitak.Text = (30550 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Osmero djece")
                lblUkupanOdbitak.Text = (40550 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Devetero djece")
                lblUkupanOdbitak.Text = (52800 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Desetero djece")
                lblUkupanOdbitak.Text = (67550 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_djece == "Nema djece")
                lblUkupanOdbitak.Text = 3800.ToString() + ",00";
        }
        private void racunajOdbitakClan(odbitakClan o) {

            if (o.broj_clanova == "Nema")
                lblUkupanOdbitak.Text = 3800.ToString() + ",00";
            else if (o.broj_clanova == "Jedan član")
                lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_clanova == "Dva člana")
                lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_clanova == "Tri člana")
                lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_clanova == "Četiri člana")
                lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
            else if (o.broj_clanova == "Pet članova")
                lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
        }
        private void cbMinimalna_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMinimalna.Checked == true)

            {

                cbZaposlenje.Checked = false;
                cbOsoba.Checked = false;
                cbStandardni.Checked = false;
            }
        }

        private void cmbOdbitakDjeca_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbOdbitakDjeca_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            racunajOdbitak(cmbOdbitakDjeca.SelectedItem as odbitakZaDjecu);

        }

        private void cmbOdbitakClan_SelectedIndexChanged(object sender, EventArgs e)
        {
            racunajOdbitakClan(cmbOdbitakClan.SelectedItem as odbitakClan);
        }
    }
}


