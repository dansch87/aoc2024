
namespace Day4Part1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "C:\\Users\\dansch\\Documents\\aoc2024\\day4\\input.txt";

            // Translate characters to an integer representation and store it as a 2D list
            List<List<char>> charMatrix = new List<List<char>>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    List<char> record = line.ToCharArray().ToList();
                    charMatrix.Add(record);
                }
            }

            string lineStr;
            List<string> records = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while ((lineStr = reader.ReadLine()) != null)
                {
                    records.Add(lineStr);
                }
            }

            Console.WriteLine($"{SolvePartA(records.ToArray())}");



        }
        
        public static string SolvePartA(string[] input)
        {
            var rows = input.Length;
            var columns = input[0].Length;

            var sum = 0;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    sum += CountAllFromPoint(i, j);
                }
            }

            return sum.ToString();

            int CountAllFromPoint(int i, int j)
            {
                if (input[i][j] != 'X') return 0;

                var count = 0;
        
                // up
                if (i - 3 >= 0 && input[i - 1][j] == 'M' && input[i - 2][j] == 'A' && input[i - 3][j] == 'S')
                    count++;
        
                // down
                if (i + 3 < rows && input[i + 1][j] == 'M' && input[i + 2][j] == 'A' && input[i + 3][j] == 'S')
                    count++;
        
                // left
                if (j - 3 >= 0 && input[i][j - 1] == 'M' && input[i][j - 2] == 'A' && input[i][j - 3] == 'S')
                    count++;
        
                // right
                if (j + 3 < columns && input[i][j + 1] == 'M' && input[i][j + 2] == 'A' && input[i][j + 3] == 'S')
                    count++;
        
                // up-left
                if (i - 3 >= 0 && j - 3 >= 0 && input[i - 1][j - 1] == 'M' && input[i - 2][j - 2] == 'A' && input[i - 3][j - 3] == 'S')
                    count++;
        
                // up-right
                if (i - 3 >= 0 && j + 3 < columns && input[i - 1][j + 1] == 'M' && input[i - 2][j + 2] == 'A' && input[i - 3][j + 3] == 'S')
                    count++;
        
                // down-left
                if (i + 3 < rows && j - 3 >= 0 && input[i + 1][j - 1] == 'M' && input[i + 2][j - 2] == 'A' && input[i + 3][j - 3] == 'S')
                    count++;
        
                // down-right
                if (i + 3 < rows && j + 3 < columns && input[i + 1][j + 1] == 'M' && input[i + 2][j + 2] == 'A' && input[i + 3][j + 3] == 'S')
                    count++;
        
                return count;
            }
        }
        
    }
}
//2584 is too low!