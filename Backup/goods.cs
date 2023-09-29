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
    public partial class goods : Form
    {
        public goods()
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

        private void Form5_Load(object sender, EventArgs e)
        {
            show();
        }

        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from goods", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "goods");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "goods";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "نوع کالا";
            con.Close();

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "insert into goods(gtype)Values('" + textBox1.Text + "')";
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("کالا جدید ثبت شد");
            show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from goods where gid=" +st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("سند مورد نظر حذف  شد");
            show();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "update goods set gtype='" + textBox1.Text + "'  where gid=" + st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ویرایش با موفقیت انجام شد");
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