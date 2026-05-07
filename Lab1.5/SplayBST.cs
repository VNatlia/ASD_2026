using System;

namespace Lab1._5;

using System;
using System.Collections.Generic;

public class SplayBST
{
    private Node root;

    private Node RotateRight(Node node)
    {
        Node newRoot = node.Left;
        node.Left = newRoot.Right;
        newRoot.Right = node;

        return newRoot;
    }

    private Node RotateLeft(Node node)
    {
        Node newRoot = node.Right;
        node.Right = newRoot.Left;
        newRoot.Left = node;

        return newRoot;
    }

    private Node Splay(Node node, double key)
    {
        if (node == null || node.Data.AverageGrade == key)
            return node;

        if (key < node.Data.AverageGrade)
        {
            if (node.Left == null)
                return node;

            if (key < node.Left.Data.AverageGrade)
            {
                node.Left.Left = Splay(node.Left.Left, key);
                node = RotateRight(node);
            }
            else if (key > node.Left.Data.AverageGrade)
            {
                node.Left.Right = Splay(node.Left.Right, key);

                if (node.Left.Right != null)
                    node.Left = RotateLeft(node.Left);
            }

            if (node.Left == null)
                return node;

            return RotateRight(node);
        }
        else
        {
            if (node.Right == null)
                return node;

            if (key > node.Right.Data.AverageGrade)
            {
                node.Right.Right = Splay(node.Right.Right, key);
                node = RotateLeft(node);
            }
            else if (key < node.Right.Data.AverageGrade)
            {
                node.Right.Left = Splay(node.Right.Left, key);

                if (node.Right.Left != null)
                    node.Right = RotateRight(node.Right);
            }

            if (node.Right == null)
                return node;

            return RotateLeft(node);
        }
    }

    public void Insert(Student student)
    {
        double key = student.AverageGrade;

        if (root == null)
        {
            root = new Node(student);
            return;
        }

        root = Splay(root, key);

        if (root.Data.AverageGrade == key)
            return;

        Node newNode = new Node(student);

        if (key < root.Data.AverageGrade)
        {
            newNode.Right = root;
            newNode.Left = root.Left;
            root.Left = null;
        }
        else
        {
            newNode.Left = root;
            newNode.Right = root.Right;
            root.Right = null;
        }

        root = newNode;
    }

    public Student Search(double key)
    {
        if (root == null)
            return null;

        root = Splay(root, key);

        if (root.Data.AverageGrade == key)
            return root.Data;

        return null;
    }

    public void PrintBFS(string title)
    {
        Console.WriteLine($"\n--- {title} ---");

        if (root == null)
        {
            Console.WriteLine("Дерево порожнє.");
            return;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();

            Console.WriteLine(node.Data);

            if (node.Left != null)
                queue.Enqueue(node.Left);

            if (node.Right != null)
                queue.Enqueue(node.Right);
        }
    }
}
