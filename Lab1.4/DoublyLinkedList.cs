using System;

namespace Lab1._4;

public class DoublyLinkedList
{
        public Node Head;
        public Node Tail;

        public void Add(Student student)
        {
            Node newNode = new Node(student);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Tail = newNode;
            }
        }

        public void Print(string title)
        {
            Console.WriteLine($"\n{title}");
            Console.WriteLine("Сер.бал | Прізвище     | Ім'я         | Стать");
            Console.WriteLine(new string('-', 50));

            Node current = Head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

            Console.WriteLine(new string('-', 50));
        }
    }
