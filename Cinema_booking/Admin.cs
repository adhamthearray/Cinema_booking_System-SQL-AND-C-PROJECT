using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Cinema_booking
{
    public partial class Admin : Form
    {
        public int AdminId;
        public Admin(int id)
        {
            this.AdminId = id;
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#201E43");

            // Set colors for all controls
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



        }

        

       

      


       
       

        private void TrackOrderBtn_Click_1(object sender, EventArgs e)
        {
            Track track = new Track(AdminId);
            track.Show();
            this.Hide();
        }

        private void UserBtn_Click_1(object sender, EventArgs e)
        {
            Users users = new Users(AdminId);
            users.Show();
            this.Hide();
        }

        private void MoviesBtn_Click_1(object sender, EventArgs e)
        {
            Movies movies = new Movies(AdminId);
            movies.Show();
            this.Hide();
        }

        private void AddAdminBtn_Click_1(object sender, EventArgs e)
        {
            AddAdmin add = new AddAdmin(AdminId);
            add.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                login f = new login();
                f.Show();
                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(AdminId);
            f.Show();
            this.Close();
        }
    }
}