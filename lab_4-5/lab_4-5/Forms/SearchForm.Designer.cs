
namespace lab_4_5.Forms
{
    partial class SearchForm
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
            this.comboSearchOption = new System.Windows.Forms.ComboBox();
            this.buttonSortRam = new System.Windows.Forms.Button();
            this.buttonSortFreq = new System.Windows.Forms.Button();
            this.listSearchResult = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboSearchOption
            // 
            this.comboSearchOption.FormattingEnabled = true;
            this.comboSearchOption.Items.AddRange(new object[] {
            "MANUFACTURER",
            "MODEL"});
            this.comboSearchOption.Location = new System.Drawing.Point(292, 77);
            this.comboSearchOption.Name = "comboSearchOption";
            this.comboSearchOption.Size = new System.Drawing.Size(153, 24);
            this.comboSearchOption.TabIndex = 12;
            // 
            // buttonSortRam
            // 
            this.buttonSortRam.Location = new System.Drawing.Point(242, 452);
            this.buttonSortRam.Name = "buttonSortRam";
            this.buttonSortRam.Size = new System.Drawing.Size(220, 44);
            this.buttonSortRam.TabIndex = 11;
            this.buttonSortRam.Text = "Sort RAM";
            this.buttonSortRam.UseVisualStyleBackColor = true;
            // 
            // buttonSortFreq
            // 
            this.buttonSortFreq.Location = new System.Drawing.Point(19, 452);
            this.buttonSortFreq.Name = "buttonSortFreq";
            this.buttonSortFreq.Size = new System.Drawing.Size(220, 44);
            this.buttonSortFreq.TabIndex = 10;
            this.buttonSortFreq.Text = "Sort Frequency";
            this.buttonSortFreq.UseVisualStyleBackColor = true;
            // 
            // listSearchResult
            // 
            this.listSearchResult.FormattingEnabled = true;
            this.listSearchResult.HorizontalScrollbar = true;
            this.listSearchResult.ItemHeight = 16;
            this.listSearchResult.Location = new System.Drawing.Point(19, 122);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(443, 324);
            this.listSearchResult.TabIndex = 9;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(35, 61);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(251, 55);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(35, 24);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(410, 22);
            this.textSearch.TabIndex = 7;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.comboSearchOption);
            this.Controls.Add(this.buttonSortRam);
            this.Controls.Add(this.buttonSortFreq);
            this.Controls.Add(this.listSearchResult);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textSearch);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSearchOption;
        private System.Windows.Forms.Button buttonSortRam;
        private System.Windows.Forms.Button buttonSortFreq;
        private System.Windows.Forms.ListBox listSearchResult;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textSearch;
    }
}