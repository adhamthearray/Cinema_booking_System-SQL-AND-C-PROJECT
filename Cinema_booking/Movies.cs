using Cinema_booking;
//using Microsoft.Data.SqlClient;
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
    public partial class Movies : Form
    {
        SqlConnection con;
        public int adid;
        public Movies(int id)
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
            this.MovieTxt.KeyDown += new KeyEventHandler(this.MovieTxt_KeyDown);
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

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
        private void MovieTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                string Name = MovieTxt.Text.Trim();

                if (string.IsNullOrWhiteSpace(Name))
                {
                    MessageBox.Show("Please enter an email to search.");
                    return;
                }

                SearchMovie(Name);
            }
        }
        private void SearchMovie(string Name)
        {
            string query = @"
        SELECT 
           * from Movies
        WHERE Movie_Name LIKE @Name";

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("Name", "%" + Name + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                AddActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadAllMovies()
        {
            string query = "SELECT * FROM Movies";

            try
            {
                SqlCommand command = new SqlCommand(query, con);

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
        private void AddActionButtons()
        {
            if (!dataGridView1.Columns.Contains("Update"))
            {
                DataGridViewButtonColumn updateBtn = new DataGridViewButtonColumn();
                updateBtn.HeaderText = "Update";
                updateBtn.Text = "Update";
                updateBtn.Name = "Update";
                updateBtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(updateBtn);
            }

            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.HeaderText = "Delete";
                deleteBtn.Text = "Delete";
                deleteBtn.Name = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteBtn);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

           
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            var movieIdCell = row.Cells["Movie_ID"]; 

            if (movieIdCell == null || movieIdCell.Value == null)
            {
                MessageBox.Show("Could not find Movie ID");
                return;
            }

            int movieId;
            if (!int.TryParse(movieIdCell.Value.ToString(), out movieId))
            {
                MessageBox.Show("Invalid Movie ID");
                return;
            }

            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
            {
                Update(movieId);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                var result = MessageBox.Show("Are you sure you want to delete this movie?",
                                           "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteMovie(movieId);
                }
            }
        }

        private void Update(int movieId)
        {
            UpdateTheMovie f = new UpdateTheMovie(adid,movieId);
            f.Show();
            this.Close();
        }

        private void DeleteMovie(int movieId)
        {
            string query = "DELETE FROM Movies WHERE Movie_ID = @MovieId";

            try
            {
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@MovieId", movieId);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Movie deleted successfully!");

               
                LoadAllMovies();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    


        private void MovieTxt_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(adid);
            f.Show();
            this.Close();
        }

        private void ShowUsersBtn_Click_1(object sender, EventArgs e)
        {
            LoadAllMovies();
            AddActionButtons(); 
        }

        private void BackBtn_Click_1(object sender, EventArgs e)
        {
            Admin admin = new Admin(adid);
            admin.Show();
            this.Hide();
        }
    }
}