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
        private poslodavac odabrani;
        public frmGlavna()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new PlaceEntities1())
            {
                odabrani = cmbPoslodavci.SelectedItem as poslodavac;
                db.poslodavac.Attach(odabrani);
                int oib;
                int ime;
                int prez;
                int brojTelefona;
                int banka;
                radnik noviRadnik;
                bool test = int.TryParse(txtOIB.Text, out oib);
                bool imetest = int.TryParse(txtIme.Text, out ime);
                bool prezimeTest = int.TryParse(txtPrezime.Text, out prez);
                bool telefonTest = int.TryParse(txtBrojTelefona.Text, out brojTelefona);
                bool bankaTest = int.TryParse(txtBanka.Text, out banka);

                if (test && imetest == false && prezimeTest == false && telefonTest && bankaTest == false && !string.IsNullOrEmpty(txtAdresa.Text) && (!string.IsNullOrEmpty(txtIme.Text) &&
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
                        poslodavac = odabrani
                       
                        
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
                    MessageBox.Show("Morate unijeti pravilne podatke-provjerite tipove unesenih podataka i obavezan je unos svih potrebnih podataka !");
               
            }
            //Close();
            OsvjeziRadnike();
            /*txtIme.Clear();
            txtPrezime.Clear();
            txtOIB.Clear();
            txtBrojRacuna.Clear();
            txtBrojTelefona.Clear();
            txtAdresa.Clear();
            txtBanka.Clear();*/

        }

        private void lblBrojRacuna_Click(object sender, EventArgs e)
        {

        }

        private void frmGlavna_Load(object sender, EventArgs e)
        {
            DohvatiPoslodavce();
            DohvatiOdabirPoslodavaca();
            //OsvjeziRadnike();
            OsvjeziRadnikePoslodavac(poslodavacBindingSource1.Current as poslodavac);
        }


        /* private void btnObrisi_Click(object sender, EventArgs e)
          {
            
        }
    */
        private void DohvatiPoslodavce()
        {

            BindingList<poslodavac> poslodavci = null;
            using (var db = new PlaceEntities1())
            {

                poslodavci = new BindingList<poslodavac>(db.poslodavac.ToList());
            }
            poslodavacBindingSource1.DataSource = poslodavci;
        }

        private void DohvatiOdabirPoslodavaca()
        {
            BindingList<poslodavac> poslodavci = null;
            using (var db = new PlaceEntities1())
            {

                poslodavci = new BindingList<poslodavac>(db.poslodavac.ToList());
            }
            poslodavacBindingSource.DataSource = poslodavci;

        }
        private void OsvjeziRadnikePoslodavac(poslodavac odabraniPoslodavac)
        {

            BindingList<radnik> radnici = null;
            using (var db = new PlaceEntities1())
            {
                db.poslodavac.Attach(odabraniPoslodavac);

                radnici = new BindingList<radnik>(odabraniPoslodavac.radnik.ToList<radnik>());
            }
            radnikBindingSource.DataSource = radnici;

        }
        private void OsvjeziRadnike()
        {

            BindingList<radnik> radnici = null;
            using (var db = new PlaceEntities1())
            {
                radnici = new BindingList<radnik>(db.radnik.ToList());
            }
            radnikBindingSource.DataSource = radnici;

        }

        /*private void btnObrisi_Click_1(object sender, EventArgs e)
        {

        }*/

        private void btnObrisi_Click_2(object sender, EventArgs e)
        {
            radnik odabrani = radnikBindingSource.Current as radnik;
            if (odabrani != null)
            {
                if (MessageBox.Show("Jeste li sigurni da želite obrisati radnika?", "Upozorenje!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    using (var db = new PlaceEntities1())
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

        /*private void cmbOdabir_SelectedIndexChanged(object sender, EventArgs e)
        {
            poslodavac p = poslodavacBindingSource.Current as poslodavac;
            if (p != null)
                OsvjeziRadnikePoslodavac(p);
            
        }*/

        /*private void cmbOdabir_SelectedValueChanged(object sender, EventArgs e)
        {
        
        }*/

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            OsvjeziRadnike();
        }

        private void cmbOdabir_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            poslodavac p = poslodavacBindingSource.Current as poslodavac;
            if (p != null)
                OsvjeziRadnikePoslodavac(p);
        }

        private void dgvRadnik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        /*private void dgvRadnik_SelectionChanged(object sender, EventArgs e)
        {
            radnik odabrani = radnikBindingSource.Current as radnik;

            if (odabrani != null)
            {

                txtIme.Text = odabrani.ime;
                txtPrezime.Text = odabrani.prezime;
                txtOIB.Text = odabrani.OIB;
                txtBrojTelefona.Text = odabrani.broj_telefona;
                txtBrojRacuna.Text = odabrani.broj_racuna;
                txtBanka.Text = odabrani.banka;
                txtAdresa.Text = odabrani.adresa;
            }
        }*/
    }
}
