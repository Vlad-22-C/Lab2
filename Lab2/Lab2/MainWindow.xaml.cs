using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SQLite;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadStudents(); // Загрузка данных студентов при инициализации окна
        }

        /// <summary>
        /// Обработчик события для кнопки добавления студента
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие соединения с базой данных SQLite
            using (var connection = new SQLiteConnection("Data Source=students.db"))
            {
                connection.Open(); // Открытие соединения

                // Запрос для вставки данных в таблицу Students
                string query = "INSERT INTO Students (StudentID, FullName, PhoneNumber) VALUES (@StudentID, @FullName, @PhoneNumber)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметров в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.Parameters.AddWithValue("@FullName", fullNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }

                // Запрос для вставки данных в таблицу Grades
                query = "INSERT INTO Grades (StudentID, PhysicsGrade, MathGrade) VALUES (@StudentID, @PhysicsGrade, @MathGrade)";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметров в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.Parameters.AddWithValue("@PhysicsGrade", physicsGradeTextBox.Text);
                    cmd.Parameters.AddWithValue("@MathGrade", mathGradeTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }
            }
            LoadStudents(); // Обновление данных студентов после добавления
        }

        /// <summary>
        /// Метод для загрузки данных студентов из базы данных
        /// </summary>
        private void LoadStudents()
        {
            // Открытие соединения с базой данных SQLite
            using (var connection = new SQLiteConnection("Data Source=students.db"))
            {
                connection.Open(); // Открытие соединения

                // Запрос для получения данных из таблиц Students и Grades
                string query = "SELECT s.StudentID, s.FullName, s.PhoneNumber, g.PhysicsGrade, g.MathGrade FROM Students s JOIN Grades g ON s.StudentID = g.StudentID";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable(); // Создание объекта DataTable
                    adapter.Fill(dt); // Заполнение DataTable данными
                    studentsDataGrid.ItemsSource = dt.DefaultView; // Привязка данных к DataGrid
                }
            }
        }

        /// <summary>
        /// Обработчик события для кнопки обновления данных студента
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие соединения с базой данных SQLite
            using (var connection = new SQLiteConnection("Data Source=students.db"))
            {
                connection.Open(); // Открытие соединения

                // Запрос для обновления данных в таблице Students
                string query = "UPDATE Students SET FullName = @FullName, PhoneNumber = @PhoneNumber WHERE StudentID = @StudentID";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметров в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.Parameters.AddWithValue("@FullName", fullNameTextBox.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }

                // Запрос для обновления данных в таблице Grades
                query = "UPDATE Grades SET PhysicsGrade = @PhysicsGrade, MathGrade = @MathGrade WHERE StudentID = @StudentID";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметров в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.Parameters.AddWithValue("@PhysicsGrade", physicsGradeTextBox.Text);
                    cmd.Parameters.AddWithValue("@MathGrade", mathGradeTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }
            }
            LoadStudents(); // Обновление данных студентов после обновления
        }

        /// <summary>
        /// Обработчик события для кнопки удаления студента
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие соединения с базой данных SQLite
            using (var connection = new SQLiteConnection("Data Source=students.db"))
            {
                connection.Open(); // Открытие соединения

                // Запрос для удаления данных из таблицы Students
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметра в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }

                // Запрос для удаления данных из таблицы Grades
                query = "DELETE FROM Grades WHERE StudentID = @StudentID";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    // Добавление параметра в запрос
                    cmd.Parameters.AddWithValue("@StudentID", studentIDTextBox.Text);
                    cmd.ExecuteNonQuery(); // Выполнение запроса
                }
            }
            LoadStudents(); // Обновление данных студентов после удаления
        }
    }

}
