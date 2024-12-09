namespace Project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView = new DataGridView();
            bindingSource1 = new BindingSource(components);
            addBtn = new Button();
            textBoxSurname = new TextBox();
            textBoxName = new TextBox();
            textBoxOtchestvo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxStreet = new TextBox();
            textBoxHouse = new TextBox();
            textBoxKorpys = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxApartment = new TextBox();
            label7 = new Label();
            textBoxPhone = new TextBox();
            label8 = new Label();
            delBtn = new Button();
            findBtn = new Button();
            menuStrip1 = new MenuStrip();
            таблицыToolStripMenuItem = new ToolStripMenuItem();
            PhoneBookBtn = new ToolStripMenuItem();
            SurnamesBtn = new ToolStripMenuItem();
            NamesBtn = new ToolStripMenuItem();
            OtchestvaBtn = new ToolStripMenuItem();
            StreetsBtn = new ToolStripMenuItem();
            HousesBtn = new ToolStripMenuItem();
            CorpsBtn = new ToolStripMenuItem();
            ApartamentsBtn = new ToolStripMenuItem();
            TelephoneNumbersBtn = new ToolStripMenuItem();
            tableNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 200);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(1040, 469);
            dataGridView.TabIndex = 0;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(809, 145);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(77, 49);
            addBtn.TabIndex = 1;
            addBtn.Text = "Добавить";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += OnAddBtnClick;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(78, 54);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(144, 23);
            textBoxSurname.TabIndex = 2;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(78, 83);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(144, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxOtchestvo
            // 
            textBoxOtchestvo.Location = new Point(78, 112);
            textBoxOtchestvo.Name = "textBoxOtchestvo";
            textBoxOtchestvo.Size = new Size(144, 23);
            textBoxOtchestvo.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 57);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 5;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 86);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 115);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Отчество";
            // 
            // textBoxStreet
            // 
            textBoxStreet.Location = new Point(359, 54);
            textBoxStreet.Name = "textBoxStreet";
            textBoxStreet.Size = new Size(144, 23);
            textBoxStreet.TabIndex = 8;
            // 
            // textBoxHouse
            // 
            textBoxHouse.Location = new Point(359, 83);
            textBoxHouse.Name = "textBoxHouse";
            textBoxHouse.Size = new Size(144, 23);
            textBoxHouse.TabIndex = 9;
            // 
            // textBoxKorpys
            // 
            textBoxKorpys.Location = new Point(359, 112);
            textBoxKorpys.Name = "textBoxKorpys";
            textBoxKorpys.Size = new Size(144, 23);
            textBoxKorpys.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 57);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 11;
            label4.Text = "Улица";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 86);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 12;
            label5.Text = "Дом";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(306, 115);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 13;
            label6.Text = "Корпус";
            // 
            // textBoxApartment
            // 
            textBoxApartment.Location = new Point(641, 67);
            textBoxApartment.Name = "textBoxApartment";
            textBoxApartment.Size = new Size(95, 23);
            textBoxApartment.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(581, 70);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 15;
            label7.Text = "Комната";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(641, 96);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(188, 23);
            textBoxPhone.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(581, 99);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 17;
            label8.Text = "Телефон";
            // 
            // delBtn
            // 
            delBtn.Location = new Point(975, 145);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(77, 49);
            delBtn.TabIndex = 18;
            delBtn.Text = "Удалить";
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += OnDeleteBtnClick;
            // 
            // findBtn
            // 
            findBtn.Location = new Point(892, 145);
            findBtn.Name = "findBtn";
            findBtn.Size = new Size(77, 49);
            findBtn.TabIndex = 19;
            findBtn.Text = "Поиск";
            findBtn.UseVisualStyleBackColor = true;
            findBtn.Click += OnFindBtnClick;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonFace;
            menuStrip1.Items.AddRange(new ToolStripItem[] { таблицыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1064, 28);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            таблицыToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            таблицыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PhoneBookBtn, SurnamesBtn, NamesBtn, OtchestvaBtn, StreetsBtn, HousesBtn, CorpsBtn, ApartamentsBtn, TelephoneNumbersBtn });
            таблицыToolStripMenuItem.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            таблицыToolStripMenuItem.Size = new Size(83, 24);
            таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // PhoneBookBtn
            // 
            PhoneBookBtn.Name = "PhoneBookBtn";
            PhoneBookBtn.Size = new Size(206, 24);
            PhoneBookBtn.Text = "Телефонная книга";
            PhoneBookBtn.Click += PhoneBook_BtnClick;
            // 
            // SurnamesBtn
            // 
            SurnamesBtn.Name = "SurnamesBtn";
            SurnamesBtn.Size = new Size(206, 24);
            SurnamesBtn.Text = "Фамилии";
            SurnamesBtn.Click += SurnamesBtn_Click;
            // 
            // NamesBtn
            // 
            NamesBtn.Name = "NamesBtn";
            NamesBtn.Size = new Size(206, 24);
            NamesBtn.Text = "Имена";
            NamesBtn.Click += NamesBtn_Click;
            // 
            // OtchestvaBtn
            // 
            OtchestvaBtn.Name = "OtchestvaBtn";
            OtchestvaBtn.Size = new Size(206, 24);
            OtchestvaBtn.Text = "Отчества";
            OtchestvaBtn.Click += OtchestvaBtn_Click;
            // 
            // StreetsBtn
            // 
            StreetsBtn.Name = "StreetsBtn";
            StreetsBtn.Size = new Size(206, 24);
            StreetsBtn.Text = "Улицы";
            StreetsBtn.Click += StreetsBtn_Click;
            // 
            // HousesBtn
            // 
            HousesBtn.Name = "HousesBtn";
            HousesBtn.Size = new Size(206, 24);
            HousesBtn.Text = "Дома";
            HousesBtn.Click += HousesBtn_Click;
            // 
            // CorpsBtn
            // 
            CorpsBtn.Name = "CorpsBtn";
            CorpsBtn.Size = new Size(206, 24);
            CorpsBtn.Text = "Корпуса";
            CorpsBtn.Click += CorpsBtn_Click;
            // 
            // ApartamentsBtn
            // 
            ApartamentsBtn.Name = "ApartamentsBtn";
            ApartamentsBtn.Size = new Size(206, 24);
            ApartamentsBtn.Text = "Комнаты";
            ApartamentsBtn.Click += ApartamentsBtn_Click;
            // 
            // TelephoneNumbersBtn
            // 
            TelephoneNumbersBtn.Name = "TelephoneNumbersBtn";
            TelephoneNumbersBtn.Size = new Size(206, 24);
            TelephoneNumbersBtn.Text = "Телефоны";
            TelephoneNumbersBtn.Click += TelephoneNumbersBtn_Click;
            // 
            // tableNameLabel
            // 
            tableNameLabel.AutoSize = true;
            tableNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            tableNameLabel.Location = new Point(14, 157);
            tableNameLabel.Name = "tableNameLabel";
            tableNameLabel.Size = new Size(249, 37);
            tableNameLabel.TabIndex = 21;
            tableNameLabel.Text = "Название таблицы";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1064, 681);
            Controls.Add(tableNameLabel);
            Controls.Add(findBtn);
            Controls.Add(delBtn);
            Controls.Add(label8);
            Controls.Add(textBoxPhone);
            Controls.Add(label7);
            Controls.Add(textBoxApartment);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxKorpys);
            Controls.Add(textBoxHouse);
            Controls.Add(textBoxStreet);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxOtchestvo);
            Controls.Add(textBoxName);
            Controls.Add(textBoxSurname);
            Controls.Add(addBtn);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private BindingSource bindingSource1;
        private Button addBtn;
        private TextBox textBoxSurname;
        private TextBox textBoxName;
        private TextBox textBoxOtchestvo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxStreet;
        private TextBox textBoxHouse;
        private TextBox textBoxKorpys;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxApartment;
        private Label label7;
        private TextBox textBoxPhone;
        private Label label8;
        private Button delBtn;
        private Button findBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem таблицыToolStripMenuItem;
        private ToolStripMenuItem PhoneBookBtn;
        private ToolStripMenuItem SurnamesBtn;
        private ToolStripMenuItem NamesBtn;
        private ToolStripMenuItem OtchestvaBtn;
        private ToolStripMenuItem StreetsBtn;
        private ToolStripMenuItem HousesBtn;
        private ToolStripMenuItem CorpsBtn;
        private ToolStripMenuItem ApartamentsBtn;
        private ToolStripMenuItem TelephoneNumbersBtn;
        private Label tableNameLabel;
    }
}