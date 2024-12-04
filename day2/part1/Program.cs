

// Read records

string path = "C:\\Users\\dansch\\Documents\\aoc2024\\day2\\input.txt";

string line;

List<List<int>> records = new List<List<int>>();
using (StreamReader reader = new StreamReader(path))
{
    while ((line = reader.ReadLine()) != null)
    {   
        List<int> record = line.Split(" ").Select(int.Parse).ToList();
        records.Add(record);
    }
}


// Define functions

static bool IsStrictIncreasing(List<int> record) {   
    for (int i = 0; i < record.Count() - 1; i++) {
        if (record[i] >= record[i+1]) {
            return false;
        }
    }
    return true;
}

static bool IsStrictDecreasing(List<int> record) {   
    for (int i = 0; i < record.Count() - 1; i++) {
        if (record[i] <= record[i+1]) {
            return false;
        }
    }
    return true;
}   

bool IsRightLevelDistance(List<int> record) {
    for (int i = 0; i < record.Count() - 1; i++) {
        int dist = Math.Abs(record[i] - record[i+1]);
        if (!(dist >= 1 && dist <= 3)) {
            return false;
        }
    }
    return true;
}

bool IsSafeRecord(List<int> record) {

    if (record.Count < 2) {
        return true;
    }

    if (IsStrictIncreasing(record) || IsStrictDecreasing(record)) {
        if (IsRightLevelDistance(record)) {
            return true;
        }
    }

    return false;
}




// Process Data to Calculate Result

int result = 0;
foreach (var record in records) {
    if (IsSafeRecord(record)) {
        result++;
    }
}
Console.WriteLine($"Result: {result}"); 
// 516
