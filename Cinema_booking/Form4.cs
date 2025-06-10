using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema_booking
{
    public partial class Form4 : Form
    {
        private FlowLayoutPanel seatPanel;
        private FlowLayoutPanel snackPanel;
        private Button btnCheckout;
        private SqlConnection con;
        int showID;
        int user;
        private Dictionary<string, NumericUpDown> snackQuantities = new Dictionary<string, NumericUpDown>();
        private List<CheckBox> seatCheckBoxes = new List<CheckBox>();

        private Color bgColor = ColorTranslator.FromHtml("#201E43");
        private Color buttonColor = ColorTranslator.FromHtml("#508C9B");
        private Color textColor = ColorTranslator.FromHtml("#EEEEEE");
        private Color elementColor = ColorTranslator.FromHtml("#134B70");

        public Form4(int user_n,int show)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = bgColor;
            showID = show;
            user = user_n;
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True");
            InitializeBookingUI();
        }

        private void ShowCustomMessageBox(string message, string title = "Message")
        {
            Form msgBox = new Form()
            {
                Size = new Size(400, 200),
                BackColor = bgColor,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title
            };

            Label label = new Label()
            {
                Text = message,
                ForeColor = textColor,
                BackColor = bgColor,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button ok = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                BackColor = buttonColor,
                ForeColor = textColor,
                Width = 100,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            ok.Click += (s, e) => msgBox.Close();
            ok.Anchor = AnchorStyles.Bottom;
            ok.Location = new Point((msgBox.ClientSize.Width - ok.Width) / 2, msgBox.ClientSize.Height - 70);
            msgBox.Controls.Add(label);
            msgBox.Controls.Add(ok);
            msgBox.AcceptButton = ok;
            msgBox.ShowDialog();
        }

        private void InitializeBookingUI()
        {
            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 2,
                BackColor = bgColor
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // Seats
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // Snacks
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); // Info panel
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            this.Controls.Add(mainLayout);

            seatPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = elementColor,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            mainLayout.Controls.Add(seatPanel, 0, 0);
            var infoPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = elementColor,
                AutoScroll = true
            };
            mainLayout.Controls.Add(infoPanel, 2, 0);
            LoadShowInfo(infoPanel);


            snackPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = elementColor,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.TopDown
            };
            mainLayout.Controls.Add(snackPanel, 1, 0);

            btnCheckout = new Button
            {
                Text = "Checkout",
                Size = new Size(120, 40),
                BackColor = buttonColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Anchor = AnchorStyles.None
            };
            btnCheckout.Click += BtnCheckout_Click;

            var checkoutPanel = new Panel { Dock = DockStyle.Fill, BackColor = bgColor };
            checkoutPanel.Controls.Add(btnCheckout);
            btnCheckout.Location = new Point((checkoutPanel.Width - btnCheckout.Width) / 2, (checkoutPanel.Height - btnCheckout.Height) / 2);
            mainLayout.Controls.Add(checkoutPanel, 0, 1);
            mainLayout.SetColumnSpan(checkoutPanel, 3);

            LoadSeats();
            LoadSnacks();
        }

        private void LoadSeats()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Seat_Number FROM Ticket WHERE Show_ID_fk = @showId AND Order_ID_fk IS NULL", con);
                cmd.Parameters.AddWithValue("@showId",showID);
                SqlDataReader reader = cmd.ExecuteReader();

                seatPanel.Controls.Clear();
                seatCheckBoxes.Clear();
                int count = 0;
                FlowLayoutPanel row = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };

                while (reader.Read())
                {
                    string seatNum = reader["Seat_Number"].ToString();
                    int seatNumberInt = int.Parse(seatNum);
                    string formatted = seatNumberInt < 10 ? $"Seat 0{seatNumberInt}" : $"Seat {seatNumberInt}";

                    CheckBox cb = new CheckBox
                    {
                        Text = formatted,
                        ForeColor = textColor,
                        BackColor = elementColor,
                        Font = new Font("Segoe UI", 14),
                        AutoSize = true,
                        Tag = seatNum
                    };
                    seatCheckBoxes.Add(cb);
                    row.Controls.Add(cb);
                    count++;

                    if (count % 3 == 0)
                    {
                        seatPanel.Controls.Add(row);
                        row = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
                    }
                }
                if (row.Controls.Count > 0)
                    seatPanel.Controls.Add(row);

                reader.Close();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Error loading seats: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void LoadShowInfo(Panel infoPanel)
        {
            try
            {
                con.Open();
                string query = @"
           SELECT 
    m.Movie_Name,
    m.Poster,
    sh.Start_Time,
    s.Screen_Number,
    ts.Screen_Type,
    cb.Cinema_Name,
    cb.Cinema_Location
FROM Shows sh
JOIN Movies m ON sh.Movie_ID_fk = m.Movie_ID
JOIN Screens s ON sh.Screen_ID_fk = s.Screen_ID
JOIN Types_of_Screen ts ON s.Screen_Type_fk = ts.Screen_Type
JOIN Cinema_Branch cb ON s.Cinema_Name_fk = cb.Cinema_Name 
                    AND s.Cinema_Locaction_fk = cb.Cinema_Location
WHERE sh.Show_ID =@showId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@showId", showID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var layout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 1,
                        RowCount = 7,
                        BackColor = elementColor
                    };
                    infoPanel.Controls.Add(layout);

                  
                    PictureBox poster = new PictureBox
                    {
                        Size = new Size(200, 300),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.White,
                        Margin = new Padding(10),
                        Anchor = AnchorStyles.Top
                    };
                   
                     poster.Image = Image.FromFile(reader["Poster"].ToString());
                    layout.Controls.Add(poster);

                    AddInfoLabel(layout, $"Movie: {reader["Movie_Name"]}", 20);
                    AddInfoLabel(layout, $"Time: {reader["Start_Time"]}", 16);
                    AddInfoLabel(layout, $"Screen: {reader["Screen_Number"]}", 16);
                    AddInfoLabel(layout, $"Type: {reader["Screen_Type"]}", 16);
                    AddInfoLabel(layout, $"Cinema: {reader["Cinema_Name"]}", 16);
                    AddInfoLabel(layout, $"Location: {reader["Cinema_Location"]}", 16);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Error loading show info: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddInfoLabel(TableLayoutPanel panel, string text, int fontSize)
        {
            Label label = new Label
            {
                Text = text,
                ForeColor = textColor,
                Font = new Font("Segoe UI", fontSize),
                AutoSize = true,
                Margin = new Padding(10, 5, 10, 5),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel.Controls.Add(label);
        }
        private void LoadSnacks()
        {
            try
            {
                con.Open();
                string query = @"
                    SELECT DISTINCT Snack_Name, available_quantity
                    FROM CinemaBranch_Snack 
                    WHERE Cinema_Name IN (
                        SELECT cb.Cinema_Name 
                        FROM Cinema_Branch cb
                        JOIN Screens s ON cb.Cinema_Name = s.Cinema_Name_fk AND cb.Cinema_Location = s.Cinema_Locaction_fk
                        JOIN Shows sh ON s.Screen_ID = sh.Screen_ID_fk
                        WHERE sh.Show_ID = @showId
                    )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@showId", showID);
                SqlDataReader reader = cmd.ExecuteReader();

                snackPanel.Controls.Clear();
                snackQuantities.Clear();

                while (reader.Read())
                {
                    string snackName = reader["Snack_Name"].ToString();
                    int quant = Convert.ToInt32(reader["available_quantity"]);

                    Label label = new Label
                    {
                        Text = snackName,
                        ForeColor = textColor,
                        Font = new Font("Segoe UI", 14, FontStyle.Bold),
                        AutoSize = true,
                        Margin = new Padding(5)
                    };

                    NumericUpDown quantity = new NumericUpDown
                    {
                        Minimum = 0,
                        Maximum = quant,
                        Width = 60,
                        Margin = new Padding(5)
                    };
                    snackQuantities[snackName] = quantity;

                    FlowLayoutPanel snackRow = new FlowLayoutPanel
                    {
                        Width = 400,
                        Height = 50,
                        BackColor = elementColor,
                        FlowDirection = FlowDirection.LeftToRight,
                        Margin = new Padding(5)
                    };
                    snackRow.Controls.Add(label);
                    snackRow.Controls.Add(quantity);
                    snackPanel.Controls.Add(snackRow);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Error loading snacks: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            List<string> selectedSeats = new List<string>();
            foreach (var cb in seatCheckBoxes)
                if (cb.Checked)
                    selectedSeats.Add(cb.Tag.ToString());

            if (selectedSeats.Count == 0)
            {
                ShowCustomMessageBox("Please select at least one seat.");
                return;
            }

            string paymentMethod = ShowPaymentOptions();
            if (!string.IsNullOrEmpty(paymentMethod))
            {
                decimal totalPrice = CalculateTotalPrice(selectedSeats);
                var selectedSnacks = new Dictionary<string, int>();
                foreach (var snack in snackQuantities)
                {
                    if (snack.Value.Value > 0)
                        selectedSnacks[snack.Key] = (int)snack.Value.Value;
                }

                CompleteCheckout(selectedSeats, selectedSnacks, paymentMethod);
                ShowCustomMessageBox($"Checkout complete. Total price: {totalPrice:C} using {paymentMethod}.", "Confirmation");
                Form1 F = new Form1(user);
                F.Show();
                this.Close();
                LoadSeats();
                LoadSnacks();
            }
        }

        private decimal CalculateTotalPrice(List<string> selectedSeats)
        {
            decimal totalSeatPrice = 0;
            decimal totalSnackPrice = 0;

            try
            {
                con.Open();

                SqlCommand baseCmd = new SqlCommand(@"
                    SELECT cb.Base_Price 
                    FROM Shows sh
                    JOIN Screens s ON sh.Screen_ID_fk = s.Screen_ID
                    JOIN Cinema_Branch cb ON cb.Cinema_Name = s.Cinema_Name_fk 
                                          AND cb.Cinema_Location = s.Cinema_Locaction_fk
                    WHERE sh.Show_ID = @showId", con);
                baseCmd.Parameters.AddWithValue("@showId", showID);
                decimal basePrice = 0;
                using (SqlDataReader reader = baseCmd.ExecuteReader())
                {
                    if (reader.Read())
                        basePrice = Convert.ToDecimal(reader["Base_Price"]);
                }

                SqlCommand factorCmd = new SqlCommand(@"
                    SELECT ts.Seat_Factor 
                    FROM Shows sh
                    JOIN Screens s ON sh.Screen_ID_fk = s.Screen_ID
                    JOIN Types_of_Screen ts ON s.Screen_Type_fk = ts.Screen_Type
                    WHERE sh.Show_ID = @showId", con);
                factorCmd.Parameters.AddWithValue("@showId", showID);
                decimal seatFactor = 1;
                using (SqlDataReader reader = factorCmd.ExecuteReader())
                {
                    if (reader.Read())
                        seatFactor = Convert.ToDecimal(reader["Seat_Factor"]);
                }

                totalSeatPrice = basePrice * seatFactor * selectedSeats.Count;

                foreach (var snack in snackQuantities)
                {
                    if (snack.Value.Value > 0)
                    {
                        SqlCommand snackCmd = new SqlCommand("SELECT Price FROM Snack WHERE Snack_Name = @snackName", con);
                        snackCmd.Parameters.AddWithValue("@snackName", snack.Key);
                        object result = snackCmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                            totalSnackPrice += Convert.ToDecimal(result) * snack.Value.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Error calculating total price: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return totalSeatPrice + totalSnackPrice;
        }

        private string ShowPaymentOptions()
        {
            string[] methods = { "Cash", "PayPal", "Credit Card", "Debit Card" };
            using (Form dialog = new Form())
            {
                dialog.Text = "Payment Options";
                dialog.Size = new Size(300, 250);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.BackColor = bgColor;

                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    BackColor = bgColor
                };

                foreach (var method in methods)
                {
                    RadioButton radioButton = new RadioButton
                    {
                        Text = method,
                        ForeColor = textColor,
                        BackColor = bgColor,
                        Font = new Font("Segoe UI", 12),
                        AutoSize = true
                    };
                    flowPanel.Controls.Add(radioButton);
                }

                dialog.Controls.Add(flowPanel);

                Button ok = new Button
                {
                    Text = "OK",
                    Dock = DockStyle.Bottom,
                    BackColor = buttonColor,
                    ForeColor = textColor
                };
                ok.Click += (s, e) => dialog.DialogResult = DialogResult.OK;
                dialog.Controls.Add(ok);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (RadioButton rb in flowPanel.Controls)
                        if (rb.Checked)
                            return rb.Text;
                }
            }

            return "";
        }

        private void CompleteCheckout(List<string> selectedSeats, Dictionary<string, int> selectedSnacks, string paymentMethod)
        {
            try
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                int newOrderId = 1;
                SqlCommand getLastId = new SqlCommand("SELECT ISNULL(MAX(Order_Id), 0) + 1 FROM Orders", con, transaction);
                newOrderId = (int)getLastId.ExecuteScalar();

                SqlCommand insertOrderCmd = new SqlCommand("INSERT INTO Orders (Order_Id, Date, payment_method, User_Id_fk) VALUES (@orderId, @date, @method, @userId)", con, transaction);
                insertOrderCmd.Parameters.AddWithValue("@orderId", newOrderId);
                insertOrderCmd.Parameters.AddWithValue("@date", DateTime.Now);
                insertOrderCmd.Parameters.AddWithValue("@method", paymentMethod);
                insertOrderCmd.Parameters.AddWithValue("@userId", user);
                insertOrderCmd.ExecuteNonQuery();

                foreach (string seat in selectedSeats)
                {
                    SqlCommand updateTicketCmd = new SqlCommand("UPDATE Ticket SET Order_ID_fk = @orderId WHERE Show_ID_fk = @showId AND Seat_Number = @seatNum", con, transaction);
                    updateTicketCmd.Parameters.AddWithValue("@orderId", newOrderId);
                    updateTicketCmd.Parameters.AddWithValue("@showId", showID);
                    updateTicketCmd.Parameters.AddWithValue("@seatNum", seat);
                    updateTicketCmd.ExecuteNonQuery();
                }

                foreach (var snack in selectedSnacks)
                {
                    SqlCommand updateSnackQty = new SqlCommand(@"
                        UPDATE CinemaBranch_Snack
                        SET available_quantity = available_quantity - @qty
                        WHERE Snack_Name = @snackName AND Cinema_Name IN (
                            SELECT cb.Cinema_Name 
                            FROM Cinema_Branch cb
                            JOIN Screens s ON cb.Cinema_Name = s.Cinema_Name_fk AND cb.Cinema_Location = s.Cinema_Locaction_fk
                            JOIN Shows sh ON s.Screen_ID = sh.Screen_ID_fk
                            WHERE sh.Show_ID = @showId
                        )", con, transaction);
                    updateSnackQty.Parameters.AddWithValue("@qty", snack.Value);
                    updateSnackQty.Parameters.AddWithValue("@snackName", snack.Key);
                    updateSnackQty.Parameters.AddWithValue("@showId", showID);
                    updateSnackQty.ExecuteNonQuery();

                    SqlCommand insertHasSnack = new SqlCommand("INSERT INTO Has_a_snack (Order_Id, Snack_Name, quantity) VALUES (@orderId, @snackName, @qty)", con, transaction);
                    insertHasSnack.Parameters.AddWithValue("@orderId", newOrderId);
                    insertHasSnack.Parameters.AddWithValue("@snackName", snack.Key);
                    insertHasSnack.Parameters.AddWithValue("@qty", snack.Value);
                    insertHasSnack.ExecuteNonQuery();
                }

                transaction.Commit();
                ShowCustomMessageBox("Booking successfully completed!", "Success");
               
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Checkout failed: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}