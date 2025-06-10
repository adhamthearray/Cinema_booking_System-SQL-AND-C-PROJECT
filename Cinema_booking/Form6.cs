using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cinema_booking
{
    public partial class Form6 : Form
    {
        int ad;
        SqlConnection con;
        public Form6(int admin)
        {
            ad = admin;
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True;");
            InitializeComponent();
            
            this.BackColor = ColorTranslator.FromHtml("#201E43");
            StyleDataGridView();
            
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
        }

        private void StyleDataGridView()
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

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(ad);
            admin.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ShowAllOrdersBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        u.First_Name + ' ' + u.Last_Name AS AdminName,
                        u.Email,
                        m.Movie_Name,
                        am.Process
                    FROM 
                        dbo.Admin_Movie am
                    JOIN 
                        dbo.end_user u ON am.Admin_ID = u.User_ID
                    JOIN 
                        dbo.Movies m ON am.Movie_ID = m.Movie_ID
                    ORDER BY 
                        AdminName, m.Movie_Name";

                SqlCommand command = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                con.Open();
                adapter.Fill(dataTable);
                con.Close();

                dataGridView1.DataSource = dataTable;

                // Format the DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["AdminName"].HeaderText = "Admin Name";
                dataGridView1.Columns["Movie_Name"].HeaderText = "Movie";
                
                // Ensure the styling is applied after data load
                StyleDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}