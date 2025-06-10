using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
namespace trailer
{
    public partial class Form2 : Form
    {
        private Label titleLabel;
        
        private Button closeButton;
        SqlConnection con;
        int movie;
        public Form2(int movie)
        {
            InitializeComponent();
            this.movie = movie;
            con = new SqlConnection("Data Source=LAPTOP-8R3EDGPC\\MSSQLSERVER1;Initial Catalog=cinemabookingsystem;Integrated Security=True");
            InitializeCustomDesign();
            view_trailer();
           
         }

        private void InitializeCustomDesign()
        {
          
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#0A192F");
            this.DoubleBuffered = true;
            this.Width = 900;
            this.Height = 650;

            
            this.Padding = new Padding(5);

           
            closeButton = new Button();
            closeButton.Text = "✕";
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Size = new Size(40, 40);
            closeButton.Location = new Point(this.Width - 45, 5);
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.FromArgb(40, 0, 0, 0);
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            closeButton.Cursor = Cursors.Hand;
            closeButton.Click += (s, e) => this.Close();
            this.Controls.Add(closeButton);

           
            string query1 = "SELECT Movie_Name FROM Movies WHERE Movie_ID = " + movie + ";";
            
            con.Open();
            SqlCommand comm1 = new SqlCommand(query1, con);
            comm1.CommandType = CommandType.Text;
            SqlDataReader read2 = comm1.ExecuteReader();


           
            
            titleLabel = new Label();
            if (read2.Read())
            {
                titleLabel.Text ="🎬 "+ read2["Movie_Name"].ToString();
            }
            read2.Close();
            con.Close();
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Montserrat", 28F, FontStyle.Bold);
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Location = new Point(50, 40);
            this.Controls.Add(titleLabel);

          
            Panel mediaPanel = new Panel();
            mediaPanel.Width = 760;
            mediaPanel.Height = 430;
            mediaPanel.Location = new Point((this.ClientSize.Width - mediaPanel.Width) / 2, 110);
            mediaPanel.BackColor = Color.FromArgb(10, 15, 30);
            mediaPanel.Paint += (s, e) => {
                using (GraphicsPath path = RoundedRectangle(new Rectangle(0, 0, mediaPanel.Width, mediaPanel.Height), 15))
                using (Pen pen = new Pen(Color.FromArgb(100, 111, 255), 2))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            };
            this.Controls.Add(mediaPanel);

           
           
            axWindowsMediaPlayer1.CreateControl();
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.Width = 740;
            axWindowsMediaPlayer1.Height = 410;
            axWindowsMediaPlayer1.Location = new Point(10, 10);
            axWindowsMediaPlayer1.BackColor = Color.Black;
            mediaPanel.Controls.Add(axWindowsMediaPlayer1);

           
            Label footerLabel = new Label();
            string query3 = "SELECT Description FROM Movies WHERE Movie_ID = " + movie + ";";
            string query4 = "SELECT Member_Name FROM [Movie&Cast] JOIN [Cast] ON [Movie&Cast].Member_ID = [Cast].Member_ID WHERE Movie_ID = " + movie + ";";

            con.Open();

          
            SqlCommand comm3 = new SqlCommand(query3, con);
            SqlDataReader read3 = comm3.ExecuteReader();

            if (read3.Read())
            {
                footerLabel.Text = read3["Description"].ToString();
            }
            read3.Close(); 

           
            SqlCommand comm4 = new SqlCommand(query4, con);
            SqlDataReader read4 = comm4.ExecuteReader();

            bool firstCast = true;
            while (read4.Read())
            {
                if (firstCast)
                {
                    footerLabel.Text += "\nStarring:";
                    firstCast = false;
                }
                footerLabel.Text += " " + read4["Member_Name"].ToString();
            }
            read4.Close();
            con.Close();


            footerLabel.ForeColor = Color.FromArgb(180, 180, 210);
            footerLabel.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            footerLabel.AutoSize = true;
            footerLabel.BackColor = Color.Transparent;
            footerLabel.Location = new Point((this.ClientSize.Width - 300) / 2, this.ClientSize.Height - 50);
            this.Controls.Add(footerLabel);

           
            this.Paint += Form6_Paint;

           
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessage(this.Handle, 0xA1, 0x2, 0);
                }
            };
        }
        private void view_trailer()
        {
            
            string query1 = "SELECT Trailer FROM Movies WHERE Movie_ID = " + movie + ";";
            con.Open();
            SqlCommand comm = new SqlCommand(query1, con);
            comm.CommandType = CommandType.Text;
            SqlDataReader read1 = comm.ExecuteReader();

            string videoPath = "";
           
            if (read1.Read())
            {
                videoPath = read1["Trailer"].ToString();
            }
            else
            {
                
                MessageBox.Show("No trailer found for this movie.");
            }

           
            read1.Close();
            con.Close();

            
            if (!string.IsNullOrEmpty(videoPath))
            {
                axWindowsMediaPlayer1.URL = videoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

          
            Rectangle gradientRectangle = new Rectangle(0, 0, this.Width, this.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(gradientRectangle,
                    ColorTranslator.FromHtml("#0A192F"), ColorTranslator.FromHtml("#112240"),
                    LinearGradientMode.ForwardDiagonal))
            {
                ColorBlend blend = new ColorBlend(3);
                blend.Colors = new Color[] {
                    ColorTranslator.FromHtml("#0A192F"),
                    ColorTranslator.FromHtml("#112240"),
                    ColorTranslator.FromHtml("#1D3461")
                };
                blend.Positions = new float[] { 0f, 0.5f, 1f };
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, gradientRectangle);
            }

           
            int size = 200;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(-50, -50, size, size);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(40, 0, 106, 167);
                    brush.SurroundColors = new Color[] { Color.FromArgb(0, 0, 11, 58) };
                    g.FillPath(brush, path);
                }
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(this.Width - 150, this.Height - 150, 250, 250);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(40, 0, 106, 167);
                    brush.SurroundColors = new Color[] { Color.FromArgb(0, 0, 11, 58) };
                    g.FillPath(brush, path);
                }
            }

          
            Random random = new Random(5); 
            using (SolidBrush starBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
            {
                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(0, this.Width);
                    int y = random.Next(0, this.Height);
                    int starSize = random.Next(1, 4);
                    g.FillEllipse(starBrush, x, y, starSize, starSize);
                }
            }
        }

        
        private GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

          
            path.AddArc(arc, 180, 90);

           
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

           
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

           
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }

   
    internal static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}