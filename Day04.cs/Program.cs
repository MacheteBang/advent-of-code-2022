string[] exampleLines = File.ReadAllLines("input.example.txt");
string[] lines = File.ReadAllLines("input.txt");

int overlappingAssignments = 0;

foreach (string line in lines)
{
    Assignment assignment1 = new Assignment(line.Split(",")[0]);
    Assignment assignment2 = new Assignment(line.Split(",")[1]);

    if (assignment1.FullyOverlaps(assignment2) || assignment2.FullyOverlaps(assignment1)) overlappingAssignments++;
}

Console.WriteLine($"Overlapping assignments: {overlappingAssignments}");