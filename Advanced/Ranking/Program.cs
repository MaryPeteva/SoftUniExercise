using System;
using System.Collections.Generic;
using System.Linq;

class Candidate
{
    public string Name { get; set; }
    public Dictionary<string, int> Contests { get; set; }

    public Candidate(string name)
    {
        Name = name;
        Contests = new Dictionary<string, int>();
    }

    public void UpdateContestPoints(string contest, int points)
    {
        if (!Contests.ContainsKey(contest))
        {
            Contests.Add(contest, points);
        }
        else
        {
            Contests[contest] = Math.Max(Contests[contest], points);
        }
    }

    public int GetTotalPoints()
    {
        return Contests.Values.Sum();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, string> contests = new Dictionary<string, string>();
        List<Candidate> candidates = new List<Candidate>();

        string input;
        while ((input = Console.ReadLine()) != "end of contests")
        {
            string[] tokens = input.Split(':');
            string contest = tokens[0];
            string password = tokens[1];

            contests[contest] = password;
        }

        while ((input = Console.ReadLine()) != "end of submissions")
        {
            string[] tokens = input.Split("=>");
            string contest = tokens[0];
            string password = tokens[1];
            string candidateName = tokens[2];
            int points = int.Parse(tokens[3]);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                Candidate candidate = candidates.FirstOrDefault(c => c.Name == candidateName);
                if (candidate == null)
                {
                    candidate = new Candidate(candidateName);
                    candidates.Add(candidate);
                }

                candidate.UpdateContestPoints(contest, points);
            }
        }

        Candidate bestCandidate = candidates.OrderByDescending(c => c.GetTotalPoints()).FirstOrDefault();
        Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {bestCandidate.GetTotalPoints()} points.");

        Console.WriteLine("Ranking:");

        foreach (Candidate candidate in candidates.OrderBy(c => c.Name))
        {
            Console.WriteLine(candidate.Name);
            foreach (var contestPoints in candidate.Contests.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"# {contestPoints.Key} -> {contestPoints.Value}");
            }
        }
    }
}
