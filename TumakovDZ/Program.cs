using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;


namespace TumakovDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }
        //NUMBER 1
        static void Task1()
        {
            Console.WriteLine("Задание номер 1\n");
            Console.WriteLine("Введите имя файла:(теkстовый файл(txt(расширение писать не надо))(файл из репозитория называется 'papa' или 'nepapa'))");
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
        static void SchetchikBykv2(List<char> characters, out int vowelsCount, out int consonantsCount)
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
            return Regex.IsMatch(c.ToString(), "[бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩbcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]", RegexOptions.IgnoreCase);
        }
        static bool IsVowel(char c)
        {
            return Regex.IsMatch(c.ToString(), "[ауоиэыяюеёАУОИЭЫЯЮЕЁaeiouyAEIOUY]", RegexOptions.IgnoreCase);
        }
        //NUMBER 2
        static void Task2()
        {
            Console.WriteLine("\nЗадание номер 2\n");
            int[,] A = { { 1, 2 }, { 3, 4 } };
            int[,] B = { { 5, 6 }, { 7, 8 } };
            int[,] product = UmnojMatrix(A, B);
            Console.WriteLine("Результат умножения:");
            PrintMatrix(product);
            Console.ReadKey();
        }
        public static void PrintMatrix(int[,] matrix)
        {
            int strok = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            for (int i = 0; i < strok; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

        }
        public static int[,] UmnojMatrix(int[,] A, int[,] B)
        {
            int strokA = A.GetLength(0);
            int stolbA = A.GetLength(1);
            int strokB = B.GetLength(0);
            int stolbB = B.GetLength(1);

            if (stolbA != strokB)
            {
                throw new ArgumentException("Матрицы нельзя перемножить.");
            }

            int[,] result = new int[strokA, stolbB];

            for (int i = 0; i < strokA; i++)
            {
                for (int j = 0; j < stolbB; j++)
                {
                    for (int k = 0; k < stolbA; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return result;
        }
        //
        static void Task3()
        {
        Console.WriteLine("\nЗадание номер 3\n");
        int[,] temperature = new int[12, 30];
        Random random = new Random();
        for (int i = 0; i < 12; i++)
            {
            for (int j = 0; j < 30; j++)
                {
                temperature[i, j] = random.Next(-20, 41);
                }
            }
        double[] averageTemperatures = CalculateAverageTemperature(temperature);
        Array.Sort(averageTemperatures);
        Console.WriteLine("Средние температуры по месяцам:");
        for (int i = 0; i < 12; i++)
            {
            Console.WriteLine($"Месяц {i + 1}: {averageTemperatures[i]:F2}");
            }
        Console.ReadKey();
        }
        static double[] CalculateAverageTemperature(int[,] temperatures)
        {
            double[] averages = new double[temperatures.GetLength(0)];
            for (int month = 0; month < temperatures.GetLength(0); month++)
            {
                double sum = 0;
                for (int day = 0; day < temperatures.GetLength(1); day++)
                {
                    sum += temperatures[month, day];
                }
                averages[month] = sum / temperatures.GetLength(1);
            }
            return averages;
        }
        static void Task4()
        {
            Console.WriteLine("\nЗадание номер 4\n");
            Console.WriteLine("Введите имя файла:(тестовый файл(txt(расширение писать не надо))(файл из репозитория называется 'papa' или 'nepapa'))");
            string filename = Console.ReadLine();
            string fileName = filename + ".txt";
            string papka = @"C:\Users\Asus\source\repos\TselousovDZ5"; //сюда допишете свою папку чтобы все красиво работало
            string papkafile = Path.Combine(papka, fileName);
            try
            {
                string content = File.ReadAllText(papkafile);
                List<char> characters = content.ToCharArray().ToList();
                int vowelsCount, consonantsCount;
                SchetchikBykv2(characters, out vowelsCount, out consonantsCount);
                Console.WriteLine($"Количество гласных букв: {vowelsCount}");
                Console.WriteLine($"Количество согласных букв: {consonantsCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            Console.ReadKey();
        }
        public static void PrintMatrix2(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.WriteLine();
        }
        public static LinkedList<LinkedList<int>> MultiplyMatrices2(LinkedList<LinkedList<int>> A, LinkedList<LinkedList<int>> B)
        {
            int m = A.Count;
            int n = A.First.Value.Count;
            int p = B.First.Value.Count;

            if (A.First.Value.Count != B.Count)
            {
                throw new ArgumentException("Матрицы нельзя перемножить.");
            }

            var result = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < m; i++)
            {
                var rowResult = new LinkedList<int>();
                for (int j = 0; j < p; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += A.ElementAt(i).ElementAt(k) * B.ElementAt(k).ElementAt(j);
                    }
                    rowResult.AddLast(sum);
                }
                result.AddLast(rowResult);
            }

            return result;
        }
        static void Task5()
        { Console.WriteLine("..."); }
        /*{
            var A = new LinkedList<LinkedList<int>>
        {
         //не получается сюда ничего написатть варианты во второй матрице
        };

            LinkedList<int> linkedList = new LinkedList<int>(new[] { 5, 6 });
            var B = new LinkedList<LinkedList<int>>
        {
         //   linkedList,
          //  new LinkedList<int>(new[] { 7, 8 })
        };

            Console.WriteLine("Матрица A:");
            PrintMatrix2(A);

            Console.WriteLine("Матрица B:");
            PrintMatrix2(B);

            MultiplyMatrices2(A, B);

            Console.WriteLine("Результат умножения A * B:");
            Console.WriteLine(MultiplyMatrices2(A, B));

        }*/
        static void Task6()
        {
            var temperatureByMonth = new Dictionary<string, double[]>
        {
            {"Январь", GenerateTemp()},
            {"Февраль", GenerateTemp()},
            {"Март", GenerateTemp()},
            {"Апрель", GenerateTemp()},
            {"Май", GenerateTemp()},
            {"Июнь", GenerateTemp()},
            {"Июль", GenerateTemp()},
            {"Август", GenerateTemp()},
            {"Сентябрь", GenerateTemp()},
            {"Октябрь", GenerateTemp()},
            {"Ноябрь", GenerateTemp()},
            {"Декабрь", GenerateTemp()}
        };

            // Рассчитываем и выводим средние температуры для каждого месяца
            foreach (var kvp in temperatureByMonth)
            {
                var averageTemp = AverageTemp(kvp.Value);
                Console.WriteLine($"Средняя температура за {kvp.Key}: {averageTemp:F2}°C");
            }

            // Сортируем средние температуры по возрастанию
            var sortedAverages = temperatureByMonth
                .Select(kvp => new { Month = kvp.Key, Average = AverageTemp(kvp.Value) })
                .OrderBy(x => x.Average)
                .ToList();

            Console.WriteLine("\nСредние температуры по месяцам, отсортированные по возрастанию:");
            foreach (var item in sortedAverages)
            {
                Console.WriteLine($"{item.Month}: {item.Average:F2}°C");
            }
        }
        private static double[] GenerateTemp()
        {
            var random = new Random();
            var temperatures = new double[30];
            for (int i = 0; i < temperatures.Length; i++)
            {
                temperatures[i] = random.Next(-20, 41); // Температура от -20°C до 40°C
            }
            return temperatures;
        }
        private static double AverageTemp(double[] temperatures)
        {
            return temperatures.Average();
        }
    }
}
