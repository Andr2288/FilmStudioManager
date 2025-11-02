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
    public partial class AddWorkerForm : Form
    {
        public AddWorkerForm()
        {
            InitializeComponent();
        }

        private void addWorkerButton_Click(object sender, EventArgs e)
        {
            AddWorker();
        }

        private async void AddWorker()
        {
            addWorkerButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            string firstNameField = firstNameTextBox.Text.Trim();
            string lastNameField = lastNameTextBox.Text.Trim();
            string positionField = positionComboBox.Text.Trim();
            string phoneField = phoneTextBox.Text.Trim();
            string emailField = emailTextBox.Text.Trim();
            decimal salaryField = salaryNumericUpDown.Value;

            if (string.IsNullOrWhiteSpace(firstNameField))
            {
                MessageBox.Show("Ім'я працівника є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addWorkerButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (string.IsNullOrWhiteSpace(lastNameField))
            {
                MessageBox.Show("Прізвище працівника є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addWorkerButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (string.IsNullOrWhiteSpace(positionField))
            {
                MessageBox.Show("Посада працівника є обов'язковою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addWorkerButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (!string.IsNullOrWhiteSpace(emailField) && !IsValidEmail(emailField))
            {
                MessageBox.Show("Будь ласка, введіть коректну електронну адресу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addWorkerButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            if (salaryField <= 0)
            {
                MessageBox.Show("Зарплата повинна бути більше 0!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addWorkerButton.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            try
            {
                Worker newWorker = new Worker(
                    firstNameField,
                    lastNameField,
                    positionField,
                    string.IsNullOrWhiteSpace(phoneField) ? null : phoneField,
                    string.IsNullOrWhiteSpace(emailField) ? null : emailField,
                    hireDatePicker.Value.Date,
                    salaryField
                );

                WorkerRepository workerRepository = new WorkerRepository();
                await workerRepository.CreateWorkerAsync(newWorker);

                MessageBox.Show("Працівника успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні працівника: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            addWorkerButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private void AddWorkerForm_Load(object sender, EventArgs e)
        {
            // Встановлюємо дату прийому на роботу на поточну дату
            hireDatePicker.Value = DateTime.Now;

            // Встановлюємо мінімальну зарплату
            salaryNumericUpDown.Minimum = 1000;
            salaryNumericUpDown.Maximum = 1000000;
            salaryNumericUpDown.Value = 15000;
            salaryNumericUpDown.DecimalPlaces = 2;
            salaryNumericUpDown.Increment = 1000;

            // Заповнюємо комбобокс посад
            positionComboBox.Items.AddRange(new string[] {
                "Режисер",
                "Сценарист",
                "Оператор",
                "Монтажер",
                "Звукорежисер",
                "Художник-постановник",
                "Художник по костюмах",
                "Продюсер",
                "Асистент режисера",
                "Директор картини",
                "Композитор",
                "Каскадер",
                "Актор",
                "Акторка"
            });
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (positionComboBox.SelectedItem != null)
            {
                positionComboBox.Text = positionComboBox.SelectedItem.ToString();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
