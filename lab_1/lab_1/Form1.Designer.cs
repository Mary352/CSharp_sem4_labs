
namespace lab_1
{
    partial class BinCalc
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
            this.andButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.orButton = new System.Windows.Forms.Button();
            this.xorButton = new System.Windows.Forms.Button();
            this.notButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.partClearButton = new System.Windows.Forms.Button();
            this.binButton = new System.Windows.Forms.Button();
            this.hexButton = new System.Windows.Forms.Button();
            this.octButton = new System.Windows.Forms.Button();
            this.decButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonE = new System.Windows.Forms.Button();
            this.buttonF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.minusButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // andButton
            // 
            this.andButton.Location = new System.Drawing.Point(25, 139);
            this.andButton.Name = "andButton";
            this.andButton.Size = new System.Drawing.Size(56, 31);
            this.andButton.TabIndex = 0;
            this.andButton.Text = "AND";
            this.andButton.UseVisualStyleBackColor = true;
            this.andButton.Click += new System.EventHandler(this.andButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(342, 71);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // orButton
            // 
            this.orButton.Location = new System.Drawing.Point(96, 139);
            this.orButton.Name = "orButton";
            this.orButton.Size = new System.Drawing.Size(56, 31);
            this.orButton.TabIndex = 1;
            this.orButton.Text = "OR";
            this.orButton.UseVisualStyleBackColor = true;
            this.orButton.Click += new System.EventHandler(this.andButton_Click);
            // 
            // xorButton
            // 
            this.xorButton.Location = new System.Drawing.Point(168, 139);
            this.xorButton.Name = "xorButton";
            this.xorButton.Size = new System.Drawing.Size(56, 31);
            this.xorButton.TabIndex = 2;
            this.xorButton.Text = "XOR";
            this.xorButton.UseVisualStyleBackColor = true;
            this.xorButton.Click += new System.EventHandler(this.andButton_Click);
            // 
            // notButton
            // 
            this.notButton.Location = new System.Drawing.Point(240, 139);
            this.notButton.Name = "notButton";
            this.notButton.Size = new System.Drawing.Size(56, 31);
            this.notButton.TabIndex = 3;
            this.notButton.Text = "NOT";
            this.notButton.UseVisualStyleBackColor = true;
            this.notButton.Click += new System.EventHandler(this.andButton_Click);
            // 
            // resultButton
            // 
            this.resultButton.Location = new System.Drawing.Point(240, 390);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(127, 31);
            this.resultButton.TabIndex = 27;
            this.resultButton.Text = "=";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(311, 191);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 31);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // partClearButton
            // 
            this.partClearButton.Location = new System.Drawing.Point(311, 139);
            this.partClearButton.Name = "partClearButton";
            this.partClearButton.Size = new System.Drawing.Size(56, 31);
            this.partClearButton.TabIndex = 4;
            this.partClearButton.Text = "<-";
            this.partClearButton.UseVisualStyleBackColor = true;
            this.partClearButton.Click += new System.EventHandler(this.partClearButton_Click);
            // 
            // binButton
            // 
            this.binButton.Location = new System.Drawing.Point(25, 191);
            this.binButton.Name = "binButton";
            this.binButton.Size = new System.Drawing.Size(56, 31);
            this.binButton.TabIndex = 5;
            this.binButton.Text = "BIN";
            this.binButton.UseVisualStyleBackColor = true;
            this.binButton.Click += new System.EventHandler(this.binButton_Click);
            // 
            // hexButton
            // 
            this.hexButton.Location = new System.Drawing.Point(240, 191);
            this.hexButton.Name = "hexButton";
            this.hexButton.Size = new System.Drawing.Size(56, 31);
            this.hexButton.TabIndex = 8;
            this.hexButton.Text = "HEX";
            this.hexButton.UseVisualStyleBackColor = true;
            this.hexButton.Click += new System.EventHandler(this.binButton_Click);
            // 
            // octButton
            // 
            this.octButton.Location = new System.Drawing.Point(96, 191);
            this.octButton.Name = "octButton";
            this.octButton.Size = new System.Drawing.Size(56, 31);
            this.octButton.TabIndex = 6;
            this.octButton.Text = "OCT";
            this.octButton.UseVisualStyleBackColor = true;
            this.octButton.Click += new System.EventHandler(this.binButton_Click);
            // 
            // decButton
            // 
            this.decButton.Location = new System.Drawing.Point(168, 191);
            this.decButton.Name = "decButton";
            this.decButton.Size = new System.Drawing.Size(56, 31);
            this.decButton.TabIndex = 7;
            this.decButton.Text = "DEC";
            this.decButton.UseVisualStyleBackColor = true;
            this.decButton.Click += new System.EventHandler(this.binButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 31);
            this.button1.TabIndex = 21;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button0_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(168, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 31);
            this.button2.TabIndex = 22;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button0_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(240, 342);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 31);
            this.button3.TabIndex = 23;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button0_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(97, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 31);
            this.button4.TabIndex = 16;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button0_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(168, 291);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(56, 31);
            this.button5.TabIndex = 17;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button0_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(240, 291);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 31);
            this.button6.TabIndex = 18;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button0_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(97, 239);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(56, 31);
            this.button7.TabIndex = 11;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button0_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(168, 239);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(56, 31);
            this.button8.TabIndex = 12;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button0_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(240, 239);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(56, 31);
            this.button9.TabIndex = 13;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button0_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(168, 390);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(56, 31);
            this.button0.TabIndex = 26;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(25, 239);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(56, 31);
            this.buttonA.TabIndex = 10;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(25, 291);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(56, 31);
            this.buttonB.TabIndex = 15;
            this.buttonB.Text = "B";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(25, 342);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(56, 31);
            this.buttonC.TabIndex = 20;
            this.buttonC.Text = "C";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(311, 239);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(56, 31);
            this.buttonD.TabIndex = 14;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonE
            // 
            this.buttonE.Location = new System.Drawing.Point(311, 291);
            this.buttonE.Name = "buttonE";
            this.buttonE.Size = new System.Drawing.Size(56, 31);
            this.buttonE.TabIndex = 19;
            this.buttonE.Text = "E";
            this.buttonE.UseVisualStyleBackColor = true;
            this.buttonE.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonF
            // 
            this.buttonF.Location = new System.Drawing.Point(311, 342);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(56, 31);
            this.buttonF.TabIndex = 24;
            this.buttonF.Text = "F";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.button0_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "DEC";
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(96, 390);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(56, 31);
            this.minusButton.TabIndex = 25;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(25, 107);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(106, 17);
            this.errorLabel.TabIndex = 30;
            this.errorLabel.Text = "Введите число";
            // 
            // BinCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 443);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.decButton);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.buttonE);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.octButton);
            this.Controls.Add(this.hexButton);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.binButton);
            this.Controls.Add(this.partClearButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.notButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.xorButton);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.orButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.andButton);
            this.MaximumSize = new System.Drawing.Size(416, 490);
            this.MinimumSize = new System.Drawing.Size(416, 490);
            this.Name = "BinCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binary Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button andButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button orButton;
        private System.Windows.Forms.Button xorButton;
        private System.Windows.Forms.Button notButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button partClearButton;
        private System.Windows.Forms.Button binButton;
        private System.Windows.Forms.Button hexButton;
        private System.Windows.Forms.Button octButton;
        private System.Windows.Forms.Button decButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonE;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Label errorLabel;
    }
}

