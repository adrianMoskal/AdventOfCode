namespace AdventOfCode._2019.Day3;

class PointComparer : IEqualityComparer<Point>
{
    public bool Equals(Point item1, Point item2)
    {
        return item1.Equals(item2);
    }

    public int GetHashCode(Point item)
    {
        return new { item.X, item.Y }.GetHashCode();
    }
}
