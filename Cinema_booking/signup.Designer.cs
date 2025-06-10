using System.Drawing;
using System.Windows.Forms;

namespace Cinema_booking
{
    partial class signup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FirstNameTxtt = new System.Windows.Forms.TextBox();
            this.AgeTxt = new System.Windows.Forms.NumericUpDown();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PhoneNumberTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstNameTxt = new System.Windows.Forms.Label();
            this.SignUpBtn = new System.Windows.Forms.Button();
            this.RstBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgeTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(165, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to CinePulse";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FirstNameTxtt);
            this.groupBox1.Controls.Add(this.AgeTxt);
            this.groupBox1.Controls.Add(this.PasswordTxt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.EmailTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PhoneNumberTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LastNameTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FirstNameTxt);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(158, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(582, 380);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Your Account";
            // 
            // FirstNameTxtt
            // 
            this.FirstNameTxtt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FirstNameTxtt.Location = new System.Drawing.Point(183, 36);
            this.FirstNameTxtt.Margin = new System.Windows.Forms.Padding(2);
            this.FirstNameTxtt.Name = "FirstNameTxtt";
            this.FirstNameTxtt.Size = new System.Drawing.Size(208, 34);
            this.FirstNameTxtt.TabIndex = 0;
            // 
            // AgeTxt
            // 
            this.AgeTxt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.AgeTxt.Location = new System.Drawing.Point(177, 196);
            this.AgeTxt.Margin = new System.Windows.Forms.Padding(2);
            this.AgeTxt.Name = "AgeTxt";
            this.AgeTxt.Size = new System.Drawing.Size(214, 34);
            this.AgeTxt.TabIndex = 3;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PasswordTxt.Location = new System.Drawing.Point(177, 314);
            this.PasswordTxt.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(213, 34);
            this.PasswordTxt.TabIndex = 5;
            this.PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 314);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 32);
            this.label7.TabIndex = 10;
            this.label7.Text = "Password:";
            // 
            // EmailTxt
            // 
            this.EmailTxt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.EmailTxt.Location = new System.Drawing.Point(176, 255);
            this.EmailTxt.Margin = new System.Windows.Forms.Padding(2);
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.Size = new System.Drawing.Size(214, 34);
            this.EmailTxt.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 255);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Age:";
            // 
            // PhoneNumberTxt
            // 
            this.PhoneNumberTxt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PhoneNumberTxt.Location = new System.Drawing.Point(180, 131);
            this.PhoneNumberTxt.Margin = new System.Windows.Forms.Padding(2);
            this.PhoneNumberTxt.Name = "PhoneNumberTxt";
            this.PhoneNumberTxt.Size = new System.Drawing.Size(211, 34);
            this.PhoneNumberTxt.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phone Number:";
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LastNameTxt.Location = new System.Drawing.Point(182, 89);
            this.LastNameTxt.Margin = new System.Windows.Forms.Padding(2);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.Size = new System.Drawing.Size(208, 34);
            this.LastNameTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Name:";
            // 
            // FirstNameTxt
            // 
            this.FirstNameTxt.AutoSize = true;
            this.FirstNameTxt.Location = new System.Drawing.Point(36, 36);
            this.FirstNameTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.Size = new System.Drawing.Size(134, 32);
            this.FirstNameTxt.TabIndex = 11;
            this.FirstNameTxt.Text = "First Name:";
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.SignUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.SignUpBtn.ForeColor = System.Drawing.Color.White;
            this.SignUpBtn.Location = new System.Drawing.Point(518, 475);
            this.SignUpBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Size = new System.Drawing.Size(126, 51);
            this.SignUpBtn.TabIndex = 6;
            this.SignUpBtn.Text = "Sign Up";
            this.SignUpBtn.UseVisualStyleBackColor = false;
            // 
            // RstBtn
            // 
            this.RstBtn.BackColor = System.Drawing.Color.LightGray;
            this.RstBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RstBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.RstBtn.ForeColor = System.Drawing.Color.Black;
            this.RstBtn.Location = new System.Drawing.Point(347, 482);
            this.RstBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RstBtn.Name = "RstBtn";
            this.RstBtn.Size = new System.Drawing.Size(108, 44);
            this.RstBtn.TabIndex = 7;
            this.RstBtn.Text = "Reset";
            this.RstBtn.UseVisualStyleBackColor = false;
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 568);
            this.Controls.Add(this.SignUpBtn);
            this.Controls.Add(this.RstBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CinePulse - Sign Up";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgeTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox FirstNameTxtt;
        private NumericUpDown AgeTxt;
        private TextBox PasswordTxt;
        private Label label7;
        private TextBox EmailTxt;
        private Label label6;
        private Label label5;
        private TextBox PhoneNumberTxt;
        private Label label4;
        private TextBox LastNameTxt;
        private Label label3;
        private Label FirstNameTxt;
        private Button SignUpBtn;
        private Button RstBtn;
    }
}