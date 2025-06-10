using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_booking
{
    partial class Admin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddAdminBtn = new System.Windows.Forms.Button();
            this.MoviesBtn = new System.Windows.Forms.Button();
            this.UserBtn = new System.Windows.Forms.Button();
            this.TrackOrderBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.AddAdminBtn);
            this.groupBox1.Controls.Add(this.MoviesBtn);
            this.groupBox1.Controls.Add(this.UserBtn);
            this.groupBox1.Controls.Add(this.TrackOrderBtn);
            this.groupBox1.Location = new System.Drawing.Point(244, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 408);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // AddAdminBtn
            // 
            this.AddAdminBtn.ForeColor = System.Drawing.Color.Black;
            this.AddAdminBtn.Location = new System.Drawing.Point(74, 217);
            this.AddAdminBtn.Name = "AddAdminBtn";
            this.AddAdminBtn.Size = new System.Drawing.Size(244, 29);
            this.AddAdminBtn.TabIndex = 3;
            this.AddAdminBtn.Text = "Add New Admin";
            this.AddAdminBtn.UseVisualStyleBackColor = true;
            this.AddAdminBtn.Click += new System.EventHandler(this.AddAdminBtn_Click_1);
            // 
            // MoviesBtn
            // 
            this.MoviesBtn.ForeColor = System.Drawing.Color.Black;
            this.MoviesBtn.Location = new System.Drawing.Point(74, 173);
            this.MoviesBtn.Name = "MoviesBtn";
            this.MoviesBtn.Size = new System.Drawing.Size(244, 29);
            this.MoviesBtn.TabIndex = 2;
            this.MoviesBtn.Text = "Movies";
            this.MoviesBtn.UseVisualStyleBackColor = true;
            this.MoviesBtn.Click += new System.EventHandler(this.MoviesBtn_Click_1);
            // 
            // UserBtn
            // 
            this.UserBtn.ForeColor = System.Drawing.Color.Black;
            this.UserBtn.Location = new System.Drawing.Point(74, 125);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(244, 29);
            this.UserBtn.TabIndex = 1;
            this.UserBtn.Text = "Users";
            this.UserBtn.UseVisualStyleBackColor = true;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click_1);
            // 
            // TrackOrderBtn
            // 
            this.TrackOrderBtn.ForeColor = System.Drawing.Color.Black;
            this.TrackOrderBtn.Location = new System.Drawing.Point(74, 74);
            this.TrackOrderBtn.Name = "TrackOrderBtn";
            this.TrackOrderBtn.Size = new System.Drawing.Size(244, 29);
            this.TrackOrderBtn.TabIndex = 0;
            this.TrackOrderBtn.Text = "Track Orders";
            this.TrackOrderBtn.UseVisualStyleBackColor = true;
            this.TrackOrderBtn.Click += new System.EventHandler(this.TrackOrderBtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Which Data You want To Access";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(744, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "LogOut";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(74, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Track Movies ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button MoviesBtn;
        private Button UserBtn;
        private Button TrackOrderBtn;
        private Button AddAdminBtn;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}