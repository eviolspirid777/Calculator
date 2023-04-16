using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TempNumbers
{
    class TempNumb
    {
        public List<double> IntermediateNumbers = new List<double>();             //создает список, для хранения промежуточных значений
        public string[] IntermediateText;                                        //создает массив (string) для хранения промежуточных действий
        public List <char> Symbols = new List <char> ();                                        //создает список для хранения знаков
        public double result = 0;
        public string TempText = "";
        int b = 0;
        public TempNumb(string text)
        {
            char[] decimilates = new char[] { '-', '+', '*', '/' };                 //набор разделителей
            IntermediateText = text.Split(decimilates);
            for (int b = 0; b < text.Length - 1; b++)                        //Сохраняет порядок действий в список
            {
                if (text[b] == '+' || text[b] == '-' || text[b] == '*' || text[b] == '/')
                    Symbols.Add(text[b]);
            }
            for (int i = 0; i < IntermediateText.Count(); i++)
            {
                if (IntermediateText[i].EndsWith('+') || IntermediateText[i].EndsWith('-') || IntermediateText[i].EndsWith('*') || IntermediateText[i].EndsWith('/'))
                    IntermediateText[i] = IntermediateText[i].Substring(0, text.Length - 1);        //удаляем знаки "* - / +"
                IntermediateText[i] = IntermediateText[i].Trim();         //обрезаем пробелы в конце
                if (IntermediateText[i].Contains("LOG"))
                {
                    bool flag = false;                               //флаг для разделения двух значений
                    double[] b = new double[2];             //массив для хранения двух значений(логарифмируемого и итогового)
                    string[] substring = IntermediateText[i].Split(' ');
                    for (int z = 0; z < substring.Length; z++)
                    {
                        if (double.TryParse(substring[z], out b[0]) && flag == false) { }
                        if (double.TryParse(substring[z], out b[1]) && flag != false) { }
                    }
                    IntermediateNumbers.Add(Math.Log(b[1], b[0]));          ////ЗАПИСЫВАЕМ РЕЗУЛЬТАТ
                }
                else if (IntermediateText[i].Contains('!'))
                {
                    double fact = 0;                                             //переменная для хранения результата
                    IntermediateText[i] = IntermediateText[i].Trim('!');                          //обрезаем !
                    if (int.TryParse(IntermediateText[i], out int number)) { var numb = Factorial(number); fact = Convert.ToDouble(numb); }
                    IntermediateNumbers.Add(fact);                //ЗАПИСЫВАЕМ РЕЗУЛЬТАТ
                }
                else if (IntermediateText[i].Contains("Ln"))
                {
                    IntermediateText[i] = IntermediateText[i].Substring(2, IntermediateText[i].Length);                          //обрезаем Ln
                    if (double.TryParse(IntermediateText[i], out double num))
                        IntermediateNumbers.Add(Math.Log(num));                //ЗАПИСЫВАЕМ РЕЗУЛЬТАТ
                }
                else if (IntermediateText[i].Contains('^'))
                {
                    bool flag = false;                               //переключатель
                    double[] b = new double[2];             //массив для хранения двух значений(основания и степени)
                    string[] substring = IntermediateText[i].Split(' ');
                    for (int z = 0; z < substring.Length; z++)
                    {
                        if (double.TryParse(substring[z], out b[0]) && flag == false) { }
                        if (double.TryParse(substring[z], out b[1]) && flag != false) { }
                    }
                    IntermediateNumbers.Add(Math.Pow(b[0], b[1]));
                }
            }
            //TempText = "";             //обнуляет текстовую переменную
            for (int i = 0; i < IntermediateNumbers.Count; i++)         //записывает в текстовую перменную простые вычисления + - * /
            {
                TempText += IntermediateNumbers[i];
                if (b <= Symbols.Count)
                {
                    TempText += Symbols[i];
                    b++;
                }
            }

            string[] subtext = TempText.Split(new char[] { '+', '-' });         //разбиваю, исходя из {'+' , '-'}
            b = 0;                                                                                      //обнуляем счетчик
            Symbols.Clear();                                                                //Удаляет все знаки, которые хранились в Symbols
            IntermediateNumbers.Clear();                            //удаляет промежуточные значения
            double[] doubles = new double[2];                 //сохраняет значения, которые стоят под ('*','/')

            foreach (char c in TempText)
            {
                if (c == '+' || c == '-')
                    Symbols.Add(c);                                        //Запоминает позиции '+' '-'
            }
            for (int i = 0; i < subtext.Length; i++)
            {
                subtext[i].Trim();          //очищаем пробелы
                subtext[i].Trim(new char[] { '+', '-' });        //удаляет промежуточные знаки
                if (subtext[i].Contains('*'))                   //находим выражения с умножениями
                {
                    string[] suberlines = subtext[i].Split(' ');
                    if (double.TryParse(suberlines[0], out doubles[0]) && double.TryParse(suberlines[2], out doubles[1]))
                        IntermediateNumbers.Add(doubles[0] * doubles[1]);               //находит значение под умножением
                }
                if (subtext[i].Contains('/'))
                {
                    string[] suberlines = subtext[i].Split(' ');
                    if (double.TryParse(suberlines[0], out doubles[0]) && double.TryParse(suberlines[2], out doubles[1]))
                        IntermediateNumbers.Add(doubles[0] / doubles[1]);               //находит значение под умножением
                }
            }
            //TempText = "";             //обнуляет текстовую переменную
            for (int i = 0; i < IntermediateNumbers.Count; i++)              //записывает в текстовую перменную простые вычисления + -
            {
                TempText += IntermediateNumbers[i];
                if (b <= Symbols.Count)
                {
                    TempText += Symbols[i];
                    b++;
                }
            }
            string[] suberstring = TempText.Split('+');        //Разбиваю по '+'
            b = 0;                                                                                      //обнуляем счетчик
            Symbols.Clear();                                          //очищает промежуточные символы
            IntermediateNumbers.Clear();                    //очищает промежуточные значения
            double[] doubl = new double[2];                 //сохраняет значения, которые стоят под ('-')

            foreach (char c in TempText)
            {
                if (c == '+')
                    Symbols.Add(c);                                     //Запоминает кол-во и порядок знаков ('+')
            }
            for (int i = 0; i < suberstring.Length; i++)
            {
                subtext[i].Trim();              //обрезаем пробелы
                subtext[i].Trim('+');       //обрезаем плюсы
                if (subtext[i].Contains('-'))
                {
                    string [ ] suberlines = subtext[i].Split(' ');
                    if (double.TryParse(suberlines[0], out doubles[0]) && double.TryParse(suberlines[2], out doubles[1]))   
                        IntermediateNumbers.Add(doubles[0] - doubles[1]);               //находит значение под вычитанием
                }
            }
            //TempText = "";             //обнуляет текстовую переменную
            for (int i = 0; i < IntermediateNumbers.Count; i++)              //записывает в текстовую перменную простые вычисления +
            {
                TempText += IntermediateNumbers[i];
                if (b <= Symbols.Count)
                {
                    TempText += Symbols[i];
                    b++;
                }
            }

            List<double> Term = new List<double>();                             //Для хранения значений для сложения
            string [ ] sbstr = TempText.Split('+');          //разбивает на подстроки

            for(int i = 0; i < sbstr.Length; i++)
            {
                if (double.TryParse(sbstr[i], out double b))            //добавляет значение в список
                    Term.Add(b);
            }
            for(int i = 0; i < Term.Count - 1; i++)
            {
                result += Term[i] + Term[i + 1];                                         //высчитывает и записывает результат вычислений
            }
        }
        public static BigInteger Factorial(int n)                              //Факториал
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= n; i++)
                factorial *= i;
            return factorial;
        }
    }
}
