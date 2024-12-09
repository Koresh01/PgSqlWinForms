using Microsoft.VisualBasic.Devices;
using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        string curTable;
        public Form1()
        {
            InitializeComponent();
            // Меняем название таблички:
            tableNameLabel.Text = "Телефонная книга";
            curTable = "PhoneBook";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        /// <summary>
        /// Загружает данные на экран.
        /// </summary>
        /// <param name="tableName">Таблица из которой выгружаем данные на экран.</param>
        private void ShowTable(DataTable data)
        {
            dataGridView.DataSource = data;
        }

        private void OnAddBtnClick(object sender, EventArgs e)
        {
            try
            {
                string familia = textBoxSurname.Text;
                string personName = textBoxName.Text;
                string otchestvo = textBoxOtchestvo.Text;
                string street = textBoxStreet.Text;
                string house = textBoxHouse.Text;
                string korpys = textBoxKorpys.Text;
                string apartment = textBoxApartment.Text;
                string phone = textBoxPhone.Text;

                // смотрим какая сейчас таблица активна у пользователя:
                switch (curTable) {
                    case "PhoneBook":
                        DatabaseManager.AddRecord(familia, personName, otchestvo, street, house, korpys, apartment, phone);
                        MessageBox.Show("Запись успешно добавлена!");

                        // Получаем нужные значения:
                        DataTable data = DatabaseManager.GetAllRecords(curTable);

                        // Отрисовываем их:
                        ShowTable(data);
                        break;
                    case "Surnames":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Names":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Otchestva":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Streets":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Houses":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Corps":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Apartments":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                    case "Phones":
                        MessageBox.Show("Ручное добавление возможно только для таблицы PhoneBook!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
            }
        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                var result = MessageBox.Show($"Вы уверены, что хотите удалить запись с ID {id}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseManager.DeleteRecord(curTable, id);
                        MessageBox.Show("Запись успешно удалена!");

                        // Получаем нужные значения:
                        DataTable data = DatabaseManager.GetAllRecords(curTable);

                        // Отрисовываем их:
                        ShowTable(data);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }

        private void OnFindBtnClick(object sender, EventArgs e)
        {
            try
            {
                string familia = textBoxSurname.Text.Trim();
                string personName = textBoxName.Text.Trim();
                string otchestvo = textBoxOtchestvo.Text.Trim();
                string street = textBoxStreet.Text.Trim();
                string house = textBoxHouse.Text.Trim();
                string korpys = textBoxKorpys.Text.Trim();
                string apartment = textBoxApartment.Text.Trim();
                string phone = textBoxPhone.Text.Trim();

                // Получаем нужные значения:
                DataTable data = DatabaseManager.FindRecords(familia, personName, otchestvo, street, house, korpys, apartment, phone);

                // Отрисовываем их:
                ShowTable(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}");
            }
        }

        #region Кнопки меню
        private void PhoneBook_BtnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Телефонная книга";


            // Отрисовываем соответствующую таблицу.

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "PhoneBook";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);

            
        }

        private void SurnamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Фамилии";

            // Отрисовываем соответствующую таблицу.

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Surnames";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void NamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Имена";

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Names";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void OtchestvaBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Отчества";


            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Otchestva";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void StreetsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Улицы";


            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Streets";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void HousesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Дома";

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Houses";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void CorpsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Корпуса";

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Corps";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void ApartamentsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Комнаты";

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Apartments";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        private void TelephoneNumbersBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // Меняем название таблички:
            tableNameLabel.Text = "Телефоны";

            // Устанавливаем название текущей отображаемой таблицы:
            curTable = "Phones";

            // Получаем нужные значения:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // Отрисовываем их:
            ShowTable(data);
        }

        #endregion
    }
}
