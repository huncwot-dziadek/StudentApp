namespace StudentApp
{
    public abstract class StudentBase
    {
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public StudentBase(string nameAndSurname)
        {
            this.NameAndSurname = nameAndSurname;
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string NameAndSurname { get; private set; }

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);

        public abstract Statistics GetStatistics();


    }
}
