using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        // ������ ����������� � ���� ������ PostgreSQL
        string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=TelephoneManager";

        public Form1()
        {
            InitializeComponent();
            ShowTable();
        }

        /// <summary>
        /// ��������� ������ �� �����.
        /// </summary>
        private void ShowTable()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Phonebook";  // SQL ������ ��� ��������� ���� ������ �� �������
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);  // ���������� DataTable ������� �� ����
                            dataGridView.DataSource = dt;  // ��������� DataSource ��� DataGridView
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// ���������� ������� �� ������ "��������".
        /// </summary>
        private void OnAddBtnClick(object sender, EventArgs e)
        {
            // ��������� �������� � ����� (��������, ��������� �����)
            string familia = textBoxSurname.Text;
            string personName = textBoxName.Text;
            string otchestvo = textBoxOtchestvo.Text;

            string street = textBoxStreet.Text;
            string house = textBoxHouse.Text;
            string korpys = textBoxKorpys.Text;
            string apartment = textBoxApartment.Text;
            string phone = textBoxPhone.Text;

            // SQL ������ ��� ���������� ����� ������ � �������
            string query = @"INSERT INTO Phonebook (famillia, person_name, otchestvo, street, house, korpys, apartment, phone)
                             VALUES (@famillia, @person_name, @otchestvo, @street, @house, @korpys, @apartment, @phone)";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // ���������� ���������� � ������
                        cmd.Parameters.AddWithValue("famillia", familia);
                        cmd.Parameters.AddWithValue("person_name", personName);
                        cmd.Parameters.AddWithValue("otchestvo", (object)otchestvo ?? DBNull.Value);  // ��������� ���������� null
                        cmd.Parameters.AddWithValue("street", (object)street ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("house", (object)house ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("korpys", (object)korpys ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("apartment", (object)apartment ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("phone", phone);

                        cmd.ExecuteNonQuery();  // ���������� �������

                        MessageBox.Show("������ ������� ���������!");
                        ShowTable();  // ���������� �������
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ���������� ������: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// ���������� ������� �� ������ "�������".
        /// </summary>
        private void OnDeleteBtnClick(object sender, EventArgs e)
        {
            // ���������, ������� �� ������ � DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // �������� ��������� ������
                var selectedRow = dataGridView.SelectedRows[0];

                // �������� id �� ��������� ������ (������������, ��� id - ��� ������ �������)
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                // ����������� ������������� ��������
                var result = MessageBox.Show($"�� �������, ��� ������ ������� ������ � ID {id}?", "������������� ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // ���� ������������ ������������ ��������
                if (result == DialogResult.Yes)
                {
                    // SQL ������ ��� �������� ������ �� id
                    string query = "DELETE FROM Phonebook WHERE id = @id";

                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            using (var cmd = new NpgsqlCommand(query, conn))
                            {
                                // ��������� �������� id � ������
                                cmd.Parameters.AddWithValue("id", id);

                                // ��������� ������
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("������ ������� �������!");

                                // ��������� �������
                                ShowTable();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"������ ��� �������� ������: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }
        }
        /// <summary>
        /// ���������� ������� �� ������ "�����".
        /// </summary>
        private void OnFindBtnClick(object sender, EventArgs e)
        {
            // �������� �������� �� ��������� �����
            string familia = textBoxSurname.Text.Trim();
            string personName = textBoxName.Text.Trim();
            string otchestvo = textBoxOtchestvo.Text.Trim();
            string street = textBoxStreet.Text.Trim();
            string house = textBoxHouse.Text.Trim();
            string korpys = textBoxKorpys.Text.Trim();
            string apartment = textBoxApartment.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            // �������� ������� SQL-������
            string query = "SELECT * FROM Phonebook WHERE 1 = 1"; // ��������� ������, ����� ��� ������� ����� ���� ��������� �����������

            // ������ ���������� ��� �������
            var parameters = new List<NpgsqlParameter>();

            // ��������� ������� ������ �� ����������� �����
            if (!string.IsNullOrWhiteSpace(familia))
            {
                query += " AND famillia ILIKE @familia";
                parameters.Add(new NpgsqlParameter("familia", "%" + familia + "%"));
            }
            if (!string.IsNullOrWhiteSpace(personName))
            {
                query += " AND person_name ILIKE @personName";
                parameters.Add(new NpgsqlParameter("personName", "%" + personName + "%"));
            }
            if (!string.IsNullOrWhiteSpace(otchestvo))
            {
                query += " AND otchestvo ILIKE @otchestvo";
                parameters.Add(new NpgsqlParameter("otchestvo", "%" + otchestvo + "%"));
            }
            if (!string.IsNullOrWhiteSpace(street))
            {
                query += " AND street ILIKE @street";
                parameters.Add(new NpgsqlParameter("street", "%" + street + "%"));
            }
            if (!string.IsNullOrWhiteSpace(house))
            {
                query += " AND house ILIKE @house";
                parameters.Add(new NpgsqlParameter("house", "%" + house + "%"));
            }
            if (!string.IsNullOrWhiteSpace(korpys))
            {
                query += " AND korpys ILIKE @korpys";
                parameters.Add(new NpgsqlParameter("korpys", "%" + korpys + "%"));
            }
            if (!string.IsNullOrWhiteSpace(apartment))
            {
                query += " AND apartment ILIKE @apartment";
                parameters.Add(new NpgsqlParameter("apartment", "%" + apartment + "%"));
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query += " AND phone ILIKE @phone";
                parameters.Add(new NpgsqlParameter("phone", "%" + phone + "%"));
            }

            // ��������� ������
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // ��������� ��� ��������� � �������
                        cmd.Parameters.AddRange(parameters.ToArray());

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);  // ���������� DataTable ������� �� ����
                            dataGridView.DataSource = dt;  // ���������� DataGridView � ������������ ������
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� ������: {ex.Message}");
                }
            }
        }

    }
}
