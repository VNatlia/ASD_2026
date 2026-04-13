using System;
using System.Collections.Generic;

namespace Lab1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();

            Student[] students =
            {
                new Student("Перший", 3, 15, 95, "Україна"),
                new Student("Другий", 2, 10, 82, "Україна"),
                new Student("Третій", 3, 25, 91, "Україна"),
                new Student("Четвертий", 1, 5, 70, "США"),
                new Student("П'ятий", 3, 20, 88, "Швейцарія"),
                new Student("Шостий", 3, 30, 97, "Іспанія")
            };

            foreach (Student student in students)
            {
                tree.Insert(student);
            }

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n\tМеню");
                Console.WriteLine("1. Прохід в ширину");
                Console.WriteLine("2. Знайти студентів 3 курсу, які вчаться на відмінно та проживають в Україні");
                Console.WriteLine("3. Видалити студентів 3 курсу, які вчаться на відмінно та проживають в Україні");
                Console.WriteLine("4. Вихід");
                Console.Write("Ваш вибір: ");

                int choice;
                bool isNumber = int.TryParse(Console.ReadLine(), out choice);

                if (!isNumber)
                {
                    Console.WriteLine("Некоректне введення");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Print(tree.TraversalBreadth());
                        break;

                    case 2:
                        List<Student> found = tree.Search(3, 90, "Україна");

                        if (found.Count == 0)
                        {
                            Console.WriteLine("Нічого не знайдено");
                        }
                        else
                        {
                            Print(found);
                        }
                        break;

                    case 3:
                        tree.DeleteByCourseGradeCitizenship(3, 90, "Україна");
                        Console.WriteLine("Вузли видалено");
                        Print(tree.TraversalBreadth());
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Невірний пункт меню");
                        break;
                }
            }
        }

        static void Print(List<Student> list)
        {
            Console.WriteLine("ID         | Прізвище         | Курс   | Бал     1| Громадянство");
            foreach (Student student in list)
            {
                Console.WriteLine(student);
            }
        }
    }
}