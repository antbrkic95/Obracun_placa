﻿using System;
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
                double bruto;
                double stimulacija;
                //bool test = int.TryParse(txtOIB.Text, out oib);
                bool imetest = int.TryParse(txtIme.Text, out ime);
                bool prezimeTest = int.TryParse(txtPrezime.Text, out prez);
                bool telefonTest = int.TryParse(txtBrojTelefona.Text, out brojTelefona);
                bool bankaTest = int.TryParse(txtBanka.Text, out banka);
                bool testoib = int.TryParse(txtOIB.Text, out oib);
                bool testadrese = int.TryParse(txtAdresa.Text, out adresa);
                bool testStimulacija = double.TryParse(txtStimulacija.Text, out stimulacija);
                bool testBruto = double.TryParse(txtIznosPocetni.Text, out bruto);


                if (testoib &&  testStimulacija &&testBruto&&  testadrese == false && imetest == false && prezimeTest == false && telefonTest && bankaTest == false && !string.IsNullOrEmpty(txtAdresa.Text) && (!string.IsNullOrEmpty(txtIme.Text) &&
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
                        iznos_bruto=double.Parse(txtIznosPocetni.Text),
                        stimulacija=double.Parse(txtStimulacija.Text),
                        poslodavac = odabrani,
                        odbitakClan = odabraniOdbitakČlan,
                        odbitakZaDjecu = odabraniOdbitakDjeca


                    };
                    txtPlaca.Text = (noviRadnik.iznos_bruto + noviRadnik.stimulacija).ToString();
                    db.radnik.Add(noviRadnik);
                    db.SaveChanges();
                    txtIme.Clear();
                    txtPrezime.Clear();
                    txtOIB.Clear();
                    txtBrojRacuna.Clear();
                    txtBrojTelefona.Clear();
                    txtAdresa.Clear();
                    txtBanka.Clear();
                    txtIznosPocetni.Clear();
                    txtStimulacija.Clear();
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
            lblUkupanOdbitak.Text = "3800" + ",00";



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

        //metode za izracun

        private void racunajMladjiOdBruto(placa p) {
            prirez odabrani = cmbPrirez.SelectedItem as prirez;
            if (cbOsoba.Checked == true && rbBruto.Checked == true) {
                lblObavijestOsoba.Text = "Kod izračuna plaće za osobe mlađe od 30 godina poslodavac je oslobođen plaćanja doprinosa na plaću u roku od pet godina.";
                lblBrutoIznos.Text = double.Parse(txtPlaca.Text).ToString();
                lblZastitaIznos.Text = lblBrutoIznos.Text;
                lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                lblZaposlavanjeUkupno.Text = 0 + ",00";
                lblZastitaUkupno.Text = 0 + ",00";
                lblIznosZdradstvenoUkupno.Text = 0 + ",00";
                lblZaposljavanjePostotak.Text = 0 + ",00 %";
                lblZdradstvenoPostotak.Text = 0 + ",00 %";
                lblZastitaPostotak.Text = 0 + ",00 %";
                lblTrosakUkupno.Text = 0 + ",00";
                lblPrirezPostotak.Text = odabrani.postotak.ToString() + "%";
                p.ukupno_bruto = p.visina;
                p.ukupno_trosak = p.ukupno_bruto;
                lblUkupanTrosakIznos.Text = lblBrutoIznos.Text;


                lblMirovinsko1Ukupno.Text =((double) (p.visina * 0.15)).ToString();
                lblMirovinsko2Ukupno.Text =((double) (p.visina * 0.05)).ToString();
                lblDoprinosIZukupno.Text = ((double)((p.visina * 0.15) + (p.visina * 0.05))).ToString();
                p.dohodak = p.visina - (int)((p.visina * 0.15) + (p.visina * 0.05));
                lblDohodakUkupno.Text =((double) ((double)(p.visina) - (double)((p.visina * 0.15) + (p.visina * 0.05)))).ToString();

                double odbitak = double.Parse(lblUkupanOdbitak.Text);

                double dohodak = ((double)(p.visina) - (double)((p.visina * 0.15) + (p.visina * 0.05)));

                if (dohodak < odbitak)
                {
                    p.ukupno_neto = p.dohodak;
                    lblNetoIznos.Text = lblDohodakUkupno.Text;
                    lblPorez1Iznos.Text = 0 + ",00";
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPrirezIznos.Text = 0 + ",00";
                    lblPorez1Ukupno.Text = lblPorez1Iznos.Text;
                    lblPorez2Ukupno.Text = lblPorez2Iznos.Text;
                    lblPrirezUkupno.Text = lblPrirezIznos.Text;
                    lblPorezUkupno.Text = 0 + ",00";
                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;
                }
                else
                {
                    double razlika = dohodak - odbitak;
                    lblPorez1Iznos.Text = razlika.ToString();
                    lblPorez1Ukupno.Text = (double.Parse(lblPorez1Iznos.Text) * 0.24).ToString();
                    lblPrirezIznos.Text = lblPorez1Ukupno.Text;

                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPorez2Ukupno.Text = 0 + ",00";
                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;
                    lblPrirezUkupno.Text = Math.Round((double.Parse(lblPrirezIznos.Text) * (double)(odabrani.postotak * 0.01)), 2).ToString();
                    lblPorezUkupno.Text = Math.Round((double.Parse(lblPorez1Ukupno.Text) + double.Parse(lblPorez2Ukupno.Text) + double.Parse(lblPrirezUkupno.Text)), 2).ToString();
                    lblNetoIznos.Text = ((p.visina - (double)((p.visina * 0.15) + (p.visina * 0.05))) - Math.Round(double.Parse(lblPorezUkupno.Text), 2)).ToString();
                    p.ukupno_neto = (int)((p.visina - (int)((p.visina * 0.15) + (p.visina * 0.05))) - float.Parse(lblPorezUkupno.Text));
                }

            }

        }



        private void racunajStandardniBruto(placa p) {
            prirez odabrani = cmbPrirez.SelectedItem as prirez;
            lblObavijestOsoba.Text = "";

            if (cbStandardni.Checked == true && rbBruto.Checked == true) {
                lblPrirezPostotak.Text = odabrani.postotak.ToString() + "%"; ;
                lblBrutoIznos.Text = double.Parse(txtPlaca.Text).ToString();
                lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;
                p.ukupno_bruto = p.visina;

                lblMirovinsko1Ukupno.Text = (double.Parse(lblMirovinsko1Iznos.Text) * 0.15).ToString();
                lblMirovinsko2Ukupno.Text = (double.Parse(lblmirovinsko2Iznos.Text) * 0.05).ToString();
                lblDoprinosIZukupno.Text = ((double.Parse(lblMirovinsko1Iznos.Text) * 0.15) + (double.Parse(lblmirovinsko2Iznos.Text) * 0.05)).ToString();
                p.dohodak = p.visina - (int)((p.visina * 0.15) + (p.visina * 0.05));
                lblDohodakUkupno.Text = ((double)((double)(p.visina) - (double)((p.visina * 0.15) + (p.visina * 0.05)))).ToString();

                lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                lblZastitaIznos.Text = lblBrutoIznos.Text;
                lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                lblZdradstvenoPostotak.Text = 15 + ",00 %";
                lblZastitaPostotak.Text = 1.7 + "%";
                lblZaposljavanjePostotak.Text = 0.5 + "%";

                lblIznosZdradstvenoUkupno.Text = (double.Parse(lblZdradstvenoIznos.Text) * 0.15).ToString();
                lblZaposlavanjeUkupno.Text = (double.Parse(lblZaposljavanjeIznos.Text) * 0.017).ToString();
                lblZastitaUkupno.Text = (double.Parse(lblZastitaIznos.Text) * 0.005).ToString();

                lblTrosakUkupno.Text = ((double.Parse(lblZdradstvenoIznos.Text) * 0.15) + (double.Parse(lblZaposljavanjeIznos.Text) * 0.017) + (double.Parse(lblZastitaIznos.Text) * 0.005)).ToString();

                lblUkupanTrosakIznos.Text = ((double.Parse(lblTrosakUkupno.Text)) + (double.Parse(lblBrutoIznos.Text))).ToString();
                //lblUkupanTrosakIznos.Text = ((double)(p.visina + ((p.visina * 0.15) + (p.visina * 0.005) + (p.visina * 0.017)))).ToString();
                p.ukupno_trosak = (int)(p.visina + ((p.visina * 0.15) + (p.visina * 0.005) + (p.visina * 0.017)));

                double odbitak = double.Parse(lblUkupanOdbitak.Text);

                double dohodak = ((double)(p.visina) - (double)((p.visina * 0.15) + (p.visina * 0.05)));

                if (dohodak < odbitak)
                {
                    p.ukupno_neto = p.dohodak;
                    lblNetoIznos.Text = lblDohodakUkupno.Text;
                    lblPorez1Iznos.Text = 0 + ",00";
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPrirezIznos.Text = 0 + ",00";
                    lblPorez1Ukupno.Text = lblPorez1Iznos.Text;
                    lblPorez2Ukupno.Text = lblPorez2Iznos.Text;
                    lblPrirezUkupno.Text = lblPrirezIznos.Text;
                    lblPorezUkupno.Text = 0 + ",00";
                
                }
                else {
                    double razlika = dohodak - odbitak;
                    lblPorez1Iznos.Text = razlika.ToString();
                    lblPorez1Ukupno.Text = (double.Parse(lblPorez1Iznos.Text) * 0.24).ToString();
                    lblPrirezIznos.Text = lblPorez1Ukupno.Text;

                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPorez2Ukupno.Text = 0 + ",00";

                    /*if (odabrani.postotak == 12)
                        lblPrirezUkupno.Text = (double.Parse(lblPrirezIznos.Text) * 0.12).ToString();
                    else if (odabrani.postotak == 10)
                        lblPrirezUkupno.Text = (double.Parse(lblPrirezIznos.Text) * 0.1).ToString();
                    else if (odabrani.postotak == 0)
                        lblPrirezUkupno.Text = 0 + ",00";*/
                    lblPrirezUkupno.Text = Math.Round((double.Parse(lblPrirezIznos.Text) * (double)(odabrani.postotak * 0.01)), 2).ToString();
                    lblPorezUkupno.Text = Math.Round((double.Parse(lblPorez1Ukupno.Text) + double.Parse(lblPorez2Ukupno.Text) + double.Parse(lblPrirezUkupno.Text)), 2).ToString();
                    lblNetoIznos.Text = ((p.visina - (double)((p.visina * 0.15) + (p.visina * 0.05))) - Math.Round(double.Parse(lblPorezUkupno.Text), 2)).ToString();
                    p.ukupno_neto = (int)((p.visina - (int)((p.visina * 0.15) + (p.visina * 0.05))) - float.Parse(lblPorezUkupno.Text));
                }
            }

        }

        private void racunajMladjiOdNeto(placa p)
        {
            double razlika;
            prirez odabrani = cmbPrirez.SelectedItem as prirez;
            if (cbOsoba.Checked == true && rbNeto.Checked == true)
            {
                lblObavijestOsoba.Text = "Kod izračuna plaće za osobe mlađe od 30 godina poslodavac je oslobođen plaćanja doprinosa na plaću u roku od pet godina.";
                lblNetoIznos.Text = double.Parse(txtPlaca.Text).ToString();
                lblZastitaIznos.Text = lblBrutoIznos.Text;
                lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                lblZaposlavanjeUkupno.Text = 0 + ",00";
                lblZastitaUkupno.Text = 0 + ",00";
                lblIznosZdradstvenoUkupno.Text = 0 + ",00";
                lblZaposljavanjePostotak.Text = 0 + ",00 %";
                lblZdradstvenoPostotak.Text = 0 + ",00 %";
                lblZastitaPostotak.Text = 0 + ",00 %";
                lblTrosakUkupno.Text = 0 + ",00";
                lblPrirezPostotak.Text = odabrani.postotak.ToString() + "%";
                p.ukupno_neto = p.visina;
                double odbitak = double.Parse(lblUkupanOdbitak.Text);
                double neto = double.Parse(txtPlaca.Text);
                if (neto <= odbitak)
                {
                    p.dohodak = p.ukupno_neto;
                    lblDohodakUkupno.Text = lblNetoIznos.Text;
                    lblPorez1Iznos.Text = 0 + ",00";
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPrirezIznos.Text = 0 + ",00";
                    lblPorez1Ukupno.Text = lblPorez1Iznos.Text;
                    lblPorez2Ukupno.Text = lblPorez2Iznos.Text;
                    lblPrirezUkupno.Text = lblPrirezIznos.Text;
                    lblPorezUkupno.Text = 0 + ",00";
                    lblBrutoIznos.Text = ((100 * neto) / (100 - 20)).ToString();
                    p.ukupno_bruto = (int)((100 * neto) / (100 - 20));
                    p.ukupno_trosak = p.ukupno_bruto;
                    lblUkupanTrosakIznos.Text = lblBrutoIznos.Text;
                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;
                    lblMirovinsko1Ukupno.Text = (double.Parse(lblMirovinsko1Iznos.Text) * 0.15).ToString();
                    lblMirovinsko2Ukupno.Text = (double.Parse(lblmirovinsko2Iznos.Text) * 0.05).ToString();
                    lblDoprinosIZukupno.Text = ((double.Parse(lblMirovinsko1Iznos.Text) * 0.15) + (double.Parse(lblmirovinsko2Iznos.Text) * 0.05)).ToString();
                    lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                    lblZastitaIznos.Text = lblBrutoIznos.Text;
                    lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;

                }
                else if (neto > odbitak)
                {

                    lblBrutoIznos.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))), 2).ToString();
                    p.ukupno_bruto = (int)Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))), 2);
                    p.ukupno_trosak = p.ukupno_bruto;

                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;

                    lblMirovinsko1Ukupno.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15), 2).ToString();

                    lblMirovinsko2Ukupno.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05), 2).ToString();
                    lblDoprinosIZukupno.Text = Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05)), 2).ToString();

                    lblDohodakUkupno.Text = Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))) -
                        ((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05))), 2).ToString();

                    p.dohodak = (int)Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))) -
                        ((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05))), 2);

                    double dohodak = double.Parse(lblDohodakUkupno.Text);
                    razlika = dohodak - odbitak;

                    lblPorez1Iznos.Text = razlika.ToString();
                    lblPorez1Ukupno.Text = Math.Round((double.Parse(lblPorez1Iznos.Text) * 0.24), 2).ToString();
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPorez2Ukupno.Text = 0 + ",00";
                    lblPrirezIznos.Text = lblPorez1Ukupno.Text;
                    lblPrirezUkupno.Text = Math.Round((double.Parse(lblPrirezIznos.Text) * (double)(odabrani.postotak * 0.01)), 2).ToString();
                    lblPorezUkupno.Text = Math.Round((double.Parse(lblPorez1Ukupno.Text) + double.Parse(lblPorez2Ukupno.Text) + double.Parse(lblPrirezUkupno.Text)), 2).ToString();

                    lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                    lblZastitaIznos.Text = lblBrutoIznos.Text;
                    lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                    lblUkupanTrosakIznos.Text = lblBrutoIznos.Text;


                }

            }
        }

        private void racunajStandardniNeto(placa p)
        {
            double razlika;
            lblObavijestOsoba.Text = "";
            prirez odabrani = cmbPrirez.SelectedItem as prirez;
            if (cbStandardni.Checked == true && rbNeto.Checked == true)
            {

                lblNetoIznos.Text = double.Parse(txtPlaca.Text).ToString();
                p.ukupno_neto = p.visina;
                lblPrirezPostotak.Text = odabrani.postotak.ToString() + "%";
                double odbitak = double.Parse(lblUkupanOdbitak.Text);
                double neto = double.Parse(txtPlaca.Text);
                if (neto <= odbitak)
                {
                    p.dohodak = p.ukupno_neto;
                    lblDohodakUkupno.Text = lblNetoIznos.Text;
                    lblPorez1Iznos.Text = 0 + ",00";
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPrirezIznos.Text = 0 + ",00";
                    lblPorez1Ukupno.Text = lblPorez1Iznos.Text;
                    lblPorez2Ukupno.Text = lblPorez2Iznos.Text;
                    lblPrirezUkupno.Text = lblPrirezIznos.Text;
                    lblPorezUkupno.Text = 0 + ",00";
                    lblBrutoIznos.Text = ((100 * neto) / (100 - 20)).ToString();
                    p.ukupno_bruto = (int)((100 * neto) / (100 - 20));
                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;
                    lblMirovinsko1Ukupno.Text = (double.Parse(lblMirovinsko1Iznos.Text) * 0.15).ToString();
                    lblMirovinsko2Ukupno.Text = (double.Parse(lblmirovinsko2Iznos.Text) * 0.05).ToString();
                    lblDoprinosIZukupno.Text = ((double.Parse(lblMirovinsko1Iznos.Text) * 0.15) + (double.Parse(lblmirovinsko2Iznos.Text) * 0.05)).ToString();
                    lblZdradstvenoIznos.Text = lblBrutoIznos.Text;
                    lblZastitaIznos.Text = lblBrutoIznos.Text;
                    lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                    lblZdradstvenoPostotak.Text = 15 + ",00 %";
                    lblZastitaPostotak.Text = 1.7 +  "%";
                    lblZaposljavanjePostotak.Text = 0.5 + "%";
                    lblIznosZdradstvenoUkupno.Text = (double.Parse(lblZdradstvenoIznos.Text) * 0.15).ToString();
                    lblZaposlavanjeUkupno.Text = (double.Parse(lblZaposljavanjeIznos.Text) * 0.017).ToString();
                    lblZastitaUkupno.Text = (double.Parse(lblZastitaIznos.Text) * 0.005).ToString();

                    lblTrosakUkupno.Text = ((double.Parse(lblZdradstvenoIznos.Text) * 0.15) + (double.Parse(lblZaposljavanjeIznos.Text) * 0.017) + (double.Parse(lblZastitaIznos.Text) * 0.005)).ToString();

                    lblUkupanTrosakIznos.Text = ((double.Parse(lblTrosakUkupno.Text)) + (double.Parse(lblBrutoIznos.Text))).ToString();
                    p.ukupno_trosak = (int)((double.Parse(lblTrosakUkupno.Text)) + (double.Parse(lblBrutoIznos.Text)));
                }
                else if (neto > odbitak)
                {
                    
                    lblBrutoIznos.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))), 2).ToString();
                    p.ukupno_bruto = (int)Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))), 2);

                    lblMirovinsko1Iznos.Text = lblBrutoIznos.Text;
                    lblmirovinsko2Iznos.Text = lblBrutoIznos.Text;

                    lblMirovinsko1Ukupno.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15), 2).ToString();

                    lblMirovinsko2Ukupno.Text = Math.Round((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05), 2).ToString();
                    lblDoprinosIZukupno.Text = Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05)), 2).ToString();

                    lblDohodakUkupno.Text = Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))) -
                        ((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05))),2).ToString();

                    p.dohodak = (int)Math.Round(((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak))))) -
                        ((((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.15) +
                        (((neto - odbitak * (0.24 + 0.0024 * (double)(odabrani.postotak))) / ((double)(0.608 - 0.00192 * (double)(odabrani.postotak)))) * 0.05))), 2);

                    double dohodak = double.Parse(lblDohodakUkupno.Text);
                    razlika = dohodak - odbitak;

                    lblPorez1Iznos.Text = razlika.ToString();

                    lblPorez1Ukupno.Text= Math.Round((double.Parse(lblPorez1Iznos.Text) * 0.24),2).ToString();
                    lblPorez2Iznos.Text = 0 + ",00";
                    lblPorez2Ukupno.Text = 0 + ",00";
                    lblPrirezIznos.Text = lblPorez1Ukupno.Text;
                    lblPrirezUkupno.Text =Math.Round( (double.Parse(lblPrirezIznos.Text) * (double)(odabrani.postotak * 0.01)),2).ToString();
                    lblPorezUkupno.Text = Math.Round((double.Parse(lblPorez1Ukupno.Text) + double.Parse(lblPorez2Ukupno.Text) + double.Parse(lblPrirezUkupno.Text)),2).ToString();

                    lblZaposljavanjeIznos.Text = lblBrutoIznos.Text;
                    lblZastitaIznos.Text= lblBrutoIznos.Text; 
                    lblZdradstvenoIznos.Text= lblBrutoIznos.Text;

                    lblZaposlavanjeUkupno.Text = Math.Round((double.Parse(lblBrutoIznos.Text) * 0.017),2).ToString();
                    lblZastitaUkupno.Text=Math.Round( (double.Parse(lblBrutoIznos.Text) * 0.005),2).ToString();
                    lblIznosZdradstvenoUkupno.Text= Math.Round((double.Parse(lblBrutoIznos.Text) * 0.15),2).ToString();

                    lblTrosakUkupno.Text = Math.Round(((double.Parse(lblBrutoIznos.Text) * 0.017) + (double.Parse(lblBrutoIznos.Text) * 0.005) + (double.Parse(lblBrutoIznos.Text) * 0.15)), 2).ToString();

                    lblUkupanTrosakIznos.Text = Math.Round((double.Parse(lblBrutoIznos.Text) + double.Parse(lblTrosakUkupno.Text)), 2).ToString();
                    p.ukupno_trosak = (int)(double.Parse(lblBrutoIznos.Text) + double.Parse(lblTrosakUkupno.Text));

                }

            }
        }

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
            double placa;
            bool testPlaca = double.TryParse(txtPlaca.Text, out placa);
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
                        visina=(int)double.Parse(txtPlaca.Text),
                        radnik = radnikPlaca,
                        prirez = odabraniPrirez,
                        datum=dtp1.Value.Date
                                            
                    };
                    racunajStandardniBruto(novaPlaca);
                    racunajStandardniNeto(novaPlaca);
                    racunajMladjiOdBruto(novaPlaca);
                    racunajMladjiOdNeto(novaPlaca);


                    if (rbBruto.Checked == true || rbNeto.Checked == true )
                    {
                        dodajObracun(novaPlaca);
                        ProvjeriRadioButtone(novaPlaca);
                        db.placa.Add(novaPlaca);
                        db.SaveChanges();
                        lblOdbitakUkupno.Text = lblUkupanOdbitak.Text;


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
            try
            {
                if (o.broj_djece == "Dvoje djece")
                    lblUkupanOdbitak.Text = (5550 + (2500 * o.koeficijent)).ToString() + ",00";
                else if (o.broj_djece == "Jedno dijete")
                    lblUkupanOdbitak.Text = (3800 + (2500 * o.koeficijent)).ToString() + ",00";
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
            catch { }

 
        }

        private void racunajOdbitkeZajedno(odbitakZaDjecu o, odbitakClan odbitakClan) {
            int ukupno = 3800;
            int ukupno2 = 8050;
            int ukupno1 = 5550;
            int ukupno3 = 11550;
            int ukupno4 = 16300;
            int ukupno5 = 22500;
            int ukupno6 = 30550;
            int ukupno7 = 40550;
            int ukupno8 = 52800;
            int ukupno9 = 67550;
            int ukupno10 = 84800;
            try
            {
                using (var db = new PlaceEntities4()) {

                    for (int i = 0; i < db.odbitakClan.Count(); i++)
                    {
                        if (o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 3800.ToString() + ",00";
                        else if (o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Tri člana" || o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Nema djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno.ToString();
                        }
                        if (o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 5550.ToString() + ",00";
                        else if (o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Tri člana" || o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Jedno dijete" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno1 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno1 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno1.ToString();
                        }
                        if (o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 8050.ToString() + ",00";
                        else if (o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Tri člana" || o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Dvoje djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno2 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno2 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno2.ToString();
                        }
                        if (o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 11550.ToString() + ",00";
                        else if (o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Tri člana" 
                            || o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Troje djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno3 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno3 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno3.ToString();
                        }
                        if (o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 16300.ToString() + ",00";
                        else if (o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Četvero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno4 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno4 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno4.ToString();
                        }
                        if (o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 22500.ToString() + ",00";
                        else if (o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Petero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno5 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno4 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno5.ToString();
                        }
                        if (o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 30550.ToString() + ",00";
                        else if (o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Dva člana" || o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Šestero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno6 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno4 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno6.ToString();
                        }
                        if (o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 40550.ToString() + ",00";
                        else if (o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Dva člana" 
                            || o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Sedmero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno7 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno7 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno7.ToString();
                        }
                        if (o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 52800.ToString() + ",00";
                        else if (o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Dva člana"
                            || o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Osmero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno8 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno8 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno8.ToString();
                        }
                        if (o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 67550.ToString() + ",00";
                        else if (o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Dva člana"
                            || o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Devetero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno9 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno9 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno9.ToString();
                        }
                        if (o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Nema")
                            lblUkupanOdbitak.Text = 84800.ToString() + ",00";
                        else if (o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Jedan član" || o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Dva člana"
                            || o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Tri člana"
                            || o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Četiri člana"
                            || o.broj_djece == "Desetero djece" && odbitakClan.broj_clanova == "Pet članova")
                        {
                            lblUkupanOdbitak.Text = (ukupno10 + (2500 * odbitakClan.koeficijent)).ToString() + ",00";
                            ukupno10 = int.Parse(lblUkupanOdbitak.Text);
                            lblUkupanOdbitak.Text = ukupno10.ToString();
                        }






                    }

                }
               
             
            }
            catch { }

        }
        private void racunajOdbitakClan(odbitakClan o ) { 
            try
            {
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
            catch { }
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
            racunajOdbitkeZajedno(cmbOdbitakDjeca.SelectedItem as odbitakZaDjecu,cmbOdbitakClan.SelectedItem as odbitakClan);

        }
        private void cmbOdbitakClan_SelectedIndexChanged(object sender, EventArgs e)
        {
            racunajOdbitakClan(cmbOdbitakClan.SelectedItem as odbitakClan);
            racunajOdbitkeZajedno(cmbOdbitakDjeca.SelectedItem as odbitakZaDjecu, cmbOdbitakClan.SelectedItem as odbitakClan);


        }

        private void gbOlaksice_Enter(object sender, EventArgs e)
        {

        }

        private void dgvRadnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvRadnici_SelectionChanged(object sender, EventArgs e)
        {
            using (var db = new PlaceEntities4())
            {

                radnik r = radnikBindingSource.Current as radnik;
                txtPlaca.Text = (r.stimulacija + r.iznos_bruto).ToString();
            }
        }
    }
}


