using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cinema_booking
{
    public partial class Form3: Form
    {
        List<string> movieLanguages = new List<string>
        {
            "English",
            "Spanish",
            "French",
            "Italian",
            "German",
            "Mandarin Chinese",
            "Japanese",
            "Russian",
            "Arabic",
            "Hindi"
        };
        List<string> movieGenres = new List<string>
{
    "Action",
    "Adventure",
    "Animation",
    "Comedy",
    "Crime",
    "Documentary",
    "Drama",
    "Family",
    "Fantasy",
    "History",
    "Horror",
    "Musical",
    "Mystery",
    "Romance",
    "Sci-Fi",
    "Sport",
    "Thriller",
    "War",
    "Western",
    "Biography"
};
        List<string> parentalGuides = new List<string>
{
    "G",       
    "PG",      
    "PG-13",   
    "R",       
    "NC-17"    
};
        int admin;
        public Form3(int a_id)
        {
            InitializeComponent();
            admin = a_id;

           
            this.BackColor = ColorTranslator.FromHtml("#201E43");
            groupBox1.BackColor = ColorTranslator.FromHtml("#134B70");
            groupBox1.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
            groupBox1.Text = "ADD A MOVIE";
            this.BackgroundImage = Image.FromFile("C:\\Users\\domma\\Downloads\\sayed.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = ColorTranslator.FromHtml("#EEEEEE");
                }
                else if (ctrl is System.Windows.Forms.TextBox || ctrl is System.Windows.Forms.ComboBox || ctrl is NumericUpDown)
                {
                    ctrl.BackColor = ColorTranslator.FromHtml("#508C9B");
                    ctrl.ForeColor = ColorTranslator.FromHtml("#201E43");
                }
            }

           
            numericUpDown1.Maximum = 10;
            numericUpDown1.Minimum = 1;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            foreach (var genre in movieGenres)
            {
                comboBox1.Items.Add(genre);
            }

            foreach (var guide in parentalGuides)
            {
                comboBox2.Items.Add(guide);
            }

            foreach (var lang in movieLanguages)
            {
                comboBox3.Items.Add(lang);
            }

            // Optional: style the submit button if it exists
            button1.BackColor = ColorTranslator.FromHtml("#508C9B");
            button1.ForeColor = ColorTranslator.FromHtml("#201E43");
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool error_found = false;

            if (string.IsNullOrWhiteSpace(moviename.Text))
            {
                MessageBox.Show("Please enter a movie name");
                error_found = true;
            }
            if (string.IsNullOrWhiteSpace(Duration.Text))
            {
                MessageBox.Show("Please enter duration");
                error_found = true;
            }
            if (string.IsNullOrWhiteSpace(description.Text))
            {
                MessageBox.Show("Please enter description");
                error_found = true;
            }
            if (int.TryParse(Duration.Text, out int numericValue))
            {
                if (numericValue < 0)
                {
                    MessageBox.Show("Duration can't be negative");
                    error_found = true;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid duration");
                error_found = true;
            }

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a genre");
                error_found = true;
            }
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a parental guide");
                error_found = true;
            }
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Please select a language");
                error_found = true;
            }
            if (string.IsNullOrWhiteSpace(date.Text))
            {
                MessageBox.Show("Please enter a release date");
                error_found = true;
            }

            DateTime releaseDate;
            string format = "yyyy-MM-dd";
            if (!DateTime.TryParseExact(date.Text, format,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out releaseDate))
            {
                MessageBox.Show("Please enter date in yyyy-MM-dd format (e.g., 2025-04-30)");
                error_found = true;
            }
            else if (releaseDate > DateTime.Now)
            {
                MessageBox.Show("Release date cannot be in the future");
                error_found = true;
            }

            if (!error_found)
            {
                try
                {
                    string connectionString = "Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertNewMovie", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@MovieName", moviename.Text);
                            cmd.Parameters.AddWithValue("@Duration", int.Parse(Duration.Text));
                            cmd.Parameters.AddWithValue("@Genre", comboBox1.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Rating", numericUpDown1.Value);
                            cmd.Parameters.AddWithValue("@Description", description.Text);
                            cmd.Parameters.AddWithValue("@Parental_Guide", comboBox2.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Release_Date", releaseDate);
                            cmd.Parameters.AddWithValue("@Language", comboBox3.SelectedItem.ToString());

                            
                            
                            con.Open();
                            int newMovieId = Convert.ToInt32(cmd.ExecuteScalar());
                            string query = "INSERT INTO Admin_Movie (Admin_ID, Movie_ID, Process) VALUES (@AdminID, @MovieID, @Process)";
                            SqlCommand cmd1 = new SqlCommand(query, con);

                           
                            cmd1.Parameters.AddWithValue("@AdminID", admin);
                            cmd1.Parameters.AddWithValue("@MovieID", newMovieId);
                            cmd1.Parameters.AddWithValue("@Process", "Added");
                            cmd1.ExecuteNonQuery();

                            MessageBox.Show("Show is added");
                            Admin f = new Admin(admin);
                            f.Show();
                            this.Close();


                           
                            moviename.Text = "";
                            Duration.Text = "";
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;
                            date.Text = "";
                           
                            
                            numericUpDown1.Value = 1;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding movie: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin f = new Admin(admin);
            f.Show();
            this.Close();
        }
    }
}
