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
    public partial class pass_change : Form
    {
        public pass_change()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");

        SqlCommand com = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {   con.Open();
            com.Connection=con;
            com.CommandText="select * from login where lid="+login_asli.ui +" and lpass='"+textBox1.Text+"'";
            SqlDataReader dr=com.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                if (textBox2.Text.CompareTo(textBox3.Text) == 0)
                {
                    com.CommandText = "update login set lpass='" + textBox2.Text + "' where lid=" + login_asli.ui;
                    com.ExecuteNonQuery();
                    MessageBox.Show("تغيير رمز با موفقيت انجام شد");
                    textBox1.Text = textBox2.Text = textBox3.Text = "";
                }
                else
                    MessageBox.Show("تکرار رمز عبور جدید اشتباه است");

            }
            else
            {
                MessageBox.Show("رمز داده شده نا معتبر است");
 
            }
            con.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}