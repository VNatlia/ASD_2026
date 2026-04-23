using System;

namespace Lab1._4;

public class Student
{
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double AverageGrade { get; set; }
        public string Gender { get; set; }

        public Student(string lastName, string firstName, double averageGrade, string gender)
        {
            LastName = lastName;
            FirstName = firstName;
            AverageGrade = averageGrade;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{AverageGrade,-7:F1} | {LastName,-12} | {FirstName,-12} | {Gender,-6}";
        }
    }

