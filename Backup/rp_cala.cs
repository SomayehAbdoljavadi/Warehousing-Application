using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gomrok1
{
    public partial class rp_cala : Form
    {
        public rp_cala()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id_ghabz,data,number,wight from vorod_anbar,property_sodor where pid=id_ghabz and data between '" + maskedTextBox1.Text + "' and '" + maskedTextBox2.Text + "'and goods_name='" +textBox1.Text+"'", con);
            DataSet ds = new DataSet();
            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;

            da.Fill(ds, "property_sodor");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "property_sodor";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        }
    }