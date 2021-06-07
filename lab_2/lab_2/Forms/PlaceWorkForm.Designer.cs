
namespace lab_2.Forms
{
    partial class PlaceWorkForm
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
            this.OKpwfButton = new System.Windows.Forms.Button();
            this.companyTxtB = new System.Windows.Forms.TextBox();
            this.positionTxtB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.experienceMTxtB = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // OKpwfButton
            // 
            this.OKpwfButton.Location = new System.Drawing.Point(140, 157);
            this.OKpwfButton.Name = "OKpwfButton";
            this.OKpwfButton.Size = new System.Drawing.Size(135, 34);
            this.OKpwfButton.TabIndex = 31;
            this.OKpwfButton.Text = "ОК";
            this.OKpwfButton.UseVisualStyleBackColor = true;
            this.OKpwfButton.Click += new System.EventHandler(this.OKpwfButton_Click);
            // 
            // companyTxtB
            // 
            this.companyTxtB.Location = new System.Drawing.Point(157, 25);
            this.companyTxtB.Name = "companyTxtB";
            this.companyTxtB.Size = new System.Drawing.Size(225, 22);
            this.companyTxtB.TabIndex = 30;
            // 
            // positionTxtB
            // 
            this.positionTxtB.Location = new System.Drawing.Point(157, 59);
            this.positionTxtB.Name = "positionTxtB";
            this.positionTxtB.Size = new System.Drawing.Size(225, 22);
            this.positionTxtB.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Стаж";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Должность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Компания";
            // 
            // experienceMTxtB
            // 
            this.experienceMTxtB.Location = new System.Drawing.Point(157, 91);
            this.experienceMTxtB.Mask = "00";
            this.experienceMTxtB.Name = "experienceMTxtB";
            this.experienceMTxtB.Size = new System.Drawing.Size(225, 22);
            this.experienceMTxtB.TabIndex = 32;
            this.experienceMTxtB.ValidatingType = typeof(int);
            // 
            // PlaceWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 209);
            this.Controls.Add(this.experienceMTxtB);
            this.Controls.Add(this.OKpwfButton);
            this.Controls.Add(this.companyTxtB);
            this.Controls.Add(this.positionTxtB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "PlaceWorkForm";
            this.Text = "PlaceWork";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKpwfButton;
        private System.Windows.Forms.TextBox companyTxtB;
        private System.Windows.Forms.TextBox positionTxtB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox experienceMTxtB;
    }
}