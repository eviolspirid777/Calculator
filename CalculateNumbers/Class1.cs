namespace CalculateNumbers
{
    public class CalculateNumbers
    {
        static public int GetSecondNumber()
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
    }
}