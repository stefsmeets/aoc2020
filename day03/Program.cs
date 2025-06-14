using System.IO;

string path = "data.txt";

var FOREST = File.ReadAllLines(path);

var NX = FOREST[0].Count();
var NY = FOREST.Count() - 1;

int GetTrees(int dx, int dy)
{
    int x = 0;
    int y = 0;
    int ntrees = 0;

    do
    {
        x = (x + dx) % NX;
        y = y + dy;
        var pos = FOREST[y][x];
        if (pos == '#')
            ntrees++;
    } while (y < NY);

    return ntrees;
}

int dx = 3;
int dy = 1;

var part1 = GetTrees(dx, dy);

Console.WriteLine($"Part 1: {part1}");

int[,] slopes =
{
    { 1, 1 },
    { 3, 1 },
    { 5, 1 },
    { 7, 1 },
    { 1, 2 },
};

long part2 = 1;
int ret = 1;

for (int i = 0; i < slopes.GetLength(0); i++)
{
    dx = slopes[i, 0];
    dy = slopes[i, 1];

    ret = GetTrees(dx, dy);

    part2 = part2 * ret;
}

Console.WriteLine($"Part 2: {part2}");
