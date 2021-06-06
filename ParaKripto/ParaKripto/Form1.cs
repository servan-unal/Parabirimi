using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ParaKripto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Aşağıdaki kodlar Satış1işlem butonunun işlevlerini gösteriyor.
        private void button1_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;

            kur =Convert.ToDouble(txtKur.Text);

            miktar = Convert.ToDouble(txtMiktar.Text);

            tutar = kur * miktar;

            txtTutar.Text = tutar.ToString();
        }
        // adres üzerinden bugünün kur girdilerini çekiliyor.
        /* kurlara ait olan banknotebuying ve banknoteselling girdilerinin
        hafızaya alıp seçmiş olduğum labellera yazdırılıyor.  */
        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmldosya = new XmlDocument();

            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;

            lblDolarAlis.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;

            lblDolarSatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;

            lblEuroAlis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            lblEuroSatis.Text = eurosatis;

            string sterlinalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;

            lblSterlinAlis.Text = sterlinalis;

            string sterlinsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;

            lblSterlinSatis.Text = sterlinsatis;

            string frangalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;

            lblFrangAlis.Text = frangalis;

            string frangsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteSelling").InnerXml;

            lblFrangSatis.Text = frangsatis;
        }
        // bu kısımda kura ait labelın yanında olan butona basıldığında kura yazdır komutunu veriliyor.
        private void btnDolarAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlis.Text;
        }
        private void btnDolarSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
        }
        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;
        }
        private void btnEuroSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSatis.Text;
        }
        private void btnSterlinAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblSterlinAlis.Text;
        }
        private void btnSterlinSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblSterlinSatis.Text;
        }
        private void btnFrangAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblFrangAlis.Text;
        }
        private void btnFrangSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblFrangSatis.Text;
        }
        //Aşagğdaki kodlar Satışİşlem2 butonunun işlemlerini ve Kalan kısmına yazılacak küsürat kısmını gösterir.
        private void btnSatis2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            int tutar = Convert.ToInt32(miktar /  kur);
            txtTutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
        }
    }
}
