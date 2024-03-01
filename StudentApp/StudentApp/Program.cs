using StudentApp;

List<Student> allStudentsFromFile = new List<Student>();

string fileOut = "ResultsAllStudents.txt";
File.Create(fileOut).Close();

string fileIn = "AllStudents.txt";
int lineCount = File.ReadAllLines(fileIn).Length;

int numberOfSubjects = 0;

Console.WriteLine("Welcome to the program WHICH STUDENT WILL RECEIVE THE AWARD");
Console.WriteLine("                       ====================================");
Console.WriteLine();
Console.WriteLine("This is the first huncwot program");
Console.WriteLine("Here we go");
Console.WriteLine();

LoadingListStudentsFromFile(fileIn);

Student anotherStudent = allStudentsFromFile[0];

Console.WriteLine("Enter the student's grades:");
Console.WriteLine();

AddingStudentGradesForAllSubjects();

WritingToFile();

Sortowanie();



void LoadingListStudentsFromFile(string filePath)
{
    for (int i = 0; i < lineCount; i++)
    {
        string studentNameAndSurname = File.ReadLines(filePath)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Skip(i)
        .FirstOrDefault();

        string[] wordsStudent = studentNameAndSurname.Split(' ');

        if (wordsStudent.Length == 2)
        {
            Student anotherStudent = new Student(wordsStudent[0], wordsStudent[1]);
            allStudentsFromFile.Add(anotherStudent);
        }
    }
}

void AddingStudentGradesForAllSubjects()
{
    Statistics statistics = new Statistics();

    foreach (var anotherStudent in allStudentsFromFile)
    {
        numberOfSubjects = 0;

        Console.WriteLine("===========================");
        Console.WriteLine($"{anotherStudent.Name} {anotherStudent.Surname}:");
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{(Student.subjectOfTeaching)numberOfSubjects} ");

            var grade = Console.ReadLine();

            try
            {
                anotherStudent.AddGrade(grade);
                numberOfSubjects++;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception catched: {ex.Message}");
                i--;
            }
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine();
    }
}


void Sortowanie()
{
    Student studentMax = allStudentsFromFile[0];
    Student studentAverage = allStudentsFromFile[0];

    for (int i = 0; i < allStudentsFromFile.Count - 1; i++)
    {
        if (allStudentsFromFile[i + 1].GetStatistics().Max > studentMax.GetStatistics().Max)
        {
            studentMax = allStudentsFromFile[i + 1];
        }

        if (allStudentsFromFile[i + 1].GetStatistics().Average > studentAverage.GetStatistics().Average)
        {
            studentAverage = allStudentsFromFile[i + 1];
        }
    }
    Console.WriteLine();
    Console.WriteLine("They receive the reward:");
    Console.WriteLine("-----------------------------------------------------");
    Console.Write("Student with the highest grade: ");
    Console.Write($"{studentMax.Surname} {studentMax.Name}");
    Console.WriteLine($" for the rating {studentMax.GetStatistics().Max}");
    Console.Write("Student with the highest grade point average: ");
    Console.Write($"{studentAverage.Surname} {studentAverage.Name}");
    Console.WriteLine($" for the rating {studentAverage.GetStatistics().Average}");
    Console.WriteLine("-----------------------------------------------------");
}

void WritingToFile()
{
    foreach (var student in allStudentsFromFile)
    {
        using (var writer = File.AppendText(fileOut))
        {
            writer.WriteLine($"{student.Surname} {student.Name} {student.GetStatistics().Max} {student.GetStatistics().Average}");
        }
    }
}
