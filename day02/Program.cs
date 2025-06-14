// See https://aka.ms/new-console-template for more information
string path = "data.txt";

var lines = File.ReadLines(path);

int nvalidp1 = 0;
int nvalidp2 = 0;

foreach (var line in lines)
{
    string[] inp = line.Split(' ', '-');

    int policy1 = int.Parse(inp[0]);
    int policy2 = int.Parse(inp[1]);
    char letter = char.Parse(inp[2].Replace(":", ""));
    string pw = inp[3];

    int count = 0;
    foreach (char ch in pw)
    {
        if (ch == letter)
            count++;
    }

    if (policy1 <= count && count <= policy2)
    {
        nvalidp1++;
    }

    if (pw[policy1 - 1] == letter ^ pw[policy2 - 1] == letter)
    {
        nvalidp2++;
    }
}

Console.WriteLine($"Part 1: {nvalidp1}");
Console.WriteLine($"Part 2: {nvalidp2}");
