namespace AdventOfCode._2019.Day3;

internal sealed class PointComparer : IEqualityComparer<Point>
{
    public bool Equals(Point? item1, Point? item2)
    {
        if (item1 is null || item2 is null)
            return false;

        return item1.Equals(item2);
    }

    public int GetHashCode(Point item)
    {
        return new { item.X, item.Y }.GetHashCode();
    }
}
