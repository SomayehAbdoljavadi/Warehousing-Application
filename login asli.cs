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
    public partial class login_asli : Form
    {
        public login_asli()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        public static int id = -1;
        public static int ui = 0;
        public static string  lname ="" ;


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "Select llimit,lid,luser from login where luser='" + textBox1.Text + "' and lpass='" + textBox2.Text + "'";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
                ui = int.Parse(dr[1].ToString());
                lname = dr[2].ToString();

                Form fr = new main();
                con.Close();
                this.Hide();
             fr.Show();
                
                
            }
            else
            {
               MessageBox.Show("کاربری با این مشخصات موجود نمی باشد");
                 con.Close();
            }      
        }

        private void login_asli_Load(object sender, EventArgs e)
        {
            
        }
    }
}