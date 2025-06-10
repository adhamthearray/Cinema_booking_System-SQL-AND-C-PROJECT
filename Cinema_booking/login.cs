using Cinema_booking;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Cinema_booking
{
    public partial class login : Form
    {
        public static int UID = -1;
        public static int AID = -1;
        public static string pass;
        public static string email;
        // Database connection
        SqlConnection con;
        public login()
        {
            InitializeComponent();
           
            this.BackColor = ColorTranslator.FromHtml("#201E43");

           
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                }
                else if (ctrl is Button)
                {
                    ctrl.BackColor = ColorTranslator.FromHtml("#134B70");
                    ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                    ((Button)ctrl).FlatStyle = FlatStyle.Flat;
                    ((Button)ctrl).FlatAppearance.BorderColor = ColorTranslator.FromHtml("#508C9B");
                }
                else if (ctrl is TextBox)
                {
                    ctrl.BackColor = ColorTranslator.FromHtml("#508C9B");
                    ctrl.ForeColor = ColorTranslator.FromHtml("#201E43");
                }
                /* else if (ctrl is LinkLabel)
                 {
                     ctrl.LinkColor = ColorTranslator.FromHtml("#508C9B");
                     ctrl.ActiveLinkColor = ColorTranslator.FromHtml("#EEEEEE");
                     ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                 }*/
            }






            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True;");
           
            this.KeyPreview = true;
           
            LoginBtn.Click += LoginBtn_Click;
            SignUPLink.LinkClicked += SignUPLink_LinkClicked;
            this.FormClosing += Form2_FormClosing;


        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool found = false;

            email = EmailLogin.Text.Trim();
            pass = PasswordLogin.Text.Trim();

           
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please enter both Email and Password.");
                return;
            }

            string query = "SELECT User_ID, Email,Role, Password FROM end_user";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dbEmail = reader["Email"].ToString().Trim();
                        string dbPassword = reader["Password"].ToString().Trim();

                        if (dbEmail.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                            dbPassword == pass && reader["Role"].ToString() == "Customer")
                        {
                            UID = (int)reader["User_ID"];
                            found = true;
                            break;
                        }
                        if (dbEmail.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                            dbPassword == pass && reader["Role"].ToString() == "Admin")
                        {
                            AID = (int)reader["User_ID"];
                            found = true;
                            break;
                        }
                    }
                }
                con.Close();
            }

            if (found && AID != -1)
            {
                MessageBox.Show("Login AS Admin Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin admin = new Admin(AID);
                admin.Show();
                AID = -1;
                
                this.Close();

               
            }
            else if (found && UID != -1)
            {
                MessageBox.Show("Login AS Customer Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 f = new Form1(UID);
                f.Show();
                UID = -1;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignUPLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup form1 = new signup();
            form1.Show();
            this.Hide();


        }
    }
}