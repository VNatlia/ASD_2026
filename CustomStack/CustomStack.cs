using System;

namespace CustomStack;

public class Node
{
    public string Data;
    public Node Next; 

    public Node(string data) 
    {
        Data = data;
        Next = null; 
    }
}

public class LinkedStack 
{
    private Node top; 

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Push(string value) 
    {
        Node newNode = new Node(value);
        newNode.Next = top; 
        top = newNode; 
    }

    public string Pop() 
    {
        if (IsEmpty())
        {
            throw new Exception("Стек пустий");
        }

        string value = top.Data;
        top = top.Next;

        return value;
    }

    public void Print()
    {
        Node current = top;
        Console.Write("Стек: ");
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}