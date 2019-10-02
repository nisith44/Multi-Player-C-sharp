using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactManagementSystem.EntityClasses;

namespace ContactManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        tel_number t1 = new tel_number();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t1.firstName = txtfname.Text;
            t1.lastName = txtlname.Text;
            t1.tel = txtphone.Text;
            t1.addess = txtaddress.Text;
            t1.gender = cmbgender.Text;

            bool success=t1.insert_tel_numbers(t1);
            if (success == true)
            {
                MessageBox.Show("Contact Inserted Successfully");
            }
            else
            {
                MessageBox.Show("Contact Inserted Failed");
            }

            DataTable dt = t1.select();
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = t1.select();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t1.contactId = int.Parse(txtid.Text);
            t1.firstName = txtfname.Text;
            t1.lastName = txtlname.Text;
            t1.tel = txtphone.Text;
            t1.addess = txtaddress.Text;
            t1.gender = cmbgender.Text;

            bool success = t1.update_contact(t1);
            if (success == true)
            {
                MessageBox.Show("Contact Inserted Successfully");
            }
            else
            {
                MessageBox.Show("Contact Inserted Failed");
            }

            DataTable dt = t1.select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtid.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtfname.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            txtlname.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            txtphone.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            cmbgender.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t1.contactId = int.Parse(txtid.Text);
            bool success=t1.delete_contact(t1);
            if (success)
            {
                MessageBox.Show("Contact Deleted Successfully");
                DataTable dt = t1.select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Contact Deleted failed");
            }

        }

        //clear all fields......
        public void clear()
        {
            txtid.Text=null;
            txtfname.Text = null;
            txtlname.Text = null;
            txtphone.Text = null;
            txtaddress.Text = null;
            cmbgender.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            DataTable dt = t1.search(key);
            dataGridView1.DataSource = dt;
        }
    }
}
