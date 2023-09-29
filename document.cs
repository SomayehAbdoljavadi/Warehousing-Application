using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace gomrok1
{
    public partial class document : Form
    {
        public document()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");

        SqlCommand com = new SqlCommand();
        string st;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            show();
        }

        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from document", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "document");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "document";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "‰Ê⁄ ”‰œ";
            con.Close();

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "insert into document(dtype)Values('" + textBox1.Text + "')";
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("”‰œ Ãœ?œ À»  ‘œ");
            show();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from document where did=" + st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("”‰œ „Ê—œ ‰Ÿ— Õ–›  ‘œ");
            show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "update document set dtype='" + textBox1.Text + "'  where did=" + st ;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ÊÌ—«Ì‘ »« „Ê›ﬁÌ  «‰Ã«„ ‘œ");
            show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();

            st = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            st = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}