using StudentApp;
using System.Diagnostics;

List<string> students = new List<string>();

List<Student> allStudentsFromFile = new List<Student>();

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

//Student anotherStudent = new Student(students[0]);

Student anotherStudent = allStudentsFromFile[0];


Console.WriteLine(anotherStudent.Name, anotherStudent.Surname);
Console.WriteLine();
Console.WriteLine("Enter the student's grades:");
Console.WriteLine();

AddingTheStudentGradesForAllSubjects();

//SavingResultsToFile();




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

        string[] wordsStudent = studentNameAndSurname.Split(' ');

       if (wordsStudent.Length > 1)
        {
            Student anotherStudent = new Student(wordsStudent[0], wordsStudent[1]);

            allStudentsFromFile.Add(anotherStudent);
            
            
            Console.WriteLine("AAAAA");
            Console.Write($"{anotherStudent.Name}     ");
            Console.WriteLine(anotherStudent.Surname);
            Console.WriteLine("BBBBB");
        }
    }
}

void AddingTheStudentGradesForAllSubjects()
{
    Statistics statistics = new Statistics();

    foreach (var student in allStudentsFromFile)
    {
        numberOfSubjects = 0;

        anotherStudent = student;
        Console.WriteLine("===========================");
        Console.WriteLine($"{anotherStudent.Name} {anotherStudent.Surname}:");
        Console.WriteLine();


        for (int i = 0; i < 5; i++)


        {
            if (numberOfSubjects < 5)
            {
                Console.Write($"{(Student.subjectOfTeaching)numberOfSubjects} ");

                var grade = Console.ReadLine();

                student.AddGrade(grade);
                
                statistics.AddGrade(float.Parse(grade));

                numberOfSubjects++;

            }
            else
            {
                break;
            }
        }
        SavingResultsToFile();
    }
}

void SavingResultsToFile()
{
        using (var writer = File.AppendText(fileOut))
        {
            writer.WriteLine($"{anotherStudent.Surname} {anotherStudent.Name} {anotherStudent.GetStatistics().Max} {anotherStudent.GetStatistics().Average}");
        }
}

