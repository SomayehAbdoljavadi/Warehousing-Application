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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        int limit = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.CompareTo(textBox3.Text) == 0)
            {
                con.Open();
                com.CommandText = "insert into login(luser,lpass,llimit)Values('" + textBox1.Text + "','" + textBox2.Text + "'," + limit + ")";
                com.Connection = con;
                com.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" کاربر جدبد ثبت شد");
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
                MessageBox.Show(" تکرار رمز عبور نادرست است");
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) limit = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) limit = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
          
    }
}