using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using trailer;

namespace Cinema_booking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(8));
            //Application.Run(new Form2(7));
            //Application.Run(new Form3());
            Application.Run(new Form5());
            //form 1 home page
            //form 2 trailer
            //form 3 add a movie (admin)
            //form 4 confirm order
            


        }
    }
}
