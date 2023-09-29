using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gomrok1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void کشورمبداءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new country();
            ff.ShowDialog();
        }

        private void شرکتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new compony();
            ff.ShowDialog();
        }

        private void نوعبستهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new closed();
            ff.ShowDialog();
        }

        private void نوعسندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new goods();
            ff.ShowDialog();

        }

        private void نوعکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new document();
            ff.ShowDialog();

        }

        private void سالToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form ff = new year();
            ff.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + "  ------->  کاربر فعال :" + login_asli.lname;
            if (login_asli.id == 0)
            {
                ایجادToolStripMenuItem.Enabled = false;        
            }
            
        }
        
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ایجادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new login();
            ff.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void تغییررمزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new pass_change();
            ff.ShowDialog();
        }

        private void صدورقبضانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new so_ghabz();
            ff.ShowDialog();
        }

        private void شرکتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ff = new rp_country_2();
            ff.ShowDialog();
        }

        private void نوعکالاToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ff = new rp_noe_kala();
            ff.ShowDialog();
        }

        private void کالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_cala();
            ff.ShowDialog();
        }

        private void خروجکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new out_kala();
            ff.ShowDialog();
        }

        private void قبضانبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_ghabz();
            ff.ShowDialog();
        }

        private void بارنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_barname();
            ff.ShowDialog();
        }

        private void صاحبکالاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_name();
            ff.ShowDialog();
        }

        private void کشورمبداToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_country();
            ff.ShowDialog();
        }

        private void وضعیتخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new rp_khorj();
            ff.ShowDialog();
        }

        private void کالایورودیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new kala_in();
            ff.ShowDialog();
        }

        private void کالایخروجیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new kala_out();
            ff.ShowDialog();
        }

        private void کالایمتروکهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ff = new kala_matrook();
            ff.ShowDialog();
        }

        private void اطلاعتاولیهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

      
    }
}