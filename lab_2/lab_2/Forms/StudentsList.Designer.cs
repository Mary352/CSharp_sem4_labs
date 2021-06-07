
namespace lab_2
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
            this.studentsListBox = new System.Windows.Forms.ListBox();
            this.createStudButt = new System.Windows.Forms.Button();
            this.delStudButt = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentsListBox
            // 
            this.studentsListBox.FormattingEnabled = true;
            this.studentsListBox.ItemHeight = 16;
            this.studentsListBox.Location = new System.Drawing.Point(27, 23);
            this.studentsListBox.Name = "studentsListBox";
            this.studentsListBox.Size = new System.Drawing.Size(696, 276);
            this.studentsListBox.TabIndex = 0;
            // 
            // createStudButt
            // 
            this.createStudButt.Location = new System.Drawing.Point(767, 23);
            this.createStudButt.Name = "createStudButt";
            this.createStudButt.Size = new System.Drawing.Size(147, 39);
            this.createStudButt.TabIndex = 1;
            this.createStudButt.Text = "Новый студент";
            this.createStudButt.UseVisualStyleBackColor = true;
            this.createStudButt.Click += new System.EventHandler(this.createStudButt_Click);
            // 
            // delStudButt
            // 
            this.delStudButt.Location = new System.Drawing.Point(767, 100);
            this.delStudButt.Name = "delStudButt";
            this.delStudButt.Size = new System.Drawing.Size(147, 39);
            this.delStudButt.TabIndex = 1;
            this.delStudButt.Text = "Удалить студента";
            this.delStudButt.UseVisualStyleBackColor = true;
            this.delStudButt.Click += new System.EventHandler(this.delStudButt_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(767, 179);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(147, 39);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(767, 260);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(147, 39);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // StudentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 327);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.delStudButt);
            this.Controls.Add(this.createStudButt);
            this.Controls.Add(this.studentsListBox);
            this.Name = "StudentsList";
            this.Text = "StudentsList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox studentsListBox;
        private System.Windows.Forms.Button createStudButt;
        private System.Windows.Forms.Button delStudButt;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button importButton;
    }
}