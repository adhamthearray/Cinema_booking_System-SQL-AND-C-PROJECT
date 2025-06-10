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

namespace Cinema_booking
{
    public partial class Users : Form
    {
        SqlConnection con;
        public int adid;
        public string Urole;
        public Users(int id)
        {

            InitializeComponent();
            adid = id;
            this.BackColor = ColorTranslator.FromHtml("#201E43");

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = ColorTranslator.FromHtml("#134B70");
                    btn.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#508C9B");
                }
            }

            StyleDataGridView();
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True;");
            this.UserTxt.KeyDown += new KeyEventHandler(this.UserTxt_KeyDown);
        }
        public void StyleDataGridView()
        {
            dataGridView1.BackgroundColor = ColorTranslator.FromHtml("#1E1C3A");
            dataGridView1.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#25234A");
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#134B70");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2D2B55");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = ColorTranslator.FromHtml("#2D2B55");
        }

        private void UserTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                string email = UserTxt.Text.Trim();

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Please enter an email to search.");
                    return;
                }

                SearchOrdersByEmail(email);
            }
        }
        private void SearchOrdersByEmail(string email)
        {
            string query = @"
        SELECT 
           * from end_user
        WHERE Email LIKE @email";

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@email", "%" + email + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadAllUsers(string role)
        {
            string query = "SELECT * FROM end_user WHERE role = @role";

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@role", role);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowUsersBtn_Click(object sender, EventArgs e)
        {
            Urole = "Customer";
            LoadAllUsers(Urole);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(adid);
            admin.Show();
            this.Hide();
        }

        private void ShowAdminBtn_Click(object sender, EventArgs e)
        {
            Urole = "Admin";
            LoadAllUsers(Urole);

        }

        private void ShowMgrBtn_Click(object sender, EventArgs e)
        {
            Urole = "Manager";
            LoadAllUsers(Urole);
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }
    }
}