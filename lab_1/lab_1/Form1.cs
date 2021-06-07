using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_1
{
    public partial class BinCalc : Form
    {
        private long x, y, res, changeNum;
        private string action, numType ="DEC", lastnumType ="DEC";
        // TB - textBox1
        private bool engagedTB, stopNextBlock = false;


        public BinCalc()
        {
            engagedTB = false;
            InitializeComponent();

            buttonA.Enabled = false;
            buttonB.Enabled = false;
            buttonC.Enabled = false;
            buttonD.Enabled = false;
            buttonE.Enabled = false;
            buttonF.Enabled = false;
            errorLabel.Visible = false;

        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (label1.Text)
                {
                    case "BIN":
                        y = Convert.ToInt64(textBox1.Text, 2);
                        break;
                    case "OCT":
                        y = Convert.ToInt64(textBox1.Text, 8);
                        break;
                    case "DEC":
                        y = Convert.ToInt64(textBox1.Text);
                        break;
                    case "HEX":
                        y = Convert.ToInt64(textBox1.Text, 16);
                        break;
                    default:
                        break;
                }

                stopNextBlock = false;
            }
            catch (OverflowException)
            {
                textBox1.Text = "";
                engagedTB = false;
                MessageBox.Show("Введено недопустимое значение. Допустимые значения: от от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807");

                // для остановки вычислений в след. блоке try-catch
                stopNextBlock = true;
            }
            catch (FormatException)
            {
                textBox1.BackColor = Color.FromArgb(255, 77, 0);
                errorLabel.Text = "Введите число";
                errorLabel.Visible = true;

                // для остановки вычислений в след. блоке try-catch
                stopNextBlock = true;
            }

            try 
            {
                if (!stopNextBlock)
                {
                    switch (action)
                    {
                        case "AND":
                            res = x & y;
                            break;
                        case "OR":
                            res = x | y;
                            break;
                        case "XOR":
                            res = x ^ y;
                            break;

                        default:
                            break;
                    }
                    
                    switch (label1.Text)
                    {
                        case "BIN":
                            textBox1.Text = Convert.ToString(res, 2);
                            break;
                        case "OCT":
                            textBox1.Text = Convert.ToString(res, 8);
                            break;
                        case "DEC":
                            textBox1.Text = res.ToString();
                            break;
                        case "HEX":
                            textBox1.Text = Convert.ToString(res, 16).ToUpper();
                            break;
                        default:
                            break;
                    }

                    engagedTB = true;
                }
                
            }
            catch (OverflowException)
            {
                MessageBox.Show("Итоговое значение выходит за диапазон допустимых значений. Допустимые значения: от от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807");

                textBox1.Text = "";
                engagedTB = false;
            }           
        }

        // обработчик событий для всех цифровых кнопок
        private void button0_Click(object sender, EventArgs e)
        {
            if (engagedTB && textBox1.Text != "-")
            {
                textBox1.Text = "";
                engagedTB = false;
            }

            textBox1.Text += (sender as Button).Text;
        }

        // обработчик событий для кнопок действия: AND-NOT
        private void andButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (label1.Text)
                {
                    case "BIN":
                        x = Convert.ToInt64(textBox1.Text, 2);
                        break;
                    case "OCT":
                        x = Convert.ToInt64(textBox1.Text, 8);
                        break;
                    case "DEC":
                        x = Convert.ToInt64(textBox1.Text);
                        break;
                    case "HEX":
                        x = Convert.ToInt64(textBox1.Text, 16);
                        break;

                    default:
                        break;
                }

                action = (sender as Button).Text;
                engagedTB = true;

                if (action == "NOT")
                {
                    res = ~x;
                    textBox1.Text = res.ToString();
                    engagedTB = true;
                }
            }
            catch (OverflowException)
            {
                textBox1.Text = "";
                engagedTB = false;
                MessageBox.Show("Введено недопустимое значение. Допустимые значения: от от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807");
            }
            catch (FormatException)
            {
                textBox1.BackColor = Color.FromArgb(255, 77, 0);
                errorLabel.Text = "Введите число";
                errorLabel.Visible = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                textBox1.BackColor = Color.FromArgb(255, 77, 0);
                errorLabel.Text = "Введите число";
                errorLabel.Visible = true;
            }

        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "-";
            engagedTB = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Window;
            errorLabel.Visible = false;
        }

        // обработчик событий для кнопок типа чисел: BIN-HEX
        private void binButton_Click(object sender, EventArgs e)
        {            
            numType = (sender as Button).Text;
            try
            {
                switch (numType)
                {
                    case "BIN":
                        label1.Text = "BIN";

                        minusButton.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        buttonA.Enabled = false;
                        buttonB.Enabled = false;
                        buttonC.Enabled = false;
                        buttonD.Enabled = false;
                        buttonE.Enabled = false;
                        buttonF.Enabled = false;

                        if (textBox1.Text != "")
                        {
                            switch (lastnumType)
                            {
                                case "OCT":
                                    changeNum = Convert.ToInt64(textBox1.Text, 8);
                                    textBox1.Text = Convert.ToString(changeNum, 2);
                                    break;
                                case "DEC":
                                    changeNum = Convert.ToInt64(textBox1.Text);
                                    textBox1.Text = Convert.ToString(changeNum, 2);
                                    break;
                                case "HEX":
                                    changeNum = Convert.ToInt64(textBox1.Text, 16);
                                    textBox1.Text = Convert.ToString(changeNum, 2).ToUpper();
                                    break;

                                default:
                                    break;
                            }
                        }

                        lastnumType = "BIN";
                        break;
                    case "OCT":
                        label1.Text = "OCT";

                        minusButton.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        buttonA.Enabled = false;
                        buttonB.Enabled = false;
                        buttonC.Enabled = false;
                        buttonD.Enabled = false;
                        buttonE.Enabled = false;
                        buttonF.Enabled = false;

                        if (textBox1.Text != "")
                        {
                            switch (lastnumType)
                            {
                                case "BIN":
                                    changeNum = Convert.ToInt64(textBox1.Text, 2);
                                    textBox1.Text = Convert.ToString(changeNum, 8);
                                    break;
                                case "DEC":
                                    changeNum = Convert.ToInt64(textBox1.Text);
                                    textBox1.Text = Convert.ToString(changeNum, 8);
                                    break;
                                case "HEX":
                                    changeNum = Convert.ToInt64(textBox1.Text, 16);
                                    textBox1.Text = Convert.ToString(changeNum, 8).ToUpper();
                                    break;

                                default:
                                    break;
                            }
                        }

                        lastnumType = "OCT";
                        break;
                    case "DEC":
                        label1.Text = "DEC";

                        minusButton.Enabled = true;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button8.Enabled = true;
                        button9.Enabled = true;
                        buttonA.Enabled = false;
                        buttonB.Enabled = false;
                        buttonC.Enabled = false;
                        buttonD.Enabled = false;
                        buttonE.Enabled = false;
                        buttonF.Enabled = false;

                        if (textBox1.Text != "")
                        {
                            switch (lastnumType)
                            {
                                case "BIN":
                                    changeNum = Convert.ToInt64(textBox1.Text, 2);
                                    textBox1.Text = Convert.ToString(changeNum, 10);
                                    break;
                                case "OCT":
                                    changeNum = Convert.ToInt64(textBox1.Text, 8);
                                    textBox1.Text = Convert.ToString(changeNum, 10);
                                    break;
                                case "HEX":
                                    changeNum = Convert.ToInt64(textBox1.Text, 16);
                                    textBox1.Text = Convert.ToString(changeNum, 10).ToUpper();
                                    break;

                                default:
                                    break;
                            }
                        }

                        lastnumType = "DEC";
                        break;
                    case "HEX":
                        label1.Text = "HEX";

                        minusButton.Enabled = false;
                        button2.Enabled = true;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        button8.Enabled = true;
                        button9.Enabled = true;
                        buttonA.Enabled = true;
                        buttonB.Enabled = true;
                        buttonC.Enabled = true;
                        buttonD.Enabled = true;
                        buttonE.Enabled = true;
                        buttonF.Enabled = true;

                        if (textBox1.Text != "")
                        {
                            switch (lastnumType)
                            {
                                case "BIN":
                                    changeNum = Convert.ToInt64(textBox1.Text, 2);
                                    textBox1.Text = Convert.ToString(changeNum, 16);
                                    break;
                                case "DEC":
                                    changeNum = Convert.ToInt64(textBox1.Text);
                                    textBox1.Text = Convert.ToString(changeNum, 16);
                                    break;
                                case "OCT":
                                    changeNum = Convert.ToInt64(textBox1.Text, 8);
                                    textBox1.Text = Convert.ToString(changeNum, 16);
                                    break;

                                default:
                                    break;
                            }
                        }

                        lastnumType = "HEX";
                        break;

                    default:
                        break;
                }
            }
            catch (OverflowException)
            {
                textBox1.Text = "";
                engagedTB = false;
                MessageBox.Show("Введено недопустимое значение. Допустимые значения: от от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807");
            }            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void partClearButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }
    }
}
