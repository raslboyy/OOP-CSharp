namespace IsuExtra.Essence.Course
{
    public readonly struct StreamNumber
    {
        public StreamNumber(int number) => Number = number;
        private int Number { get; }

        public static explicit operator int(StreamNumber number) => number.Number;

        public static bool operator ==(StreamNumber left, StreamNumber right) => left.Equals(right);

        public static bool operator !=(StreamNumber left, StreamNumber right) => !(left == right);

        public override bool Equals(object obj) => obj is StreamNumber other && Equals(other);
        public bool Equals(StreamNumber other) => Number.Equals(other.Number);

        public override int GetHashCode() => Number.GetHashCode();
    }
}