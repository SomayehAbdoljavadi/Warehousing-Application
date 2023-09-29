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
    public partial class rp_khorj : Form
    {
        public rp_khorj()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                show();
        }
        public void show()
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select property_malek,dtype,document_num,recive_date,child_id from document,property_sodor where document_id=did and pid=" + int.Parse(textBox1.Text), con);
            DataSet ds = new DataSet();
            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;

            da.Fill(ds, "property_sodor");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "property_sodor";
            con.Close();
        }
    }
}