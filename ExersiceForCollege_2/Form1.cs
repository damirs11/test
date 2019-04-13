using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Calculate
{
    public partial class fCalc : Form
    {
        
        public fCalc()
        {
            InitializeComponent();
        }


        bool NewOp = true;
        int op = -1;
        double a = 0, b = 0, c = 0;
        int gCC = 10;

        private void fCalc_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void fCalc_Load(object sender, EventArgs e)
        {
            
        }

        private void tb_Calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Back) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                if (NewOp)
                {
                    tb_Calc.Text = "";
                    NewOp = false;
                }
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar == ',' && tb_Calc.Text.IndexOf(',') > -1) e.Handled = true;
                if (e.KeyChar == '0' && tb_Calc.Text == "0") e.Handled = true;
                if (tb_Calc.Text == "0" && e.KeyChar >= '1' && e.KeyChar <= '9') tb_Calc.Text = "";
            }
            else e.Handled = true;

            
        }

        private void bNum1_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            op = -1;
            tb_Calc.Text =  "0";
            NewOp = true;
        }

        private void bPoint_Click(object sender, EventArgs e)
        {
            if(NewOp)
            {
                tb_Calc.Text = "0";
                NewOp = false;
            }
            if (tb_Calc.Text.IndexOf(",") == -1) tb_Calc.Text += ',';

        }

        private void bRavno_Click(object sender, EventArgs e)
        {
            if (gCC == 10)
                b = Convert.ToDouble(tb_Calc.Text);
            else
                b = Convert.ToInt32(tb_Calc.Text, gCC);

            switch (op)
            {
                case 1:
                    c = a + b;
                    break;
                case 2:
                    c = a - b;
                    break;
                case 3:
                    c = a * b;
                    break;
                case 4:
                    c = a / b;
                    break;
                case 5:
                    c = Math.Pow(a, b);
                    break;
            }
            string exp = Convert.ToString(c);

            if (gCC == 10)
                tb_Calc.Text = exp;
            else
                tb_Calc.Text = Convert.ToString(Convert.ToInt32(exp, 10), gCC);

            NewOp = true;
            op = -1;
        }

        private void bPlus_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            else
            {
                if (op > 0)
                    bRavno_Click(sender, e);

                if (tb_Calc.Text.IndexOf(",") == -1)
                    a = Convert.ToInt32(tb_Calc.Text, gCC);
                else
                    a = Convert.ToDouble(tb_Calc.Text);

                NewOp = true;
                op = 1;
                
            }
        }

        private void bMinus_Click(object sender, EventArgs e)
        {
            if (!(tb_Calc.Text.IndexOf("-")>-1&& tb_Calc.Text.Length - 1 == tb_Calc.Text.IndexOf("-")))
            {
                if (tb_Calc.Text == "" || tb_Calc.Text == "0")
                {
                    tb_Calc.Text = "-";
                    NewOp = false;
                    op = -1;
                }
                else
                {
                    

                    if (op > 0)
                        bRavno_Click(sender, e);
                    a = Convert.ToDouble(tb_Calc.Text);
                    NewOp = true;
                    op = 2;
                }

            }
            
        }

        private void bUmn_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            else
            {
                
                if (op > 0)
                    bRavno_Click(sender, e);
                a = Convert.ToDouble(tb_Calc.Text);
                NewOp = true;
                op = 3;
            }
        }

        private void bDelenie_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            else
            {
                
                if (op > 0)
                    bRavno_Click(sender, e);
                a = Convert.ToDouble(tb_Calc.Text);
                NewOp = true;
                op = 4;
            }
        }

        private void bsin_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Sin(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bCos_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Cos(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bTg_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Tan(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bCtg_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text =(1/Math.Tan(Convert.ToDouble(tb_Calc.Text))).ToString();
            NewOp = true;
            op = -1;
        }

        private void bAbs_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Abs(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bLn_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Log(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bExp_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Exp(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bSqrt_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Sqrt(Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void bX_in2_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = ((Convert.ToDouble(tb_Calc.Text))*Convert.ToDouble(tb_Calc.Text)).ToString();
            NewOp = true;
            op = -1;
        }

        private void b1_x_Click(object sender, EventArgs e)
        {


            if (Convert.ToDouble(tb_Calc.Text) == 0) MessageBox.Show("Деление на ноль невозможно.", "Ошибка!");
            else
            {
                if (tb_Calc.Text == "") tb_Calc.Text = "0";
                tb_Calc.Text = (1 / (Convert.ToDouble(tb_Calc.Text))).ToString();
                NewOp = true;
                op = -1;
            }
         
        }

        private void bx_y_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            else
            {
                if (op > 0)
                    bRavno_Click(sender, e);
                a = Convert.ToDouble(tb_Calc.Text);
                NewOp = true;
                op = 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            tb_Calc.Text = Math.Log(Convert.ToDouble(tb_Calc.Text), 10).ToString();
            NewOp = true;
            op = -1;
        }

        private void CC_disable(int CC)
        {
            bNum2.Enabled = false;
            bNum3.Enabled = false;
            bNum4.Enabled = false;
            bNum5.Enabled = false;
            bNum6.Enabled = false;
            bNum7.Enabled = false;
            bNum8.Enabled = false;
            bNum9.Enabled = false;
            bA.Enabled = false;
            bB.Enabled = false;
            bC.Enabled = false;
            bD.Enabled = false;
            bE.Enabled = false;
            bF.Enabled = false;
            bPoint.Enabled = false;

            bsin.Enabled = false;
            bCos.Enabled = false;
            bTg.Enabled = false;
            bLn.Enabled = false;
            button1.Enabled = false;
            bx_y.Enabled = false;


            СС2.Enabled = true;
            СС8.Enabled = true;
            СС10.Enabled = true;
            СС16.Enabled = true;
  

            switch (CC)
            {
                case 2:
                    СС2.Enabled = false;
                    break;

                case 8:
                    bNum2.Enabled = true;
                    bNum3.Enabled = true;
                    bNum4.Enabled = true;
                    bNum5.Enabled = true;
                    bNum6.Enabled = true;
                    bNum7.Enabled = true;

                    СС8.Enabled = false;
                    break;

                case 10:
                    bNum2.Enabled = true;
                    bNum3.Enabled = true;
                    bNum4.Enabled = true;
                    bNum5.Enabled = true;
                    bNum6.Enabled = true;
                    bNum7.Enabled = true;
                    bNum8.Enabled = true;
                    bNum9.Enabled = true;
                    bPoint.Enabled = true;

                    bsin.Enabled = true;
                    bCos.Enabled = true;
                    bTg.Enabled = true;
                    bLn.Enabled = true;
                    button1.Enabled = true;
                    bx_y.Enabled = true;

                    СС10.Enabled = false;
                    break;

                case 16:
                    bNum2.Enabled = true;
                    bNum3.Enabled = true;
                    bNum4.Enabled = true;
                    bNum5.Enabled = true;
                    bNum6.Enabled = true;
                    bNum7.Enabled = true;
                    bNum8.Enabled = true;
                    bNum9.Enabled = true;

                    bA.Enabled = true;
                    bB.Enabled = true;
                    bC.Enabled = true;
                    bD.Enabled = true;
                    bE.Enabled = true;
                    bF.Enabled = true;

                    СС16.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Converts the given decimal number to the numeral system with the
        /// specified radix (in the range [2, 36]).
        /// </summary>
        /// <param name="decimalNumber">The number to convert.</param>
        /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
        /// <returns></returns>
        private static string DecimalToArbitrarySystem(int decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        private string BaseChange(int decimalNumber, int from, int to)
        {
            if (from == 10)
                return DecimalToArbitrarySystem(decimalNumber, to);
            else
            {
                string exp = DecimalToArbitrarySystem(decimalNumber, 10);
                return exp; //DecimalToArbitrarySystem(exp, radix); 
            }
        }

        private void СС2_Click(object sender, EventArgs e)
        {
            string res = tb_Calc.Text == "" ? res = "" : DecimalToArbitrarySystem(Convert.ToInt32(tb_Calc.Text, gCC), 2);
            tb_Calc.Text = res;

            gCC = 2;
            CC_disable(gCC);
        }

        private void СС8_Click(object sender, EventArgs e)
        {
            string res = tb_Calc.Text == "" ? res = "" : DecimalToArbitrarySystem(Convert.ToInt32(tb_Calc.Text, gCC), 8);
            tb_Calc.Text = res;

            gCC = 8;
            CC_disable(gCC);
        }

        private void СС10_Click(object sender, EventArgs e)
        {
            string res = tb_Calc.Text == "" ? res = "" : DecimalToArbitrarySystem(Convert.ToInt32(tb_Calc.Text, gCC), 10);
            tb_Calc.Text = res;

            gCC = 10;
            CC_disable(gCC);
        }

        private void СС16_Click(object sender, EventArgs e)
        {
            string res = tb_Calc.Text == "" ? res = "" : DecimalToArbitrarySystem(Convert.ToInt32(tb_Calc.Text, gCC), 16);
            tb_Calc.Text = res;

            gCC = 16;
            CC_disable(gCC);
        }

        private void tb_Calc_TextChanged(object sender, EventArgs e)
        {
        }

        private void bA_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bB_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bC_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bD_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bE_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void bF_Click(object sender, EventArgs e)
        {
            if (NewOp == true || tb_Calc.Text == "0")
            {
                tb_Calc.Text = (sender as Button).Text;
                NewOp = false;
            }
            else tb_Calc.Text += (sender as Button).Text;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void bFact_Click(object sender, EventArgs e)
        {
            if (tb_Calc.Text == "") tb_Calc.Text = "0";
            int a = 1;
            try
            {
                Convert.ToInt32(tb_Calc.Text);
                
            }
            catch
            {
                
                MessageBox.Show("Введите, пожалуйста целое число.","Ошибка!");
                a = 0;
                
            }
            
            if (a == 0)
            {

            }
            else
            {
                for (int i = 2; i <= Convert.ToInt32(tb_Calc.Text); i++)
                {

                    a = a * i;
                }
                tb_Calc.Text = a.ToString();
                NewOp = true;
                op = -1;
            }
        }
    }
}
