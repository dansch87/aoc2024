

string path = "C:\\Users\\dansch\\Documents\\aoc2024\\day2\\input.txt";
string line;

/* PART 1 */

static bool is_strict_increasing(string line) {   
    int[] line_items = line.Split(' ').Select(int.Parse).ToArray();
    for (int i = 0; i < line_items.Count() - 1; i++) {
        if (line_items[i] >= line_items[i+1]) {
            return false;
        }
    }
    return true;
}


static bool is_strict_decreasing(string line) {   
    int[] line_items = line.Split(' ').Select(int.Parse).ToArray();
    for (int i = 0; i < line_items.Count() - 1; i++) {
        if (line_items[i] <= line_items[i+1]) {
            return false;
        }
    }
    return true;
}   


static bool has_right_dist(string line) {
    int[] line_items = line.Split(' ').Select(int.Parse).ToArray();
    bool flag = true;
    
    for (int i = 1; i < line_items.Count(); i++) {
        int j = i - 1;
        int distance = line_items[i] - line_items[j];
        distance = Math.Abs(distance);
        if (!(distance >= 1 && distance <= 3)) {
            flag = false;
        }
    }
    return flag;
}   


int safe_report_count = 0;

try {
	StreamReader sr = new StreamReader(path);
	line = sr.ReadLine();
    
    while (line != null) {    
        if (is_strict_increasing(line) || is_strict_decreasing(line)) {
            if (has_right_dist(line)) {
                safe_report_count += 1;
            }
        }
		line = sr.ReadLine();
	}
} catch (Exception e) {
	Console.WriteLine(e);
} finally {
	Console.WriteLine("Finished!");
}


Console.WriteLine($"Result Part 1: {safe_report_count}");












dampener_tolerance