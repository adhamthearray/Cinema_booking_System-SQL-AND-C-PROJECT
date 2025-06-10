using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_booking
{
    partial class login
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
            this.label1 = new System.Windows.Forms.Label();
            this.EmailLogin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SignUPLink = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(225, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome Back To CinePulse";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmailLogin
            // 
            this.EmailLogin.Location = new System.Drawing.Point(46, 108);
            this.EmailLogin.Name = "EmailLogin";
            this.EmailLogin.Size = new System.Drawing.Size(270, 39);
            this.EmailLogin.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.SignUPLink);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PasswordLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EmailLogin);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(281, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 413);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LoginBtn.ForeColor = System.Drawing.Color.White;
            this.LoginBtn.Location = new System.Drawing.Point(401, 508);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(135, 54);
            this.LoginBtn.TabIndex = 7;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            // 
            // SignUPLink
            // 
            this.SignUPLink.AutoSize = true;
            this.SignUPLink.Location = new System.Drawing.Point(132, 331);
            this.SignUPLink.Name = "SignUPLink";
            this.SignUPLink.Size = new System.Drawing.Size(98, 32);
            this.SignUPLink.TabIndex = 6;
            this.SignUPLink.TabStop = true;
            this.SignUPLink.Text = "Sign Up";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Don\'t have an account?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter Password:";
            // 
            // PasswordLogin
            // 
            this.PasswordLogin.Location = new System.Drawing.Point(56, 216);
            this.PasswordLogin.Name = "PasswordLogin";
            this.PasswordLogin.Size = new System.Drawing.Size(270, 39);
            this.PasswordLogin.TabIndex = 3;
            this.PasswordLogin.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Email:";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 597);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// /////////////////////////////////////
        /// </summary>
        #endregion

        private Label label1;
        private TextBox EmailLogin;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private TextBox PasswordLogin;
        private LinkLabel SignUPLink;
        private Label label5;
        private Button LoginBtn;
    }
}