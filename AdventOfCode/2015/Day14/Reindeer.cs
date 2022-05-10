namespace AdventOfCode._2015.Day14;

internal sealed class Reindeer
{
    public string Name { get; set; }
    public int Speed { get; set; }
    public int FlyTime { get; set; }
    public int TimeSpentFlying { get; set; }
    public int RestTime { get; set; }
    public int TimeSpentResting { get; set; }
    public bool IsFlying { get; set; }
    public int Distance { get; set; }
    public int Points { get; set; }

    public Reindeer(string name, int speed, int flyTime, int restTime, bool isFlying)
    {
        Name = name;
        Speed = speed;
        FlyTime = flyTime;
        RestTime = restTime;
        IsFlying = isFlying;
        Points = TimeSpentFlying = TimeSpentResting = Distance = 0;
    }

    public void Step()
    {
        if(IsFlying)
        {
            Distance += Speed;
            TimeSpentFlying++;
            if(TimeSpentFlying >= FlyTime)
            {
                TimeSpentFlying = 0;
                IsFlying = false;
            }
        }
        else
        {
            TimeSpentResting++;
            if (TimeSpentResting >= RestTime)
            {
                TimeSpentResting = 0;
                IsFlying = true;
            }
        }
    }
}
