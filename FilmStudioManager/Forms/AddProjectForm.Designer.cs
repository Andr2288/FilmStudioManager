namespace FilmStudioManager.Forms
{
    partial class AddProjectForm
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
            addProjectButton = new Button();
            label2 = new Label();
            projectNameTextBox = new TextBox();
            label7 = new Label();
            projectTypeComboBox = new ComboBox();
            budgetNumericUpDown = new NumericUpDown();
            label5 = new Label();
            label8 = new Label();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            label4 = new Label();
            statusComboBox = new ComboBox();
            endDateCheckBox = new CheckBox();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)budgetNumericUpDown).BeginInit();
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
            topPanel.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(470, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 49);
            label1.TabIndex = 11;
            label1.Text = "Додати Проект";
            // 
            // addProjectButton
            // 
            addProjectButton.BackColor = Color.MediumSlateBlue;
            addProjectButton.FlatAppearance.BorderSize = 0;
            addProjectButton.FlatStyle = FlatStyle.Flat;
            addProjectButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            addProjectButton.ForeColor = Color.WhiteSmoke;
            addProjectButton.Location = new Point(754, 572);
            addProjectButton.Margin = new Padding(4, 5, 4, 5);
            addProjectButton.Name = "addProjectButton";
            addProjectButton.Size = new Size(466, 62);
            addProjectButton.TabIndex = 25;
            addProjectButton.Text = "Додати Проект";
            addProjectButton.UseVisualStyleBackColor = false;
            addProjectButton.Click += addProjectButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(56, 153);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 29);
            label2.TabIndex = 27;
            label2.Text = "Назва проекту";
            // 
            // projectNameTextBox
            // 
            projectNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            projectNameTextBox.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            projectNameTextBox.Location = new Point(56, 193);
            projectNameTextBox.Margin = new Padding(4, 5, 4, 5);
            projectNameTextBox.Name = "projectNameTextBox";
            projectNameTextBox.Size = new Size(466, 44);
            projectNameTextBox.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label7.Location = new Point(738, 153);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(136, 29);
            label7.TabIndex = 29;
            label7.Text = "Тип проекту";
            // 
            // projectTypeComboBox
            // 
            projectTypeComboBox.Font = new Font("Calibri", 18F);
            projectTypeComboBox.FormattingEnabled = true;
            projectTypeComboBox.Location = new Point(743, 193);
            projectTypeComboBox.Name = "projectTypeComboBox";
            projectTypeComboBox.Size = new Size(466, 45);
            projectTypeComboBox.TabIndex = 28;
            // 
            // budgetNumericUpDown
            // 
            budgetNumericUpDown.Font = new Font("Calibri", 18F);
            budgetNumericUpDown.Location = new Point(61, 319);
            budgetNumericUpDown.Name = "budgetNumericUpDown";
            budgetNumericUpDown.Size = new Size(466, 44);
            budgetNumericUpDown.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(56, 279);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(146, 29);
            label5.TabIndex = 30;
            label5.Text = "Бюджет (грн)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(61, 425);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(146, 29);
            label8.TabIndex = 33;
            label8.Text = "Дата початку";
            // 
            // startDatePicker
            // 
            startDatePicker.Font = new Font("Calibri", 18F);
            startDatePicker.Location = new Point(61, 469);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(466, 44);
            startDatePicker.TabIndex = 32;
            // 
            // endDatePicker
            // 
            endDatePicker.Font = new Font("Calibri", 18F);
            endDatePicker.Location = new Point(743, 469);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(466, 44);
            endDatePicker.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(743, 279);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(77, 29);
            label4.TabIndex = 37;
            label4.Text = "Статус";
            // 
            // statusComboBox
            // 
            statusComboBox.Font = new Font("Calibri", 18F);
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(748, 319);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(466, 45);
            statusComboBox.TabIndex = 36;
            // 
            // endDateCheckBox
            // 
            endDateCheckBox.AutoSize = true;
            endDateCheckBox.Font = new Font("Calibri", 14.25F);
            endDateCheckBox.Location = new Point(738, 421);
            endDateCheckBox.Name = "endDateCheckBox";
            endDateCheckBox.Size = new Size(295, 33);
            endDateCheckBox.TabIndex = 38;
            endDateCheckBox.Text = "Вказати дату завершення";
            endDateCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(endDateCheckBox);
            Controls.Add(label4);
            Controls.Add(statusComboBox);
            Controls.Add(endDatePicker);
            Controls.Add(label8);
            Controls.Add(startDatePicker);
            Controls.Add(budgetNumericUpDown);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(projectTypeComboBox);
            Controls.Add(label2);
            Controls.Add(projectNameTextBox);
            Controls.Add(addProjectButton);
            Controls.Add(topPanel);
            Name = "AddProjectForm";
            Text = "AddProjectForm";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)budgetNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label label1;
        private Button addProjectButton;
        private Label label2;
        private TextBox projectNameTextBox;
        private Label label7;
        private ComboBox projectTypeComboBox;
        private NumericUpDown budgetNumericUpDown;
        private Label label5;
        private Label label8;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Label label4;
        private ComboBox statusComboBox;
        private CheckBox endDateCheckBox;
    }
}