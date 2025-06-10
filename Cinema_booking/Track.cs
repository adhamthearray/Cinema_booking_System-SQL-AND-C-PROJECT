using Cinema_booking;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema_booking
{
    public partial class Track : Form
    {
        SqlConnection con;
        public int adid;


        public Track(int id)
        {

            adid = id;
            InitializeComponent();
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
            this.OrderTxt.KeyDown += new KeyEventHandler(this.OrderTxt_KeyDown);

        }
        private void OrderTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string email = OrderTxt.Text.Trim();

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
            o.Order_Id,
            e.Email,
            o.Payment_Method,
            o.Date
        FROM Orders o
        JOIN end_user e ON o.User_Id_fk = e.User_Id
        WHERE e.Email LIKE @email";

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

        private void LoadAllOrders()
        {
            string query = @"
                SELECT 
                    o.Order_Id,
                    e.Email,       
                    o.Payment_Method,
                    o.Date
                FROM Orders o
                JOIN end_user e ON o.User_Id_fk = e.User_Id";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadLastWeekOrders()
        {
            string query = @"
                SELECT 
                    o.Order_Id,
                    e.Email,       
                    o.Payment_Method,
                    o.Date
                FROM Orders o
                JOIN end_user e ON o.User_Id_fk = e.User_Id
                WHERE o.Date >= DATEADD(DAY, -7, GETDATE())";


            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

       

        private void ShowAllOrdersBtn_Click(object sender, EventArgs e)
        {
            LoadAllOrders();
        }

        private void BackBtn_Click_1(object sender, EventArgs e)
        {

            Admin admin = new Admin(adid);
            admin.Show();
            this.Hide();
        }

        private void ShowLastBtn_Click_1(object sender, EventArgs e)
        {
            LoadLastWeekOrders();
        }
    }
}