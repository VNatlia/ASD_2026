using System;
using RhombusLibrary;

namespace HashTableLibrary;

public class HashTable
{
    private Rhombus[] table;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        table = new Rhombus[size];
    }

    private int GetKey(Rhombus rhombus)
    {
        return (int)rhombus.GetPerimeter();
    }

    private int Hash1(int key)
    {
        return key % size;
    }

    private int Hash2(int key)
    {
        return 1 + (key % (size - 1));
    }

    public bool Insert(Rhombus rhombus)
    {
        int key = GetKey(rhombus);
        int index = Hash1(key);

        if (table[index] == null)
        {
            table[index] = rhombus;
            return true;
        }

        int step = Hash2(key);

        for (int i = 1; i < size; i++)
        {
            int newIndex = (index + i * step) % size;

            if (table[newIndex] == null)
            {
                table[newIndex] = rhombus;
                return true;
            }
        }

        return false; 
    }

    public void Print()
    {
        Console.WriteLine("Hash table:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(i + ": ");

            if (table[i] != null)
            {
                Console.Write("Key = " + GetKey(table[i]) + " | ");
                table[i].Print();
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }

    public void DeleteByArea(double maxArea)
    {
        for (int i = 0; i < size; i++)
        {
            if (table[i] != null && table[i].GetArea() > maxArea)
            {
                table[i] = null;
            }
        }
    }
}