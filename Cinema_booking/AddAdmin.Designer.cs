using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_booking
{
    partial class AddAdmin
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
            groupBox1 = new GroupBox();
            FirstNameTxtt = new TextBox();
            AgeTxt = new NumericUpDown();
            PasswordTxt = new TextBox();
            label7 = new Label();
            EmailTxt = new TextBox();
            label6 = new Label();
            label5 = new Label();
            PhoneNumberTxt = new TextBox();
            label4 = new Label();
            LastNameTxt = new TextBox();
            label3 = new Label();
            FirstNameTxt = new Label();
            SignUpBtn = new Button();
            RstBtn = new Button();
            BackBtn = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AgeTxt).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FirstNameTxtt);
            groupBox1.Controls.Add(AgeTxt);
            groupBox1.Controls.Add(PasswordTxt);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(EmailTxt);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(PhoneNumberTxt);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(LastNameTxt);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(FirstNameTxt);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(208, 65);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(384, 320);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Your Account";
            // 
            // FirstNameTxtt
            // 
            FirstNameTxtt.Font = new Font("Segoe UI", 10F);
            FirstNameTxtt.Location = new Point(142, 38);
            FirstNameTxtt.Margin = new Padding(2);
            FirstNameTxtt.Name = "FirstNameTxtt";
            FirstNameTxtt.Size = new Size(185, 30);
            FirstNameTxtt.TabIndex = 0;
            // 
            // AgeTxt
            // 
            AgeTxt.Font = new Font("Segoe UI", 10F);
            AgeTxt.Location = new Point(136, 144);
            AgeTxt.Margin = new Padding(2);
            AgeTxt.Name = "AgeTxt";
            AgeTxt.Size = new Size(190, 30);
            AgeTxt.TabIndex = 3;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Font = new Font("Segoe UI", 10F);
            PasswordTxt.Location = new Point(136, 216);
            PasswordTxt.Margin = new Padding(2);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(190, 30);
            PasswordTxt.TabIndex = 5;
            PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 215);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(97, 28);
            label7.TabIndex = 10;
            label7.Text = "Password:";
            // 
            // EmailTxt
            // 
            EmailTxt.Font = new Font("Segoe UI", 10F);
            EmailTxt.Location = new Point(136, 180);
            EmailTxt.Margin = new Padding(2);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(191, 30);
            EmailTxt.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 179);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(63, 28);
            label6.TabIndex = 9;
            label6.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 143);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(51, 28);
            label5.TabIndex = 8;
            label5.Text = "Age:";
            // 
            // PhoneNumberTxt
            // 
            PhoneNumberTxt.Font = new Font("Segoe UI", 10F);
            PhoneNumberTxt.Location = new Point(139, 106);
            PhoneNumberTxt.Margin = new Padding(2);
            PhoneNumberTxt.Name = "PhoneNumberTxt";
            PhoneNumberTxt.Size = new Size(188, 30);
            PhoneNumberTxt.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 110);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(131, 23);
            label4.TabIndex = 7;
            label4.Text = "Phone Number:";
            // 
            // LastNameTxt
            // 
            LastNameTxt.Font = new Font("Segoe UI", 10F);
            LastNameTxt.Location = new Point(141, 72);
            LastNameTxt.Margin = new Padding(2);
            LastNameTxt.Name = "LastNameTxt";
            LastNameTxt.Size = new Size(185, 30);
            LastNameTxt.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 71);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(107, 28);
            label3.TabIndex = 6;
            label3.Text = "Last Name:";
            // 
            // FirstNameTxt
            // 
            FirstNameTxt.AutoSize = true;
            FirstNameTxt.Location = new Point(31, 35);
            FirstNameTxt.Margin = new Padding(2, 0, 2, 0);
            FirstNameTxt.Name = "FirstNameTxt";
            FirstNameTxt.Size = new Size(110, 28);
            FirstNameTxt.TabIndex = 11;
            FirstNameTxt.Text = "First Name:";
            // 
            // SignUpBtn
            // 
            SignUpBtn.BackColor = Color.DarkSlateBlue;
            SignUpBtn.FlatStyle = FlatStyle.Flat;
            SignUpBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            SignUpBtn.ForeColor = Color.White;
            SignUpBtn.Location = new Point(480, 389);
            SignUpBtn.Margin = new Padding(2);
            SignUpBtn.Name = "SignUpBtn";
            SignUpBtn.Size = new Size(112, 36);
            SignUpBtn.TabIndex = 8;
            SignUpBtn.Text = "ADD";
            SignUpBtn.UseVisualStyleBackColor = false;
            // 
            // RstBtn
            // 
            RstBtn.BackColor = Color.LightGray;
            RstBtn.FlatStyle = FlatStyle.Flat;
            RstBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            RstBtn.ForeColor = Color.Black;
            RstBtn.Location = new Point(380, 389);
            RstBtn.Margin = new Padding(2);
            RstBtn.Name = "RstBtn";
            RstBtn.Size = new Size(96, 36);
            RstBtn.TabIndex = 9;
            RstBtn.Text = "Reset";
            RstBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            BackBtn.BackColor = Color.DarkSlateBlue;
            BackBtn.FlatStyle = FlatStyle.Flat;
            BackBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BackBtn.ForeColor = Color.White;
            BackBtn.Location = new Point(11, 11);
            BackBtn.Margin = new Padding(2);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new Size(112, 36);
            BackBtn.TabIndex = 10;
            BackBtn.Text = "Back";
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += BackBtn_Click;
            // 
            // AddAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackBtn);
            Controls.Add(SignUpBtn);
            Controls.Add(RstBtn);
            Controls.Add(groupBox1);
            Name = "AddAdmin";
            Text = "AddAdmin";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AgeTxt).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
        private Button BackBtn;
    }
}