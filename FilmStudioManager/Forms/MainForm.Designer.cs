namespace FilmStudioManager.Forms
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            panel1 = new Panel();
            logoutButton = new Button();
            activeProjectsButton = new Button();
            workersButton = new Button();
            projectsButton = new Button();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            welcomeLabel2 = new Label();
            welcomeLabel = new Label();
            HomeDataGridViewMainPanel = new Panel();
            mainDataGridView = new DataGridView();
            controlPanel = new Panel();
            refreshButton = new Button();
            deleteButton = new Button();
            editButton = new Button();
            addButton = new Button();
            assignButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            HomeDataGridViewMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).BeginInit();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(logoutButton);
            panel1.Controls.Add(activeProjectsButton);
            panel1.Controls.Add(workersButton);
            panel1.Controls.Add(projectsButton);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(421, 982);
            panel1.TabIndex = 0;
            // 
            // logoutButton
            // 
            logoutButton.BackgroundImageLayout = ImageLayout.Center;
            logoutButton.Cursor = Cursors.Hand;
            logoutButton.Dock = DockStyle.Top;
            logoutButton.Enabled = false;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            logoutButton.ForeColor = Color.WhiteSmoke;
            logoutButton.Image = (Image)resources.GetObject("logoutButton.Image");
            logoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            logoutButton.Location = new Point(0, 477);
            logoutButton.Margin = new Padding(4, 5, 4, 5);
            logoutButton.Name = "logoutButton";
            logoutButton.Padding = new Padding(27, 0, 0, 0);
            logoutButton.Size = new Size(421, 77);
            logoutButton.TabIndex = 12;
            logoutButton.Text = "         Вийти                                ";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // activeProjectsButton
            // 
            activeProjectsButton.BackgroundImageLayout = ImageLayout.Center;
            activeProjectsButton.Cursor = Cursors.Hand;
            activeProjectsButton.Dock = DockStyle.Top;
            activeProjectsButton.FlatAppearance.BorderSize = 0;
            activeProjectsButton.FlatStyle = FlatStyle.Flat;
            activeProjectsButton.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            activeProjectsButton.ForeColor = Color.WhiteSmoke;
            activeProjectsButton.Image = (Image)resources.GetObject("activeProjectsButton.Image");
            activeProjectsButton.ImageAlign = ContentAlignment.MiddleLeft;
            activeProjectsButton.Location = new Point(0, 400);
            activeProjectsButton.Margin = new Padding(4, 5, 4, 5);
            activeProjectsButton.Name = "activeProjectsButton";
            activeProjectsButton.Padding = new Padding(27, 0, 0, 0);
            activeProjectsButton.Size = new Size(421, 77);
            activeProjectsButton.TabIndex = 9;
            activeProjectsButton.Text = "Активні Проекти   ";
            activeProjectsButton.UseVisualStyleBackColor = true;
            activeProjectsButton.Click += activeProjectsButton_Click;
            // 
            // workersButton
            // 
            workersButton.BackgroundImageLayout = ImageLayout.Center;
            workersButton.Cursor = Cursors.Hand;
            workersButton.Dock = DockStyle.Top;
            workersButton.FlatAppearance.BorderSize = 0;
            workersButton.FlatStyle = FlatStyle.Flat;
            workersButton.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            workersButton.ForeColor = Color.WhiteSmoke;
            workersButton.Image = (Image)resources.GetObject("workersButton.Image");
            workersButton.ImageAlign = ContentAlignment.MiddleLeft;
            workersButton.Location = new Point(0, 323);
            workersButton.Margin = new Padding(4, 5, 4, 5);
            workersButton.Name = "workersButton";
            workersButton.Padding = new Padding(27, 0, 0, 0);
            workersButton.Size = new Size(421, 77);
            workersButton.TabIndex = 8;
            workersButton.Text = "Працівники            ";
            workersButton.UseVisualStyleBackColor = true;
            workersButton.Click += workersButton_Click;
            // 
            // projectsButton
            // 
            projectsButton.BackColor = Color.DarkSlateBlue;
            projectsButton.BackgroundImageLayout = ImageLayout.Center;
            projectsButton.Cursor = Cursors.Hand;
            projectsButton.Dock = DockStyle.Top;
            projectsButton.FlatAppearance.BorderSize = 0;
            projectsButton.FlatStyle = FlatStyle.Flat;
            projectsButton.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            projectsButton.ForeColor = Color.WhiteSmoke;
            projectsButton.Image = (Image)resources.GetObject("projectsButton.Image");
            projectsButton.ImageAlign = ContentAlignment.MiddleLeft;
            projectsButton.Location = new Point(0, 246);
            projectsButton.Margin = new Padding(4, 5, 4, 5);
            projectsButton.Name = "projectsButton";
            projectsButton.Padding = new Padding(27, 0, 0, 0);
            projectsButton.Size = new Size(421, 77);
            projectsButton.TabIndex = 7;
            projectsButton.Text = "Всі Проекти            ";
            projectsButton.UseVisualStyleBackColor = false;
            projectsButton.Click += projectsButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(421, 246);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(119, 18);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(welcomeLabel2);
            panel3.Controls.Add(welcomeLabel);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(421, 0);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1455, 145);
            panel3.TabIndex = 1;
            // 
            // welcomeLabel2
            // 
            welcomeLabel2.AutoSize = true;
            welcomeLabel2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            welcomeLabel2.Location = new Point(55, 85);
            welcomeLabel2.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel2.Name = "welcomeLabel2";
            welcomeLabel2.Size = new Size(307, 24);
            welcomeLabel2.TabIndex = 1;
            welcomeLabel2.Text = "Керування проектами фільм-студії";
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            welcomeLabel.Location = new Point(53, 26);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(133, 37);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Вітаємо, ";
            // 
            // HomeDataGridViewMainPanel
            // 
            HomeDataGridViewMainPanel.BackColor = Color.Transparent;
            HomeDataGridViewMainPanel.Controls.Add(mainDataGridView);
            HomeDataGridViewMainPanel.Dock = DockStyle.Bottom;
            HomeDataGridViewMainPanel.Location = new Point(421, 256);
            HomeDataGridViewMainPanel.Margin = new Padding(4, 5, 4, 5);
            HomeDataGridViewMainPanel.Name = "HomeDataGridViewMainPanel";
            HomeDataGridViewMainPanel.Padding = new Padding(0, 15, 0, 0);
            HomeDataGridViewMainPanel.Size = new Size(1455, 726);
            HomeDataGridViewMainPanel.TabIndex = 5;
            // 
            // mainDataGridView
            // 
            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.AllowUserToDeleteRows = false;
            mainDataGridView.AllowUserToResizeColumns = false;
            mainDataGridView.AllowUserToResizeRows = false;
            mainDataGridView.BackgroundColor = Color.WhiteSmoke;
            mainDataGridView.BorderStyle = BorderStyle.None;
            mainDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            mainDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.SlateBlue;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle13.ForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle13.SelectionBackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle13.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            mainDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            mainDataGridView.ColumnHeadersHeight = 45;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle14.ForeColor = Color.DarkSlateBlue;
            dataGridViewCellStyle14.SelectionBackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle14.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.False;
            mainDataGridView.DefaultCellStyle = dataGridViewCellStyle14;
            mainDataGridView.Dock = DockStyle.Fill;
            mainDataGridView.EnableHeadersVisualStyles = false;
            mainDataGridView.GridColor = Color.LightGray;
            mainDataGridView.Location = new Point(0, 15);
            mainDataGridView.Margin = new Padding(4, 5, 4, 5);
            mainDataGridView.MultiSelect = false;
            mainDataGridView.Name = "mainDataGridView";
            mainDataGridView.ReadOnly = true;
            mainDataGridView.RowHeadersVisible = false;
            mainDataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = Color.Navy;
            mainDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle15;
            mainDataGridView.RowTemplate.DividerHeight = 2;
            mainDataGridView.RowTemplate.Height = 45;
            mainDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainDataGridView.Size = new Size(1455, 711);
            mainDataGridView.TabIndex = 2;
            mainDataGridView.SelectionChanged += mainDataGridView_SelectionChanged;
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(refreshButton);
            controlPanel.Controls.Add(deleteButton);
            controlPanel.Controls.Add(editButton);
            controlPanel.Controls.Add(addButton);
            controlPanel.Controls.Add(assignButton);
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Location = new Point(421, 145);
            controlPanel.Margin = new Padding(4, 5, 4, 5);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(1455, 111);
            controlPanel.TabIndex = 6;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.RoyalBlue;
            refreshButton.BackgroundImage = (Image)resources.GetObject("refreshButton.BackgroundImage");
            refreshButton.BackgroundImageLayout = ImageLayout.Zoom;
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            refreshButton.ForeColor = Color.WhiteSmoke;
            refreshButton.Location = new Point(60, 26);
            refreshButton.Margin = new Padding(4, 5, 4, 5);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(51, 58);
            refreshButton.TabIndex = 5;
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.RoyalBlue;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            deleteButton.ForeColor = Color.WhiteSmoke;
            deleteButton.Location = new Point(617, 26);
            deleteButton.Margin = new Padding(4, 5, 4, 5);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(240, 58);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Видалити";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // editButton
            // 
            editButton.BackColor = Color.RoyalBlue;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            editButton.ForeColor = Color.WhiteSmoke;
            editButton.Location = new Point(369, 26);
            editButton.Margin = new Padding(4, 5, 4, 5);
            editButton.Name = "editButton";
            editButton.Size = new Size(240, 58);
            editButton.TabIndex = 3;
            editButton.Text = "Редагувати";
            editButton.UseVisualStyleBackColor = false;
            editButton.Click += editButton_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.RoyalBlue;
            addButton.Enabled = false;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            addButton.ForeColor = Color.WhiteSmoke;
            addButton.Location = new Point(121, 26);
            addButton.Margin = new Padding(4, 5, 4, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(240, 58);
            addButton.TabIndex = 2;
            addButton.Text = "Додати Проект";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // assignButton
            // 
            assignButton.BackColor = Color.RoyalBlue;
            assignButton.Enabled = false;
            assignButton.FlatAppearance.BorderSize = 0;
            assignButton.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            assignButton.ForeColor = Color.WhiteSmoke;
            assignButton.Location = new Point(1157, 26);
            assignButton.Margin = new Padding(4, 5, 4, 5);
            assignButton.Name = "assignButton";
            assignButton.Size = new Size(240, 58);
            assignButton.TabIndex = 1;
            assignButton.Text = "Призначити працівника";
            assignButton.UseVisualStyleBackColor = false;
            assignButton.Click += assignButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1876, 982);
            Controls.Add(controlPanel);
            Controls.Add(HomeDataGridViewMainPanel);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Activated += MainForm_Activated;
            FormClosed += MainForm_FormClosed;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            HomeDataGridViewMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainDataGridView).EndInit();
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button activeProjectsButton;
        private System.Windows.Forms.Button workersButton;
        private System.Windows.Forms.Button projectsButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label welcomeLabel2;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel HomeDataGridViewMainPanel;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button refreshButton;
    }
}