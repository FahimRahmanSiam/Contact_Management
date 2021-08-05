using Contact_Management.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Contact_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EcontactClasses ec = new EcontactClasses();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = ec.Select();
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = searchBox.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Contacts WHERE FirstName LIKE'%" + keyword + "%' OR LastName LIKE'%" + keyword + "%' OR Address LIKE'%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            ec.FirstName = firstNameBox.Text;
            ec.LastName = lastNameBox.Text;
            ec.Email = emailBox.Text;
            ec.Mobile = int.Parse(mobileBox.Text);
            ec.Address = addressBox.Text;
            ec.Gender = genderBox.Text;

            bool success = ec.Insert(ec);

            if (success == true) 
            {
                MessageBox.Show("New Contact created successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to create new contact! Please try again !");
            }
            DataTable dt = ec.Select();
            dataGridView1.DataSource = dt;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
        public void clear()
        {
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            emailBox.Text = "";
            mobileBox.Text = "";
            addressBox.Text = "";
            genderBox.Text = "";
            contactID.Text = "";
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ec.ContactID = int.Parse(contactID.Text);
            ec.FirstName = firstNameBox.Text;
            ec.LastName = lastNameBox.Text;
            ec.Email = emailBox.Text;
            ec.Mobile = int.Parse(mobileBox.Text);
            ec.Address = addressBox.Text;
            ec.Gender = genderBox.Text;

            bool success = ec.Update(ec);

            if (success == true)
            {
                MessageBox.Show("Contact has been updated successfully!!");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update the contact! Please try again !");
            }
            DataTable dt = ec.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            contactID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            firstNameBox.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            lastNameBox.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            mobileBox.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            addressBox.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            emailBox.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            genderBox.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ec.ContactID = int.Parse(contactID.Text);
            bool success = ec.Delete(ec);
            if (success == true)
            {
                MessageBox.Show("Contact has been deleted successfully!!");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete the contact! Please try again !");
            }
            DataTable dt = ec.Select();
            dataGridView1.DataSource = dt;
        }
    }
    
}
