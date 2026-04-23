using System;

namespace Lab1._4;

public static class Sort
{
    //1l
    public static void InsertionSortArray(Student[] students)
    {

        for (int i = 1; i < students.Length; i++)
        {
            Student key = students[i];
            int j = i - 1;

            while (j >= 0 && students[j].AverageGrade > key.AverageGrade)
            {
                students[j + 1] = students[j];
                j--;
            }

            students[j + 1] = key;
        }
    }

    //2l
    public static void InsertionSortList(DoublyLinkedList list)
    {

        if (list.Head == null) return;

        Node current = list.Head.Next;

        while (current != null)
        {
            Student key = current.Data;
            Node j = current.Prev;

            while (j != null && j.Data.AverageGrade > key.AverageGrade)
            {
                j.Next.Data = j.Data;
                j = j.Prev;
            }

            if (j == null)
                list.Head.Data = key;
            else
                j.Next.Data = key;

            current = current.Next;
        }
    }

    // 3l
    public static void BucketSort(Student[] students)
    {

        double min = students[0].AverageGrade;
        double max = students[0].AverageGrade;

        foreach (Student s in students)
        {
            if (s.AverageGrade < min) min = s.AverageGrade;
            if (s.AverageGrade > max) max = s.AverageGrade;
        }

        int bucketCount = 5;
        Student[][] buckets = new Student[bucketCount][];

        int[] counts = new int[bucketCount];

        for (int i = 0; i < bucketCount; i++)
            buckets[i] = new Student[students.Length];

        double interval = (max - min + 0.1) / bucketCount;

        // розкладка по кишенях
        foreach (Student stud in students)
        {
            int index = (int)((stud.AverageGrade - min) / interval);
            if (index >= bucketCount) index = bucketCount - 1;

            buckets[index][counts[index]] = stud;
            counts[index]++;
        }

        for (int i = 0; i < bucketCount; i++)
        {
            InsertionSortBucket(buckets[i], counts[i]);
        }

        int k = 0;
        for (int i = 0; i < bucketCount; i++)
        {
            for (int j = 0; j < counts[i]; j++)
            {
                students[k++] = buckets[i][j];
            }
        }
    }

    private static void InsertionSortBucket(Student[] bucket, int size)
    {
        for (int i = 1; i < size; i++)
        {
            Student key = bucket[i];
            int j = i - 1;

            while (j >= 0 && bucket[j].AverageGrade > key.AverageGrade)
            {
                bucket[j + 1] = bucket[j];
                j--;
            }

            bucket[j + 1] = key;
        }
    }

    public static void PrintArray(Student[] students, string title)
    {
        Console.WriteLine($"\n{title}");

        foreach (Student stud in students)
        {
            Console.WriteLine(stud);
        }
    }
}

