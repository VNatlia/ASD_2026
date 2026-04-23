using System;

namespace Lab1._4;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

//1l
        Console.WriteLine("\nСОРТУВАННЯ ВСТАВКОЮ МАСИВУ\n");

        Student[] studentsArray =
            {
                new Student("Іваненко", "Олег", 81.4, "Ч"),
                new Student("Петренко", "Марія", 95.2, "Ж"),
                new Student("Сидоренко", "Андрій", 73.8, "Ч"),
                new Student("Коваль", "Ірина", 88.1, "Ж"),
                new Student("Бойко", "Василь", 69.5, "Ч")
            };

        Sort.PrintArray(studentsArray, "1 рівень: масив до сортування");

        Sort.InsertionSortArray(studentsArray);

        Sort.PrintArray(studentsArray, "1 рівень: масив після сортування");

//2l
        Console.WriteLine("\nСОРТУВАНЯ ВСТАВКОЮ СПИСКУ\n");

        DoublyLinkedList list = new DoublyLinkedList();

        list.Add(new Student("Іваненко", "Олег", 81.4, "Ч"));
        list.Add(new Student("Петренко", "Марія", 95.2, "Ж"));
        list.Add(new Student("Сидоренко", "Андрій", 73.8, "Ч"));
        list.Add(new Student("Коваль", "Ірина", 88.1, "Ж"));
        list.Add(new Student("Бойко", "Василь", 69.5, "Ч"));

        list.Print("2 рівень: Список до сортування");

        Sort.InsertionSortList(list);

        list.Print("2 рівень: Список після сортування");


//3l
        Console.WriteLine("\nКИШЕНЬКОВЕ СОРТУВАННЯ\n");

        Student[] studentsBucket =
        {
                new Student("Іваненко", "Олег", 81.4, "Ч"),
                new Student("Петренко", "Марія", 95.2, "Ж"),
                new Student("Сидоренко", "Андрій", 73.8, "Ч"),
                new Student("Коваль", "Ірина", 88.1, "Ж"),
                new Student("Бойко", "Василь", 69.5, "Ч")
            };

        Sort.PrintArray(studentsBucket, "3 рівень: масив до сортування");

        Sort.BucketSort(studentsBucket);

        Sort.PrintArray(studentsBucket, "3 рівень: масив після");


        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}
