using System;

namespace Lab1._4;


public class Node
{
    public Student Data;
    public Node Prev;
    public Node Next;

    public Node(Student data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}

