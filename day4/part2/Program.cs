
//string filePath = "C:\\Users\\dansch\\Documents\\aoc2024\\day4\\part2\\test.txt";
string filePath = "C:\\Users\\dansch\\Documents\\aoc2024\\day4\\input.txt";

var records = ReadRecords(filePath);

var rows = records.Count;
var cols = records[0].Length;

var count = 0;
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < cols; j++)
    {
        //Console.Write(records[i][j]);
        if (CheckIfXMAS(i, j))
        {
            count++;
        }
    }
}
Console.WriteLine($"Count: {count}");
bool CheckIfXMAS(int row, int col)
{
    
    // Skip to prevent out of range exception
    if (row == 0 || row == rows - 1 || col == 0 || col == cols - 1)
    {
        return false;
    }
    // Skip if not A char
    if (records[row][col] != 'A') return false;
    
    if (records[row][col] == 'A')
    {
        /* Version 1:
         * M M
         *  A
         * S S
         */
        if (records[row-1][col-1] == 'M' && records[row-1][col+1] == 'M' && records[row+1][col-1] == 'S' && records[row+1][col+1] == 'S')
        {
            return true;
        }
        
        /* Version 2:
         * S S
         *  A
         * M M
         */
        if (records[row-1][col-1] == 'S' && records[row-1][col+1] == 'S' && records[row+1][col-1] == 'M' && records[row+1][col+1] == 'M')
        {
            return true;
        }
        
        /* Version 3:
         * M S
         *  A
         * M S
         */
        if (records[row-1][col-1] == 'M' && records[row-1][col+1] == 'S' && records[row+1][col-1] == 'M' && records[row+1][col+1] == 'S')
        {
            return true;
        }
        
        /* Version 4:
         * S M
         *  A
         * S M
         */
        if (records[row-1][col-1] == 'S' && records[row-1][col+1] == 'M' && records[row+1][col-1] == 'S' && records[row+1][col+1] == 'M')
        {
            return true;
        }
    }
    

    return false;
}



List<string> ReadRecords(string file)
{
    var records = new List<string>();
    string line;
    using (StreamReader sr = new StreamReader(file))
    {
        while ((line = sr.ReadLine()) != null)
        {
            records.Add(line);
        }
    }
    return records;
}
