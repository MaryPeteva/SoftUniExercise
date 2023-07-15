using System;
using System.Collections.Generic;
using System.Linq;

class Vlogger
{
    public string Name { get; set; }
    public HashSet<string> Followers { get; set; }
    public HashSet<string> Followings { get; set; }

    public Vlogger(string name)
    {
        Name = name;
        Followers = new HashSet<string>();
        Followings = new HashSet<string>();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();

        string command;
        while ((command = Console.ReadLine()) != "Statistics")
        {
            string[] tokens = command.Split();

            if (tokens[1] == "joined" && !vloggers.ContainsKey(tokens[0]))
            {
                string vloggerName = tokens[0];
                Vlogger vlogger = new Vlogger(vloggerName);
                vloggers.Add(vloggerName, vlogger);
            }
            else if (tokens[1] == "followed" && vloggers.ContainsKey(tokens[0]) && vloggers.ContainsKey(tokens[2]) &&
                tokens[0] != tokens[2] && !vloggers[tokens[2]].Followers.Contains(tokens[0]))
            {
                string followerName = tokens[0];
                string followingName = tokens[2];
                vloggers[followerName].Followings.Add(followingName);
                vloggers[followingName].Followers.Add(followerName);
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

        var mostFamousVlogger = vloggers.OrderByDescending(v => v.Value.Followers.Count)
                                        .ThenBy(v => v.Value.Followings.Count)
                                        .FirstOrDefault();

        if (mostFamousVlogger.Key != null)
        {
            Console.WriteLine($"1. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Followings.Count} following");

            int counter = 2;
            foreach (string follower in mostFamousVlogger.Value.Followers.OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogger in vloggers.Where(v => v.Key != mostFamousVlogger.Key)
                                            .OrderByDescending(v => v.Value.Followers.Count)
                                            .ThenBy(v => v.Value.Followings.Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Followings.Count} following");
                counter++;
            }
        }
    }
}
