
namespace lab_3
{
    partial class StudentsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsList));
            this.studentsListBox = new System.Windows.Forms.ListBox();
            this.createStudButt = new System.Windows.Forms.Button();
            this.delStudButt = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.comboSearchOption = new System.Windows.Forms.ComboBox();
            this.listSearchResult = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonExpSort = new System.Windows.Forms.Button();
            this.buttonGroupSort = new System.Windows.Forms.Button();
            this.buttonCourseSort = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripNumberOfElements = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLastAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.поискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортировкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentsListBox
            // 
            this.studentsListBox.FormattingEnabled = true;
            this.studentsListBox.ItemHeight = 16;
            this.studentsListBox.Location = new System.Drawing.Point(12, 102);
            this.studentsListBox.Name = "studentsListBox";
            this.studentsListBox.Size = new System.Drawing.Size(569, 276);
            this.studentsListBox.TabIndex = 0;
            // 
            // createStudButt
            // 
            this.createStudButt.Location = new System.Drawing.Point(607, 102);
            this.createStudButt.Name = "createStudButt";
            this.createStudButt.Size = new System.Drawing.Size(147, 39);
            this.createStudButt.TabIndex = 1;
            this.createStudButt.Text = "Новый студент";
            this.createStudButt.UseVisualStyleBackColor = true;
            this.createStudButt.Click += new System.EventHandler(this.createStudButt_Click);
            // 
            // delStudButt
            // 
            this.delStudButt.Location = new System.Drawing.Point(607, 179);
            this.delStudButt.Name = "delStudButt";
            this.delStudButt.Size = new System.Drawing.Size(147, 39);
            this.delStudButt.TabIndex = 1;
            this.delStudButt.Text = "Удалить студента";
            this.delStudButt.UseVisualStyleBackColor = true;
            this.delStudButt.Click += new System.EventHandler(this.delStudButt_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(607, 258);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(147, 39);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(607, 339);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(147, 39);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSearch,
            this.toolStripButtonSort,
            this.toolStripButtonSave,
            this.toolStripButtonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1117, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSearch.Text = "Поиск";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
            // 
            // toolStripButtonSort
            // 
            this.toolStripButtonSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSort.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSort.Image")));
            this.toolStripButtonSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSort.Name = "toolStripButtonSort";
            this.toolStripButtonSort.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSort.Text = "Сортировка";
            this.toolStripButtonSort.Click += new System.EventHandler(this.toolStripButtonSort_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonSave.Text = "Сохранить";
            this.toolStripButtonSave.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonAbout.Text = "О программе";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // comboSearchOption
            // 
            this.comboSearchOption.FormattingEnabled = true;
            this.comboSearchOption.Items.AddRange(new object[] {
            "ФИО",
            "Специальность",
            "Курс",
            "Средний балл"});
            this.comboSearchOption.Location = new System.Drawing.Point(665, 60);
            this.comboSearchOption.Name = "comboSearchOption";
            this.comboSearchOption.Size = new System.Drawing.Size(153, 24);
            this.comboSearchOption.TabIndex = 16;
            this.comboSearchOption.SelectedIndexChanged += new System.EventHandler(this.comboSearchOption_SelectedIndexChanged);
            // 
            // listSearchResult
            // 
            this.listSearchResult.FormattingEnabled = true;
            this.listSearchResult.HorizontalScrollbar = true;
            this.listSearchResult.ItemHeight = 16;
            this.listSearchResult.Location = new System.Drawing.Point(780, 102);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(239, 276);
            this.listSearchResult.TabIndex = 15;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(439, 59);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(203, 24);
            this.buttonSearch.TabIndex = 14;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(12, 59);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(410, 22);
            this.textSearch.TabIndex = 13;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // buttonExpSort
            // 
            this.buttonExpSort.Location = new System.Drawing.Point(12, 407);
            this.buttonExpSort.Name = "buttonExpSort";
            this.buttonExpSort.Size = new System.Drawing.Size(147, 39);
            this.buttonExpSort.TabIndex = 1;
            this.buttonExpSort.Text = "Стаж";
            this.buttonExpSort.UseVisualStyleBackColor = true;
            this.buttonExpSort.Click += new System.EventHandler(this.buttonExpSort_Click);
            // 
            // buttonGroupSort
            // 
            this.buttonGroupSort.Location = new System.Drawing.Point(197, 407);
            this.buttonGroupSort.Name = "buttonGroupSort";
            this.buttonGroupSort.Size = new System.Drawing.Size(147, 39);
            this.buttonGroupSort.TabIndex = 1;
            this.buttonGroupSort.Text = "Группа";
            this.buttonGroupSort.UseVisualStyleBackColor = true;
            this.buttonGroupSort.Click += new System.EventHandler(this.buttonGroupSort_Click);
            // 
            // buttonCourseSort
            // 
            this.buttonCourseSort.Location = new System.Drawing.Point(383, 407);
            this.buttonCourseSort.Name = "buttonCourseSort";
            this.buttonCourseSort.Size = new System.Drawing.Size(147, 39);
            this.buttonCourseSort.TabIndex = 1;
            this.buttonCourseSort.Text = "Курс";
            this.buttonCourseSort.UseVisualStyleBackColor = true;
            this.buttonCourseSort.Click += new System.EventHandler(this.buttonCourseSort_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDateTime,
            this.toolStripNumberOfElements,
            this.toolStripLastAction});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1117, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDateTime
            // 
            this.toolStripDateTime.Name = "toolStripDateTime";
            this.toolStripDateTime.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripNumberOfElements
            // 
            this.toolStripNumberOfElements.Name = "toolStripNumberOfElements";
            this.toolStripNumberOfElements.Size = new System.Drawing.Size(17, 20);
            this.toolStripNumberOfElements.Text = "0";
            // 
            // toolStripLastAction
            // 
            this.toolStripLastAction.Name = "toolStripLastAction";
            this.toolStripLastAction.Size = new System.Drawing.Size(0, 20);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поискToolStripMenuItem,
            this.сортировкаToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // поискToolStripMenuItem
            // 
            this.поискToolStripMenuItem.Name = "поискToolStripMenuItem";
            this.поискToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.поискToolStripMenuItem.Text = "Поиск";
            this.поискToolStripMenuItem.Click += new System.EventHandler(this.поискToolStripMenuItem_Click);
            // 
            // сортировкаToolStripMenuItem
            // 
            this.сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            this.сортировкаToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.сортировкаToolStripMenuItem.Text = "Сортировка";
            this.сортировкаToolStripMenuItem.Click += new System.EventHandler(this.сортировкаToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // StudentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 490);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboSearchOption);
            this.Controls.Add(this.listSearchResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonCourseSort);
            this.Controls.Add(this.buttonGroupSort);
            this.Controls.Add(this.buttonExpSort);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.delStudButt);
            this.Controls.Add(this.createStudButt);
            this.Controls.Add(this.studentsListBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StudentsList";
            this.Text = "StudentsList";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox studentsListBox;
        private System.Windows.Forms.Button createStudButt;
        private System.Windows.Forms.Button delStudButt;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSort;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ComboBox comboSearchOption;
        private System.Windows.Forms.ListBox listSearchResult;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button buttonExpSort;
        private System.Windows.Forms.Button buttonGroupSort;
        private System.Windows.Forms.Button buttonCourseSort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDateTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripNumberOfElements;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLastAction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem поискToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортировкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
    }
}