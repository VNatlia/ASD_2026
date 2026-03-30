using System;
using System.Diagnostics.Contracts;

namespace List;

public class CustomList
{
    private int[] collection;
    private int size;
    private int capacity;

    private const int CAPACITY = 10; 

    public CustomList() 
    {
        capacity = CAPACITY;
        collection = new int[capacity];
        size = 0; 
    }

    public bool IsFull()
    {
        return size == capacity; 
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public bool Add(int item)
    {
        if (IsFull())
        {
            capacity += CAPACITY;
            Array.Resize(ref collection, capacity);
        }

        collection[size] = item;
        size++;

        return true;
    }

    public int RemoveLast()
    {
        if (IsEmpty())
        {
            throw new Exception("Список пустий");
        }
        int value = collection[size - 1];
        collection[size - 1] = 0;
        size--;
        return value;
    }

    public int RemoveAt(int index)
    {
        if (IsEmpty())
            throw new Exception("Список пустий");

        if (index < 0 || index >= size)
            throw new Exception("Неправильний індекс");

        int value = collection[index];

        for (int i = index; i < size - 1; i++)
        {
            collection[i] = collection[i + 1];
        }

        size--;
        return value;
    }

    public void Print()
    {
        Console.Write("List: ");
        for (int i = 0; i < size; i++)
        {
            Console.Write(collection[i] + " ");
        }
        Console.WriteLine();
    }

    public int GetIndex(int index) 
    {
        return collection[index];
    }

    public int Size()
    {
        return size;
    }
}