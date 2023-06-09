﻿using System;
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
using System.DirectoryServices.ActiveDirectory;
using TempNumbers;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        static double S1, S2, MemoryFirst, MemorySecond = 0;
        bool flag, flagForDecimal = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        public void WindowKeyDown(object sender, KeyEventArgs e)                //Обработка нажатия клавиш на клавиатуре
        {
            if (e.Key == Key.D1)
            {
                CalculateBox.Text += "1";
            }
            else if (e.Key == Key.Space)
            {
                CalculateBox.Text += " ";
            }
            else if (e.Key == Key.D2)
            {
                CalculateBox.Text += "2";
            }
            else if (e.Key == Key.D3)
            {
                CalculateBox.Text += "3";
            }
            else if (e.Key == Key.D4)
            {
                CalculateBox.Text += "4";
            }
            else if (e.Key == Key.D5)
            {
                CalculateBox.Text += "5";
            }
            else if (e.Key == Key.D6)
            {
                CalculateBox.Text += "6";
            }
            else if (e.Key == Key.D7)
            {
                CalculateBox.Text += "7";
            }
            else if (e.Key == Key.D8)
            {
                CalculateBox.Text += "8";
            }
            else if (e.Key == Key.D9)
            {
                CalculateBox.Text += "9";
            }
            else if (e.Key == Key.NumPad0)
            {
                CalculateBox.Text += "0";
            }
            else if (e.Key == Key.NumPad1)
            {
                CalculateBox.Text += "1";
            }
            else if (e.Key == Key.NumPad2)
            {
                CalculateBox.Text += "2";
            }
            else if (e.Key == Key.NumPad3)
            {
                CalculateBox.Text += "3";
            }
            else if (e.Key == Key.NumPad4)
            {
                CalculateBox.Text += "4";
            }
            else if (e.Key == Key.NumPad5)
            {
                CalculateBox.Text += "5";
            }
            else if (e.Key == Key.NumPad6)
            {
                CalculateBox.Text += "6";
            }
            else if (e.Key == Key.NumPad7)
            {
                CalculateBox.Text += "7";
            }
            else if (e.Key == Key.NumPad8)
            {
                CalculateBox.Text += "8";
            }
            else if (e.Key == Key.NumPad9)
            {
                CalculateBox.Text += "9";
            }
            else if (e.Key == Key.D0)
            {
                CalculateBox.Text += "0";
            }
            else if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.OemPlus)          //обработка нажатия (shift + '+')
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnEquals.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
            else if (e.Key == Key.Add || e.Key == Key.OemPlus)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnPlus.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
            else if (e.Key == Key.Subtract)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnMinus.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
            else if (e.Key == Key.Multiply)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnMultiply.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
            else if (e.Key == Key.Divide)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnDivision.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
            else if (e.Key == Key.Decimal)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnDot.RaiseEvent(args);
            }
            else if (e.Key == Key.Back)
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);
                btnBack.RaiseEvent(args);
            }
            else if(e.Key == Key.Enter) 
            {
                RoutedEventArgs args = new RoutedEventArgs(Button.ClickEvent);                    //создает событие нажатия на клавишу
                btnEquals.RaiseEvent(args);                                                                                //поднимает(вызывает событие args), правильнее симулирует нажатие
            }
        }
        public void EqualClick(object e, RoutedEventArgs arg)       //Функция для обработки результата
        {
            if (CheckText())                              //(false => чисел больше 1; true => чисел меньше 1)
            {
                string[] substring = CalculateBox.Text.Split(' ');
                S2 = GetSecondNumber();
                if (substring[1] == "+")
                {
                    CalculateBox.Text = Convert.ToString(S1 + S2);
                }
                if (substring[1] == "-")
                {
                    CalculateBox.Text = Convert.ToString(S1 - S2);
                }
                if (substring[1] == "*")
                {
                    CalculateBox.Text = Convert.ToString(S1 * S2);
                }
                if (substring[1] == "/")
                {
                    if (S2 == 0)
                        CatchError();
                    else
                        CalculateBox.Text = Convert.ToString(S1 / S2);
                }
                if (substring[1] == "^")
                {
                    CalculateBox.Text = Convert.ToString(Math.Pow(S1, S2));
                }
                if (CalculateBox.Text.Contains("LOG"))
                {
                    string [ ] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                    if (!double.TryParse(substring[2], out S2) || !double.TryParse(substring[1], out S1))
                        CatchError();
                    else
                        CalculateBox.Text = Convert.ToString(Math.Log(S2, S1));
                }
            }
        }

/*        public void EqualClick(object e, RoutedEventArgs arg)       //Функция для обработки результата
        {
            if (CheckText())                              //(false => чисел больше 1; true => чисел меньше 1)
            {
                TempNumb numbers = new TempNumb(CalculateBox.Text);
                CalculateBox.Text = Convert.ToString(numbers.result);
            }
        }
*/
        public void buttonPlusMinusClick(object sender, EventArgs e)
        {
            if (!flag)
            {
                if (CalculateBox.Text.EndsWith('+'))
                    CalculateBox.Text = CalculateBox.Text.Substring(0, CalculateBox.Text.Length - 1);
                CalculateBox.Text += "-";
                flag = true;
            }
            else if (flag)
            {
                if (CalculateBox.Text.EndsWith('-'))
                    CalculateBox.Text = CalculateBox.Text.Substring(0,CalculateBox.Text.Length - 1);
                CalculateBox.Text += "+";
                flag = false;
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
        public void button3Click(object sender, RoutedEventArgs arg)         //3
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
        public void BackClick(object sender, RoutedEventArgs arg)                                   //Удаляет последний символ в строке
        {
            if (CalculateBox.Text.EndsWith("LOG"))          //проверяет, заканчивается ли текст на LOG, если заканчивается - добавляет пробел (защита от случайного удаления)
            {
                CalculateBox.Text += " ";
            }
            else if (CalculateBox.Text.Length != 0)
            {
                CalculateBox.Text = CalculateBox.Text.Substring(0, CalculateBox.Text.Length - 1);
                if (CalculateBox.Text.EndsWith(' '))                                                                                 //Проверяет, оканчивается ли текст на ' '
                {
                    CalculateBox.Text = CalculateBox.Text.Substring(0, CalculateBox.Text.Length - 1);
                }
            }
        }
        public void DotClick(object sender, RoutedEventArgs arg)                        //Функция для запятой (работа с дробными и десятичными числами)
        {
            if (flagForDecimal is false && CalculateBox.Text.Length != 0)           //Проверка на наличие флага И проверка на начало строки
            {
                flagForDecimal = true;
                CalculateBox.Text += ",";
            }
            else
            {
                char[] decimilates = new char[] { '-', '+', '*', '/' };                 //набор разделителей
                string[] SubString = CalculateBox.Text.Split(decimilates);          //разделяет на набор чисел
                string LastString = SubString[SubString.Length-1];                 //присваивает последнюю подстроку переменной LastString
                if (SubString.Length - 1 == CalculateBox.Text.Count(c => c == ',') && flagForDecimal is true && !LastString.EndsWith(' '))           //Вычитаем из кол-ва чисел 1, чтобы определить начало следующего числа
                    CalculateBox.Text += ",";
            }
        }
        public void buttonCClick(object e, RoutedEventArgs arg)                 //Обнуляет textbox
        {
            ClearTextField();
        }
        public void buttonM1RClick(object e, RoutedEventArgs arg)            //Считывает из памяти на экран
        {
            if(CheckSymbols())
                CalculateBox.Text = Convert.ToString(MemoryFirst);
            else
                CalculateBox.Text += Convert.ToString(MemoryFirst);
        }
        public void buttonM2RClick(object e, RoutedEventArgs arg)            //Считывает из памяти на экран
        {
            if (CheckSymbols())
                CalculateBox.Text = Convert.ToString(MemorySecond);
            else
                CalculateBox.Text += Convert.ToString(MemorySecond);
        }
        public void buttonM1CClick(object e, RoutedEventArgs arg)                //Обнуляет 1 память
        {
            MemoryFirst = 0;
        }
        public void buttonM2CClick(object e, RoutedEventArgs arg)                //Обнуляет 2 память
        {
            MemorySecond = 0;
        }
        public void buttonM1PlusClick(object e, RoutedEventArgs arg)                 //Прибавляет к памяти Memory 1 число в textbox
        {
            if (CheckSymbols())
                MemoryFirst += GetFirstNumber();
            else
                MessageBox.Show("Вы не выполнили операцию, прежде чем записать в память!");
        }
        public void buttonM2PlusClick(object e, RoutedEventArgs arg)                 //Прибавляет к памяти Memory 2 число в textbox
        {
            if (CheckSymbols())
                MemorySecond += GetFirstNumber();
            else
                MessageBox.Show("Вы не выполнили операцию, прежде чем записать в память!");
        }
        private void buttonM1MinusClick(object e, RoutedEventArgs arg)               //Вычитает из памяти Memory 1 число в textbox
        {
            if(int.TryParse(CalculateBox.Text, out int result))
            {
                MemoryFirst -= result;
                ClearTextField();
            }
            else
            {
                MessageBox.Show("Memory is clear!");
            }
        }
        private void buttonM2MinusClick(object e, RoutedEventArgs arg)               //Вычитает из памяти Memory 2 число в textbox
        {
            if (int.TryParse(CalculateBox.Text, out int result))
            {
                MemorySecond -= result;
                ClearTextField();
            }
            else
            {
                MessageBox.Show("Memory is clear!");
            }
        }
        private void buttonMultiply(object e, RoutedEventArgs ard)                          //Высчитывает умножение
        {
            if (!CheckText())
            {
                S1 = GetFirstNumber();
                if (S1 == 0)
                    ClearTextField();
                else
                    CalculateBox.Text += " * ";
            }
        }
        private void buttonPlus(object e, RoutedEventArgs ard)              //Высчитывает сложение
        {
            if (!CheckText())
            {
                S1 = GetFirstNumber();
                if (S1 == 0)
                    ClearTextField();
                else
                    CalculateBox.Text += " + ";
            }
        }
        private void buttonMinus(object e, RoutedEventArgs ard)                     //Высчитывает вычитывание
        {
            if (!CheckText())
            {
                S1 = GetFirstNumber();
                if (S1 == 0)
                    ClearTextField();
                else
                    CalculateBox.Text += " - ";
            }
        }
        private void buttonDivision(object e, RoutedEventArgs ard)                          //Высчитывает деление
        {
            if (!CheckText())
            {
                S1 = GetFirstNumber();
                if (S1 == 0)
                    ClearTextField();
                else
                    CalculateBox.Text += " / ";
            }
        }
        private void buttonSin(object e, RoutedEventArgs ard)                                                       //Высчитывает синус
        {
            if(!CheckText())
                CalculateBox.Text = Convert.ToString(Math.Sin(GetFirstNumber()));
        }
        private void buttonCos(object e, RoutedEventArgs ard)                                                           //Высчитывает косинус
        {
            if(!CheckText())
                CalculateBox.Text = Convert.ToString(Math.Cos(GetFirstNumber()));
        }
        private void buttonTan(object e, RoutedEventArgs ard)                       //Высчитывает тангенс
        {
            if(!CheckText())
                CalculateBox.Text = Convert.ToString(Math.Tan(GetFirstNumber()));
        }
        private void buttonArctg(object e, RoutedEventArgs ard)                                 //Высчитывает ArcTg
        {
            if(!CheckText())
                CalculateBox.Text = Convert.ToString(Math.Atan(GetFirstNumber()));
        }
        private void buttonLn(object e, RoutedEventArgs ard)                                                    //Высчитывает Ln
        {
            if(!CheckText())
                CalculateBox.Text = Convert.ToString(Math.Log(GetFirstNumber()));
        }
        private void buttonFactorial(object e, RoutedEventArgs ard)                 //Высчитывает факториал !x
        {
            if (!CheckText() && int.TryParse(CalculateBox.Text, out int result))
                CalculateBox.Text = TempNumb.Factorial(Convert.ToInt32(result)).ToString();
            else
                MessageBox.Show("Вы ввели не число!");
        }
        private void buttonReverse(object e, RoutedEventArgs ard)                   //Обратная дробь 1/X
        {
            if (!CheckText())
            {
                if (GetFirstNumber() == 0)
                    CatchError();
                else
                    CalculateBox.Text = Convert.ToString(1 / GetFirstNumber());
            }
        }
        private void buttonExp(object e, RoutedEventArgs ard)                       //Высчитывает exp^X
        {
            if(!CheckText())
               CalculateBox.Text = Convert.ToString(Math.Exp(GetFirstNumber()));
        }
        private void buttonExponentiation(object e, RoutedEventArgs ard)                //Высчитывает x^y
        {
            if (!CheckText())
            {
                S1 = GetFirstNumber();
                CalculateBox.Text += " ^ ";
            }
        }
        private void buttonLog(object e, RoutedEventArgs ard)                       //высчитывает Логарифм
        {
            if (!CheckText())
            {
                if (CalculateBox.Text != "")
                {
                    S1 = GetFirstNumber();
                    CalculateBox.Text = $"LOG {S1} Y";
                }
                else
                    CalculateBox.Text = "LOG x Y";
            }
        }

        public double GetFirstNumber()          //Получает значение первой переменной
        {
            if (double.TryParse(CalculateBox.Text, out var number))
            {
                    return number;
            }
            else
            {
                MessageBox.Show("Вы ввели не число!");
                return 0;
            }
        }
        public double GetSecondNumber()
        {
            if (!CalculateBox.Text.Contains("LOG"))
            {
                string[] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                string numberStr = substrings[2];                              // извлекаем второй элемент массива
                if (double.TryParse(numberStr, out double number))
                {
                        return number;
                }
                else
                {
                    MessageBox.Show("Вы ввели не число!");
                    return 0;
                }
            }
            else
            {
                string[] substrings = CalculateBox.Text.Split(' ');         // разбиваем строку на массив подстрок
                string numberStr = substrings[1];                              // извлекаем второй элемент массива
                if (double.TryParse(numberStr, out double number))
                        return number;
                else
                {
                    MessageBox.Show("Вы ввели не число!");
                    return 0;
                }
            }
        }
        public bool CheckText()
        {
            string [] substrings = CalculateBox.Text.Split(' ');
            if (substrings.Length > 1)
                return true;
            else
                return false;
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
        public void ClearTextField() {CalculateBox.Text = null;}
    }
}
