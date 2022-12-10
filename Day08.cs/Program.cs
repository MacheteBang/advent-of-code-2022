int[,] forest = LoadForest("input.txt");

int rowBound = forest.GetUpperBound(0);
int colBound = forest.GetUpperBound(1);

int visibleTreeCount = 0;

// All trees on the perimeter are visible.
visibleTreeCount += 2 * (colBound + 1); // top & bottom edges
visibleTreeCount += 2 * (rowBound - 1); // left & right edges (excluding the top & bottom)

Console.WriteLine(visibleTreeCount);

// check all inner trees
for (int row = 1; row < rowBound; row++)
{
    for (int col = 1; col < colBound; col++)
    {
        int thisTree = forest[row, col];

        var thisRowToEastEdge = Enumerable.Range(0, col).Select(c => forest[row, c]).ToArray();
        if (IsHigher(thisTree, thisRowToEastEdge))
        {
            visibleTreeCount++;
            continue;
        }

        var thisRowToWestEdge = Enumerable.Range(col + 1, colBound - col).Select(c => forest[row, c]).ToArray();
        if (IsHigher(thisTree, thisRowToWestEdge))
        {
            visibleTreeCount++;
            continue;
        }

        var thisColToNorthEdge = Enumerable.Range(0, row).Select(r => forest[r, col]).ToArray();
        if (IsHigher(thisTree, thisColToNorthEdge))
        {
            visibleTreeCount++;
            continue;
        }

        var thisRowToSouthEdge = Enumerable.Range(row + 1, rowBound - row).Select(r => forest[r, col]).ToArray();
        if (IsHigher(thisTree, thisRowToSouthEdge))
        {
            visibleTreeCount++;
            continue;
        }
    }
}

Console.WriteLine(visibleTreeCount);











// ----------
int[,] LoadForest(string inputFile)
{
    string fileData = File.ReadAllText(inputFile);
    int rowCount = fileData.Trim().Where(c => c == '\r').Count();
    int colCount = fileData.Split('\r')[0].Length;

    int[,] forest = new int[rowCount + 1, colCount];

    int row = 0, col = 0;

    foreach (char tree in fileData)
    {
        if (tree == '\n') continue;
        if (tree == '\r')
        {
            row++;
            col = 0;
            continue;
        }

        forest[row, col] = Convert.ToInt32(tree.ToString());

        col++;
    }

    return forest;
}

bool IsHigher(int tree, int[] treeList)
{
    return tree > treeList.Max();
}

int GetScenicScore(int tree, int[] treeList)
{
    return 0;
}