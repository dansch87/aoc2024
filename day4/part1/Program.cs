
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
            
            
            int count = 0;
            for (int i = 0; i < charMatrix.Count; i++)
            {
                var row = charMatrix[i];
                for (int j = 0; j < row.Count; j++)
                {
                    if (charMatrix[i][j].Equals('X'))
                    {
                        
                        if (IsHorizontal(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsHorizontalReverse(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsVertical(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsVerticalReverse(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsDiagonalDown(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsDiagonalDownReverse(charMatrix, i, j))
                        {
                            // TODO: is 3 but should be 4
                            count++;
                        }
                        
                        if (IsDiagonalUp(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                        if (IsDiagonalUpReverse(charMatrix, i, j))
                        {
                            count++;
                        }
                        
                    }
                    
                }
            }
            Console.WriteLine(count);
        }

        public static bool IsHorizontal(List<List<char>> charMatrix, int row, int col)
        {
            if (col+1 > (charMatrix[0].Count - 4))
            {
                return false;
            }
            else
            {
                if (charMatrix[row][col + 1] == 'M' && charMatrix[row][col + 2] == 'A' && charMatrix[row][col + 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool IsHorizontalReverse(List<List<char>> charMatrix, int row, int col)
        {
            if (col+1 < 4)
            {
                return false;
            }
            else
            {
                if (charMatrix[row][col - 1] == 'M' && charMatrix[row][col - 2] == 'A' && charMatrix[row][col - 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool IsVertical(List<List<char>> charMatrix, int row, int col)
        {
            if (row+1 > (charMatrix.Count - 4))
            {
                return false;
            }
            else
            {
                if (charMatrix[row + 1][col] == 'M' && charMatrix[row + 2][col] == 'A' && charMatrix[row + 3][col] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool IsVerticalReverse(List<List<char>> charMatrix, int row, int col)
        {
            if (row+1 < 4)
            {
                return false;
            }
            else
            {
                if (charMatrix[row - 1][col] == 'M' && charMatrix[row - 2][col] == 'A' && charMatrix[row - 3][col] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        
        public static bool IsDiagonalDown(List<List<char>> charMatrix, int row, int col)
        {
            if ((row+1 > (charMatrix.Count - 4)) || (col+1 > (charMatrix[0].Count - 4)))
            {
                return false;
            }
            else
            {
                if (charMatrix[row + 1][col + 1] == 'M' && charMatrix[row + 2][col + 2] == 'A' && charMatrix[row + 3][col + 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool IsDiagonalDownReverse(List<List<char>> charMatrix, int row, int col)
        {
            if ((row+1 < 4) || (col+1 < 4))
            {
                return false;
            }
            else
            {
                if (charMatrix[row - 1][col - 1] == 'M' && charMatrix[row - 2][col - 2] == 'A' && charMatrix[row - 3][col - 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        
        public static bool IsDiagonalUp(List<List<char>> charMatrix, int row, int col)
        {
            if ((row+1 < 4) || (col+1 > (charMatrix[0].Count - 4)))
            {
                return false;
            }
            else
            {
                if (charMatrix[row - 1][col + 1] == 'M' && charMatrix[row - 2][col + 2] == 'A' && charMatrix[row - 3][col + 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool IsDiagonalUpReverse(List<List<char>> charMatrix, int row, int col)
        {
            if ((row+1 > (charMatrix.Count - 4)) || (col+1 < 4))
            {
                return false;
            }
            else
            {
                if (charMatrix[row + 1][col - 1] == 'M' && charMatrix[row + 2][col - 2] == 'A' && charMatrix[row + 3][col - 3] == 'S')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
//2584 is too low!