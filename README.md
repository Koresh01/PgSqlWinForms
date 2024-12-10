![image](https://github.com/user-attachments/assets/7bf0378a-d95c-4fae-b47b-ef55ff8ce236)Эта работа демонстрирует, как можно с помощью C# winForms сделать GUI программу для работы с вашей PostgreSQL базой данных.

PostgreSQL - это что то вроде программы, которую вы можете скачать https://www.postgresql.org/download/ и установить на свой ПК.
ВНИМАНИЕ!!! Во время установки вам предложат "зарегестрироваться", а именно:
* создать пароль
* оставить username postgres - без изменений.

Это те самые логин и пароль, зная которые вы сможете подключиться в коде к вашей БД(базе данных). Причем из любого языка программирования.
Вот в С# например вам лишь потребуется установить библиотеку Npgsql. В Visual Studio (которая НЕ VS Code) можно сделать это так:

 ![Снимок экрана 2024-12-10 030739](https://github.com/user-attachments/assets/9cc87144-30a7-4aa8-b719-66c5c5ef71a2)

Короче запоминаем логин и пароль...

Далее, чтоб у вас всё работало, вам необходимо создать БазуДанных в программе PostgreSQL. Да! В PostgreSQL вы можете создавать несколько Баз Данных.

База Данных - это набор таблиц, которые как правило связаны между собой, вот к примеру:
![Снимок экрана 2024-12-10 031215](https://github.com/user-attachments/assets/7036cd7f-2f0f-4559-903d-d3e169acde07)

Короче вот как создать базу данных:
![image](https://github.com/user-attachments/assets/63aa232b-2ef3-448f-ba9b-bd94f0fb4599)


И тут снова запоминаем название, которое вы даёте своей БД-шке. Вообщем то это всё что вам нужно запомнить. В С# коде вы будете писать так:
```C#
// Строка подключения к базе данных PostgreSQL
private static string connectionString = "Host=localhost;Username=postgres;Password=ПАРОЛЬ;Database=НазваниеБД";
```

И теперь самое сложное. Суть моего задания была в том, чтобы я создал GUI, для управления 5 таблицами в БД под названием "TelephoneManager".
PhoneBook - главная таблица с полями:
имя, фамилия, отчество, адрес...

И таблицы которые, собственно хранят эти имена, отчества, адреса.

Получается что в PhoneBook у нас НЕ хранятся текстовые значения улиц, имен, домов... И вот преподаватель хотел чтоб мы научились писать joins, и всё такое...


Так что чтоюы у вас всё работало, необходимо создать эти таблицы, для этого:
![image](https://github.com/user-attachments/assets/1749075f-a4aa-44ca-a5c4-80111ee2ea92)
И вписываем sql команды:
```sql
-- Создаем таблицу для хранения фамилий
CREATE TABLE Surnames (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL    -- Фамилия, обязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения имен
CREATE TABLE Names (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL       -- Имя, обязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения отчеств
CREATE TABLE Otchestva (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL          -- Отчество, необязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения названий улиц
CREATE TABLE Streets (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL    -- Название улицы, обязательное поле, строка длиной до 100 символов
);

-- Создаем таблицу для хранения номеров домов
CREATE TABLE Houses (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL      -- Номер дома, обязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения корпусов (дополнение к номеру дома)
CREATE TABLE Corps (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL              -- Номер корпуса, необязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения номеров квартир
CREATE TABLE Apartments (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL           -- Номер квартиры, необязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения телефонных номеров
CREATE TABLE Phones (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL      -- Телефонный номер, обязательное поле, строка длиной до 15 символов
);

-- Создаем основную таблицу телефонного справочника
CREATE TABLE PhoneBook (
    id SERIAL PRIMARY KEY,              -- Уникальный идентификатор записи (автоинкремент)
    surname_id INT REFERENCES Surnames(id),      -- Ссылка на фамилию в таблице Surnames
    name_id INT REFERENCES Names(id),            -- Ссылка на имя в таблице Names
    patronymic_id INT REFERENCES Otchestva(id),-- Ссылка на отчество в таблице Otchestva
    street_id INT REFERENCES Streets(id),        -- Ссылка на улицу в таблице Streets
    house_id INT REFERENCES Houses(id),          -- Ссылка на дом в таблице Houses
    korpus_id INT REFERENCES Corps(id),          -- Ссылка на корпус в таблице Corps
    apartment_id INT REFERENCES Apartments(id),  -- Ссылка на квартиру в таблице Apartments
    phone_id INT REFERENCES Phones(id)           -- Ссылка на телефон в таблице Phones
);
```
![image](https://github.com/user-attachments/assets/9ad68608-19ee-4b3c-9e9b-7bc6e974ec80)


Поздравляю! Теперь можете запускать Visual Studio проект который и лежит в этом репозитории. 

Дополнительные sql команды, если вдруг инересно:
```sql
-- Создаем таблицу для хранения фамилий
CREATE TABLE Surnames (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL    -- Фамилия, обязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения имен
CREATE TABLE Names (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL       -- Имя, обязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения отчеств
CREATE TABLE Otchestva (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL          -- Отчество, необязательное поле, строка длиной до 50 символов
);

-- Создаем таблицу для хранения названий улиц
CREATE TABLE Streets (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL    -- Название улицы, обязательное поле, строка длиной до 100 символов
);

-- Создаем таблицу для хранения номеров домов
CREATE TABLE Houses (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL      -- Номер дома, обязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения корпусов (дополнение к номеру дома)
CREATE TABLE Corps (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL              -- Номер корпуса, необязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения номеров квартир
CREATE TABLE Apartments (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL           -- Номер квартиры, необязательное поле, строка длиной до 10 символов
);

-- Создаем таблицу для хранения телефонных номеров
CREATE TABLE Phones (
    id SERIAL PRIMARY KEY,          -- Уникальный идентификатор записи (автоинкремент)
    value VARCHAR(50) UNIQUE NOT NULL      -- Телефонный номер, обязательное поле, строка длиной до 15 символов
);

-- Создаем основную таблицу телефонного справочника
CREATE TABLE PhoneBook (
    id SERIAL PRIMARY KEY,              -- Уникальный идентификатор записи (автоинкремент)
    surname_id INT REFERENCES Surnames(id),      -- Ссылка на фамилию в таблице Surnames
    name_id INT REFERENCES Names(id),            -- Ссылка на имя в таблице Names
    patronymic_id INT REFERENCES Otchestva(id),-- Ссылка на отчество в таблице Otchestva
    street_id INT REFERENCES Streets(id),        -- Ссылка на улицу в таблице Streets
    house_id INT REFERENCES Houses(id),          -- Ссылка на дом в таблице Houses
    korpus_id INT REFERENCES Corps(id),          -- Ссылка на корпус в таблице Corps
    apartment_id INT REFERENCES Apartments(id),  -- Ссылка на квартиру в таблице Apartments
    phone_id INT REFERENCES Phones(id)           -- Ссылка на телефон в таблице Phones
);

-- Показать таблицы
SELECT * FROM Surnames
SELECT * FROM Names
SELECT * FROM Otchestva
SELECT * FROM Streets
SELECT * FROM Houses
SELECT * FROM Corps
SELECT * FROM Apartments
SELECT * FROM Phones

SELECT * FROM PhoneBook
-- 

-- Удаление таблиц
DROP TABLE Surnames;
DROP TABLE Names;
DROP TABLE Otchestva;
DROP TABLE Streets;
DROP TABLE Houses;
DROP TABLE Corps;
DROP TABLE Apartments;
DROP TABLE Phones;

DROP TABLE Phonebook;
--

-- Отчистка таблицы
TRUNCATE TABLE Surnames
TRUNCATE TABLE Names
TRUNCATE TABLE Otchestva
TRUNCATE TABLE Streets
TRUNCATE TABLE Houses
TRUNCATE TABLE Corps
TRUNCATE TABLE Apartments
TRUNCATE TABLE Phones

TRUNCATE TABLE PhoneBook
--



-- Отображение таблицы PhoneBook с текстовыми значениями:
SELECT 
    pb.id AS phonebook_id,
    s.value AS surname,
    n.value AS name,
    o.value AS patronymic,
    st.value AS street,
    h.value AS house,
    c.value AS korpus,
    a.value AS apartment,
    p.value AS phone
FROM PhoneBook pb
LEFT JOIN Surnames s ON pb.surname_id = s.id
LEFT JOIN Names n ON pb.name_id = n.id
LEFT JOIN Otchestva o ON pb.patronymic_id = o.id
LEFT JOIN Streets st ON pb.street_id = st.id
LEFT JOIN Houses h ON pb.house_id = h.id
LEFT JOIN Corps c ON pb.korpus_id = c.id
LEFT JOIN Apartments a ON pb.apartment_id = a.id
LEFT JOIN Phones p ON pb.phone_id = p.id;
--



-- Добавление записи в PhoneBook:
WITH 
inserted_surname AS (
    INSERT INTO Surnames(value) VALUES ('Иванов')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_name AS (
    INSERT INTO Names(value) VALUES ('Иван')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_otchestvo AS (
    INSERT INTO Otchestva(value) VALUES ('Иваныч')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_street AS (
    INSERT INTO Streets(value) VALUES ('Виноградная')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_house AS (
    INSERT INTO Houses(value) VALUES ('17А')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_corpus AS (
    INSERT INTO Corps(value) VALUES ('3')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_apartment AS (
    INSERT INTO Apartments(value) VALUES ('1420')
    ON CONFLICT (value) DO UPDATE SET value = EXCLUDED.value
    RETURNING id
),
inserted_phone AS (
    INSERT INTO Phones(value) VALUES ('+79001234567')
    ON CONFLICT (value) DO NOTHING
    RETURNING id
)
INSERT INTO PhoneBook(surname_id, name_id, patronymic_id, street_id, house_id, korpus_id, apartment_id, phone_id)	-- названия столбцов
VALUES (
    (SELECT id FROM inserted_surname),
    (SELECT id FROM inserted_name),
    (SELECT id FROM inserted_otchestvo),
	(SELECT id FROM inserted_street),
	(SELECT id FROM inserted_house),
	(SELECT id FROM inserted_corpus),
	(SELECT id FROM inserted_apartment),
    (SELECT id FROM inserted_phone)
);

-- Команда для очистки всех таблиц:
TRUNCATE TABLE 
    PhoneBook,
    Surnames,
    Names,
    Otchestva,
    Streets,
    Houses,
    Corps,
    Apartments,
    Phones

RESTART IDENTITY CASCADE;

/*
Что делает эта команда:
TRUNCATE TABLE:
Удаляет все строки из перечисленных таблиц.
Быстрее, чем DELETE, так как не записывает информацию об удалении в журнал транзакций.
RESTART IDENTITY:
Сбрасывает счётчики SERIAL (или GENERATED AS IDENTITY) на значение по умолчанию (1).
CASCADE:
Удаляет строки из таблиц, на которые есть ссылки через внешние ключи, чтобы избежать конфликтов.
*/
```


