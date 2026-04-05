using System;
using List;
using CustomStack;

class Program
{
    static void Main()
    {
        CustomList list = new CustomList();
        LinkedStack stack = new LinkedStack();

        list.Add(-10);
        list.Add(-5);
        list.Add(7);
        list.Add(-3);
        list.Add(20);

        Console.WriteLine("Початковий список:");
        list.Print();

        for (int i = 0; i < list.Size(); i++)
        {
            int value = list.GetIndex(i);

            if (value < 0)
            {
                list.RemoveAt(i);
                i--; 
            }
            else
            {
                string octal = Convert.ToString(value, 8);
                stack.Push(octal);
            }
        }

        Console.WriteLine("\nСписок після видалення від’ємних:");
        list.Print();

        Console.WriteLine("\nСтек (вісімкова система):");
        stack.Print();
    }
}