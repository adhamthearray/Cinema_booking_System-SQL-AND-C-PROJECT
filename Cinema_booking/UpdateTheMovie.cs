using Cinema_booking;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cinema_booking
{
    public partial class UpdateTheMovie : Form
    {
        public int adid;
        public int movieId;
        SqlConnection con;

        public UpdateTheMovie(int aId, int mId)
        {
            InitializeComponent();
            movieId = mId;
            adid = aId;
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True;");

            LoadMovieData();

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

            
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                
            }
            else if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void LoadMovieData()
        {
            string query = "SELECT Movie_Name, Duration, Rating, Description, Parental_Guide, Language, trailer, Poster FROM Movies WHERE Movie_ID = @movieId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MovieNameInfo.Text = reader["Movie_Name"].ToString();
                            DurationInfo.Text = reader["Duration"].ToString();
                            RatingInfo.Text = reader["Rating"].ToString();
                            DescInfo.Text = reader["Description"].ToString();
                            GuideInfo.Text = reader["Parental_Guide"].ToString();
                            LanguageInfo.Text = reader["Language"].ToString();
                            TrailerInfo.Text = reader["Trailer"].ToString();
                            PosterInfo.Text = reader["Poster"].ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

           
            MovieNameTxt.Text = MovieNameInfo.Text;
            DurationTxt.Text = DurationInfo.Text;
            RatingTxt.Text = RatingInfo.Text;
            DescTxt.Text = DescInfo.Text;
            GuideTxt.Text = GuideInfo.Text;
            LanguageTxt.Text = LanguageInfo.Text;
            TrailerTxt.Text = TrailerInfo.Text;
            PosterTxt.Text = PosterInfo.Text;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateBtnBtn_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Movies 
                             SET Movie_Name = @name,
                                 Duration = @Duration,
                                 Rating = @rate,
                                 Description = @Desc,
                                 Parental_Guide = @Guide,
                                 Language = @Language,
                                 Poster = @Post,
                                 Trailer = @Trailer
                             WHERE movie_id = @movieId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", MovieNameTxt.Text);
                cmd.Parameters.AddWithValue("@Duration", DurationTxt.Text);
                cmd.Parameters.AddWithValue("@rate", RatingTxt.Text);
                cmd.Parameters.AddWithValue("@Desc", DescTxt.Text);
                cmd.Parameters.AddWithValue("@Guide", GuideTxt.Text);
                cmd.Parameters.AddWithValue("@Language", LanguageTxt.Text);
                cmd.Parameters.AddWithValue("@Post", PosterTxt.Text);
                cmd.Parameters.AddWithValue("@Trailer", TrailerTxt.Text);
                cmd.Parameters.AddWithValue("@movieId", movieId);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string query1 = "INSERT INTO Admin_Movie (Admin_ID, Movie_ID, Process) VALUES (@AdminID, @MovieID, @Process)";
                    SqlCommand cmd1 = new SqlCommand(query1, con);

                   
                    cmd1.Parameters.AddWithValue("@AdminID", adid);
                    cmd1.Parameters.AddWithValue("@MovieID", movieId);
                    cmd1.Parameters.AddWithValue("@Process", "Updated");
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Movie data updated successfully!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

           
            MovieNameInfo.Text = MovieNameTxt.Text;
            DurationInfo.Text = DurationTxt.Text;
            RatingInfo.Text = RatingTxt.Text;
            DescInfo.Text = DescTxt.Text;
            GuideInfo.Text = GuideTxt.Text;
            LanguageInfo.Text = LanguageTxt.Text;
            TrailerInfo.Text = TrailerTxt.Text;
            PosterInfo.Text = PosterTxt.Text;
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(adid);
            admin.Show();
            this.Hide();
        }
    }
}