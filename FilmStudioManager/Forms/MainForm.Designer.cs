namespace BookcrossingApp.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.borrowedButton = new System.Windows.Forms.Button();
            this.myBooksButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.welcomeLabel2 = new System.Windows.Forms.Label();
            this.welcomeLabel1 = new System.Windows.Forms.Label();
            this.HomeDataGridViewMainPanel = new System.Windows.Forms.Panel();
            this.HomeDataGridView = new System.Windows.Forms.DataGridView();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.deleteBookButton = new System.Windows.Forms.Button();
            this.returnBookButton = new System.Windows.Forms.Button();
            this.borrowBookButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.HomeDataGridViewMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).BeginInit();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.borrowedButton);
            this.panel1.Controls.Add(this.myBooksButton);
            this.panel1.Controls.Add(this.homeButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 638);
            this.panel1.TabIndex = 0;
            // 
            // logoutButton
            // 
            this.logoutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoutButton.Enabled = false;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoutButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.logoutButton.Image = ((System.Drawing.Image)(resources.GetObject("logoutButton.Image")));
            this.logoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutButton.Location = new System.Drawing.Point(0, 310);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.logoutButton.Size = new System.Drawing.Size(316, 50);
            this.logoutButton.TabIndex = 12;
            this.logoutButton.Text = "         Вийти                                ";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // borrowedButton
            // 
            this.borrowedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.borrowedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borrowedButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.borrowedButton.FlatAppearance.BorderSize = 0;
            this.borrowedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borrowedButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.borrowedButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.borrowedButton.Image = ((System.Drawing.Image)(resources.GetObject("borrowedButton.Image")));
            this.borrowedButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.borrowedButton.Location = new System.Drawing.Point(0, 260);
            this.borrowedButton.Name = "borrowedButton";
            this.borrowedButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.borrowedButton.Size = new System.Drawing.Size(316, 50);
            this.borrowedButton.TabIndex = 9;
            this.borrowedButton.Text = "Позичені                ";
            this.borrowedButton.UseVisualStyleBackColor = true;
            this.borrowedButton.Click += new System.EventHandler(this.borrowedButton_Click);
            // 
            // myBooksButton
            // 
            this.myBooksButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.myBooksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.myBooksButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.myBooksButton.FlatAppearance.BorderSize = 0;
            this.myBooksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myBooksButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.myBooksButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.myBooksButton.Image = ((System.Drawing.Image)(resources.GetObject("myBooksButton.Image")));
            this.myBooksButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myBooksButton.Location = new System.Drawing.Point(0, 210);
            this.myBooksButton.Name = "myBooksButton";
            this.myBooksButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.myBooksButton.Size = new System.Drawing.Size(316, 50);
            this.myBooksButton.TabIndex = 8;
            this.myBooksButton.Text = "Мої Книги              ";
            this.myBooksButton.UseVisualStyleBackColor = true;
            this.myBooksButton.Click += new System.EventHandler(this.myBooksButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.homeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.homeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.homeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.homeButton.Image = ((System.Drawing.Image)(resources.GetObject("homeButton.Image")));
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Location = new System.Drawing.Point(0, 160);
            this.homeButton.Name = "homeButton";
            this.homeButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.homeButton.Size = new System.Drawing.Size(316, 50);
            this.homeButton.TabIndex = 7;
            this.homeButton.Text = "Головна                  ";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 160);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(89, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.welcomeLabel2);
            this.panel3.Controls.Add(this.welcomeLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(316, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1091, 94);
            this.panel3.TabIndex = 1;
            // 
            // welcomeLabel2
            // 
            this.welcomeLabel2.AutoSize = true;
            this.welcomeLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel2.Location = new System.Drawing.Point(41, 55);
            this.welcomeLabel2.Name = "welcomeLabel2";
            this.welcomeLabel2.Size = new System.Drawing.Size(530, 19);
            this.welcomeLabel2.TabIndex = 1;
            this.welcomeLabel2.Text = "Explore the latest books available for borrowing or add your own books to share.";
            // 
            // welcomeLabel1
            // 
            this.welcomeLabel1.AutoSize = true;
            this.welcomeLabel1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcomeLabel1.Location = new System.Drawing.Point(40, 17);
            this.welcomeLabel1.Name = "welcomeLabel1";
            this.welcomeLabel1.Size = new System.Drawing.Size(118, 29);
            this.welcomeLabel1.TabIndex = 0;
            this.welcomeLabel1.Text = "Welcome, ";
            // 
            // HomeDataGridViewMainPanel
            // 
            this.HomeDataGridViewMainPanel.BackColor = System.Drawing.Color.Transparent;
            this.HomeDataGridViewMainPanel.Controls.Add(this.HomeDataGridView);
            this.HomeDataGridViewMainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HomeDataGridViewMainPanel.Location = new System.Drawing.Point(316, 166);
            this.HomeDataGridViewMainPanel.Name = "HomeDataGridViewMainPanel";
            this.HomeDataGridViewMainPanel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.HomeDataGridViewMainPanel.Size = new System.Drawing.Size(1091, 472);
            this.HomeDataGridViewMainPanel.TabIndex = 5;
            // 
            // HomeDataGridView
            // 
            this.HomeDataGridView.AllowUserToAddRows = false;
            this.HomeDataGridView.AllowUserToDeleteRows = false;
            this.HomeDataGridView.AllowUserToResizeColumns = false;
            this.HomeDataGridView.AllowUserToResizeRows = false;
            this.HomeDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.HomeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HomeDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HomeDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HomeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.HomeDataGridView.ColumnHeadersHeight = 45;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HomeDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.HomeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomeDataGridView.EnableHeadersVisualStyles = false;
            this.HomeDataGridView.GridColor = System.Drawing.Color.LightGray;
            this.HomeDataGridView.Location = new System.Drawing.Point(0, 10);
            this.HomeDataGridView.MultiSelect = false;
            this.HomeDataGridView.Name = "HomeDataGridView";
            this.HomeDataGridView.ReadOnly = true;
            this.HomeDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            this.HomeDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.HomeDataGridView.RowTemplate.DividerHeight = 2;
            this.HomeDataGridView.RowTemplate.Height = 45;
            this.HomeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HomeDataGridView.Size = new System.Drawing.Size(1091, 462);
            this.HomeDataGridView.TabIndex = 2;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.refreshButton);
            this.controlPanel.Controls.Add(this.deleteBookButton);
            this.controlPanel.Controls.Add(this.returnBookButton);
            this.controlPanel.Controls.Add(this.borrowBookButton);
            this.controlPanel.Controls.Add(this.addBookButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Location = new System.Drawing.Point(316, 94);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(1091, 72);
            this.controlPanel.TabIndex = 6;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.refreshButton.Location = new System.Drawing.Point(45, 17);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(38, 38);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // deleteBookButton
            // 
            this.deleteBookButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.deleteBookButton.FlatAppearance.BorderSize = 0;
            this.deleteBookButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteBookButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.deleteBookButton.Location = new System.Drawing.Point(463, 17);
            this.deleteBookButton.Name = "deleteBookButton";
            this.deleteBookButton.Size = new System.Drawing.Size(180, 38);
            this.deleteBookButton.TabIndex = 4;
            this.deleteBookButton.Text = "Видалити";
            this.deleteBookButton.UseVisualStyleBackColor = false;
            this.deleteBookButton.Click += new System.EventHandler(this.deleteBookButton_Click);
            // 
            // returnBookButton
            // 
            this.returnBookButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.returnBookButton.FlatAppearance.BorderSize = 0;
            this.returnBookButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.returnBookButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.returnBookButton.Location = new System.Drawing.Point(277, 17);
            this.returnBookButton.Name = "returnBookButton";
            this.returnBookButton.Size = new System.Drawing.Size(180, 38);
            this.returnBookButton.TabIndex = 3;
            this.returnBookButton.Text = "Повернути";
            this.returnBookButton.UseVisualStyleBackColor = false;
            this.returnBookButton.Click += new System.EventHandler(this.returnBookButton_Click);
            // 
            // borrowBookButton
            // 
            this.borrowBookButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.borrowBookButton.Enabled = false;
            this.borrowBookButton.FlatAppearance.BorderSize = 0;
            this.borrowBookButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.borrowBookButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.borrowBookButton.Location = new System.Drawing.Point(91, 17);
            this.borrowBookButton.Name = "borrowBookButton";
            this.borrowBookButton.Size = new System.Drawing.Size(180, 38);
            this.borrowBookButton.TabIndex = 2;
            this.borrowBookButton.Text = "Позичити";
            this.borrowBookButton.UseVisualStyleBackColor = false;
            this.borrowBookButton.Click += new System.EventHandler(this.borrowBookButton_Click);
            // 
            // addBookButton
            // 
            this.addBookButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.addBookButton.Enabled = false;
            this.addBookButton.FlatAppearance.BorderSize = 0;
            this.addBookButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addBookButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.addBookButton.Location = new System.Drawing.Point(868, 17);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(180, 38);
            this.addBookButton.TabIndex = 1;
            this.addBookButton.Text = "Додати Книгу";
            this.addBookButton.UseVisualStyleBackColor = false;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1407, 638);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.HomeDataGridViewMainPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.HomeDataGridViewMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HomeDataGridView)).EndInit();
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button borrowedButton;
        private System.Windows.Forms.Button myBooksButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label welcomeLabel1;
        private System.Windows.Forms.Label welcomeLabel2;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel HomeDataGridViewMainPanel;
        private System.Windows.Forms.DataGridView HomeDataGridView;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button borrowBookButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button deleteBookButton;
        private System.Windows.Forms.Button returnBookButton;
        private System.Windows.Forms.Button refreshButton;
    }
}