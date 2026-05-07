using Lab1._5;

class Program
{
    static void InsertSortedByGroup(List<Student> students, Student student)
    {
        int position = students.Count;

        for (int i = 0; i < students.Count; i++)
        {
            if (student.Group < students[i].Group)
            {
                position = i;
                break;
            }
        }

        students.Insert(position, student);
    }

    static int CountFemaleStudentsWithHighGrade(List<Student> students, int group)
    {
        int count = 0;

        foreach (Student student in students)
        {
            if (student.Group == group &&
                student.Gender == "Ж" &&
                student.AverageGrade > 9)
            {
                count++;
            }
        }

        return count;
    }

    static void PrintStudents(List<Student> students, string title)
    {
        Console.WriteLine($"\n-{title}-");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i]}");
        }
    }

    static void Main()
    {
        Student[] rawStudents =
        {
            new Student("Іваненко", "Олег", 103, "М", 6),
            new Student("Петренко", "Марія", 101, "Ж", 10),
            new Student("Коваль", "Ірина", 102, "Ж", 11),
            new Student("Мельник", "Оксана", 101, "Ж", 3),
            new Student("Левченко", "Наталія", 103, "Ж", 2)
        };

        List<Student> students = new List<Student>();

        foreach (Student student in rawStudents)
        {
            InsertSortedByGroup(students, student);
        }

        PrintStudents(students, "Масив студентів, впорядкований за номером групи");

        int targetGroup = 101;
        int count = CountFemaleStudentsWithHighGrade(students, targetGroup);

        Console.WriteLine($"\nКількість студенток групи {targetGroup} із середнім балом вище 4.5: {count}");

        Console.WriteLine("\n\n---Побудова Splay BST з оптимізацією---");

        SplayBST tree = new SplayBST();

        foreach (Student student in rawStudents)
        {
            Console.WriteLine($"\nДодаємо: {student}");
            tree.Insert(student);
            tree.PrintBFS("Дерево після додавання");
        }

        double searchKey = 10;

        Console.WriteLine($"\n\n=== Пошук у Splay BST за середнім балом {searchKey} ===");

        Student found = tree.Search(searchKey);

        if (found != null)
        {
            Console.WriteLine("Знайдено студента:");
            Console.WriteLine(found);
        }
        else
        {
            Console.WriteLine("Студента з таким середнім балом не знайдено.");
        }

        tree.PrintBFS("Дерево після пошуку");
    }
}