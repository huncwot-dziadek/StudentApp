namespace StudentApp.Tests;

public class Tests
{
    [Test]
    public void WhetherTheStatisticsAreCalculatedCorrectly()
    {
        Student student1 = new Student("Jan", "Pierwszy");
        Student student2 = new Student("Arnold", "Drugi");
        Student student3 = new Student("Maria", "Trzecia");

        student1.AddGrade("2");
        student1.AddGrade("3");
        student1.AddGrade("4");
        student1.AddGrade("5");
        student1.AddGrade("6");

        student2.AddGrade("2");
        student2.AddGrade("-3");
        student2.AddGrade("+4");
        student2.AddGrade("+5");
        student2.AddGrade("-6");

        student3.AddGrade("2+");
        student3.AddGrade("3+");
        student3.AddGrade("4+");
        student3.AddGrade("5+");
        student3.AddGrade("5");

        Statistics statistics2 = new Statistics();

        Assert.AreEqual(100, student1.GetStatistics().Max);
        Assert.AreEqual(60, student1.GetStatistics().Average);

        Assert.AreEqual(95, student2.GetStatistics().Max);
        Assert.AreEqual(60, student2.GetStatistics().Average);

        Assert.AreEqual(85, student3.GetStatistics().Max);
        Assert.AreEqual(60, student3.GetStatistics().Average);
    }
}
