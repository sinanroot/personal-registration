using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Personel_Kayıt
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-707SDOT;Initial Catalog=Personel;Integrated Security=True");
        
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtSehir.Text = "";
            txtMaas.Text = "";
            txtMeslek.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelDataSet1.Tbl_Personel' table. You can move, or remove it, as needed.

            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet1.Tbl_Personel);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet1.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
           

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Personel (perAd, perSoyad, perSehir, perMaas, perMeslek, perDurum) values (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtSehir.Text);
            komut.Parameters.AddWithValue("@p4", txtMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label7.Text);


            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label7.Text = "True";

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label7.Text = "False";

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            

            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

            


        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if (label7.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if (label7.Text == "False")
            {
                radioButton2.Checked = true;
            } 
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("DELETE FROM Tbl_Personel WHERE perId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtId.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi!");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("UPDATE Tbl_Personel SET perAd=@a1, perSoyad=@a2, perSehir=@a3, perMaas=@a4, perDurum=@a5, perMeslek=@a6 WHERE perId=@a7", baglanti);

            komutguncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", txtSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", txtMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label7.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtId.Text);

            komutguncelle.ExecuteNonQuery();


            baglanti.Close();
            MessageBox.Show("Guncellendi!");
        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();

            fr.Show();  
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafik frg = new FrmGrafik();
            frg.Show();
        }
    }
}
