namespace FilmStudioManager
{
    partial class RegistrationForm
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
            topPanel = new Panel();
            label1 = new Label();
            passwordLabel = new Label();
            loginLabel = new Label();
            passwordTextBox = new TextBox();
            loginTextBox = new TextBox();
            emailLabel = new Label();
            emailTextBox = new TextBox();
            registerButton = new Button();
            goToLoginLabel = new Label();
            createTestDatabaseCheckBox = new CheckBox();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.MediumSlateBlue;
            topPanel.Controls.Add(label1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(4, 5, 4, 5);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(529, 222);
            topPanel.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(157, 80);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(207, 49);
            label1.TabIndex = 12;
            label1.Text = "Реєстрація";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passwordLabel.Location = new Point(25, 549);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(89, 29);
            passwordLabel.TabIndex = 18;
            passwordLabel.Text = "Пароль";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginLabel.Location = new Point(25, 428);
            loginLabel.Margin = new Padding(4, 0, 4, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(185, 29);
            loginLabel.TabIndex = 17;
            loginLabel.Text = "Ім'я Користувача";
            // 
            // passwordTextBox
            // 
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passwordTextBox.Location = new Point(31, 589);
            passwordTextBox.Margin = new Padding(4, 5, 4, 5);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(466, 44);
            passwordTextBox.TabIndex = 3;
            // 
            // loginTextBox
            // 
            loginTextBox.BorderStyle = BorderStyle.FixedSingle;
            loginTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loginTextBox.Location = new Point(31, 468);
            loginTextBox.Margin = new Padding(4, 5, 4, 5);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(466, 44);
            loginTextBox.TabIndex = 1;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailLabel.Location = new Point(25, 303);
            emailLabel.Margin = new Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(204, 29);
            emailLabel.TabIndex = 20;
            emailLabel.Text = "Електронна Пошта";
            // 
            // emailTextBox
            // 
            emailTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailTextBox.Location = new Point(31, 343);
            emailTextBox.Margin = new Padding(4, 5, 4, 5);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(466, 44);
            emailTextBox.TabIndex = 0;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.MediumSlateBlue;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            registerButton.ForeColor = Color.WhiteSmoke;
            registerButton.Location = new Point(31, 845);
            registerButton.Margin = new Padding(4, 5, 4, 5);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(467, 77);
            registerButton.TabIndex = 4;
            registerButton.Text = "Зареєструватися";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += RegisterButton_Click;
            // 
            // goToLoginLabel
            // 
            goToLoginLabel.AutoSize = true;
            goToLoginLabel.Cursor = Cursors.Hand;
            goToLoginLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            goToLoginLabel.Location = new Point(233, 926);
            goToLoginLabel.Margin = new Padding(4, 0, 4, 0);
            goToLoginLabel.Name = "goToLoginLabel";
            goToLoginLabel.Size = new Size(78, 29);
            goToLoginLabel.TabIndex = 21;
            goToLoginLabel.Text = "Увійти";
            goToLoginLabel.Click += goToLoginLabel_Click;
            // 
            // createTestDatabaseCheckBox
            // 
            createTestDatabaseCheckBox.AutoSize = true;
            createTestDatabaseCheckBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            createTestDatabaseCheckBox.Location = new Point(31, 680);
            createTestDatabaseCheckBox.Margin = new Padding(4, 5, 4, 5);
            createTestDatabaseCheckBox.Name = "createTestDatabaseCheckBox";
            createTestDatabaseCheckBox.Size = new Size(357, 33);
            createTestDatabaseCheckBox.TabIndex = 22;
            createTestDatabaseCheckBox.Text = "Створити початкову базу даних";
            createTestDatabaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 1002);
            Controls.Add(createTestDatabaseCheckBox);
            Controls.Add(goToLoginLabel);
            Controls.Add(registerButton);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "RegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrationForm";
            FormClosed += RegistrationForm_FormClosed;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label goToLoginLabel;
        private System.Windows.Forms.CheckBox createTestDatabaseCheckBox;
        private System.Windows.Forms.Label label1;
    }
}