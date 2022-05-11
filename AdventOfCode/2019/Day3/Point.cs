namespace AdventOfCode._2019.Day3;

internal sealed class Point : IEquatable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point()
    {
        X = 0;
        Y = 0;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(Point point)
    {
        X = point.X;
        Y = point.Y;
    }

    public List<Point> MoveUp(int value)
    {
        var points = new List<Point>();
        int destination = this.Y + value;

        while(this.Y < destination)
        {
            this.Y++;
            points.Add(new Point(this));
        }

        return points;
    }

    public List<Point> MoveRight(int value)
    {
        var points = new List<Point>();
        int destination = this.X + value;

        while (this.X < destination)
        {
            this.X++;
            points.Add(new Point(this));
        }

        return points;
    }

    public List<Point> MoveDown(int value)
    {
        var points = new List<Point>();
        int destination = this.Y - value;

        while (this.Y > destination)
        {
            this.Y--;
            points.Add(new Point(this));
        }

        return points;
    }

    public List<Point> MoveLeft(int value)
    {
        var points = new List<Point>();
        int destination = this.X - value;

        while (this.X > destination)
        {
            this.X--;
            points.Add(new Point(this));
        }

        return points;
    }

    public List<Point> GetPath(string[] commands)
    {
        var path = new List<Point>();

        foreach (var command in commands)
        {
            char direction = command[0];
            int value = int.Parse(command.Substring(1));
            List<Point>? points = null;

            switch (direction)
            {
                case 'U':
                    points = this.MoveUp(value);
                    break;

                case 'R':
                    points = this.MoveRight(value);
                    break;

                case 'D':
                    points = this.MoveDown(value);
                    break;

                case 'L':
                    points = this.MoveLeft(value);
                    
                    break;

                default:
                    throw new ArgumentException("Wrong direction argument");
            }
            path.AddRange(points);
        }

        return path;
    }

    public bool Equals(Point? other)
    {
        if (other is null)
            return false;
        else if (this.X == other.X && this.Y == other.Y)
            return true;
        else
            return false;
    }
}
