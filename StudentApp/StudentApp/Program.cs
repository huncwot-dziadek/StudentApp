using ChallengeApp2024;
using StudentApp;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Linq;

List<string> students = new List<string>();

int numberOfSubjects = 0;
string fileIn = "AllStudents.txt";
string fileOut = "ResultsAllStudents.txt";

File.Create(fileOut).Close();


int lineCount = File.ReadAllLines(fileIn).Length;

Console.WriteLine("Welcome to the program WHICH STUDENT WILL ADVANCE");
Console.WriteLine("                       ==========================");
Console.WriteLine();
Console.WriteLine("This is the first huncwot program");
Console.WriteLine("Here we go");
Console.WriteLine();

LoadingListStudentsFromFile(fileIn);

Student anotherStudent = new Student(students[0]);

Console.WriteLine(students[0], students[1]);
Console.WriteLine();
Console.WriteLine("Enter the student's grades:");
Console.WriteLine();







AddingTheStudentGradesForAllSubjects();

Console.WriteLine();
Console.WriteLine(students[0], students[1]);


Console.WriteLine();
Console.WriteLine("============================================");
Console.WriteLine($"{anotherStudent.Name} {anotherStudent.Surname} final results:");
Console.WriteLine($"Masimum rating = {anotherStudent.GetStatistics().Max}   ");
Console.WriteLine($"Average rating = {anotherStudent.GetStatistics().Average:N2}   ");
Console.WriteLine("============================================");
Console.Write($"Max = {anotherStudent.GetStatistics().Max}   ");
Console.Write($"Average = {anotherStudent.GetStatistics().Average:N2}   ");












void LoadingListStudentsFromFile(string filePath)
{
    for (int i = 0; i < lineCount; i++)
    {
        string studentNameAndSurname = File.ReadLines(filePath)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Skip(i)
        .FirstOrDefault();

        students.Add(studentNameAndSurname);
        //string fileName = studentNameAndSurname + ".txt";
       // File.Create(fileName).Close();

        //Student anotherStudent = new Student(studentNameAndSurname);
        //students.Add(studentNameAndSurname);


        string[] wordsStudent = students[i].Split(' ');
        if (wordsStudent.Length > 1)
        {
            //var nname = wordsStudent[0];
            //var ssurname = wordsStudent[1];
            Student anotherStudent = new Student(wordsStudent[0], wordsStudent[1]);
            //students.Add(wordsStudent[0] + "_" + wordsStudent[1]);
        }

    }
}


void AddingTheStudentGradesForAllSubjects()
{
    Statistics statistics = new Statistics();

    for (int i = 0; i < 5; i++)
    {
        if (numberOfSubjects < 5)
        {
            Console.Write($"{(Student.subjectOfTeaching)numberOfSubjects} ");

            var grade = Console.ReadLine();

            anotherStudent.AddGrade(grade);

            numberOfSubjects++;

        }
        else
        {
            break;
        }

        using (var writer = File.AppendText(fileOut))
        {
            writer.WriteLine($"{students[0]} {anotherStudent.GetStatistics().Max} {anotherStudent.GetStatistics().Average}");
        }

    }
}






//void CreatingSeparatFileForEachStudent(string namme, string surnamme)
//{
//    string[] wordsStudent = students[0].Split(' ');
//    if (wordsStudent.Length > 1)
//    {

//        var nname = wordsStudent[0];
//        var ssurname = wordsStudent[1];
//        Student anotherStudent = new Student(nname, ssurname);
//    }
//}







//    anotherStudent.AddGrade(44);
//string abla = "55";
////{
////    Console.WriteLine("Invalid date in file");
////}

//string name = "Jan";
//string surname = "Kowalski";
//string fileName = $"{name}_{surname}.txt";

//// Zapisywanie danych do pliku
//File.WriteAllText(fileName, abla);

//Console.WriteLine($"Plik {fileName} został zapisany.");


//Student student1 = list2.get(1);


//Animal myDog = animalList.get(1);




//for (int i = 0; i < 3; i++)
//{
//    var uczen = i;

//    Student GetGetGet(Student);


//    var number = Console.ReadLine();






//}






//string[] wordsLine = line.Split(' ');

//if (wordsLine.Length > 1)
//{



//    NameKlasa1 = wordsLine[0];
//    SurnameKlasa1 = wordsLine[1];
//    Student student = new Student(NameKlasa1, SurnameKlasa1);

//    Console.Write($"{student.Name}    ");
//    Console.WriteLine(student.Surname);


//}

