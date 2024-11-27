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
            Console.WriteLine("Задание номер 1\n");
            Console.WriteLine("Введите имя файла:(тестовый файл(txt(расширение писать не надо))(файл из репозитория называется 'papa' или 'nepapa'))");
            string filename = Console.ReadLine();
            string fileName = filename + ".txt";
            string papka = @"C:\Users\Asus\source\repos\TselousovDZ5"; //сюда допишете свою папку чтобы все красиво работало
            string papkafile = Path.Combine(papka, fileName);
            try
            {
                string content = File.ReadAllText(papkafile);
                char[] characters = content.ToCharArray();
                int vowelsCount, consonantsCount;
                SchetchikBykv(characters, out vowelsCount, out consonantsCount);
                Console.WriteLine($"Количество гласных букв: {vowelsCount}");
                Console.WriteLine($"Количество согласных букв: {consonantsCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            Console.ReadKey();
        }
        static void SchetchikBykv(char[] characters, out int vowelsCount, out int consonantsCount)
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
            return Regex.IsMatch(c.ToString(), "[bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]", RegexOptions.IgnoreCase);
        }
        static bool IsVowel(char c)
        {
            return Regex.IsMatch(c.ToString(), "[aeiouyAEIOUY]", RegexOptions.IgnoreCase);
        }
        
        static void Task2()
        {

        }
    }
}
