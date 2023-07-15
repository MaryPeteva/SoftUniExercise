using System;
using System.Collections.Generic;
using System.Linq;

int price =  int.Parse(Console.ReadLine());
int sizeGunBarrel = int.Parse(Console.ReadLine());
Stack<int> bullets = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
int initalBullets = bullets.Count();
Queue<int> locks = new(Console.ReadLine().Split().Select(int.Parse).ToArray());
int intelligence =  int.Parse(Console.ReadLine());
int bulletsCount = 0;
bool openedSafe = false;

while (bullets.Any() && locks.Any()) 
{
    
    if (bullets.Pop() <= locks.Peek())
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else 
    {
        Console.WriteLine("Ping!");
    }

    bulletsCount++;
    if ((bulletsCount % sizeGunBarrel == 0) && bullets.Any())
    {
        Console.WriteLine("Reloading!");
    }    

}

if ((bullets.Any() && !locks.Any()) || (!bullets.Any() && !locks.Any()))
{
    int moneyEarned = intelligence - (bulletsCount * price);
    Console.WriteLine($"{initalBullets - bulletsCount} bullets left. Earned ${moneyEarned}");
}
else if(!bullets.Any() && locks.Any()) 
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");

}