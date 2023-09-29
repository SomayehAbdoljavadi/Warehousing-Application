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
    public partial class compony : Form
    {
        public compony()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
       
        SqlCommand com = new SqlCommand();
        string st;
        private void Form3_Load(object sender, EventArgs e)
        {
            show();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "insert into compony(coname)Values('" + textBox1.Text + "')";
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("شرکت جدید ثبت شد");
            show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from compony where coid=" + st ;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("شرکت مورد نظر حذف  شد");
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

        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from compony", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "compony");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "compony";
            dataGridView1.AutoGenerateColumns = true;
            
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].HeaderText = "نام شرکت";
            dataGridView1.Columns[0].Width = 300;

            con.Close();

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "update compony set coname='" + textBox1.Text + "' where coid=" + st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ویرایش با موفقیت انجام شد");
            show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


       
        
       

     

      
    }
}