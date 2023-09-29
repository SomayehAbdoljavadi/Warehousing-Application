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
    public partial class kala_out : Form
    {
        public kala_out()
        {
            InitializeComponent();
        }

        private void kala_out_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select pid,data,wight,document_id,document_num,recive_date from vorod_anbar,property_sodor where pid=id_ghabz and data between '" + maskedTextBox1.Text + "' and '" + maskedTextBox2.Text + "' and document_num<>'' ", con);
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