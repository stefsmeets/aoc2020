using System.IO;

string path = "data.txt";

var lines = File.ReadLines(path);

List<int> numbers = new List<int>();

foreach (var line in lines)
{
    int x = int.Parse(line);
    numbers.Add(x);
}

int target = 2020;

for (int i = 0; i < numbers.Count; i++)
{
    int x = numbers[i];
    for (int j = i; j < numbers.Count; j++)
    {
        int y = numbers[j];
        if (x + y == target)
        {
            Console.WriteLine($"Part 1: {x} * {y} = {x * y}");
        }
    }
}

for (int i = 0; i < numbers.Count; i++)
{
    int x = numbers[i];
    for (int j = i; j < numbers.Count; j++)
    {
        int y = numbers[j];
        for (int k = j; k < numbers.Count; k++)
        {
            int z = numbers[k];
            if (x + y + z == target)
            {
                Console.WriteLine($"Part 2: {x} * {y} * {z} = {x * y * z}");
            }
        }
    }
}
