using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webServisCagir4
{
    public partial class Form1 : Form
    {
        public Form1() {
    
            InitializeComponent();

            comboBox1.Items.Add(new DictionaryEntry("Yangınla Mücadele Ekibi", "1"));
            comboBox1.Items.Add(new DictionaryEntry("İlk Yardım Ekibi", "2"));
            comboBox1.Items.Add(new DictionaryEntry("Arama Kurtarma Ekibi", "3"));
            comboBox1.Items.Add(new DictionaryEntry("Çevre Ekibi", "4"));
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = comboBox1.Items;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int ekipNo = int.Parse(txtEkip.Text);
            //ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            //dataGridView1.DataSource= srv.Bagla(ekipNo);

            int deger = int.Parse(comboBox1.SelectedValue.ToString());
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = srv.Bagla(deger);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String adi = (txtad.Text);
            String soyadi = (txtSoyad.Text);
            String resim = (txtResim.Text);
            int ekipNo = int.Parse(txtEkipGir.Text);
            int bolgeNo = int.Parse(txtBolge.Text);
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            srv.KisiKaydet(adi, soyadi, ekipNo, bolgeNo, resim);
            MessageBox.Show("Kayıt İşlemi Tamamlandı!", "Bilgi");
            dataGridView1.DataSource = srv.Listele();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtid.Text);
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            srv.KisiSil(ID);
            MessageBox.Show("Silme İşlemi Tamamlandı!", "Bilgi");
            dataGridView1.DataSource = srv.Listele();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtidGun.Text);
            String adi = (txtadGun.Text);
            String soyadi = (txtsoyadGun.Text);
            int ekipNo = int.Parse(txtekipGun.Text);
            int bolgeNo = int.Parse(txtbolgeGun.Text);
            String resim = (txtresimGun.Text);
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            srv.Guncelle(id, adi, soyadi, ekipNo, bolgeNo, resim);
            MessageBox.Show("Güncelleme İşlemi Tamamlandı!", "Bilgi");
            dataGridView1.DataSource = srv.Listele();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = srv.Listele();
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient srv = new ServiceReference1.WebService1SoapClient();
            dataGridView1.DataSource = srv.Listele();
        }
        
    }
}  
