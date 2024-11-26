using System;
using System.IO;
using System.Text.RegularExpressions;


namespace TumakovDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        static void Task1()
        {
            Console.WriteLine("Необходимо передать имя файла в качестве аргумента.");
            string filename = Console.ReadLine();
            string fileName = filename + ".txt";
            try
            {
                // Чтение содержимого файла в строку
                string content = File.ReadAllText(fileName);

                // Преобразование строки в массив символов
                char[] characters = content.ToCharArray();

                // Вызов метода для подсчета количества гласных и согласных букв
                int vowelsCount, consonantsCount;
                CountVowelsAndConsonants(characters, out vowelsCount, out consonantsCount);

                // Вывод результатов
                Console.WriteLine($"Количество гласных букв: {vowelsCount}");
                Console.WriteLine($"Количество согласных букв: {consonantsCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            Console.ReadKey();
        }
        static void CountVowelsAndConsonants(char[] characters, out int vowelsCount, out int consonantsCount)
        {
            vowelsCount = 0;
            consonantsCount = 0;

            foreach (char c in characters)
            {
                if (IsVowel(c))
                    vowelsCount++;
                else if (IsConsonant(c))
                    consonantsCount++;
            }
        }
        static bool IsConsonant(char c)
        {
            // Регулярное выражение для проверки, является ли символ согласной буквой
            return Regex.IsMatch(c.ToString(), "[bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]", RegexOptions.IgnoreCase);
        }
        static bool IsVowel(char c)
        {
            // Регулярное выражение для проверки, является ли символ гласной буквой
            return Regex.IsMatch(c.ToString(), "[aeiouyAEIOUY]", RegexOptions.IgnoreCase);
        }
        
        static void Task2()
        {

        }
    }
}
