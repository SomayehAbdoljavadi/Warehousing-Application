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
    public partial class so_ghabz : Form
    {
        public so_ghabz()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
        string st;

        private void Form9_Load(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "select * from country";
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read()) comboBox4.Items.Add(dr[0].ToString()+ ":" + dr[1].ToString().Trim()+ "," + dr[2].ToString().Trim ());
            dr.Close();

            com.CommandText = "select * from compony";
            dr = com.ExecuteReader();
            while (dr.Read()) comboBox1.Items.Add(dr[1].ToString()+":"+dr[0].ToString().Trim());
            dr.Close();

            com.CommandText = "select * from closed";
            dr = com.ExecuteReader();
            while (dr.Read()) comboBox2.Items.Add(dr[1].ToString()+":"+dr[0].ToString().Trim());
            dr.Close();

            com.CommandText = "select * from goods";
            dr = com.ExecuteReader();
            while (dr.Read()) comboBox3.Items.Add(dr[0].ToString() + ":" + dr[1].ToString().Trim());
            dr.Close();



            com.CommandText = "select max(pid) from property_sodor";
            try
            {
                textBox1.Text = (int.Parse(com.ExecuteScalar().ToString()) + 1).ToString();
            }
            catch (Exception es)
            { 
                textBox1.Text = "1";
            }

            textBox1.Enabled = false;

            con.Close();
            show();

            DateTime dt =DateTime.Now;
            textBox2.Text = dt.Year + "/" + dt.Month + "/" + dt.Day;
            textBox2.Enabled = false;


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                groupBox1.Enabled = false;
            else groupBox1.Enabled = true;
        }

        
        private void Insert_Click(object sender, EventArgs e)
        {
            string[] stt1 = comboBox2.Text.Split(':');
            string[] stt2 = comboBox3.Text.Split(':');
            
            con.Open();
            com.CommandText = "insert into vorod_anbar(id_ghabz,number,closed_id,goods_name,wight,goods_id,num_gh,comment)Values(" +int.Parse( textBox1.Text) + "," + int.Parse(textBox8.Text )+ ","+stt1[0]+",'"+textBox9.Text+"',"+int.Parse(textBox10.Text)+","+stt2[0]+","+int.Parse(textBox11.Text)+",'"+textBox12.Text+"')";
            com.ExecuteNonQuery().ToString ();
            con.Close();
            show();
            MessageBox.Show("قبض جدید ثبت شد");
        }
        public void show()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select vid,id_ghabz,number,ctype,goods_name,wight,gtype,num_gh,comment from vorod_anbar,goods,closed where goods_id=gid and closed_id=cid and id_ghabz="+int.Parse(textBox1.Text), con);
            //da.SelectCommand = new SqlCommand();
            ///da.SelectCommand.CommandType=CommandType.StoredProcedure
            //da.SelectCommand.CommandText=
            DataSet ds = new DataSet();

            DataGridViewCellStyle csd = new DataGridViewCellStyle();
            csd.BackColor = Color.Silver;
            dataGridView1.AlternatingRowsDefaultCellStyle = csd;

            da.Fill(ds, "vorod_anbar");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "vorod_anbar";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].HeaderText = "تعداد";
            dataGridView1.Columns[2].Width = 40;
            dataGridView1.Columns[3].HeaderText = "نوع بسته";
            dataGridView1.Columns[4].HeaderText = "نام کالا";
            dataGridView1.Columns[5].HeaderText = "وزن";
            dataGridView1.Columns[5].Width = 40;
            dataGridView1.Columns[6].HeaderText = "نوع کالا";
            dataGridView1.Columns[7].HeaderText = "ش قفسه";
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].HeaderText = "توضیحات";
            dataGridView1.Columns[8].Width = 150;
            con.Close();

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            con.Open();
            com.CommandText = "delete from vorod_anbar where vid=" +id  ;
            com.Connection = con;
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("قبض  مورد نظر حذف شد");
            show();

        }
        int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                textBox8.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                comboBox2.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                textBox9.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                textBox10.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                comboBox3.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                textBox11.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                textBox12.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            }
            catch (Exception ex)
                {}
        }

        private void Edit_Click(object sender, EventArgs e)
        {

                string[] stt1 = comboBox2.Text.Split(':');
                string[] stt2 = comboBox3.Text.Split(':');

                con.Open();
                com.CommandText = "update vorod_anbar set number=" + int.Parse(textBox8.Text) + ",closed_id="+stt1[0]+", goods_name='"+textBox9.Text+"',wight="+int.Parse(textBox10.Text)+",goods_id="+stt2[0]+",num_gh="+int.Parse(textBox11.Text)+",comment='"+textBox12.Text+"' where vid=" + id ;
                com.Connection = con;
                com.ExecuteNonQuery();
                MessageBox.Show("ویرایش با موفقیت انجام شد");
                con.Close();
                show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] stt1 = comboBox1.Text.Split(':');
            string[] stt2 = comboBox4.Text.Split(':');
            con.Open();
            if (checkBox1.Checked==true)
                 com.CommandText = "Insert into property_sodor(pid,data,countery_id,compony_id) values(" + int.Parse(textBox1.Text) + ",'" + textBox2.Text + "'," + stt2[0] + "," + stt1[0] + ")";
            else
                 com.CommandText = "insert into property_sodor(pid,data,countery_id,compony_id,name,number_pa,tel,address)Values(" + int.Parse(textBox1.Text) + ",'" + textBox2.Text + "'," + stt2[0] + "," + stt1[0] + ",'" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox7.Text + "')";
            
            com.ExecuteNonQuery();
            MessageBox.Show("اطلاعات اوليه ثبت شد");
            groupBox2.Enabled = true;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        }
  }

        
       

       
