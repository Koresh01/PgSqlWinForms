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
    }
}
