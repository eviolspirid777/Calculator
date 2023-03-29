using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Numerics;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        static double S1, S2, Memory = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void EqualClick(object e, RoutedEventArgs arg)       //Функция для обработки результата
        {
            S2 = GetSecondNumber();
            if (CalculateBox.Text.Contains('+'))
            {
                CalculateBox.Text = Convert.ToString(S1 + S2);
            }
            if (CalculateBox.Text.Contains('-'))
            {
                CalculateBox.Text = Convert.ToString(S1 - S2);
            }
            if (CalculateBox.Text.Contains('*'))
            {
                CalculateBox.Text = Convert.ToString(S1 * S2);
            }
            if (CalculateBox.Text.Contains('/'))
            {
                CalculateBox.Text = Convert.ToString(S1 / S2);
            }
            if (CalculateBox.Text.Contains('^'))
            {
                CalculateBox.Text = Convert.ToString(Math.Pow(S1,S2));
            }
            if (CalculateBox.Text.Contains("LOG"))
            {
                string[] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                S1 = int.Parse(substrings[1]);                              // извлекаем первый элемент массива
                S2 = int.Parse(substrings[2]);
                CalculateBox.Text = Convert.ToString(Math.Log(S2, S1));
            }
        }
        public void button0Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "0";
        }
        public void button1Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "1";
        }
        public void button2Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "2";
        }
        public void button3Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "3";
        }
        public void button4Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "4";
        }
        public void button5Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "5";
        }
        public void button6Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "6";
        }
        public void button7Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "7";
        }
        public void button8Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "8";
        }
        public void button9Click(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text += "9";
        }
        public void buttonCClick(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text = null;
        }
        public void buttonMRClick(object e, RoutedEventArgs arg)
        {
            CalculateBox.Text = Convert.ToString(Memory);
        }
        public void buttonMCClick(object e, RoutedEventArgs arg)
        {
            Memory = 0;
        }
        public void buttonMPlusClick(object e, RoutedEventArgs arg)
        {
            Memory +=  ConvertToDouble(CalculateBox.Text);
        }
        private void buttonMMinusClick(object e, RoutedEventArgs arg)
        {
            if(int.TryParse(CalculateBox.Text, out int result))
            {
                Memory -= result;
                ClearTextField();
            }
            else
            {
                MessageBox.Show("Memory is clear!");
            }
        }
        private void buttonMultiply(object e, RoutedEventArgs ard)
        {
            S1 = ConvertToDouble(CalculateBox.Text);
            CalculateBox.Text += " * ";
        }
        private void buttonPlus(object e, RoutedEventArgs ard)
        {
            S1 = ConvertToDouble(CalculateBox.Text);
            CalculateBox.Text += " + ";
        }
        private void buttonMinus(object e, RoutedEventArgs ard)
        {
            S1 = ConvertToDouble(CalculateBox.Text);
            CalculateBox.Text += " - ";
        }
        private void buttonDivision(object e, RoutedEventArgs ard)
        {
            S1 = ConvertToDouble(CalculateBox.Text);
            CalculateBox.Text += " / ";
        }
        private void buttonSin(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Sin(ConvertToDouble(CalculateBox.Text)));
        }
        private void buttonCos(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Cos(ConvertToDouble(CalculateBox.Text)));
        }
        private void buttonTan(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Tan(ConvertToDouble(CalculateBox.Text)));
        }
        private void buttonArctg(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Atan(ConvertToDouble(CalculateBox.Text)));
        }
        private void buttonLn(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Log(ConvertToDouble(CalculateBox.Text)));
        }
        private void buttonFactorial(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Factorial(Convert.ToInt32(CalculateBox.Text)).ToString();
        }
        private void buttonReverse(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(1 / (Convert.ToDouble(CalculateBox.Text)));
        }
        private void buttonExp(object e, RoutedEventArgs ard)
        {
            CalculateBox.Text = Convert.ToString(Math.Exp(Convert.ToDouble(CalculateBox.Text)));
        }
        private void buttonExponentiation(object e, RoutedEventArgs ard)
        {
            S1 = ConvertToDouble(CalculateBox.Text);
            CalculateBox.Text += " ^ ";
        }
        private void buttonLog(object e, RoutedEventArgs ard)
        {
            if (CalculateBox.Text != "")
            {
                S1 = Convert.ToDouble(CalculateBox.Text);
                CalculateBox.Text = $"LOG {S1} Y";
            }
            else
            {
                CalculateBox.Text = $"LOG x Y";
            }
        }

        public double ConvertToDouble(string value)
        {
            return Convert.ToDouble(value);
        }
        public BigInteger Factorial(int n)                              //Факториал
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }
        public int GetSecondNumber ()
        {
            if (!CalculateBox.Text.Contains("LOG"))
            {
                string[] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                string numberStr = substrings[2];                              // извлекаем второй элемент массива
                return int.Parse(numberStr);
            }
            else
            {
                string[] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                string numberStr = substrings[1];                              // извлекаем второй элемент массива
                return int.Parse(numberStr);
            }
        }
        public void ClearTextField() {CalculateBox.Text = null;}
    }
}
