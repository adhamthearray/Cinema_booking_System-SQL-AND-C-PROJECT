using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cinema_booking
{
    partial class Track
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
            this.ShowAllOrdersBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShowLastBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.OrderTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowAllOrdersBtn
            // 
            this.ShowAllOrdersBtn.Location = new System.Drawing.Point(193, 39);
            this.ShowAllOrdersBtn.Name = "ShowAllOrdersBtn";
            this.ShowAllOrdersBtn.Size = new System.Drawing.Size(178, 62);
            this.ShowAllOrdersBtn.TabIndex = 0;
            this.ShowAllOrdersBtn.Text = "Show Orders";
            this.ShowAllOrdersBtn.UseVisualStyleBackColor = true;
            this.ShowAllOrdersBtn.Click += new System.EventHandler(this.ShowAllOrdersBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(145, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(672, 333);
            this.dataGridView1.TabIndex = 1;
            // 
            // ShowLastBtn
            // 
            this.ShowLastBtn.Location = new System.Drawing.Point(599, 12);
            this.ShowLastBtn.Name = "ShowLastBtn";
            this.ShowLastBtn.Size = new System.Drawing.Size(218, 77);
            this.ShowLastBtn.TabIndex = 2;
            this.ShowLastBtn.Text = "Show Last 7 days Orders";
            this.ShowLastBtn.UseVisualStyleBackColor = true;
            this.ShowLastBtn.Click += new System.EventHandler(this.ShowLastBtn_Click_1);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(14, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(155, 29);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back ";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click_1);
            // 
            // OrderTxt
            // 
            this.OrderTxt.Location = new System.Drawing.Point(377, 75);
            this.OrderTxt.Name = "OrderTxt";
            this.OrderTxt.Size = new System.Drawing.Size(216, 26);
            this.OrderTxt.TabIndex = 4;
            // 
            // Track
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.OrderTxt);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ShowLastBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ShowAllOrdersBtn);
            this.Name = "Track";
            this.Text = "Track";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ShowAllOrdersBtn;
        private DataGridView dataGridView1;
        private Button ShowLastBtn;
        private Button BackBtn;
        private TextBox OrderTxt;
    }
}