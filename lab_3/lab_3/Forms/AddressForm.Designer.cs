
namespace lab_3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.houseTxtB = new System.Windows.Forms.TextBox();
            this.aptTxtB = new System.Windows.Forms.TextBox();
            this.postcodeMTxtB = new System.Windows.Forms.MaskedTextBox();
            this.OKaddrButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // streetTxtB
            // 
            this.streetTxtB.Location = new System.Drawing.Point(159, 89);
            this.streetTxtB.Name = "streetTxtB";
            this.streetTxtB.Size = new System.Drawing.Size(225, 22);
            this.streetTxtB.TabIndex = 21;
            // 
            // cityTxtB
            // 
            this.cityTxtB.Location = new System.Drawing.Point(159, 24);
            this.cityTxtB.Name = "cityTxtB";
            this.cityTxtB.Size = new System.Drawing.Size(225, 22);
            this.cityTxtB.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Улица";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Индекс";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Город";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Дом";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Квартира";
            // 
            // houseTxtB
            // 
            this.houseTxtB.Location = new System.Drawing.Point(159, 123);
            this.houseTxtB.Name = "houseTxtB";
            this.houseTxtB.Size = new System.Drawing.Size(225, 22);
            this.houseTxtB.TabIndex = 20;
            // 
            // aptTxtB
            // 
            this.aptTxtB.Location = new System.Drawing.Point(159, 155);
            this.aptTxtB.Name = "aptTxtB";
            this.aptTxtB.Size = new System.Drawing.Size(225, 22);
            this.aptTxtB.TabIndex = 21;
            // 
            // postcodeMTxtB
            // 
            this.postcodeMTxtB.Location = new System.Drawing.Point(159, 57);
            this.postcodeMTxtB.Mask = "000000";
            this.postcodeMTxtB.Name = "postcodeMTxtB";
            this.postcodeMTxtB.Size = new System.Drawing.Size(225, 22);
            this.postcodeMTxtB.TabIndex = 23;
            this.postcodeMTxtB.ValidatingType = typeof(int);
            // 
            // OKaddrButton
            // 
            this.OKaddrButton.Location = new System.Drawing.Point(145, 220);
            this.OKaddrButton.Name = "OKaddrButton";
            this.OKaddrButton.Size = new System.Drawing.Size(135, 34);
            this.OKaddrButton.TabIndex = 24;
            this.OKaddrButton.Text = "ОК";
            this.OKaddrButton.UseVisualStyleBackColor = true;
            this.OKaddrButton.Click += new System.EventHandler(this.OKaddrButton_Click);
            // 
            // AddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 272);
            this.Controls.Add(this.OKaddrButton);
            this.Controls.Add(this.postcodeMTxtB);
            this.Controls.Add(this.aptTxtB);
            this.Controls.Add(this.streetTxtB);
            this.Controls.Add(this.houseTxtB);
            this.Controls.Add(this.cityTxtB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox houseTxtB;
        private System.Windows.Forms.TextBox aptTxtB;
        private System.Windows.Forms.MaskedTextBox postcodeMTxtB;
        private System.Windows.Forms.Button OKaddrButton;
    }
}