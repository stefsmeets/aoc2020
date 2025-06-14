using System.IO;

string path = "data.txt";

var lines = File.ReadLines(path);

Passport passport = new Passport();

var lst = new List<Passport> { };

foreach (var line in lines)
{
    if (line == "")
    {
        lst.Add(passport);
        passport = new Passport();
        // Console.WriteLine("\nnew");
        continue;
    }

    var inp = line.Split(" ");

    foreach (var row in inp)
    {
        var split = row.Split(":");
        string left = split[0];
        string right = split[1];

        // Console.WriteLine($"{inp}, {left}, {right}");

        switch (left)
        {
            case "byr":
                passport.byr = int.Parse(right);
                break;
            case "iyr":
                passport.iyr = int.Parse(right);
                break;
            case "eyr":
                passport.eyr = int.Parse(right);
                break;
            case "hgt":
                passport.hgt = right;
                break;
            case "hcl":
                passport.hcl = right;
                break;
            case "ecl":
                passport.ecl = right;
                break;
            case "pid":
                passport.pid = right;
                break;
            case "cid":
                passport.cid = int.Parse(right);
                break;
            default:
                break;
        }
    }
}
lst.Add(passport);

int nvalidp1 = 0;
int nvalidp2 = 0;

foreach (var item in lst)
{
    if (item.isValid_part1())
        nvalidp1++;
    if (item.isValid_part2())
        nvalidp2++;
}

Console.WriteLine($"Part 1: {nvalidp1}");
Console.WriteLine($"Part 2: {nvalidp2}");

class Passport
{
    public Passport() { }

    public bool isValid_part1()
    {
        if (
            this.byr > 0
            && this.iyr > 0
            && this.eyr > 0
            && !string.IsNullOrEmpty(this.hgt)
            && !string.IsNullOrEmpty(this.hcl)
            && !string.IsNullOrEmpty(this.ecl)
            && !string.IsNullOrEmpty(this.pid)
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isValid_part2()
    {
        bool validateHeight(string hgt)
        {
            if (hgt.Count() <= 2)
            {
                return false;
            }

            var system = hgt[^2..];
            int val = int.Parse(hgt[..^2]);
            if (system == "cm" && val >= 150 && val <= 193)
            {
                return true;
            }
            else if (system == "in" && val >= 59 && val <= 76)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool validateHair(string hcl)
        {
            if (hcl[0] != '#')
            {
                return false;
            }

            string letters = "0123456789abcdef";

            foreach (var ch in hcl[1..])
            {
                if (!letters.Contains(ch))
                {
                    return false;
                }
            }

            if (hcl.Count() != 7)
            {
                return false;
            }

            return true;
        }

        bool validateEye(string ecl)
        {
            string[] valid = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            if (valid.Contains(ecl))
            {
                return true;
            }
            return false;
        }

        bool validatePid(string pid)
        {
            string letters = "0123456789";

            foreach (var ch in pid)
            {
                if (!letters.Contains(ch))
                {
                    return false;
                }
            }

            if (pid.Count() != 9)
            {
                return false;
            }

            return true;
        }

        if (
            this.byr >= 1920
            && this.byr <= 2002
            && this.iyr >= 2010
            && this.iyr <= 2020
            && this.eyr >= 2020
            && this.eyr <= 2030
            && !string.IsNullOrEmpty(this.hgt)
            && validateHeight(this.hgt)
            && !string.IsNullOrEmpty(this.hcl)
            && validateHair(this.hcl)
            && !string.IsNullOrEmpty(this.ecl)
            && validateEye(this.ecl)
            && !string.IsNullOrEmpty(this.pid)
            && validatePid(this.pid)
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Birth Year
    public int byr { get; set; }

    // Issue Year
    public int iyr { get; set; }

    // Expiration Year
    public int eyr { get; set; }

    // Height
    public string hgt { get; set; } = string.Empty;

    // Hair Color
    public string hcl { get; set; } = string.Empty;

    // Eye Color
    public string ecl { get; set; } = string.Empty;

    // Passport ID
    public string pid { get; set; } = string.Empty;

    // Country ID
    public int cid { get; set; }
}
