using System;

namespace Lab1._5;

public class Node
{
    public Student Data;
    public Node Left;
    public Node Right;

    public Node(Student student)
    {
        Data = student;
        Left = null;
        Right = null;
    }
}