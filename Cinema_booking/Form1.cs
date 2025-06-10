using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using trailer;

namespace Cinema_booking
{
    public partial class Form1 : Form
    {
        private Label welcomeLabel;
        private Panel pnlPastOrders;
        private FlowLayoutPanel flowMovies;
        private bool isPastOrdersPanelVisible = false;
        SqlConnection con;
        int user;

        
        private Panel panelProfile;
        private Button btnEditProfile;
        private TextBox txtName, txtPassword, txtEmail, txtAge, txtLastName, txtPhone;

        public Form1(int id)
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True");
            user = id;
            this.MinimumSize = new Size(800, 600);
            this.AutoScroll = true;

            CreateUI();
        }

        private void CreateUI()
        {
            this.BackgroundImage = Image.FromFile(@"C:\Users\domma\Downloads\sebs.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

           
            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(0x20, 0x1E, 0x43),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(header);

            
            Label lblTitle = new Label
            {
                Text = "CinePulse 💓 (the heartbeat of movie lovers)",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            header.Controls.Add(lblTitle);

            
            welcomeLabel = new Label
            {
                Text = "There's beauty there. What happens up on that screen means something.",
                Font = new Font("Georgia", 22, FontStyle.Bold | FontStyle.Italic),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(30, 30, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(700, 120),
                BorderStyle = BorderStyle.None,
                Padding = new Padding(10),
                Location = new Point((this.ClientSize.Width - 700) / 2, (this.ClientSize.Height - 120) / 2)
            };

            Label shadowLabel = new Label
            {
                Text = welcomeLabel.Text,
                Font = welcomeLabel.Font,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = welcomeLabel.TextAlign,
                AutoSize = false,
                Size = welcomeLabel.Size,
                BorderStyle = BorderStyle.None,
                Location = new Point(welcomeLabel.Location.X + 4, welcomeLabel.Location.Y + 4)
            };

            this.Controls.Add(shadowLabel);
            this.Controls.Add(welcomeLabel);

            
            PictureBox pbOrders = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(header.Width - 150, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Image = Image.FromFile(@"C:\Users\domma\Downloads\order-icon-5.jpg")
            };
            pbOrders.Click += (s, e) =>
            {
                isPastOrdersPanelVisible = !isPastOrdersPanelVisible;
                pnlPastOrders.Visible = isPastOrdersPanelVisible;
                panelProfile.Visible = false;
            };
            header.Controls.Add(pbOrders);

           
            PictureBox pbProfile = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(header.Width - 80, 15),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand,
                Image = Image.FromFile("C:\\Users\\domma\\Downloads\\white-profile-icon-png-7.png")
            };
            pbProfile.Click += (s, e) =>
            {
                LoadProfileData();
                pnlPastOrders.Visible = false;
                isPastOrdersPanelVisible = false;
            };
            header.Controls.Add(pbProfile);

           
            Panel dropPanel = new Panel
            {
                Dock = DockStyle.None,
                Height = 70,
                Width = this.ClientSize.Width,
                BackColor = Color.FromArgb(0x50, 0x8C, 0x9B),
                Location = new Point(0, header.Height)
            };
            this.Controls.Add(dropPanel);
            Label lblLogout = new Label
            {
                Text = "Log out",
                ForeColor = Color.White,  
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(header.Width - 220, 25),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            lblLogout.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    login f = new login();
                    f.Show();
                    this.Close();
                    
                }
            };
            header.Controls.Add(lblLogout);
           
            flowMovies = new FlowLayoutPanel
            {
                Dock = DockStyle.None,
                Location = new Point(0, dropPanel.Bottom),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - dropPanel.Bottom),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(20),
                BackColor = Color.Transparent
            };
            this.Controls.Add(flowMovies);

           
            InitializeProfilePanel();

            
            InitializePastOrdersPanel();

           
            Label lblLocation = new Label
            {
                Text = "Choose Location:",
                Location = new Point(100, 5),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            dropPanel.Controls.Add(lblLocation);

            ComboBox cboLocation = new ComboBox
            {
                Location = new Point(100, 30),
                Size = new Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cboLocation"
            };
            dropPanel.Controls.Add(cboLocation);

            
            Label lblCinema = new Label
            {
                Text = "Choose Cinema:",
                Location = new Point(300, 5),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            dropPanel.Controls.Add(lblCinema);

            ComboBox cbocinema = new ComboBox
            {
                Location = new Point(300, 30),
                Size = new Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "cbocinema"
            };
            dropPanel.Controls.Add(cbocinema);

            // Load locations
            string query = "select distinct Cinema_Location from Cinema_Branch";
            con.Open();
            SqlCommand comm = new SqlCommand(query, con);
            comm.CommandType = CommandType.Text;
            SqlDataReader read = comm.ExecuteReader();
            while (read.Read())
            {
                cboLocation.Items.Add(read["Cinema_Location"].ToString());
            }
            read.Close();
            con.Close();

            cboLocation.SelectedIndexChanged += (s, e) =>
            {
                cbocinema.Items.Clear();
                string query1 = "select distinct Cinema_Name from Cinema_Branch where Cinema_Location ='" + cboLocation.Text.ToString() + "';";
                con.Open();
                SqlCommand comm1 = new SqlCommand(query1, con);
                comm.CommandType = CommandType.Text;
                SqlDataReader read1 = comm1.ExecuteReader();
                while (read1.Read())
                {
                    cbocinema.Items.Add(read1["Cinema_Name"].ToString());
                }
                read1.Close();
                con.Close();
            };

           
            Button btnSearch = new Button
            {
                Text = "Search 🎬",
                Location = new Point(550, 25),
                Size = new Size(100, 28),
                BackColor = Color.FromArgb(0x13, 0x4B, 0x70),
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) =>
            {
                if (cboLocation.SelectedItem == null || cbocinema.SelectedItem == null)
                {
                    MessageBox.Show("Please select both Location and Cinema!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                welcomeLabel.Visible = false;
                shadowLabel.Visible = false;
                flowMovies.Controls.Clear();

                string selectedCinema = cbocinema.SelectedItem.ToString();
                string selectedLocation = cboLocation.SelectedItem.ToString();

                string query10 = @"SELECT DISTINCT Movie_ID, Movie_Name, Duration, Rating, Parental_Guide, Poster, Genre, Description
                    FROM Movies 
                    JOIN Shows ON Movie_ID = Movie_ID_fk
                    JOIN Screens ON Screen_ID_fk = Screen_ID
                    WHERE Cinema_Name_fk = @CinemaName
                    AND Cinema_Locaction_fk = @CinemaLocation
                    AND Date_Of_Show >= GETDATE()";

                con.Open();
                SqlCommand cmd = new SqlCommand(query10, con);
                cmd.Parameters.AddWithValue("@CinemaName", selectedCinema);
                cmd.Parameters.AddWithValue("@CinemaLocation", selectedLocation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string movieName = reader["Movie_Name"].ToString();
                    string duration = reader["Duration"].ToString() + " min";
                    string rating = reader["Rating"].ToString();
                    string parentalGuide = reader["Parental_Guide"].ToString();
                    string posterPath = reader["Poster"].ToString();

                    Image poster = Image.FromFile(posterPath);
                    AddMovieItem(movieName, duration, rating, parentalGuide, poster, selectedCinema, selectedLocation);
                }

                reader.Close();
                con.Close();

                if (flowMovies.Controls.Count == 0)
                {
                    MessageBox.Show($"No movies currently showing at {selectedCinema} in {selectedLocation}",
                                   "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            dropPanel.Controls.Add(btnSearch);

            // Resize event
            this.Resize += (s, e) =>
            {
                flowMovies.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - dropPanel.Bottom);
                dropPanel.Width = this.ClientSize.Width;
                pnlPastOrders.Height = this.ClientSize.Height - 70;
                pnlPastOrders.Location = new Point(this.ClientSize.Width - 350, 70);
                pbOrders.Location = new Point(header.Width - 150, 15);
                pbProfile.Location = new Point(header.Width - 80, 15);
                welcomeLabel.Location = new Point((this.ClientSize.Width - welcomeLabel.Width) / 2, (this.ClientSize.Height - welcomeLabel.Height) / 2);
                shadowLabel.Location = new Point(welcomeLabel.Location.X + 4, welcomeLabel.Location.Y + 4);

                foreach (Control control in pnlPastOrders.Controls)
                {
                    if (control is Label label && label.Text.StartsWith("ord:"))
                    {
                        label.Location = new Point(pnlPastOrders.Width - 190, label.Location.Y);
                    }
                }
            };
        }

        private void InitializeProfilePanel()
        {
            panelProfile = new Panel
            {
                Name = "panelProfile",
                Size = new Size(320, this.Height - 70),
                Location = new Point(this.Width - 340, 70),
                Visible = false,
                BackColor = ColorTranslator.FromHtml("#134B70"),
                Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom
            };
            this.Controls.Add(panelProfile);
            panelProfile.BringToFront();

            int y = 20;
            int spacing = 30;

            txtName = CreateProfileField("First Name:", y); y += spacing;
            txtLastName = CreateProfileField("Last Name:", y); y += spacing;
            txtPassword = CreateProfileField("Password:", y); y += spacing;
            (txtPhone = CreateProfileField("Phone:", y)).ReadOnly = false; y += spacing;
            (txtEmail = CreateProfileField("Email:", y)).ReadOnly = true; y += spacing;
            (txtAge = CreateProfileField("Age:", y)).ReadOnly = true; y += spacing;

            btnEditProfile = new Button
            {
                Text = "Edit",
                Location = new Point(100, y),
                Size = new Size(80, 30),
                BackColor = ColorTranslator.FromHtml("#508C9B"),
                ForeColor = ColorTranslator.FromHtml("#EEEEEE")
            };
            btnEditProfile.Click += btnEditProfile_Click;
            panelProfile.Controls.Add(btnEditProfile);
        }

        private TextBox CreateProfileField(string label, int y)
        {
            Label lbl = new Label
            {
                Text = label,
                Location = new Point(10, y + 3),
                Size = new Size(90, 20),
                ForeColor = ColorTranslator.FromHtml("#EEEEEE")
            };
            panelProfile.Controls.Add(lbl);

            TextBox txt = new TextBox
            {
                Location = new Point(110, y),
                Size = new Size(180, 22),
                BackColor = ColorTranslator.FromHtml("#201E43"),
                ForeColor = ColorTranslator.FromHtml("#EEEEEE")
            };
            panelProfile.Controls.Add(txt);
            return txt;
        }

        private void LoadProfileData()
        {
            panelProfile.Visible = !panelProfile.Visible;
            if (!panelProfile.Visible) return;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT User_ID, First_Name, Last_Name, Age, Phone_Number, Email, Password FROM end_user WHERE User_ID = " + user + ";", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtName.Text = reader["First_Name"].ToString();
                    txtLastName.Text = reader["Last_Name"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                    txtPhone.Text = reader["Phone_Number"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtAge.Text = reader["Age"].ToString();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Name and Phone number cannot be empty.");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.");
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE end_user SET First_Name = @name, Password = @pass, Phone_Number = @phone WHERE User_ID = @id", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@id", user);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Profile updated successfully!");
                }
                else
                {
                    MessageBox.Show("No record updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void InitializePastOrdersPanel()
        {
            pnlPastOrders = new Panel
            {
                Size = new Size(350, 400),
                Location = new Point(this.ClientSize.Width - 350, 70),
                BackColor = Color.FromArgb(0x20, 0x1E, 0x43),
                Visible = false,
                Padding = new Padding(15, 50, 15, 15)
            };
            pnlPastOrders.AutoScroll = true;
            this.Controls.Add(pnlPastOrders);
            pnlPastOrders.BringToFront();

            Label titleLabel = new Label
            {
                Text = "Past Orders",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            pnlPastOrders.Controls.Add(titleLabel);

            Button btnClose = new Button
            {
                Text = "×",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Size = new Size(30, 30),
                Location = new Point(pnlPastOrders.Width - 45, 10),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) =>
            {
                pnlPastOrders.Visible = false;
                isPastOrdersPanelVisible = false;
            };
            pnlPastOrders.Controls.Add(btnClose);

            LoadPastOrders();
        }

        private void LoadPastOrders()
        {
            string query3 = "exec dbo.GetUserOrdersWithDetails @UserID= " + user;
            con.Open();
            SqlCommand comm3 = new SqlCommand(query3, con);
            comm3.CommandType = CommandType.Text;
            SqlDataReader read3 = comm3.ExecuteReader();

            int currentY = 60;
            while (read3.Read())
            {
                string Order_id = read3["Order_ID"].ToString();
                string Sho4_ID = read3["hamada"].ToString();
                string orderDate = read3["Date"].ToString();
                string payment = read3["Payment_Method"].ToString();
                string m_name = read3["Movie_Name"].ToString();
                string showTime = read3["Start_Time"].ToString();
                string seatNumber = read3["Seat_Number"].ToString();
                string screenNumber = read3["Screen_Number"].ToString();
                string cinemaName = read3["Cinema_Name"].ToString();
                string cinemaLocation = read3["Cinema_Location"].ToString();

                AddOrderItem(Order_id, Sho4_ID, orderDate, payment, m_name, showTime, seatNumber,
                    screenNumber, cinemaName, cinemaLocation, currentY);
                currentY += 125;
            }
            read3.Close();
            con.Close();
        }

        private void AddMovieItem(string movieName, string duration, string rating, string parentalGuide, Image poster, String c_name, String c_loc)
        {
            Panel moviePanel = new Panel
            {
                Size = new Size(250, 400),
                BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pbPoster = new PictureBox
            {
                Size = new Size(230, 250),
                Location = new Point(10, 10),
                Image = poster,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            moviePanel.Controls.Add(pbPoster);

            Label lblName = new Label
            {
                Text = movieName,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 270),
                AutoSize = true,
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            moviePanel.Controls.Add(lblName);

            Label lblRating = new Label
            {
                Text = $"Rating: {rating}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 300),
                AutoSize = true,
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            moviePanel.Controls.Add(lblRating);

            Label lblDuration = new Label
            {
                Text = $"Duration: {duration}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 325),
                AutoSize = true,
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            moviePanel.Controls.Add(lblDuration);

            Label lblGuide = new Label
            {
                Text = $"ShowTimes:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 350),
                AutoSize = true,
                ForeColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };
            moviePanel.Controls.Add(lblGuide);

            ComboBox cboShowtimes = new ComboBox
            {
                Location = new Point(10, 375),
                Size = new Size(200, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9),
                DropDownWidth = 300
            };

            try
            {
                using (SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True"))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetMovieShowtimes", con1))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CinemaName", c_name);
                    cmd.Parameters.AddWithValue("@CinemaLocation", c_loc);
                    cmd.Parameters.AddWithValue("@MovieName", movieName);

                    con1.Open();

                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            cboShowtimes.Items.Add($"Time: {read["Start_Time"]} | Date: {Convert.ToDateTime(read["Date_Of_Show"]).ToString("MMM dd, yyyy")} | Screen: {read["Screen_Type"]} |                                               {read["Show_ID"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading showtimes: " + ex.Message);
            }

            moviePanel.Controls.Add(cboShowtimes);

            Button btnDetails = new Button
            {
                Text = "Trailer",
                Location = new Point(133, 340),
                Size = new Size(50, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0x50, 0x8C, 0x9B),
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE)
            };
            btnDetails.Click += (s, e) => {
                string query1 = "SELECT Movie_ID FROM Movies WHERE Movie_Name='" + movieName + "';";
                con.Open();
                SqlCommand comm = new SqlCommand(query1, con);
                comm.CommandType = CommandType.Text;
                SqlDataReader read1 = comm.ExecuteReader();

                if (read1.Read())
                {
                    Form2 f = new Form2((int)read1["Movie_ID"]);
                    f.Show();
                }
                read1.Close();
                con.Close();
            };
            moviePanel.Controls.Add(btnDetails);

            Button btnBook = new Button
            {
                Text = "Book",
                Location = new Point(190, 340),
                Size = new Size(50, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0x13, 0x4B, 0x70),
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE)
            };
            btnBook.Click += (s, e) => {
                if (cboShowtimes.SelectedItem == null)
                {
                    MessageBox.Show("Choose a ShowTime");
                    return;
                }
                string selectedItem = cboShowtimes.SelectedItem.ToString();
                string[] parts = selectedItem.Split('|');
                Form4 f=new Form4(user, int.Parse(parts[3]));
                //MessageBox.Show(parts[3]);
                f.Show();
                this.Close();
            };
            moviePanel.Controls.Add(btnBook);

            flowMovies.Controls.Add(moviePanel);
        }

        private void AddOrderItem(string order_id, string Sho_ID, string orderDate, string paymentMethod, string movieName,
              string showTime, string seatNumber, string screenNumber,
              string cinemaName, string cinemaLocation,
              int yPos)
        {
            Panel titlePanel = new Panel
            {
                Size = new Size(pnlPastOrders.Width - 30, 35),
                Location = new Point(15, yPos),
                BackColor = Color.FromArgb(0x13, 0x4B, 0x70),
                BorderStyle = BorderStyle.None
            };

            Label lblMovieName = new Label
            {
                Text = movieName,
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 5)
            };
            titlePanel.Controls.Add(lblMovieName);

            Label lblPayment = new Label
            {
                Text = $"Payment: {paymentMethod}",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(titlePanel.Width - 150, 10)
            };

         
            float ticketPrice = 0;
            int numOfTickets = 0;
            int snacks = 0;

            try
            {
                using (SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True"))
                {
                    con1.Open();
                    SqlCommand priceCmd = new SqlCommand("CalculateTicketPrice", con1);


                    priceCmd.CommandType = CommandType.StoredProcedure;

                    // Input parameter
                    priceCmd.Parameters.AddWithValue("@Show_ID",Sho_ID);

                    SqlParameter priceParam = new SqlParameter("@TicketPrice", SqlDbType.Float);
                    priceParam.Direction = ParameterDirection.Output;
                    priceCmd.Parameters.Add(priceParam);

                    // Execute the procedure
                    priceCmd.ExecuteNonQuery();

                    // Get the output value
                    
                        ticketPrice = Convert.ToSingle(priceParam.Value);
                    
                    con1.Close();
                }

                using (SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True"))
                {
                    con2.Open();
                    SqlCommand countCmd = new SqlCommand("SELECT COUNT(*) AS Ticket_Count FROM Ticket WHERE Order_ID_fk = @OrderID", con2);
                    countCmd.Parameters.AddWithValue("@OrderID", order_id);
                    numOfTickets = Convert.ToInt32(countCmd.ExecuteScalar());
                    con2.Close();
                }

                using (SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True"))
                {
                    con3.Open();
                    SqlCommand snackCmd = new SqlCommand(
                        "select Snack.Snack_Name,Price,Quantity,Order_ID from Has_a_snack join Snack on Has_a_snack.Snack_Name=Snack.Snack_Name where Order_ID=" + order_id, con3);

                    using (SqlDataReader snackReader = snackCmd.ExecuteReader())
                    {
                        while (snackReader.Read())
                        {
                            snacks += (int)(snackReader["Price"]) * (int)(snackReader)["Quantity"];
                        }
                    }
                    con3.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating order total: {ex.Message}");
            }

            Label lblPrice = new Label
            {
                Text = "Total:   " + (numOfTickets * ticketPrice + snacks).ToString("C"),
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(titlePanel.Width - 250, 10)
            };

            titlePanel.Controls.Add(lblPrice);
            titlePanel.Controls.Add(lblPayment);

            Panel separatorLine = new Panel
            {
                Size = new Size(titlePanel.Width, 1),
                Location = new Point(0, titlePanel.Height - 1),
                BackColor = Color.FromArgb(0x50, 0x8C, 0x9B)
            };
            titlePanel.Controls.Add(separatorLine);

            pnlPastOrders.Controls.Add(titlePanel);

            Panel detailsPanel = new Panel
            {
                Size = new Size(titlePanel.Width, 95),
                Location = new Point(titlePanel.Left, titlePanel.Bottom),
                BackColor = Color.FromArgb(0x20, 0x1E, 0x43)
            };

            Label lblTime = new Label
            {
                Text = $"Time: {showTime}",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            detailsPanel.Controls.Add(lblTime);

            Label lblCinema = new Label
            {
                Text = $"{cinemaName}, {cinemaLocation}",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                Location = new Point(10, 35)
            };
            detailsPanel.Controls.Add(lblCinema);

            Label lblScreenSeat = new Label
            {
                Text = $"Screen {screenNumber} - Seat {seatNumber}",
                ForeColor = Color.FromArgb(0xEE, 0xEE, 0xEE),
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                Location = new Point(10, 60)
            };
            detailsPanel.Controls.Add(lblScreenSeat);

            Label lblOrderid = new Label
            {
                Text = $"order id: {order_id}",
                ForeColor = Color.FromArgb(0x50, 0x8C, 0x9B),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                AutoSize = true,
                Location = new Point(detailsPanel.Width - 150, 60)
            };
            detailsPanel.Controls.Add(lblOrderid);

            pnlPastOrders.Controls.Add(detailsPanel);
        }
    }
}