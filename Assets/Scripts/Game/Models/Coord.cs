using System;

namespace InCheck.Game.Models
{
    public readonly struct Coord : IEquatable<Coord>
    {
        public int X { get; }
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsWithinBounds(int width, int height)
        {
            return X >= 0 && Y >= 0 && X < width && Y < height;
        }

        public Coord Clamp(int width, int height)
        {
            var clampedX = Math.Clamp(X, 0, Math.Max(0, width - 1));
            var clampedY = Math.Clamp(Y, 0, Math.Max(0, height - 1));
            return new Coord(clampedX, clampedY);
        }

        public bool Equals(Coord other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Coord other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Coord left, Coord right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coord left, Coord right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
