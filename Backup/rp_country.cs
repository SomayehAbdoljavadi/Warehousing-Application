using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gomrok1
{
    public partial class rp_country : Form
    {
        public rp_country()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        
        private void rp_country_Load(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "select * from country";
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read()) comboBox4.Items.Add(dr[0].ToString()+ ":" + dr[1].ToString().Trim()+ "," + dr[2].ToString().Trim ());
            dr.Close();
            con.Close();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] stt = comboBox4.Text.Split(':');
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id_ghabz,wight from vorod_anbar,property_sodor where pid=id_ghabz and data between '"+maskedTextBox1 .Text +"' and '"+maskedTextBox2.Text +"'and countery_id=" + stt[0], con);
            DataSet ds = new DataSet();
            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;

            da.Fill(ds, "property_sodor");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "property_sodor";
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}