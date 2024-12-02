using System.IO;


/* 
 * PART 1
*/

string line;
List<int> column1 = new List<int>();
List<int> column2 = new List<int>();


// Read input.txt file, convert values to int and store each column as a list
try {
	StreamReader sr = new StreamReader("C:\\Users\\dansch\\Documents\\aoc2024\\day1\\input.txt");
	line = sr.ReadLine();
	while (line != null) {
		string[] words = line.Split(' ');

		column1.Add(Convert.ToInt32(words[0]));
		column2.Add(Convert.ToInt32(words[3]));

		line = sr.ReadLine();
	}
	sr.Close();
} catch (Exception e) {
	Console.WriteLine("Exception: " + e);
} finally {
	Console.WriteLine("Execution of final block");
}


// Sort both lists
column1.Sort();
column2.Sort();

// Calculate the distance between the sorted elements of each list and sum it up
int sum1 = 0;
int dist;
for (int i = 0; i < column1.Count; i++) {
	dist = column1[i] - column2[i];
	if (dist < 0) {
		dist *= -1;
	}
	//Console.WriteLine($"{column1[i]} - {column2[i]} = {dist}");
	sum1 += dist;
}

// Print result for part 1
Console.WriteLine($"Part 1 Result: {sum1}");





/* 
 * PART 2
*/

Dictionary<int, int> LocationCount = new Dictionary<int, int>();


// Add values from first list as keys to the dictionary
for (int i = 0; i < column1.Count; i++) {
	if (!LocationCount.ContainsKey(column1[i])) {
		LocationCount.Add(column1[i], 0);
	}
}


// Count occurence of keys in the second list
for (int i = 0; i < column2.Count; i++) {
	int location = column2[i];
	if (LocationCount.ContainsKey(location)) {
		LocationCount[location] += 1; 
	}
}


int sum2 = 0;
foreach (var item in LocationCount) {
	sum2 += item.Key * item.Value;
	//Console.WriteLine(item);
	//Console.WriteLine(sum2);
}
Console.WriteLine($"Part 2 Result: {sum2}");