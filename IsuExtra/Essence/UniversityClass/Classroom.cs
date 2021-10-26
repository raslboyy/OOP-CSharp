namespace IsuExtra.Essence.UniversityClass
{
    public class Classroom : IClassroom
    {
        public Classroom(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}