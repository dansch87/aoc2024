using System.Text.RegularExpressions;


// Read input file
string path = "C:\\Users\\dansch\\Documents\\aoc2024\\day3\\input.txt";
string fileContent = File.ReadAllText(path);


// Regex
var patternMul = @"mul\(\d+,\d+\)";
var patternDo = @"do\(\)";
var patternDont = @"don't\(\)";

MatchCollection matchMul = Regex.Matches(fileContent, patternMul);
MatchCollection matchDo = Regex.Matches(fileContent, patternDo);
MatchCollection matchDont = Regex.Matches(fileContent, patternDont);



List<List<int>> disableRange = new List<List<int>>();
var prevDo = 0;
for (int i = 0; i < matchDont.Count; i++)
{
    var nextDont = matchDont[i].Index;
    
    if (nextDont < prevDo)
    {
        continue;
    }
    
    for (int j = 0; j < matchDo.Count; j++)
    {
        var nextDo = matchDo[j].Index;
        if (nextDo > nextDont)
        {
            //Console.WriteLine($"dont: {nextDont} | do: {nextDo}");
            disableRange.Add([nextDont, nextDo]);
            
            prevDo = nextDo;
            break;
        }
    }
}


bool IsDiabled(int index, List<List<int>> disableRange)
{
    foreach (var disableItem in disableRange)
    {
        var disableStart = disableItem[0];
        var disableEnd = disableItem[1];
        
        if (index > disableStart && index < disableEnd)
        {
            return true;
        }
    }

    return false;
}


var result = 0;
var sub_pattern = @"\d+";
for (int i = 0; i < matchMul.Count; i++)
{
    if (IsDiabled(matchMul[i].Index, disableRange))
    {
        continue;
    }
    
    var amount = 1;
    foreach (Match number in Regex.Matches(matchMul[i].Value, sub_pattern)) {
        amount *= int.Parse(number.ToString());
    }
    
    result += amount;
}
Console.WriteLine($"Result: {result}");
