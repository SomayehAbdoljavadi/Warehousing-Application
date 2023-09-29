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
    public partial class rp_ghabz : Form
    {
        public rp_ghabz()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection("data source=localhost;initial catalog=gomrokf;integrated security=true");
        SqlCommand com = new SqlCommand();
            
        private void rp_ghabz_Load(object sender, EventArgs e)
        {
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                show();
        }
        public void show()
        {


                con.Open();
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
                con.Close();

                DataSet ds1 = new DataSet();
                con.Open();
                da.SelectCommand.CommandText ="select pid,data,cname,coname,name,number_pa,tel,address,document_id,document_num,recive_date,property_malek from property_sodor , compony,country where compony.coid=compony_id and country.cuid=countery_id and pid=" + int.Parse(textBox1.Text);
                dataGridView2.AlternatingRowsDefaultCellStyle = csd;

                da.Fill(ds1, "property_sodor");
                dataGridView2.DataSource = ds1;
                dataGridView2.DataMember = "property_sodor";
                con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
        
    }
