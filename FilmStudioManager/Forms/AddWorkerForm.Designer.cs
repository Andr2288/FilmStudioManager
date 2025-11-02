namespace FilmStudioManager.Forms
{
    partial class AddWorkerForm
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
            label2 = new Label();
            firstNameTextBox = new TextBox();
            label3 = new Label();
            lastNameTextBox = new TextBox();
            label4 = new Label();
            emailTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            phoneTextBox = new TextBox();
            addWorkerButton = new Button();
            salaryNumericUpDown = new NumericUpDown();
            positionComboBox = new ComboBox();
            label7 = new Label();
            hireDatePicker = new DateTimePicker();
            label8 = new Label();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)salaryNumericUpDown).BeginInit();
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
            topPanel.Size = new Size(1262, 104);
            topPanel.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(470, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(361, 49);
            label1.TabIndex = 11;
            label1.Text = "Додати Працівника";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(139, 136);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 29);
            label2.TabIndex = 15;
            label2.Text = "Ім'я";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            firstNameTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            firstNameTextBox.Location = new Point(139, 176);
            firstNameTextBox.Margin = new Padding(4, 5, 4, 5);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(466, 44);
            firstNameTextBox.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(134, 271);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(112, 29);
            label3.TabIndex = 17;
            label3.Text = "Прізвище";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            lastNameTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lastNameTextBox.Location = new Point(139, 311);
            lastNameTextBox.Margin = new Padding(4, 5, 4, 5);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(466, 44);
            lastNameTextBox.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(665, 136);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(68, 29);
            label4.TabIndex = 19;
            label4.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailTextBox.Location = new Point(670, 176);
            emailTextBox.Margin = new Padding(4, 5, 4, 5);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(466, 44);
            emailTextBox.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(665, 271);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(160, 29);
            label5.TabIndex = 21;
            label5.Text = "Зарплата (грн)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(134, 393);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 29);
            label6.TabIndex = 23;
            label6.Text = "Телефон";
            // 
            // phoneTextBox
            // 
            phoneTextBox.BorderStyle = BorderStyle.FixedSingle;
            phoneTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phoneTextBox.Location = new Point(139, 433);
            phoneTextBox.Margin = new Padding(4, 5, 4, 5);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(466, 44);
            phoneTextBox.TabIndex = 22;
            // 
            // addWorkerButton
            // 
            addWorkerButton.BackColor = Color.MediumSlateBlue;
            addWorkerButton.FlatAppearance.BorderSize = 0;
            addWorkerButton.FlatStyle = FlatStyle.Flat;
            addWorkerButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            addWorkerButton.ForeColor = Color.WhiteSmoke;
            addWorkerButton.Location = new Point(670, 545);
            addWorkerButton.Margin = new Padding(4, 5, 4, 5);
            addWorkerButton.Name = "addWorkerButton";
            addWorkerButton.Size = new Size(466, 62);
            addWorkerButton.TabIndex = 24;
            addWorkerButton.Text = "Додати Працівника";
            addWorkerButton.UseVisualStyleBackColor = false;
            addWorkerButton.Click += addWorkerButton_Click;
            // 
            // salaryNumericUpDown
            // 
            salaryNumericUpDown.Font = new Font("Calibri", 18F);
            salaryNumericUpDown.Location = new Point(670, 311);
            salaryNumericUpDown.Name = "salaryNumericUpDown";
            salaryNumericUpDown.Size = new Size(466, 44);
            salaryNumericUpDown.TabIndex = 25;
            // 
            // positionComboBox
            // 
            positionComboBox.Font = new Font("Calibri", 18F);
            positionComboBox.FormattingEnabled = true;
            positionComboBox.Location = new Point(670, 433);
            positionComboBox.Name = "positionComboBox";
            positionComboBox.Size = new Size(466, 45);
            positionComboBox.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(665, 393);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(94, 29);
            label7.TabIndex = 27;
            label7.Text = "Позиція";
            // 
            // hireDatePicker
            // 
            hireDatePicker.Font = new Font("Calibri", 18F);
            hireDatePicker.Location = new Point(139, 545);
            hireDatePicker.Name = "hireDatePicker";
            hireDatePicker.Size = new Size(466, 44);
            hireDatePicker.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(139, 501);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(265, 29);
            label8.TabIndex = 29;
            label8.Text = "Дата прийому на роботу";
            // 
            // AddWorkerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(label8);
            Controls.Add(hireDatePicker);
            Controls.Add(label7);
            Controls.Add(positionComboBox);
            Controls.Add(salaryNumericUpDown);
            Controls.Add(addWorkerButton);
            Controls.Add(label6);
            Controls.Add(phoneTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(emailTextBox);
            Controls.Add(label3);
            Controls.Add(lastNameTextBox);
            Controls.Add(label2);
            Controls.Add(firstNameTextBox);
            Controls.Add(topPanel);
            Name = "AddWorkerForm";
            Text = "AddWorkerForm";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)salaryNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label label1;
        private Label label2;
        private TextBox firstNameTextBox;
        private Label label3;
        private TextBox lastNameTextBox;
        private Label label4;
        private TextBox emailTextBox;
        private Label label5;
        private Label label6;
        private TextBox phoneTextBox;
        private Button addWorkerButton;
        private NumericUpDown salaryNumericUpDown;
        private ComboBox positionComboBox;
        private Label label7;
        private DateTimePicker hireDatePicker;
        private Label label8;
    }
}