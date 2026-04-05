using System;
using RhombusLibrary;
using HashTableLibrary;

namespace ProgramLab12;

class Program
{
    static void Main(string[] args)
    {
        HashTable table = new HashTable(10);

        Rhombus r1 = new Rhombus(6, 8, 5);   // S = 24, P = 20
        Rhombus r2 = new Rhombus(4, 10, 6);  // S = 20, P = 24
        Rhombus r3 = new Rhombus(10, 12, 7); // S = 60, P = 28
        Rhombus r4 = new Rhombus(8, 6, 5);   // S = 24, P = 20
        Rhombus r5 = new Rhombus(14, 10, 8); // S = 70, P = 32

        table.Insert(r1);
        table.Insert(r2);
        table.Insert(r3);
        table.Insert(r4);
        table.Insert(r5);

        Console.WriteLine("Before delete:");
        table.Print();

        Console.WriteLine();
        table.DeleteByArea(30);

        Console.WriteLine("After delete:");
        table.Print();
    }
}