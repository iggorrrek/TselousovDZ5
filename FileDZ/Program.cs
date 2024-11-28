using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileDZ
{
    internal class Program
    {
        //private static Queue<Grandma> grandmas = new Queue<Grandma>();
        //private static Stack<Hospital> hospitals = new Stack<Hospital>();

        static void Main(string[] args)
        {
            Task1();
            Task2();
            //Task3();
            Task4();
        }
        static void Task1()
        {
            //FileInfo info = new FileInfo("");  
            string folderPath = Path.Combine(@"C:\Users\Asus\source\repos\TselousovDZ5"); // здесь тоже самое что и в первом зажании Тумакова
            List<string> imageFiles = Directory.GetFiles(folderPath, "*.jpg").ToList();
            if (imageFiles.Count != 32)
            {
                Console.WriteLine( imageFiles.Count);
                Console.WriteLine("ошибка не 32 фотографии");
                return;
            }
            List<string> images = new List<string>();
            foreach (string file in imageFiles)
            {
                images.Add(file);
                images.Add(file);
            }
            Console.WriteLine("Исходная последовательность:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"Элемент {i + 1}: {Path.GetFileName(images[i])}");
            }
            Shuffle(images);
            Console.WriteLine("\nПеремешанная последовательность:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"Элемент {i + 1}: {Path.GetFileName(images[i])}");
            }
        }
        static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }













        public struct Student
        {
            public string LastName;
            public string FirstName;
            public int BirthYear;
            public string Exam;
            public int Score;

            public Student(string lastName, string firstName, int birthYear, string exam, int score)
            {
                LastName = lastName;
                FirstName = firstName;
                BirthYear = birthYear;
                Exam = exam;
                Score = score;
            }
        }
        private static void AddStudent()
        {
            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Год рождения: ");
            int birthYear = int.Parse(Console.ReadLine());
            Console.Write("Экзамен: ");
            string exam = Console.ReadLine();
            Console.Write("Баллы: ");
            int score = int.Parse(Console.ReadLine());

            Student student = new Student(lastName, firstName, birthYear, exam, score);
            students.Add(student);
            Console.WriteLine("Студент добавлен.\n");
        }
        private static void RemoveStudent()
        {
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();

            var studentToRemove = students.FirstOrDefault(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                                                             s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

            if (studentToRemove.Equals(default(Student)))
            {
                Console.WriteLine("Студент не найден.\n");
            }
            else
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Студент удален.\n");
            }
        }
        private static void PrintStudents()
        {
            Console.WriteLine("Список студентов:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.LastName} {student.FirstName}, Год рождения: {student.BirthYear}, Экзамен: {student.Exam}, Баллы: {student.Score}");
            }
            Console.WriteLine();
        }
        private static void SortStudents()
        {
            students = students.OrderBy(s => s.Score).ToList();
            Console.WriteLine("Студенты отсортированы по баллам.\n");
        }
        private static void ReadStudentsFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 5 &&
                            int.TryParse(parts[2], out int birthYear) &&
                            int.TryParse(parts[4], out int score))
                        {
                            var student = new Student(parts[0], parts[1], birthYear, parts[3], score);
                            students.Add(student);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл не найден. Будьте внимательны при вводе данных.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при чтении файла: {ex.Message}");
            }
        }
        private static List<Student> students = new List<Student>();


        static void Task2()
        {
            ReadStudentsFromFile(@"C:\Users\Asus\source\repos\TselousovDZ5\studentu.txt");
            try 
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Новый студент");
                Console.WriteLine("2. Удалить");
                Console.WriteLine("3. Сортировать");
                Console.WriteLine("4. Вывести список студентов");
                Console.WriteLine("5. Выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        SortStudents();
                        break;
                    case "4":
                        PrintStudents();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
            catch (Exception ex) // Указываем тип исключения
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}"); // Обработка ошибки (можно вывести сообщение об ошибке)
            }
        }












        /*struct Grandma           МОЖНО НЕ ПРОВЕРЯТЬ Я ОСТАВИЛ ДЛЯ СЕБЯ ПОТОМУ ЧТО ЭТОТ КОД ИЗ ЧАТА ГПТ (НЕРАБОТАЕТ ВВОД БОЛЬНИЦ)             
        {
            public string Name;
            public int Age;
            public List<string> Illnesses;
            public List<string> Medicines;

            public Grandma(string name, int age, List<string> illnesses, List<string> medicines)
            {
                Name = name;
                Age = age;
                Illnesses = illnesses;
                Medicines = medicines;
            }

            public override string ToString()
            {
                return $"{Name} (Age: {Age}, Illnesses: {string.Join(", ", Illnesses)})";
            }
        }

        struct Hospital
        {
            public string Name;
            public List<string> TreatableIllnesses;
            public int Capacity;
            public Queue<Grandma> Patients;

            public Hospital(string name, List<string> treatableIllnesses, int capacity)
            {
                Name = name;
                TreatableIllnesses = treatableIllnesses;
                Capacity = capacity;
                Patients = new Queue<Grandma>();
            }

            public double OccupancyPercentage()
            {
                return (double)Patients.Count / Capacity * 100;
            }

            public bool CanAdmit(Grandma grandma)
            {
                return CanAdmit(grandma, TreatableIllnesses);
            }

            public bool CanAdmit(Grandma grandma, List<string> treatableIllnesses)
            {
                if (Capacity <= Patients.Count) return false;
                int matchingIllnesses = grandma.Illnesses.Count(i => treatableIllnesses.Contains(i));
                return matchingIllnesses > (grandma.Illnesses.Count / 2.0);
            }

            public void Admit(Grandma grandma)
            {
                if (Patients.Count < Capacity)
                {
                    Patients.Enqueue(grandma);
                }
            }

            public override string ToString()
            {
                return $"{Name} (Capacity: {Capacity}, Current Patients: {Patients.Count}, Occupancy: {OccupancyPercentage():F2}%)";
            }
        }


        static void Task3()
        {
            InitializeHospitals();

            while (true)
            {
                Console.Write("Enter grandma's name (or type 'exit' to finish): ");
                string name = Console.ReadLine();
                if (name.ToLower() == "exit") break;

                Console.Write("Enter grandma's age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter grandma's illnesses (comma-separated): ");
                List<string> illnesses = Console.ReadLine().Split(',').Select(i => i.Trim()).ToList();

                Console.Write("Enter grandma's medicines (comma-separated): ");
                List<string> medicines = Console.ReadLine().Split(',').Select(m => m.Trim()).ToList();

                Grandma grandma = new Grandma(name, age, illnesses, medicines);
                grandmas.Enqueue(grandma);
                AssignGrandmaToHospital(grandma);
            }

            DisplayResults();
        }

        private static void InitializeHospitals()
        {
            hospitals.Push(new Hospital("City Hospital", new List<string> { "Flu", "Cold" }, 5));
            hospitals.Push(new Hospital("County Hospital", new List<string> { "Heart Disease", "Diabetes", "Flu" }, 3));
            hospitals.Push(new Hospital("Village Hospital", new List<string> { "Cold" }, 2));
        }

        private static void AssignGrandmaToHospital(Grandma grandma)
        {
            if (!grandma.Illnesses.Any())
            {
                // If no illnesses, the grandma can go to the first available hospital
                if (hospitals.Count > 0)
                {
                    var hospital = hospitals.Peek();
                    hospital.Admit(grandma);
                    Console.WriteLine($"{grandma.Name} is asking for advice at {hospital.Name}.");
                    return;
                }
                else
                {
                    Console.WriteLine($"{grandma.Name} has no place to go.");
                    return;
                }
            }

            while (hospitals.Count > 0)
            {
                var hospital = hospitals.Peek();
                if (hospital.CanAdmit(grandma))
                {
                    hospital.Admit(grandma);
                    Console.WriteLine($"{grandma.Name} has been admitted to {hospital.Name}.");
                    return;
                }
                else
                {
                    hospitals.Pop(); // Remove the hospital from the stack if it can't admit
                }
            }

            Console.WriteLine($"{grandma.Name} has no hospital that can treat her.");
        }

        private static void DisplayResults()
        {
            Console.WriteLine("\nGrandmas in the system:");
            foreach (var grandma in grandmas)
            {
                Console.WriteLine(grandma);
            }

            Console.WriteLine("\nHospitals in the system:");
            foreach (var hospital in hospitals)
            {
                Console.WriteLine(hospital);
            }

        }*/



        static void Task4()
        {
            Console.ReadKey();
        }
    }
}
