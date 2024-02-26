using System;
using System.IO;
using System.Xml.Linq;
using StudentApp;


List<string> students = new List<string>();


Student studen = new Student("blabla", "cece");


string filePath = "GroupOfStudents.txt";

int lineCount = File.ReadAllLines(filePath).Length;

Console.WriteLine(lineCount);
Console.WriteLine();



LoadingListStudentsFromFile(filePath);

CreatingSeparatFileForEachStudent(students[0], students[1]);

Student anotherStudent = new Student(students[0], students[1]);


var grade = 4;
anotherStudent.AddGrade(grade);







void LoadingListStudentsFromFile(string filePath)
{
    for (int i = 0; i < lineCount; i++)
    {
        string studentNameAndSurname = File.ReadLines(filePath)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Skip(i)
        .FirstOrDefault();

        students.Add(studentNameAndSurname);
    }
}
void CreatingSeparatFileForEachStudent(string namme, string surnamme)
{
    string[] wordsStudent = students[0].Split(' ');
    if (wordsStudent.Length > 1)
    {

        var nname = wordsStudent[0];
        var ssurname = wordsStudent[1];
        Student anotherStudent = new Student(nname, ssurname);
    }
}







//    anotherStudent.AddGrade(44);
string abla = "55";
//{
//    Console.WriteLine("Invalid date in file");
//}

string name = "Jan";
string surname = "Kowalski";
string fileName = $"{name}_{surname}.txt";

// Zapisywanie danych do pliku
File.WriteAllText(fileName, abla);

Console.WriteLine($"Plik {fileName} został zapisany.");


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

