public class CoordinateSet
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;


    public double DistanceTo(CoordinateSet otherCoordinateSet) => Math.Sqrt(Math.Pow(otherCoordinateSet.X - X, 2) + Math.Pow(otherCoordinateSet.Y - Y, 2));
    public CoordinateSet Clone() => new() { X = this.X, Y = this.Y };

    public bool Equals(CoordinateSet otherCoordinateSet) => this.X == otherCoordinateSet.X && this.Y == otherCoordinateSet.Y;
    public static bool operator ==(CoordinateSet one, CoordinateSet two)
    {
        return one.Equals(two);
    }

    public static bool operator !=(CoordinateSet one, CoordinateSet two)
    {
        return !one.Equals(two);
    }

    public override string ToString()
    {
        return $"{X.ToString().PadLeft(3)},{Y.ToString().PadLeft(3)}";
    }
}