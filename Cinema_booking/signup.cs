using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;
using trailer;

namespace Cinema_booking
{
    public partial class signup : Form
    {
   
        public static string fname;
        public static string lname;
        public static string phoneNum;
        public static string email;
        public static int age;
        public static string pass;

        
        SqlConnection con;

        public signup()
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
                else if (ctrl is GroupBox)
                {
                    ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                    ctrl.BackColor = ColorTranslator.FromHtml("#201E43");
                }
                else if (ctrl is NumericUpDown nud)
                {
                    nud.BackColor = ColorTranslator.FromHtml("#508C9B");
                    nud.ForeColor = ColorTranslator.FromHtml("#201E43");
                }
            }










            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True");

            // Attach KeyDown event to the Form
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            SignUpBtn.Click += SignUpBtn_Click;
            RstBtn.Click += ResetBtn_Click;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                ResetBtn_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {

                SignUpBtn_Click(sender, e);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void FirstNameTxtt_TextChanged(object sender, EventArgs e) { }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fname = FirstNameTxtt.Text.Trim();
                lname = LastNameTxt.Text.Trim();
                email = EmailTxt.Text.Trim();
                phoneNum = PhoneNumberTxt.Text.Trim();
                age = (int)AgeTxt.Value;
                pass = PasswordTxt.Text.Trim();
                string errors = "";


                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (age < 13)
                {
                    errors += "• Age must be 13 or older to sign up.\n";
                }
                if (phoneNum.Length != 11)
                {

                    errors += "• Invalid phone number, must be 11 digits.\n";
                }
                if (!long.TryParse(phoneNum, out _)) 
                    errors += "• Phone number must contain only digits.\n";

                bool found = false;
                con.Open();
                string query = "SELECT email FROM end_user ";

                using (SqlCommand comm = new SqlCommand(query, con))
                {

                    SqlDataReader read = comm.ExecuteReader();


                    while (read.Read())
                    {
                        for (int i = 0; i < read.FieldCount; i++)
                        {
                            if (read[i].ToString() == email)
                                found = true;

                        }
                    }

                    con.Close();
                    read.Close();
                    if (found)
                    {
                        errors += "• Email already used before.\n";
                       
                    }

                }
                if (!string.IsNullOrEmpty(errors))
                {

                    MessageBox.Show(errors, "Input Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                con.Open();
                SqlCommand cmd = new SqlCommand("InsertNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", fname);
                cmd.Parameters.AddWithValue("@LastName", lname);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNum);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.Parameters.AddWithValue("@Role", "Customer");
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login login = new login();
                login.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during signup:\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {

            FirstNameTxtt.Text = "";
            LastNameTxt.Text = "";
            EmailTxt.Text = "";
            PhoneNumberTxt.Text = "";
            PasswordTxt.Text = "";
            AgeTxt.Value = AgeTxt.Minimum; 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SignUpBtn_Click_1(object sender, EventArgs e)
        {

        }
    }
}