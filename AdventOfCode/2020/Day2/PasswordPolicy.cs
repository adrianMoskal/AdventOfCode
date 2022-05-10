namespace AdventOfCode._2020.Day2;

internal sealed class PasswordPolicy
{
    public int Min { get;set; }
    public int Max { get;set; }

    public char Letter { get;set; }

    public string Password { get;set; }

    public PasswordPolicy(string passwordPolicy)
    {
        passwordPolicy = passwordPolicy.Replace(":", "");
        string[] policies = passwordPolicy.Split(" ");
        var range = policies[0].Split("-").Select(Int32.Parse);
        
        Min = range.ElementAt(0);
        Max = range.ElementAt(1);
        Letter = Convert.ToChar(policies[1]);
        Password = policies[2];
    }

    public bool OldValidation()
    {
        int count = Password.Count(x => x.Equals(Letter));
        if(Min <= count && count <= Max)
        {
            return true;
        }
        return false;
    }

    public bool NewValidation()
    {
        bool x = Password[Min-1].Equals(Letter);
        bool y = Password[Max-1].Equals(Letter);

        if(x != y)
        {
            return true;
        }
        return false;
    }
}
