using System;
using System.Collections.Generic;
using System.Linq;

Queue<int> cups = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
Stack<int> bottles = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
int wasted = 0;
int currentBottle = 0;
int currentCup = 0;

while (cups.Any() && bottles.Any()) 
{
    currentBottle = bottles.Pop();
    currentCup = cups.Dequeue();

    currentCup -= currentBottle;
    if (currentCup <= 0)
    {
        wasted += Math.Abs(currentCup);
    }
    else 
    {
        while (currentCup > 0 && bottles.Any()) 
        {
            currentBottle = bottles.Pop();
            currentCup -= currentBottle;
            if (currentCup <= 0)
            {
                wasted += Math.Abs(currentCup);
            }
        }
    }

}

if (!cups.Any()) 
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
}

if (!bottles.Any()) 
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
}

Console.WriteLine($"Wasted litters of water: {wasted}");