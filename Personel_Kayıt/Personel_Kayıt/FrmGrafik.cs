﻿using System;
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
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-707SDOT;Initial Catalog=Personel;Integrated Security=True");


        private void FrmGrafik_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select perSehir, Count(*) From Tbl_Personel Group By perSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();

            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select perMeslek, Avg(perMaas) From Tbl_Personel Group By perMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();

            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglanti.Close();

        }
    }
}
