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
    public partial class kala_matrook : Form
    {
        public kala_matrook()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct pid,data,ctype,number,coname,tel,address,name from vorod_anbar,property_sodor,closed,compony where cid=closed_id and compony_id=coid and pid=id_ghabz and DATEDIFF(day,data,GETDATE())>60 ", con);
            DataSet ds = new DataSet();
            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;

            da.Fill(ds, "property_sodor");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "property_sodor";
            con.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}