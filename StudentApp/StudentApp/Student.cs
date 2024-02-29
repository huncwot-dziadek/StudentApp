﻿using StudentApp;
using System.Xml.Linq;

namespace StudentApp
{
    public class Student : StudentBase

    {
        public delegate Student NazwaNazwa(Student messa);


        private List<float> grades = new List<float>();


        private List<string> listOfStudents = new List<string>();


        private bool oneOfTheConditionsIsMet = false;


        public static int uczen = 0;


        static string nname;


        static string fileName = "Klasa2.txt";

        public enum subjectOfTeaching
        {
            combinatorics______ ,
            algebra____________ ,
            physics____________ ,
            communicativeness__ ,
            teamwork_ability___ 
        }

        public Student(string name, string surname) : base(name, surname)
        {
            NazwaNazwa del;
        }

        public Student(string nameAndSurname) : base(nameAndSurname)
        {
            NazwaNazwa del;
        }

        public override void AddGrade(float grade)
        {
            Statistics statistics = new Statistics();

            if (grade >= 0 && grade <= 100)

            {
                this.grades.Add(grade);              
                


            }
            else
            {
                throw new Exception("This grade is out of range");
            }

            statistics.AddGrade(grade);
        }

        public override void AddGrade(string grade)
        {
            if (grade.Length == 1)
            {
                if (grade[0] >= 49 && grade[0] <= 54)
                {
                    var rating = grade[0] - 48;
                    var valueRating = (rating - 1) * 20;
                    AddGrade(valueRating);
                }
                else
                {
                    throw new Exception("This grade is not float or is bigger 6");
                }
            }

            if (grade.Length == 2)
            {
                for (int i = 0; i < grade.Length; i++)
                {
                    for (int j = 1; j >= 0; j--)
                    {
                        if ((grade[i] >= 49 && grade[i] <= 54) && (grade[j] == 43))
                        {
                            var rating = grade[i] - 48;
                            var valueRating = ((rating - 1) * 20) + 5;
                            AddGrade(valueRating);
                            oneOfTheConditionsIsMet = true;
                        }
                        else if ((grade[i] >= 49 && grade[i] <= 54) && (grade[j] == 45))
                        {
                            var rating = grade[i] - 48;
                            var valueRating = ((rating - 1) * 20) - 5;
                            AddGrade(valueRating);
                            oneOfTheConditionsIsMet = true;
                        }
                        else
                        {
                            if (oneOfTheConditionsIsMet == false)
                            {
                                throw new Exception("Incorrectly entered rating");
                            }
                        }
                    }
                }
            }

            if (grade.Length > 2)
            {
                throw new Exception("This grade is not float or is bigger 6");
            }
        }


        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }
    }
}
