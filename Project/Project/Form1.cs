using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        // Строка подключения к базе данных PostgreSQL
        string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=TelephoneManager";

        public Form1()
        {
            InitializeComponent();
            ShowTable();
        }

        /// <summary>
        /// Загружает данные на экран.
        /// </summary>
        private void ShowTable()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Phonebook";  // SQL запрос для получения всех данных из таблицы
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);  // Заполнение DataTable данными из базы
                            dataGridView.DataSource = dt;  // Установка DataSource для DataGridView
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Добавить".
        /// </summary>
        private void OnAddBtnClick(object sender, EventArgs e)
        {
            // Получение значений с формы (например, текстовых полей)
            string familia = textBoxSurname.Text;
            string personName = textBoxName.Text;
            string otchestvo = textBoxOtchestvo.Text;

            string street = textBoxStreet.Text;
            string house = textBoxHouse.Text;
            string korpys = textBoxKorpys.Text;
            string apartment = textBoxApartment.Text;
            string phone = textBoxPhone.Text;

            // SQL запрос для добавления новой записи в таблицу
            string query = @"INSERT INTO Phonebook (famillia, person_name, otchestvo, street, house, korpys, apartment, phone)
                             VALUES (@famillia, @person_name, @otchestvo, @street, @house, @korpys, @apartment, @phone)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Добавление параметров в запрос
                        cmd.Parameters.AddWithValue("famillia", familia);
                        cmd.Parameters.AddWithValue("person_name", personName);
                        cmd.Parameters.AddWithValue("otchestvo", (object)otchestvo ?? DBNull.Value);  // Обработка возможного null
                        cmd.Parameters.AddWithValue("street", (object)street ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("house", (object)house ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("korpys", (object)korpys ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("apartment", (object)apartment ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("phone", phone);

                        cmd.ExecuteNonQuery();  // Выполнение запроса

                        MessageBox.Show("Запись успешно добавлена!");
                        ShowTable();  // Обновление таблицы
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Удалить".
        /// </summary>
        private void OnDeleteBtnClick(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                var selectedRow = dataGridView.SelectedRows[0];

                // Получаем id из выбранной строки (предполагаем, что id - это первый столбец)
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                // Запрашиваем подтверждение удаления
                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись с ID {id}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Если пользователь подтверждает удаление
                if (result == DialogResult.Yes)
                {
                    // SQL запрос для удаления записи по id
                    string query = "DELETE FROM Phonebook WHERE id = @id";

                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                // Добавляем параметр id в запрос
                                cmd.Parameters.AddWithValue("id", id);

                                // Выполняем запрос
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Запись успешно удалена!");

                                // Обновляем таблицу
                                ShowTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }
    }
}
