using FilmStudioManager.Models;
using FilmStudioManager.Repositories;
using FilmStudioManager.Services;

namespace FilmStudioManager.Forms
{
    public partial class MainForm : Form
    {
        private string currentView = "projects"; // projects, workers, myProjects

        public MainForm()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=FilmStudioManager;Integrated Security=True;TrustServerCertificate=True;";
            DatabaseService.Connect(connectionString);

            if (CurrentState.GetInstance().User == null)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        public async void LoadProjectsPage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                currentView = "projects";
                Cursor = Cursors.WaitCursor;

                ProjectRepository projectRepository = new ProjectRepository();
                List<Project> projects = await projectRepository.GetAllProjectsAsync();

                // Отримуємо розширену інформацію про проекти з типами
                var projectsWithTypes = await GetProjectsWithTypesAsync(projects);

                mainDataGridView.DataSource = projectsWithTypes;
                ConfigureDataGridView(mainDataGridView);
                SetupProjectColumnsProperties(mainDataGridView);

                // Налаштовуємо кнопки
                addButton.Text = "Додати Проект";
                addButton.Enabled = true;
                editButton.Enabled = false;
                deleteButton.Enabled = false;
                assignButton.Text = "Призначити Працівника";
                assignButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async void LoadWorkersPage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                currentView = "workers";
                Cursor = Cursors.WaitCursor;

                WorkerRepository workerRepository = new WorkerRepository();
                List<Worker> workers = await workerRepository.GetAllWorkersAsync();

                mainDataGridView.DataSource = workers;
                ConfigureDataGridView(mainDataGridView);
                SetupWorkerColumnsProperties(mainDataGridView);

                // Налаштовуємо кнопки
                addButton.Text = "Додати Працівника";
                addButton.Enabled = true;
                editButton.Enabled = false;
                deleteButton.Enabled = false;
                assignButton.Text = "Призначити на Проект";
                assignButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async void LoadActiveProjectsPage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                currentView = "activeProjects";
                Cursor = Cursors.WaitCursor;

                ProjectRepository projectRepository = new ProjectRepository();
                List<Project> projects = await projectRepository.GetProjectsByStatusAsync("В роботі");

                var projectsWithTypes = await GetProjectsWithTypesAsync(projects);

                mainDataGridView.DataSource = projectsWithTypes;
                ConfigureDataGridView(mainDataGridView);
                SetupProjectColumnsProperties(mainDataGridView);

                // Налаштовуємо кнопки
                addButton.Text = "Додати Проект";
                addButton.Enabled = true;
                editButton.Enabled = false;
                deleteButton.Enabled = false;
                assignButton.Text = "Призначити Працівника";
                assignButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task<List<object>> GetProjectsWithTypesAsync(List<Project> projects)
        {
            var projectsWithTypes = new List<object>();
            ProjectTypeRepository projectTypeRepository = new ProjectTypeRepository();

            foreach (var project in projects)
            {
                var projectType = await projectTypeRepository.GetProjectTypeByIdAsync(project.ProjectTypeID);
                projectsWithTypes.Add(new
                {
                    ProjectID = project.ProjectID,
                    ProjectName = project.ProjectName,
                    ProjectType = projectType?.TypeName ?? "Невідомо",
                    Budget = project.Budget,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    Status = project.Status
                });
            }

            return projectsWithTypes;
        }

        private async Task<bool> CheckDatabaseConnection()
        {
            bool isConnected = await DatabaseService.TestConnectionAsync();

            if (!isConnected)
            {
                MessageBox.Show("Не вдалося підключитися до бази даних. Деякі функції можуть бути недоступні.",
                                "Помилка підключення до бази даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isConnected;
        }

        private void UpdateCurrentForm()
        {
            User currentUser = CurrentState.GetInstance().User;

            if (currentUser != null)
            {
                welcomeLabel.Text = "Вітаємо, " + currentUser.Login + "!";
                projectsButton.Enabled = true;
                workersButton.Enabled = true;
                activeProjectsButton.Enabled = true;
                logoutButton.Enabled = true;
            }
            else
            {
                welcomeLabel.Text = "Спочатку увійдіть, будь ласка!";
                projectsButton.Enabled = false;
                workersButton.Enabled = false;
                activeProjectsButton.Enabled = false;
                logoutButton.Enabled = false;
            }
        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            LoadProjectsPage();
        }

        private void workersButton_Click(object sender, EventArgs e)
        {
            LoadWorkersPage();
        }

        private void activeProjectsButton_Click(object sender, EventArgs e)
        {
            LoadActiveProjectsPage();
        }

        public static void ConfigureDataGridView(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 185);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 75, 175);

            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(66, 65, 75);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 90, 100);

            dataGridView.BackgroundColor = Color.FromArgb(48, 51, 58);
        }

        private void SetupProjectColumnsProperties(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (column.Name == "ProjectID")
                {
                    column.HeaderText = "ID";
                    column.FillWeight = 50;
                }
                else if (column.Name == "ProjectName")
                {
                    column.HeaderText = "Назва проекту";
                    column.FillWeight = 150;
                }
                else if (column.Name == "ProjectType")
                {
                    column.HeaderText = "Тип";
                    column.FillWeight = 100;
                }
                else if (column.Name == "Budget")
                {
                    column.HeaderText = "Бюджет";
                    column.FillWeight = 100;
                    column.DefaultCellStyle.Format = "C2";
                }
                else if (column.Name == "StartDate")
                {
                    column.HeaderText = "Дата початку";
                    column.FillWeight = 100;
                    column.DefaultCellStyle.Format = "dd.MM.yyyy";
                }
                else if (column.Name == "EndDate")
                {
                    column.HeaderText = "Дата завершення";
                    column.FillWeight = 100;
                    column.DefaultCellStyle.Format = "dd.MM.yyyy";
                }
                else if (column.Name == "Status")
                {
                    column.HeaderText = "Статус";
                    column.FillWeight = 80;
                }
            }
        }

        private void SetupWorkerColumnsProperties(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (column.Name == "WorkerID")
                {
                    column.HeaderText = "ID";
                    column.FillWeight = 50;
                }
                else if (column.Name == "FirstName")
                {
                    column.HeaderText = "Ім'я";
                    column.FillWeight = 80;
                }
                else if (column.Name == "LastName")
                {
                    column.HeaderText = "Прізвище";
                    column.FillWeight = 100;
                }
                else if (column.Name == "Position")
                {
                    column.HeaderText = "Посада";
                    column.FillWeight = 120;
                }
                else if (column.Name == "Phone")
                {
                    column.HeaderText = "Телефон";
                    column.FillWeight = 100;
                }
                else if (column.Name == "Email")
                {
                    column.HeaderText = "Email";
                    column.FillWeight = 120;
                }
                else if (column.Name == "HireDate")
                {
                    column.HeaderText = "Дата прийому";
                    column.FillWeight = 100;
                    column.DefaultCellStyle.Format = "dd.MM.yyyy";
                }
                else if (column.Name == "Salary")
                {
                    column.HeaderText = "Зарплата";
                    column.FillWeight = 100;
                    column.DefaultCellStyle.Format = "C2";
                }
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentState.GetInstance().User = null;
            UpdateCurrentForm();

            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (currentView == "projects" || currentView == "activeProjects")
            {
                AddProjectForm addProjectForm = new AddProjectForm();
                addProjectForm.ShowDialog();
                // Оновлюємо дані після додавання
                if (currentView == "projects")
                    LoadProjectsPage();
                else
                    LoadActiveProjectsPage();
            }
            else if (currentView == "workers")
            {
                AddWorkerForm addWorkerForm = new AddWorkerForm();
                addWorkerForm.ShowDialog();
                LoadWorkersPage();
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateCurrentForm();

            if (mainDataGridView.Rows.Count == 0)
            {
                LoadProjectsPage();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedItem();
        }

        private async void DeleteSelectedItem()
        {
            if (mainDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок для видалення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Ви впевнені, що хочете видалити обраний елемент?",
                "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            deleteButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var selectedRow = mainDataGridView.SelectedRows[0];

                if (currentView == "projects" || currentView == "activeProjects")
                {
                    int projectId = (int)selectedRow.Cells["ProjectID"].Value;
                    ProjectRepository projectRepository = new ProjectRepository();
                    await projectRepository.DeleteProjectAsync(projectId);

                    if (currentView == "projects")
                        LoadProjectsPage();
                    else
                        LoadActiveProjectsPage();
                }
                else if (currentView == "workers")
                {
                    int workerId = (int)selectedRow.Cells["WorkerID"].Value;
                    WorkerRepository workerRepository = new WorkerRepository();
                    await workerRepository.DeleteWorkerAsync(workerId);
                    LoadWorkersPage();
                }

                MessageBox.Show("Елемент успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при видаленні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            deleteButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void mainDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = mainDataGridView.SelectedRows.Count > 0;
            editButton.Enabled = hasSelection;
            deleteButton.Enabled = hasSelection;
            assignButton.Enabled = hasSelection;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (currentView == "projects")
                LoadProjectsPage();
            else if (currentView == "workers")
                LoadWorkersPage();
            else if (currentView == "activeProjects")
                LoadActiveProjectsPage();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функція редагування буде додана в наступних версіях.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void assignButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функція призначення буде додана в наступних версіях.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}