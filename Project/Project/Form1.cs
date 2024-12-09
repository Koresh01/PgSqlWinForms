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
            // ������ �������� ��������:
            tableNameLabel.Text = "���������� �����";
            curTable = "PhoneBook";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        /// <summary>
        /// ��������� ������ �� �����.
        /// </summary>
        /// <param name="tableName">������� �� ������� ��������� ������ �� �����.</param>
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

                // ������� ����� ������ ������� ������� � ������������:
                switch (curTable) {
                    case "PhoneBook":
                        DatabaseManager.AddRecord(familia, personName, otchestvo, street, house, korpys, apartment, phone);
                        MessageBox.Show("������ ������� ���������!");

                        // �������� ������ ��������:
                        DataTable data = DatabaseManager.GetAllRecords(curTable);

                        // ������������ ��:
                        ShowTable(data);
                        break;
                    case "Surnames":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Names":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Otchestva":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Streets":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Houses":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Corps":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Apartments":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                    case "Phones":
                        MessageBox.Show("������ ���������� �������� ������ ��� ������� PhoneBook!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ���������� ������: {ex.Message}");
            }
        }

        private void OnDeleteBtnClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                var result = MessageBox.Show($"�� �������, ��� ������ ������� ������ � ID {id}?", "������������� ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseManager.DeleteRecord(curTable, id);
                        MessageBox.Show("������ ������� �������!");

                        // �������� ������ ��������:
                        DataTable data = DatabaseManager.GetAllRecords(curTable);

                        // ������������ ��:
                        ShowTable(data);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
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

                // �������� ������ ��������:
                DataTable data = DatabaseManager.FindRecords(familia, personName, otchestvo, street, house, korpys, apartment, phone);

                // ������������ ��:
                ShowTable(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������: {ex.Message}");
            }
        }

        #region ������ ����
        private void PhoneBook_BtnClick(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "���������� �����";


            // ������������ ��������������� �������.

            // ������������� �������� ������� ������������ �������:
            curTable = "PhoneBook";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);

            
        }

        private void SurnamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������ ��������������� �������.

            // ������������� �������� ������� ������������ �������:
            curTable = "Surnames";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void NamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�����";

            // ������������� �������� ������� ������������ �������:
            curTable = "Names";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void OtchestvaBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "��������";


            // ������������� �������� ������� ������������ �������:
            curTable = "Otchestva";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void StreetsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�����";


            // ������������� �������� ������� ������������ �������:
            curTable = "Streets";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void HousesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "����";

            // ������������� �������� ������� ������������ �������:
            curTable = "Houses";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void CorpsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������� �������� ������� ������������ �������:
            curTable = "Corps";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void ApartamentsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������� �������� ������� ������������ �������:
            curTable = "Apartments";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        private void TelephoneNumbersBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "��������";

            // ������������� �������� ������� ������������ �������:
            curTable = "Phones";

            // �������� ������ ��������:
            DataTable data = DatabaseManager.GetAllRecords(curTable);

            // ������������ ��:
            ShowTable(data);
        }

        #endregion
    }
}
