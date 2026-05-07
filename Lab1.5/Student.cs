using System;

namespace Lab1._5;

public class Student
    {
        public string LastName;
        public string FirstName;
        public int Group;
        public string Gender;
        public double AverageGrade;

        public Student(string lastName, string firstName, int group, string gender, double averageGrade)
        {
            LastName = lastName;
            FirstName = firstName;
            Group = group;
            Gender = gender;
            AverageGrade = averageGrade;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} | група {Group} | стать: {Gender} | середній бал: {AverageGrade}";
        }
    }

