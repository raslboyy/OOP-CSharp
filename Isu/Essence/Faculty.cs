namespace Isu.Essence
{
    public readonly struct Faculty
    {
        public Faculty(char literal) => Literal = literal;

        public char Literal { get; }

        public static bool operator ==(Faculty left, Faculty right) => left.Equals(right);
        public static bool operator !=(Faculty left, Faculty right) => !(left == right);
        public override bool Equals(object obj) => obj is Faculty other && Equals(other);
        public bool Equals(Faculty other) => Literal.Equals(other.Literal);
        public override int GetHashCode() => Literal.GetHashCode();
    }
}