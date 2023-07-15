using System;
using System.Collections.Generic;
using System.Linq;

int greenLightDuration = int.Parse(Console.ReadLine());
int freeWindow = int.Parse(Console.ReadLine());
int currentGreenLight = greenLightDuration;
string input = string.Empty;
Queue<string> cars = new Queue<string>();
int passedCars = 0;
bool crash = false;
char hitChar = 'a';
string currentCar = string.Empty;
while ((input = Console.ReadLine()) != "END") 
{
    switch (input) 
    {
        case "green":
            currentGreenLight = greenLightDuration;
            while (currentGreenLight > 0 && cars.Any()) 
            {
                currentCar = cars.Dequeue();
                if(currentGreenLight - currentCar.Length >= 0)
                {
                    currentGreenLight -= currentCar.Length; 
                    passedCars++;
                    continue;
                }

                if (currentGreenLight + freeWindow - currentCar.Length >= 0) 
                {
                    
                    freeWindow -= currentCar.Length - currentGreenLight;
                    currentGreenLight = 0;
                    passedCars++;
                    continue;
                }

                crash = true;
                hitChar = currentCar[currentGreenLight + freeWindow];
                if (crash) 
                {
                    break;
                }
            }
            break;
        default:
            cars.Enqueue(input);
            continue;
    }

    if (crash)
    {
        break;
    }

}

if (crash)
{
    Console.WriteLine("A crash happened!");
    Console.WriteLine($"{currentCar} was hit at {hitChar}.");
}
else
{
    Console.WriteLine("Everyone is safe.");
    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
}