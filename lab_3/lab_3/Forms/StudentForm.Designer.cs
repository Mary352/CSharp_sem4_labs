
namespace lab_3
{
    partial class StudentForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AddrButtShowForm = new System.Windows.Forms.Button();
            this.PlaceWorkButtShowForm = new System.Windows.Forms.Button();
            this.OKstudButton = new System.Windows.Forms.Button();
            this.surnameTxtB = new System.Windows.Forms.TextBox();
            this.nameTxtB = new System.Windows.Forms.TextBox();
            this.patronymicTxtB = new System.Windows.Forms.TextBox();
            this.dateBirthDTP = new System.Windows.Forms.DateTimePicker();
            this.avMarkMTxtB = new System.Windows.Forms.MaskedTextBox();
            this.groupNUD = new System.Windows.Forms.NumericUpDown();
            this.courseTrB = new System.Windows.Forms.TrackBar();
            this.specialityCmbB = new System.Windows.Forms.ComboBox();
            this.genderCmbB = new System.Windows.Forms.ComboBox();
            this.ageMTxtB = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseTrB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Возраст";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Специальность";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Дата рождения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Курс";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Группа";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Средний балл";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Пол";
            // 
            // AddrButtShowForm
            // 
            this.AddrButtShowForm.Location = new System.Drawing.Point(35, 432);
            this.AddrButtShowForm.Name = "AddrButtShowForm";
            this.AddrButtShowForm.Size = new System.Drawing.Size(75, 34);
            this.AddrButtShowForm.TabIndex = 10;
            this.AddrButtShowForm.Text = "Адрес";
            this.AddrButtShowForm.UseVisualStyleBackColor = true;
            this.AddrButtShowForm.Click += new System.EventHandler(this.AddrButtShowForm_Click);
            // 
            // PlaceWorkButtShowForm
            // 
            this.PlaceWorkButtShowForm.Location = new System.Drawing.Point(135, 432);
            this.PlaceWorkButtShowForm.Name = "PlaceWorkButtShowForm";
            this.PlaceWorkButtShowForm.Size = new System.Drawing.Size(135, 34);
            this.PlaceWorkButtShowForm.TabIndex = 11;
            this.PlaceWorkButtShowForm.Text = "Место работы";
            this.PlaceWorkButtShowForm.UseVisualStyleBackColor = true;
            this.PlaceWorkButtShowForm.Click += new System.EventHandler(this.PlaceWorkButtShowForm_Click);
            // 
            // OKstudButton
            // 
            this.OKstudButton.Location = new System.Drawing.Point(162, 493);
            this.OKstudButton.Name = "OKstudButton";
            this.OKstudButton.Size = new System.Drawing.Size(135, 34);
            this.OKstudButton.TabIndex = 12;
            this.OKstudButton.Text = "ОК";
            this.OKstudButton.UseVisualStyleBackColor = true;
            this.OKstudButton.Click += new System.EventHandler(this.OKstudButton_Click);
            // 
            // surnameTxtB
            // 
            this.surnameTxtB.Location = new System.Drawing.Point(165, 41);
            this.surnameTxtB.Name = "surnameTxtB";
            this.surnameTxtB.Size = new System.Drawing.Size(225, 22);
            this.surnameTxtB.TabIndex = 13;
            // 
            // nameTxtB
            // 
            this.nameTxtB.Location = new System.Drawing.Point(165, 74);
            this.nameTxtB.Name = "nameTxtB";
            this.nameTxtB.Size = new System.Drawing.Size(225, 22);
            this.nameTxtB.TabIndex = 14;
            // 
            // patronymicTxtB
            // 
            this.patronymicTxtB.Location = new System.Drawing.Point(165, 106);
            this.patronymicTxtB.Name = "patronymicTxtB";
            this.patronymicTxtB.Size = new System.Drawing.Size(225, 22);
            this.patronymicTxtB.TabIndex = 15;
            // 
            // dateBirthDTP
            // 
            this.dateBirthDTP.Location = new System.Drawing.Point(165, 207);
            this.dateBirthDTP.Name = "dateBirthDTP";
            this.dateBirthDTP.Size = new System.Drawing.Size(225, 22);
            this.dateBirthDTP.TabIndex = 20;
            // 
            // avMarkMTxtB
            // 
            this.avMarkMTxtB.Location = new System.Drawing.Point(165, 346);
            this.avMarkMTxtB.Mask = "00.0";
            this.avMarkMTxtB.Name = "avMarkMTxtB";
            this.avMarkMTxtB.Size = new System.Drawing.Size(225, 22);
            this.avMarkMTxtB.TabIndex = 22;
            // 
            // groupNUD
            // 
            this.groupNUD.Location = new System.Drawing.Point(165, 312);
            this.groupNUD.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.groupNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.groupNUD.Name = "groupNUD";
            this.groupNUD.Size = new System.Drawing.Size(225, 22);
            this.groupNUD.TabIndex = 23;
            this.groupNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // courseTrB
            // 
            this.courseTrB.Location = new System.Drawing.Point(165, 250);
            this.courseTrB.Maximum = 5;
            this.courseTrB.Minimum = 1;
            this.courseTrB.Name = "courseTrB";
            this.courseTrB.Size = new System.Drawing.Size(225, 56);
            this.courseTrB.TabIndex = 24;
            this.courseTrB.Value = 1;
            // 
            // specialityCmbB
            // 
            this.specialityCmbB.FormattingEnabled = true;
            this.specialityCmbB.Items.AddRange(new object[] {
            "АТПиП",
            "БТ",
            "ДЭиВИ",
            "ИД",
            "ИСИТ",
            "КиПИизКМ",
            "ЛИЛК",
            "ЛХ",
            "МД",
            "МиАХПиПСМ",
            "МК",
            "МОДП",
            "МОЛП",
            "ООСиРИПР",
            "ПИОТТ",
            "ПОИБМС",
            "ПОиСОИ",
            "ПОИТ",
            "СПС",
            "ТДО",
            "ТДП",
            "ТиП",
            "ТЛП",
            "ТПП",
            "ТЭХП",
            "ФХМП",
            "ХТНВМиИ",
            "ХТНМ",
            "ХТОМ",
            "ХТПД",
            "ЭТЭМ",
            "ЭУП"});
            this.specialityCmbB.Location = new System.Drawing.Point(165, 175);
            this.specialityCmbB.Name = "specialityCmbB";
            this.specialityCmbB.Size = new System.Drawing.Size(225, 24);
            this.specialityCmbB.TabIndex = 25;
            this.specialityCmbB.Text = "АТПиП";
            // 
            // genderCmbB
            // 
            this.genderCmbB.FormattingEnabled = true;
            this.genderCmbB.Items.AddRange(new object[] {
            "м",
            "ж"});
            this.genderCmbB.Location = new System.Drawing.Point(165, 376);
            this.genderCmbB.Name = "genderCmbB";
            this.genderCmbB.Size = new System.Drawing.Size(225, 24);
            this.genderCmbB.TabIndex = 25;
            this.genderCmbB.Text = "м";
            // 
            // ageMTxtB
            // 
            this.ageMTxtB.Location = new System.Drawing.Point(165, 140);
            this.ageMTxtB.Mask = "00";
            this.ageMTxtB.Name = "ageMTxtB";
            this.ageMTxtB.Size = new System.Drawing.Size(225, 22);
            this.ageMTxtB.TabIndex = 22;
            this.ageMTxtB.ValidatingType = typeof(int);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 557);
            this.Controls.Add(this.genderCmbB);
            this.Controls.Add(this.specialityCmbB);
            this.Controls.Add(this.courseTrB);
            this.Controls.Add(this.groupNUD);
            this.Controls.Add(this.ageMTxtB);
            this.Controls.Add(this.avMarkMTxtB);
            this.Controls.Add(this.dateBirthDTP);
            this.Controls.Add(this.patronymicTxtB);
            this.Controls.Add(this.nameTxtB);
            this.Controls.Add(this.surnameTxtB);
            this.Controls.Add(this.OKstudButton);
            this.Controls.Add(this.PlaceWorkButtShowForm);
            this.Controls.Add(this.AddrButtShowForm);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudentForm";
            this.Text = "Student";
            ((System.ComponentModel.ISupportInitialize)(this.groupNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseTrB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button AddrButtShowForm;
        private System.Windows.Forms.Button PlaceWorkButtShowForm;
        private System.Windows.Forms.Button OKstudButton;
        private System.Windows.Forms.TextBox surnameTxtB;
        private System.Windows.Forms.TextBox nameTxtB;
        private System.Windows.Forms.TextBox patronymicTxtB;
        private System.Windows.Forms.DateTimePicker dateBirthDTP;
        private System.Windows.Forms.MaskedTextBox avMarkMTxtB;
        private System.Windows.Forms.NumericUpDown groupNUD;
        private System.Windows.Forms.TrackBar courseTrB;
        private System.Windows.Forms.ComboBox specialityCmbB;
        private System.Windows.Forms.ComboBox genderCmbB;
        private System.Windows.Forms.MaskedTextBox ageMTxtB;
    }
}

