using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_booking
{
    partial class Movies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MovieTxt = new System.Windows.Forms.TextBox();
            this.ShowUsersBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(6, 10);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(106, 29);
            this.BackBtn.TabIndex = 14;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(799, 305);
            this.dataGridView1.TabIndex = 12;
            // 
            // MovieTxt
            // 
            this.MovieTxt.Location = new System.Drawing.Point(270, 57);
            this.MovieTxt.Name = "MovieTxt";
            this.MovieTxt.Size = new System.Drawing.Size(383, 26);
            this.MovieTxt.TabIndex = 11;
            // 
            // ShowUsersBtn
            // 
            this.ShowUsersBtn.Location = new System.Drawing.Point(66, 45);
            this.ShowUsersBtn.Name = "ShowUsersBtn";
            this.ShowUsersBtn.Size = new System.Drawing.Size(180, 41);
            this.ShowUsersBtn.TabIndex = 10;
            this.ShowUsersBtn.Text = "Show Movies";
            this.ShowUsersBtn.UseVisualStyleBackColor = true;
            this.ShowUsersBtn.Click += new System.EventHandler(this.ShowUsersBtn_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 50);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add A Movie";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Movies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MovieTxt);
            this.Controls.Add(this.ShowUsersBtn);
            this.Name = "Movies";
            this.Text = "Movies";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button BackBtn;
        private DataGridView dataGridView1;
        private TextBox MovieTxt;
        private Button ShowUsersBtn;
        private Button button1;
    }
}