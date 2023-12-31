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
    public partial class out_kala : Form
    {
        public out_kala()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        int count;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                show();
        }
        public void show()
        {
            con.Open();
            com.CommandText = "select document_num from property_sodor where pid=" + int.Parse(textBox1.Text);
            com.Connection = con;
           
            if (com.ExecuteScalar().ToString() == "")
            {

                SqlDataAdapter da = new SqlDataAdapter("select vid,id_ghabz,number,ctype,goods_name,wight,gtype,num_gh,comment from vorod_anbar,goods,closed where goods_id=gid and closed_id=cid and id_ghabz=" + int.Parse(textBox1.Text), con);
                DataSet ds = new DataSet();

                DataGridViewCellStyle csd = new DataGridViewCellStyle();
                csd.BackColor = Color.Silver;
                dataGridView1.AlternatingRowsDefaultCellStyle = csd;

                da.Fill(ds, "vorod_anbar");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "vorod_anbar";
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.RowHeadersWidth = 20;
                dataGridView1.ColumnHeadersHeight = 20;

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].HeaderText = "تعداد";
                dataGridView1.Columns[2].Width = 40;
                dataGridView1.Columns[3].HeaderText = "نوع بسته";
                dataGridView1.Columns[2].Width = 50;
                dataGridView1.Columns[4].HeaderText = "نام کالا";
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[5].HeaderText = "وزن";
                dataGridView1.Columns[5].Width = 30;
                dataGridView1.Columns[6].HeaderText = "نوع کالا";
                dataGridView1.Columns[6].Width = 70;
                dataGridView1.Columns[7].HeaderText = "ش قفسه";
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[8].HeaderText = "توضیحات";
                dataGridView1.Columns[8].Width = 85;

                com.CommandText = "select count(*) from vorod_anbar where id_ghabz=" + int.Parse(textBox1.Text);
                com.Connection = con;
                count = int.Parse(com.ExecuteScalar().ToString());

                dataGridView2.Rows.Clear();
                if (count > 0)
                {
                    dataGridView2.Rows.Add(count);
                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToAddRows = false;
                }
            }
            else
                MessageBox.Show("اين حواله قبلا خارج شده");

            con.Close();

        }

        private void out_kala_Load(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "select * from document";
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read()) comboBox1.Items.Add(dr[0].ToString() + ":" + dr[1].ToString().Trim());
            dr.Close();
            con.Close();

            DateTime dt = DateTime.Now;
            textBox2.Text= textBox5 .Text  = dt.Year + "/" + dt.Month + "/" + dt.Day;
            textBox2.Enabled = textBox5.Enabled = false;
            

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            for (int t = 0; t < count; t++)
            {
                if (int.Parse(dataGridView1[2, t].Value.ToString()) - int.Parse(dataGridView2[0, t].Value.ToString()) > 0)
                    groupBox1.Enabled = true;
                       
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string[] stt = comboBox1.Text.Split(':');
            con.Open();
            com.CommandText = "update property_sodor set document_id="+stt[0]+" , document_num="+textBox3 .Text +" , recive_date= '"+textBox2 .Text +"', property_malek='"+textBox4 .Text +"' where pid=" + int.Parse(textBox1.Text);
            com.ExecuteNonQuery();
            con.Close();
            groupBox1.Enabled = false;
            textBox1.Text = textBox3.Text = textBox4.Text  = textBox6.Text = "";
        }


    }
}