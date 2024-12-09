using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project
{
    public static class DatabaseManager
    {
        // Строка подключения к базе данных PostgreSQL
        private static string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=TelephoneManager";

        #region Отправка сформированного запроса
        /// <summary>
        /// Выполняет запрос к базе данных.
        /// </summary>
        public static DataTable ExecuteQuery(string query, List<NpgsqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Лучше пробрасывать исключение в вызывающий код, чтобы он мог обработать его
                    throw new Exception("Ошибка при выполнении запроса к базе данных.", ex);
                }
            }
            return dt;
        }
        #endregion
        #region Формирование SQL запроса
        /// <summary>
        /// Добавляет новую запись в таблицу PhoneBook с использованием CTE и обработкой уникальных значений.
        /// </summary>
        public static void AddRecord(string familia, string personName, string otchestvo, string street, string house,
                                      string korpys, string apartment, string phone)
        {
            string query = @"
                            WITH 
                            inserted_surname AS (
                                INSERT INTO Surnames(value) VALUES (@surname)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_name AS (
                                INSERT INTO Names(value) VALUES (@name)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_otchestvo AS (
                                INSERT INTO Otchestva(value) VALUES (@otchestvo)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_street AS (
                                INSERT INTO Streets(value) VALUES (@street)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_house AS (
                                INSERT INTO Houses(value) VALUES (@house)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_corpus AS (
                                INSERT INTO Corps(value) VALUES (@korpus)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_apartment AS (
                                INSERT INTO Apartments(value) VALUES (@apartment)
                                ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
                                RETURNING id
                            ),
                            inserted_phone AS (
                                INSERT INTO Phones(value) VALUES (@phone)
                                ON CONFLICT (value) DO NOTHING
                                RETURNING id
                            )
                            INSERT INTO PhoneBook(surname_id, name_id, patronymic_id, street_id, house_id, korpus_id, apartment_id, phone_id)
                            VALUES (
                                (SELECT id FROM inserted_surname),
                                (SELECT id FROM inserted_name),
                                (SELECT id FROM inserted_otchestvo),
                                (SELECT id FROM inserted_street),
                                (SELECT id FROM inserted_house),
                                (SELECT id FROM inserted_corpus),
                                (SELECT id FROM inserted_apartment),
                                (SELECT id FROM inserted_phone)
                            );";

            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("surname", familia),
                new NpgsqlParameter("name", personName),
                new NpgsqlParameter("otchestvo", (object)otchestvo ?? DBNull.Value),
                new NpgsqlParameter("street", (object)street ?? DBNull.Value),
                new NpgsqlParameter("house", (object)house ?? DBNull.Value),
                new NpgsqlParameter("korpus", (object)korpys ?? DBNull.Value),
                new NpgsqlParameter("apartment", (object)apartment ?? DBNull.Value),
                new NpgsqlParameter("phone", phone)
            };

            try
            {
                ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                // Логируем ошибку или обрабатываем её, если нужно
                throw new Exception("Ошибка при добавлении записи в PhoneBook.", ex);
            }
        }


        /// <summary>
        /// Удаляет запись из таблицы Phonebook.
        /// </summary>
        public static void DeleteRecord(int id)
        {
            string query = "DELETE FROM Phonebook WHERE id = @id";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("id", id)
            };

            ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Поиск записей в таблице Phonebook по заданным критериям.
        /// </summary>
        public static DataTable FindRecords(string familia, string personName, string otchestvo, string street, string house,
                                            string korpys, string apartment, string phone)
        {
            string query = "SELECT * FROM Phonebook WHERE 1 = 1";
            var parameters = new List<NpgsqlParameter>();

            if (!string.IsNullOrWhiteSpace(familia)) { query += " AND famillia ILIKE @familia"; parameters.Add(new NpgsqlParameter("familia", "%" + familia + "%")); }
            if (!string.IsNullOrWhiteSpace(personName)) { query += " AND person_name ILIKE @personName"; parameters.Add(new NpgsqlParameter("personName", "%" + personName + "%")); }
            if (!string.IsNullOrWhiteSpace(otchestvo)) { query += " AND otchestvo ILIKE @otchestvo"; parameters.Add(new NpgsqlParameter("otchestvo", "%" + otchestvo + "%")); }
            if (!string.IsNullOrWhiteSpace(street)) { query += " AND street ILIKE @street"; parameters.Add(new NpgsqlParameter("street", "%" + street + "%")); }
            if (!string.IsNullOrWhiteSpace(house)) { query += " AND house ILIKE @house"; parameters.Add(new NpgsqlParameter("house", "%" + house + "%")); }
            if (!string.IsNullOrWhiteSpace(korpys)) { query += " AND korpys ILIKE @korpys"; parameters.Add(new NpgsqlParameter("korpys", "%" + korpys + "%")); }
            if (!string.IsNullOrWhiteSpace(apartment)) { query += " AND apartment ILIKE @apartment"; parameters.Add(new NpgsqlParameter("apartment", "%" + apartment + "%")); }
            if (!string.IsNullOrWhiteSpace(phone)) { query += " AND phone ILIKE @phone"; parameters.Add(new NpgsqlParameter("phone", "%" + phone + "%")); }

            return ExecuteQuery(query, parameters);
        }

        /// <summary>
        /// Получает все записи из таблицы Phonebook.
        /// </summary>
        public static DataTable GetAllRecords(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return ExecuteQuery(query);
        }
        #endregion
    }
}
