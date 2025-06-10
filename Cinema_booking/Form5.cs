using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_booking
{
    public partial class Form5: Form
    {
        public Form5()
        {
            InitializeComponent();
            login f = new login();
            f.Show();
        }
    }
}
