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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-707SDOT;Initial Catalog=Personel;Integrated Security=True");

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {

                lbltoplamPer.Text = dr1[0].ToString();


            }

            baglanti.Close();


            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel  WHERE perDurum = 1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPer.Text = dr2[0].ToString();
            }
            
            baglanti.Close();



            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE perDurum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPer.Text = dr3[0].ToString();
            }

            baglanti.Close();

            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("SELECT COUNT(DISTINCT(perSehir)) FROM Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehir.Text = dr4[0].ToString();
            }

            baglanti.Close();


            baglanti.Open();

            SqlCommand komut5 = new SqlCommand("SELECT SUM(perMaas) FROM Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblTopMaas.Text = dr5[0].ToString();
            }

            baglanti.Close();


            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("SELECT AVG(perMaas) FROM Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString();
            }

            baglanti.Close();

        }
    }
}
