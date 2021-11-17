namespace IsuExtra.Entity.Course
{
    public readonly struct StreamNumber
    {
        private static int _id;
        public StreamNumber(int number)
        {
            Number = number;
            Id = _id++;
        }

        public int Id { get; }
        private int Number { get; }

        public static explicit operator int(StreamNumber number) => number.Number;

        public static bool operator ==(StreamNumber left, StreamNumber right) => left.Equals(right);

        public static bool operator !=(StreamNumber left, StreamNumber right) => !(left == right);

        public override bool Equals(object obj) => obj is StreamNumber other && Equals(other);
        public bool Equals(StreamNumber other) => Number.Equals(other.Number) && Id.Equals(other.Id);

        public override int GetHashCode() => Number.GetHashCode();
    }
}