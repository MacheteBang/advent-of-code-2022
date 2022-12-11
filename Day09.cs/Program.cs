string[] lines = File.ReadAllLines("input.example.txt");

CoordinateSet head = new();
CoordinateSet tail = new();

double maxDistance = Math.Sqrt(2);

List<CoordinateSet> tailHistory = new() { new CoordinateSet(0, 0) };

foreach (string line in lines)
{
    string direction = line.Split(" ")[0];
    int steps = Convert.ToInt32(line.Split(" ")[1]);

    for (int i = 1; i <= steps; i++)
    {
        CoordinateSet previousHead = head.Clone();

        switch (direction)
        {
            case "U":
                head.Y--;
                break;
            case "D":
                head.Y++;
                break;
            case "R":
                head.X++;
                break;
            case "L":
                head.X--;
                break;
            default:
                break;
        }

        if (tail.DistanceTo(head) > maxDistance)
        {
            tail = previousHead;
            tailHistory.Add(tail);
        }

        //PrintMap(head, tail);
    }
}

Console.WriteLine(tailHistory.DistinctBy(c => c.ToString()).Count());














void PrintMap(CoordinateSet head, CoordinateSet tail)
{
    string map = "";

    int gridDimension = 40;
    Console.Clear();
    for (int y = -gridDimension; y <= gridDimension; y++)
    {
        for (int x = -gridDimension; x <= gridDimension; x++)
        {
            CoordinateSet currentLocation = new CoordinateSet() { X = x, Y = y };

            if (tail == currentLocation)
            {
                map += "T";
                continue;
            }

            if (head == currentLocation)
            {
                map += "H";
                continue;
            }

            map += ".";

        }
        map += Environment.NewLine;
    }

    Console.WriteLine(map);
    Thread.Sleep(1000);
}