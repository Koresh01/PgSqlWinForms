using Npgsql;
using System;
using System.Data;
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
            ShowTable("PhoneBook");
        }

        /// <summary>
        /// ��������� ������ �� �����.
        /// </summary>
        /// <param name="tableName">������� �� ������� ��������� ������ �� �����.</param>
        private void ShowTable(string tableName)
        {
            try
            {
                dataGridView.DataSource = DatabaseManager.GetAllRecords(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
            }
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
                        break;
                    case "Surnames":
                        break;
                    case "Names":
                        break;
                    case "Otchestva":
                        break;
                    case "Streets":
                        break;
                    case "Houses":
                        break;
                    case "Corps":
                        break;
                    case "Apartments":
                        break;
                    case "Phones":
                        break;
                }
                
                MessageBox.Show("������ ������� ���������!");
                ShowTable(curTable);
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
                        DatabaseManager.DeleteRecord(id);
                        MessageBox.Show("������ ������� �������!");
                        ShowTable(curTable);
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

                dataGridView.DataSource = DatabaseManager.FindRecords(familia, personName, otchestvo, street, house, korpys, apartment, phone);
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
            ShowTable("PhoneBook");

            // ������������� �������� ������� ������������ �������:
            curTable = "PhoneBook";
        }

        private void SurnamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������ ��������������� �������.
            ShowTable("Surnames");

            // ������������� �������� ������� ������������ �������:
            curTable = "Surnames";
        }

        private void NamesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�����";

            // ������������ ��������������� �������.
            ShowTable("Names");

            // ������������� �������� ������� ������������ �������:
            curTable = "Names";
        }

        private void OtchestvaBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "��������";

            // ������������ ��������������� �������.
            ShowTable("Otchestva");

            // ������������� �������� ������� ������������ �������:
            curTable = "Otchestva";
        }

        private void StreetsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�����";

            // ������������ ��������������� �������.
            ShowTable("Streets");

            // ������������� �������� ������� ������������ �������:
            curTable = "Streets";
        }

        private void HousesBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "����";

            // ������������ ��������������� �������.
            ShowTable("Houses");

            // ������������� �������� ������� ������������ �������:
            curTable = "Houses";
        }

        private void CorpsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������ ��������������� �������.
            ShowTable("Corps");

            // ������������� �������� ������� ������������ �������:
            curTable = "Corps";
        }

        private void ApartamentsBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "�������";

            // ������������ ��������������� �������.
            ShowTable("Apartments");

            // ������������� �������� ������� ������������ �������:
            curTable = "Apartments";
        }

        private void TelephoneNumbersBtn_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;

            // ������ �������� ��������:
            tableNameLabel.Text = "��������";

            // ������������ ��������������� �������.
            ShowTable("Phones");

            // ������������� �������� ������� ������������ �������:
            curTable = "Phones";
        }

        #endregion
    }
}
