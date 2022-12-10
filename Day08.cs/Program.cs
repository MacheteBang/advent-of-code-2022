int[,] forest = LoadForest("input.txt");

int rowBound = forest.GetUpperBound(0);
int colBound = forest.GetUpperBound(1);

int visibleTreeCount = 0;

// All trees on the perimeter are visible.
visibleTreeCount += 2 * (colBound + 1); // top & bottom edges
visibleTreeCount += 2 * (rowBound - 1); // left & right edges (excluding the top & bottom)

// check all inner trees
for (int row = 1; row < rowBound; row++)
{
    for (int col = 1; col < colBound; col++)
    {
        int thisTree = forest[row, col];
        var thisRowToEastEdge = Enumerable.Range(0, col).Select(c => forest[row, c]).ToArray();
        Array.Reverse(thisRowToEastEdge);

        var thisRowToWestEdge = Enumerable.Range(col + 1, colBound - col).Select(c => forest[row, c]).ToArray();

        var thisColToNorthEdge = Enumerable.Range(0, row).Select(r => forest[r, col]).ToArray();
        Array.Reverse(thisRowToEastEdge);

        var thisRowToSouthEdge = Enumerable.Range(row + 1, rowBound - row).Select(r => forest[r, col]).ToArray();

        visibleTreeCount += IsVisible(thisTree, thisRowToEastEdge, thisColToNorthEdge, thisRowToWestEdge, thisRowToSouthEdge);
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

int IsVisible(int tree, int[] fromEast, int[] fromNorth, int[] fromWest, int[] fromSouth)
{
    if (tree > fromEast.Max()) return 1;
    if (tree > fromNorth.Max()) return 1;
    if (tree > fromWest.Max()) return 1;
    if (tree > fromSouth.Max()) return 1;

    return 0;
}

int GetScenicScore(int tree, int[] treeList)
{
    foreach (int s in treeList)
    {
        if (tree >= s) return s + 1;
    }

    return 0;
}