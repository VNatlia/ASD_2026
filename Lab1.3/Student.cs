using System;

namespace Lab1._3;

public class Student
    {
        public string LastName { get; set; }
        public int Course { get; set; }
        public uint StudentId { get; set; }
        public double AverageGrade { get; set; }
        public string Citizenship { get; set; }

        public Student(string lastName, int course, uint studentId, double averageGrade, string citizenship)
        {
            LastName = lastName;
            Course = course;
            StudentId = studentId;
            AverageGrade = averageGrade;
            Citizenship = citizenship;
        }

        public override string ToString()
        {
            return string.Format("{0,-10} | {1,-15} | {2,-5} | {3,-6:F2} | {4,-10}",
                StudentId, LastName, Course, AverageGrade, Citizenship);
        }
    }

