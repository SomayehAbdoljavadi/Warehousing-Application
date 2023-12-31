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
    public partial class country : Form
    {
        public country()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        private void Insert_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "insert into country(cname,ccod)Values('" + textBox1.Text + "','" + textBox2.Text + "')";
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            show();
            MessageBox.Show("کشور جدید ثبت شد");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from country where cuid="+st;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("کشور مورد نظر حذف شد");
            show();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           show();   
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text =dataGridView1[2,e.RowIndex].Value.ToString ()  ;
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            st = dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText ="update country set cname='"+textBox1 .Text+ "' , ccod='"+textBox2 .Text +"' where cuid="+st;
            com.Connection = con;
            com.ExecuteNonQuery ();
            MessageBox.Show("ویرایش با موفقیت انجام شد");
            con.Close();
            show();
        }
      
        string st;
        
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            st = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox1.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString(); 
        }
        
        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from country", con);
            DataSet ds = new DataSet();
            
            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver ;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;
            
            da.Fill(ds, "country");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "country";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[2].HeaderText = "نام کشور";
            dataGridView1.Columns[1].HeaderText = "کد کشور";
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;

            dataGridView1.Columns[0].Visible = false;
            con.Close();  
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}