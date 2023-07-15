int numOfRows = int.Parse(Console.ReadLine());
Dictionary<string,List<decimal>> students = new Dictionary<string,List<decimal>>();
for (int i = 0; i < numOfRows; i++) 
{
    var input = Console.ReadLine().Split();
    var key = input[0];
    var value = decimal.Parse(input[1]);
    if (!students.ContainsKey(key)) 
    {
        students.Add(key, new List<decimal>());
    }
    students[key].Add(value);
}

foreach (var (student,grades) in students)
{
    Console.Write($"{student} -> ");
    var average = grades.Average();
    foreach (var grade in grades) 
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {average:f2})");
}
