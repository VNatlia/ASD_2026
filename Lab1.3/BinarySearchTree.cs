

namespace Lab1._3;

public class BinarySearchTree

{
    private Node root;

    public void Insert(Student student)
    {
        root = InsertRecursive(root, student);
    }

    private Node InsertRecursive(Node node, Student student)
    {
        if (node == null)
        {
            return new Node(student);
        }

        if (student.StudentId < node.Data.StudentId)
        {
            node.Left = InsertRecursive(node.Left, student);
        }
        else if (student.StudentId > node.Data.StudentId)
        {
            node.Right = InsertRecursive(node.Right, student);
        }
        else
        {
            Console.WriteLine($"Студент з ID {student.StudentId} вже існує");
        }

        return node;
    }

    public List<Student> TraversalBreadth()
    {
        List<Student> result = new List<Student>();

        if (root == null)
        {
            return result;
        }

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            result.Add(current.Data);

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }
        }

        return result;
    }

    public List<Student> Search(int course, double minGrade, string citizenship)
    {
        List<Student> result = new List<Student>();
        SearchRecursive(root, course, minGrade, citizenship, result);
        return result;
    }

    private void SearchRecursive(Node node, int course, double minGrade, string citizenship, List<Student> result)
    {
        if (node == null)
        {
            return;
        }

        if (node.Data.Course == course &&
            node.Data.AverageGrade >= minGrade &&
            node.Data.Citizenship.Equals(citizenship, StringComparison.OrdinalIgnoreCase))
        {
            result.Add(node.Data);
        }

        SearchRecursive(node.Left, course, minGrade, citizenship, result);
        SearchRecursive(node.Right, course, minGrade, citizenship, result);
    }

    public void DeleteByCourseGradeCitizenship(int course, double minGrade, string citizenship)
    {
        List<Student> studentsToDelete = Search(course, minGrade, citizenship);

        foreach (Student student in studentsToDelete)
        {
            root = DeleteRecursiveByStudentId(root, student.StudentId);
        }
    }

    private Node DeleteRecursiveByStudentId(Node node, uint studentId)
    {
        if (node == null)
        {
            return null;
        }

        if (studentId < node.Data.StudentId)
        {
            node.Left = DeleteRecursiveByStudentId(node.Left, studentId);
        }
        else if (studentId > node.Data.StudentId)
        {
            node.Right = DeleteRecursiveByStudentId(node.Right, studentId);
        }
        else
        {
            if (node.Left == null && node.Right == null)
            {
                return null;
            }

            if (node.Left == null)
            {
                return node.Right;
            }

            if (node.Right == null)
            {
                return node.Left;
            }


            Node minNode = FindMinNode(node.Right);
            node.Data = minNode.Data;
            node.Right = DeleteRecursiveByStudentId(node.Right, minNode.Data.StudentId);
        }

        return node;
    }

    private Node FindMinNode(Node node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }
}

