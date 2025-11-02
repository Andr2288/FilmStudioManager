using FilmStudioManager.Models;
using FilmStudioManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudioManager.Forms
{
    public partial class AddProjectForm : Form
    {
        private List<ProjectType> projectTypes;

        public AddProjectForm()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                ProjectTypeRepository projectTypeRepository = new ProjectTypeRepository();
                projectTypes = await projectTypeRepository.GetAllProjectTypesAsync();

                projectTypeComboBox.DataSource = projectTypes;
                projectTypeComboBox.DisplayMember = "TypeName";
                projectTypeComboBox.ValueMember = "ProjectTypeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}",
                                "Помилка бази даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProjectButton_Click(object sender, EventArgs e)
        {
            AddProject();
        }

        private async void AddProject()
        {
            addProjectButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            string projectNameField = projectNameTextBox.Text.Trim();
            decimal budgetField = budgetNumericUpDown.Value;
            DateTime startDateField = startDatePicker.Value.Date;
            DateTime? endDateField = endDateCheckBox.Checked ? endDatePicker.Value.Date : (DateTime?)null;
            string statusField = statusComboBox.SelectedItem?.ToString() ?? "В роботі";

            if (string.IsNullOrWhiteSpace(projectNameField))
            {
                MessageBox.Show("Назва проекту є обов'язковою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addProjectButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (projectTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Тип проекту є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addProjectButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (budgetField <= 0)
            {
                MessageBox.Show("Бюджет повинен бути більше 0!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addProjectButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (endDateField.HasValue && endDateField.Value < startDateField)
            {
                MessageBox.Show("Дата завершення не може бути раніше дати початку!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addProjectButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            try
            {
                int projectTypeId = (int)projectTypeComboBox.SelectedValue;

                Project newProject = new Project(
                    projectNameField,
                    projectTypeId,
                    budgetField,
                    startDateField,
                    endDateField,
                    statusField
                );

                ProjectRepository projectRepository = new ProjectRepository();
                int projectId = await projectRepository.CreateProjectAsync(newProject);

                MessageBox.Show("Проект успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні проекту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            addProjectButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            // Встановлюємо дату початку на поточну дату
            startDatePicker.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now.AddMonths(6);

            // Встановлюємо бюджет
            budgetNumericUpDown.Minimum = 1000;
            budgetNumericUpDown.Maximum = 100000000; // 100 млн
            budgetNumericUpDown.Value = 100000; // 100 тис за замовчуванням
            budgetNumericUpDown.DecimalPlaces = 2;
            budgetNumericUpDown.Increment = 10000;

            // Заповнюємо статуси проектів
            statusComboBox.Items.AddRange(new string[] {
                "В роботі",
                "Завершено",
                "Призупинено",
                "Скасовано",
                "Планується"
            });
            statusComboBox.SelectedIndex = 0; // "В роботі" за замовчуванням

            // За замовчуванням дата завершення не вказана
            endDateCheckBox.Checked = false;
            endDatePicker.Enabled = false;
        }

        private void endDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            endDatePicker.Enabled = endDateCheckBox.Checked;

            if (endDateCheckBox.Checked && endDatePicker.Value < startDatePicker.Value)
            {
                endDatePicker.Value = startDatePicker.Value.AddMonths(3);
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Якщо дата завершення включена і менша за дату початку - коригуємо її
            if (endDateCheckBox.Checked && endDatePicker.Value < startDatePicker.Value)
            {
                endDatePicker.Value = startDatePicker.Value.AddMonths(3);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
