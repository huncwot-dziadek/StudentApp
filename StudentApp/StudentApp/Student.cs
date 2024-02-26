using System.Xml.Linq;
using StudentApp;

namespace StudentApp
{
    public class Student : StudentBase
    {
        public delegate Student NazwaNazwa(Student messa);


        private List<float> grades = new List<float>();


        private List<string> listOfStudents = new List<string>();


        internal List<Students> list2 = new List<Students>();


        private bool oneOfTheConditionsIsMet = false;


        public static int uczen = 0;


        static string nname;



        static string fileName = "Klasa2.txt";

        public Student(string name, string surname) : base(name, surname)
        {
            NazwaNazwa del;
        }

        public override void AddStudentToList(string student)
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] wordsStudent = line.Split(' ');
                        if (wordsStudent.Length > 1)
                        {

                            var name = wordsStudent[0];
                            var surname = wordsStudent[1];
                            Student anotherStudent = new Student(name, surname);
                            this.list2.Add(new Students { Id = 1, Nazwa = "Students1" });

                        }

                        //this.listOfStudents.Add(line);
                    }

                    line = reader.ReadLine();

                }

            }
        }

        //public override Student GetGetGet(Student student)
        //{
        //    student = list2[uczen];
        //}

        public override void GetStudent(Student student)
        {
            foreach (var studentFromList in this.listOfStudents)
            {
                string[] wordsStudent = studentFromList.Split(' ');

                if (wordsStudent.Length > 1)
                {
                    var name = wordsStudent[0];
                    var surname = wordsStudent[1];
                    Student anotherStudent = new Student(name, surname);

                }
            }
        }

        public override void AddGrade(float grade)
        {
            this.grades.Add(grade);
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

    }


    public class Students
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }
}
    
//    public List<Obiekt> listaObiektow = new List<Obiekt>();

  
//    listaObiektow.Add(new Obiekt { Id = 1, Nazwa = "Obiekt1" });
//listaObiektow.Add(new Obiekt { Id = 2, Nazwa = "Obiekt2" });


//Obiekt wybranyObiekt = listaObiektow[0]; // Wybieramy pierwszy obiekt z listy
//Console.WriteLine(wybranyObiekt.Nazwa); // Wyświetli: Obiekt1
//}