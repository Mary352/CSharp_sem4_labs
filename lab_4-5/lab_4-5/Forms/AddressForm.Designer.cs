
namespace lab_4_5
{
    partial class AddressForm
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
            this.streetTxtB = new System.Windows.Forms.TextBox();
            this.cityTxtB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.houseTxtB = new System.Windows.Forms.TextBox();
            this.aptTxtB = new System.Windows.Forms.TextBox();
            this.OKaddrButton = new System.Windows.Forms.Button();
            this.postcodeTxtB = new System.Windows.Forms.TextBox();
            this.countryTxtB = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // streetTxtB
            // 
            this.streetTxtB.Location = new System.Drawing.Point(162, 124);
            this.streetTxtB.Name = "streetTxtB";
            this.streetTxtB.Size = new System.Drawing.Size(225, 22);
            this.streetTxtB.TabIndex = 21;
            // 
            // cityTxtB
            // 
            this.cityTxtB.Location = new System.Drawing.Point(162, 59);
            this.cityTxtB.Name = "cityTxtB";
            this.cityTxtB.Size = new System.Drawing.Size(225, 22);
            this.cityTxtB.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Улица";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Индекс";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(32, 65);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(48, 17);
            this.cityLabel.TabIndex = 16;
            this.cityLabel.Text = "Город";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Дом";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Квартира";
            // 
            // houseTxtB
            // 
            this.houseTxtB.Location = new System.Drawing.Point(162, 158);
            this.houseTxtB.Name = "houseTxtB";
            this.houseTxtB.Size = new System.Drawing.Size(225, 22);
            this.houseTxtB.TabIndex = 20;
            // 
            // aptTxtB
            // 
            this.aptTxtB.Location = new System.Drawing.Point(162, 190);
            this.aptTxtB.Name = "aptTxtB";
            this.aptTxtB.Size = new System.Drawing.Size(225, 22);
            this.aptTxtB.TabIndex = 21;
            // 
            // OKaddrButton
            // 
            this.OKaddrButton.Location = new System.Drawing.Point(143, 258);
            this.OKaddrButton.Name = "OKaddrButton";
            this.OKaddrButton.Size = new System.Drawing.Size(135, 34);
            this.OKaddrButton.TabIndex = 24;
            this.OKaddrButton.Text = "ОК";
            this.OKaddrButton.UseVisualStyleBackColor = true;
            this.OKaddrButton.Click += new System.EventHandler(this.OKaddrButton_Click);
            // 
            // postcodeTxtB
            // 
            this.postcodeTxtB.Location = new System.Drawing.Point(162, 94);
            this.postcodeTxtB.Name = "postcodeTxtB";
            this.postcodeTxtB.Size = new System.Drawing.Size(225, 22);
            this.postcodeTxtB.TabIndex = 25;
            // 
            // countryTxtB
            // 
            this.countryTxtB.Location = new System.Drawing.Point(162, 29);
            this.countryTxtB.Name = "countryTxtB";
            this.countryTxtB.Size = new System.Drawing.Size(225, 22);
            this.countryTxtB.TabIndex = 19;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(32, 35);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(56, 17);
            this.countryLabel.TabIndex = 16;
            this.countryLabel.Text = "Страна";
            // 
            // AddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 304);
            this.Controls.Add(this.postcodeTxtB);
            this.Controls.Add(this.OKaddrButton);
            this.Controls.Add(this.aptTxtB);
            this.Controls.Add(this.streetTxtB);
            this.Controls.Add(this.houseTxtB);
            this.Controls.Add(this.countryTxtB);
            this.Controls.Add(this.cityTxtB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.cityLabel);
            this.Name = "AddressForm";
            this.Text = "Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox streetTxtB;
        private System.Windows.Forms.TextBox cityTxtB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox houseTxtB;
        private System.Windows.Forms.TextBox aptTxtB;
        private System.Windows.Forms.Button OKaddrButton;
        private System.Windows.Forms.TextBox postcodeTxtB;
        private System.Windows.Forms.TextBox countryTxtB;
        private System.Windows.Forms.Label countryLabel;
    }
}