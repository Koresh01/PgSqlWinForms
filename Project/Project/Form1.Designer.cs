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
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 297);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(1040, 372);
            dataGridView.TabIndex = 0;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(669, 242);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(77, 49);
            addBtn.TabIndex = 1;
            addBtn.Text = "Добавить";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += OnAddBtnClick;
            // 
            // textBoxSurname
            // 
            textBoxSurname.Location = new Point(76, 18);
            textBoxSurname.Name = "textBoxSurname";
            textBoxSurname.Size = new Size(144, 23);
            textBoxSurname.TabIndex = 2;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(76, 47);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(144, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxOtchestvo
            // 
            textBoxOtchestvo.Location = new Point(76, 76);
            textBoxOtchestvo.Name = "textBoxOtchestvo";
            textBoxOtchestvo.Size = new Size(144, 23);
            textBoxOtchestvo.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 5;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 50);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Отчество";
            // 
            // textBoxStreet
            // 
            textBoxStreet.Location = new Point(357, 18);
            textBoxStreet.Name = "textBoxStreet";
            textBoxStreet.Size = new Size(144, 23);
            textBoxStreet.TabIndex = 8;
            // 
            // textBoxHouse
            // 
            textBoxHouse.Location = new Point(357, 47);
            textBoxHouse.Name = "textBoxHouse";
            textBoxHouse.Size = new Size(144, 23);
            textBoxHouse.TabIndex = 9;
            // 
            // textBoxKorpys
            // 
            textBoxKorpys.Location = new Point(357, 76);
            textBoxKorpys.Name = "textBoxKorpys";
            textBoxKorpys.Size = new Size(144, 23);
            textBoxKorpys.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(310, 21);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 11;
            label4.Text = "Улица";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(320, 50);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 12;
            label5.Text = "Дом";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(304, 79);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 13;
            label6.Text = "Корпус";
            // 
            // textBoxApartment
            // 
            textBoxApartment.Location = new Point(639, 31);
            textBoxApartment.Name = "textBoxApartment";
            textBoxApartment.Size = new Size(95, 23);
            textBoxApartment.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(579, 34);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 15;
            label7.Text = "Комната";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(639, 60);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(188, 23);
            textBoxPhone.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(579, 63);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 17;
            label8.Text = "Телефон";
            // 
            // delBtn
            // 
            delBtn.Location = new Point(750, 242);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(77, 49);
            delBtn.TabIndex = 18;
            delBtn.Text = "Удалить";
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += OnDeleteBtnClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 681);
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
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
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
    }
}