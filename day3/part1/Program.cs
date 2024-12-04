
// Read input file

using System.Text.RegularExpressions;

string path = "C:\\Users\\dansch\\Documents\\aoc2024\\day3\\input.txt";

string file_content = File.ReadAllText(path);

var pattern = @"mul\(\d+,\d+\)";

int result = 0;
foreach (Match match in Regex.Matches(file_content, pattern)) {

    int amount = 1;

    if (match.Success) {
        var sub_pattern = @"\d+";

        foreach (Match number in Regex.Matches(match.Groups[0].Value, sub_pattern)) {
            amount *= int.Parse(number.ToString());
        }

        result += amount;
    }
}

Console.WriteLine($"Result: {result}");
