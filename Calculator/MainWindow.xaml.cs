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
                if (S2 == 0)
                    CatchError();
                else
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
        public void button0Click(object e, RoutedEventArgs arg)     //0
        {
            CalculateBox.Text += "0";
        }
        public void button1Click(object e, RoutedEventArgs arg)     //1
        {
            CalculateBox.Text += "1";
        }
        public void button2Click(object e, RoutedEventArgs arg)         //2
        {
            CalculateBox.Text += "2";
        }
        public void button3Click(object e, RoutedEventArgs arg)         //3
        {
            CalculateBox.Text += "3";
        }
        public void button4Click(object e, RoutedEventArgs arg)         //4
        {
            CalculateBox.Text += "4";
        }
        public void button5Click(object e, RoutedEventArgs arg)     //5
        {
            CalculateBox.Text += "5";
        }
        public void button6Click(object e, RoutedEventArgs arg)     //6
        {
            CalculateBox.Text += "6";
        }
        public void button7Click(object e, RoutedEventArgs arg)         //7
        {
            CalculateBox.Text += "7";
        }
        public void button8Click(object e, RoutedEventArgs arg)         //8
        {
            CalculateBox.Text += "8";
        }
        public void button9Click(object e, RoutedEventArgs arg)     //9
        {
            CalculateBox.Text += "9";
        }
        public void buttonCClick(object e, RoutedEventArgs arg)                 //Обнуляет textbox
        {
            CalculateBox.Text = null;
        }
        public void buttonMRClick(object e, RoutedEventArgs arg)            //Считывает из памяти на экран
        {
            CalculateBox.Text = Convert.ToString(Memory);
        }
        public void buttonMCClick(object e, RoutedEventArgs arg)                //Обнуляет память
        {
            Memory = 0;
        }
        public void buttonMPlusClick(object e, RoutedEventArgs arg)                 //Прибавляет к памяти Memory число в textbox
        {
            if (CheckSymbols())
                Memory += GetFirstNumber();
            else
                MessageBox.Show("Вы не выполнили операцию, прежде чем записать в память!");
        }
        private void buttonMMinusClick(object e, RoutedEventArgs arg)               //Вычитает из памяти Memory число в textbox
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
        private void buttonMultiply(object e, RoutedEventArgs ard)                          //Высчитывает умножение
        {
            S1 = GetFirstNumber();
            CalculateBox.Text += " * ";
        }
        private void buttonPlus(object e, RoutedEventArgs ard)              //Высчитывает сложение
        {
            S1 = GetFirstNumber();
            CalculateBox.Text += " + ";
        }
        private void buttonMinus(object e, RoutedEventArgs ard)                     //Высчитывает вычитывание
        {
            S1 = GetFirstNumber();
            CalculateBox.Text += " - ";
        }
        private void buttonDivision(object e, RoutedEventArgs ard)                          //Высчитывает деление
        {
            S1 = GetFirstNumber();
            CalculateBox.Text += " / ";
        }
        private void buttonSin(object e, RoutedEventArgs ard)                                                       //Высчитывает синус
        {
            CalculateBox.Text = Convert.ToString(Math.Sin(GetFirstNumber()));
        }
        private void buttonCos(object e, RoutedEventArgs ard)                                                           //Высчитывает косинус
        {
            CalculateBox.Text = Convert.ToString(Math.Cos(GetFirstNumber()));
        }
        private void buttonTan(object e, RoutedEventArgs ard)                       //Высчитывает тангенс
        {
            CalculateBox.Text = Convert.ToString(Math.Tan(GetFirstNumber()));
        }
        private void buttonArctg(object e, RoutedEventArgs ard)                                 //Высчитывает ArcTg
        {
            CalculateBox.Text = Convert.ToString(Math.Atan(GetFirstNumber()));
        }
        private void buttonLn(object e, RoutedEventArgs ard)                                                    //Высчитывает Ln
        {
            CalculateBox.Text = Convert.ToString(Math.Log(GetFirstNumber()));
        }
        private void buttonFactorial(object e, RoutedEventArgs ard)                 //Высчитывает факториал !x
        {
            CalculateBox.Text = Factorial(Convert.ToInt32(CalculateBox.Text)).ToString();
        }
        private void buttonReverse(object e, RoutedEventArgs ard)                   //Обратная дробь 1/X
        {
            if (GetFirstNumber() == 0)
                CatchError();
            else
                CalculateBox.Text = Convert.ToString(1 / (GetFirstNumber()));
        }
        private void buttonExp(object e, RoutedEventArgs ard)                       //Высчитывает exp^X
        {
            CalculateBox.Text = Convert.ToString(Math.Exp(GetFirstNumber()));
        }
        private void buttonExponentiation(object e, RoutedEventArgs ard)                //Высчитывает x^y
        {
            S1 = GetFirstNumber();
            CalculateBox.Text += " ^ ";
        }
        private void buttonLog(object e, RoutedEventArgs ard)                       //высчитывает Логарифм
        {
            if (CalculateBox.Text != "")
            {
                S1 = GetFirstNumber();
                CalculateBox.Text = $"LOG {S1} Y";
            }
            else
            {
                CalculateBox.Text = $"LOG x Y";
            }
        }

        public double GetFirstNumber()          //Получает значение первой переменной
        {
            return Convert.ToDouble(CalculateBox.Text);
        }
        public BigInteger Factorial(int n)                              //Факториал
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }

        public bool CheckSymbols()
        {
            if (CalculateBox.Text.Contains('+') || CalculateBox.Text.Contains('-') || CalculateBox.Text.Contains('*') || CalculateBox.Text.Contains('/') || CalculateBox.Text.Contains("LOG") || CalculateBox.Text.Contains("Ln"))
                return false;
            else return true;
        }
        public void CatchError()
        {
            CalculateBox.Text = "Error!";
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
