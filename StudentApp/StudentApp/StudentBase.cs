namespace StudentApp
{
    public abstract class StudentBase
    {
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public abstract void AddStudentToList(string student);

        public abstract void GetStudent(Student student);

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);

    }
}
