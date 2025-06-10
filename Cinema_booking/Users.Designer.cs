using System.Drawing;
using System.Windows.Forms;

namespace Cinema_booking
{
    partial class Users
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
            this.ShowUsersBtn = new System.Windows.Forms.Button();
            this.UserTxt = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShowAdminBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ShowMgrBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowUsersBtn
            // 
            this.ShowUsersBtn.Location = new System.Drawing.Point(142, 37);
            this.ShowUsersBtn.Name = "ShowUsersBtn";
            this.ShowUsersBtn.Size = new System.Drawing.Size(106, 51);
            this.ShowUsersBtn.TabIndex = 0;
            this.ShowUsersBtn.Text = "Show Users";
            this.ShowUsersBtn.UseVisualStyleBackColor = true;
            // 
            // UserTxt
            // 
            this.UserTxt.Location = new System.Drawing.Point(266, 61);
            this.UserTxt.Name = "UserTxt";
            this.UserTxt.Size = new System.Drawing.Size(216, 26);
            this.UserTxt.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(142, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(628, 305);
            this.dataGridView1.TabIndex = 6;
            // 
            // ShowAdminBtn
            // 
            this.ShowAdminBtn.Location = new System.Drawing.Point(488, 37);
            this.ShowAdminBtn.Name = "ShowAdminBtn";
            this.ShowAdminBtn.Size = new System.Drawing.Size(130, 52);
            this.ShowAdminBtn.TabIndex = 7;
            this.ShowAdminBtn.Text = "Show Admins";
            this.ShowAdminBtn.UseVisualStyleBackColor = true;
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(14, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(106, 29);
            this.BackBtn.TabIndex = 8;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            // 
            // ShowMgrBtn
            // 
            this.ShowMgrBtn.Location = new System.Drawing.Point(643, 37);
            this.ShowMgrBtn.Name = "ShowMgrBtn";
            this.ShowMgrBtn.Size = new System.Drawing.Size(175, 52);
            this.ShowMgrBtn.TabIndex = 9;
            this.ShowMgrBtn.Text = "Show Managers";
            this.ShowMgrBtn.UseVisualStyleBackColor = true;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.ShowMgrBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ShowAdminBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UserTxt);
            this.Controls.Add(this.ShowUsersBtn);
            this.Name = "Users";
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ShowUsersBtn;
        private TextBox UserTxt;
        private DataGridView dataGridView1;
        private Button ShowAdminBtn;
        private Button BackBtn;
        private Button ShowMgrBtn;
    }
}