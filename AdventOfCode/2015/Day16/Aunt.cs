namespace AdventOfCode._2015.Day16;

internal sealed class Aunt : IEquatable<Aunt>
{
    public int Number { get; set; }
    public int? Children { get; set; }
    public int? Cats { get; set; }
    public int? Samoyeds { get; set; }
    public int? Pomeranians { get; set; }
    public int? Akitas { get; set; }
    public int? Vizslas { get; set; }
    public int? Goldfish { get; set; }
    public int? Trees { get; set; }
    public int? Cars { get; set; }
    public int? Perfumes { get; set; }
    
    public Aunt(int number)
    {
        Number = number;
    }

    public bool Equals(Aunt other)
    {
        if (other.Children.HasValue && Children != other.Children)
            return false;
        if (other.Cats.HasValue && Cats != other.Cats)
            return false;
        if (other.Samoyeds.HasValue && Samoyeds != other.Samoyeds)
            return false;
        if (other.Pomeranians.HasValue && Pomeranians != other.Pomeranians)
            return false;
        if (other.Akitas.HasValue && Akitas != other.Akitas)
            return false;
        if (other.Vizslas.HasValue && Vizslas != other.Vizslas)
            return false;
        if (other.Goldfish.HasValue && Goldfish != other.Goldfish)
            return false;
        if (other.Trees.HasValue && Trees != other.Trees)
            return false;
        if (other.Cars.HasValue && Cars != other.Cars)
            return false;
        if (other.Perfumes.HasValue && Perfumes != other.Perfumes)
            return false;

        return true;
    }

    public bool EqualsPartTwo(Aunt other)
    {
        if (other.Children.HasValue && Children != other.Children)
            return false;
        if (other.Cats.HasValue && Cats >= other.Cats)
            return false;
        if (other.Samoyeds.HasValue && Samoyeds != other.Samoyeds)
            return false;
        if (other.Pomeranians.HasValue && Pomeranians <= other.Pomeranians)
            return false;
        if (other.Akitas.HasValue && Akitas != other.Akitas)
            return false;
        if (other.Vizslas.HasValue && Vizslas != other.Vizslas)
            return false;
        if (other.Goldfish.HasValue && Goldfish <= other.Goldfish)
            return false;
        if (other.Trees.HasValue && Trees >= other.Trees)
            return false;
        if (other.Cars.HasValue && Cars != other.Cars)
            return false;
        if (other.Perfumes.HasValue && Perfumes != other.Perfumes)
            return false;

        return true;
    }
}
