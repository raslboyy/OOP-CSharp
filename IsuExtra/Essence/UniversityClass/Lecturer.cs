namespace IsuExtra.Essence.UniversityClass
{
    public class Lecturer : ILecturer
    {
        public Lecturer(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}