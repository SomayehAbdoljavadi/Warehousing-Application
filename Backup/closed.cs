using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
namespace gomrok1
{
    public partial class closed : Form
    {
        public closed()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        
        SqlCommand com = new SqlCommand();
        string st;
        private void Form4_Load(object sender, EventArgs e)
        {
            show();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "insert into closed(ctype)Values('" + textBox1.Text + "')";
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("بسته جدید ثبت شد");
            show();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from closed where cid=" + st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("بسته مورد نظر حذف  شد");
            show();
           
        }


        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from closed", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "closed");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "closed";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].HeaderText = "نوع بسته";
            dataGridView1.Columns[0].Width = 200;
            con.Close();

        }

        private void Edit_Click(object sender, EventArgs e)
        {
           con.Open();
            com.CommandText = "update closed set ctype='" + textBox1.Text + "'  where cid=" + st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ویرایش با موفقیت انجام شد");
            show();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            
            st = dataGridView1[1, e.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            st = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

       
       
    }
}