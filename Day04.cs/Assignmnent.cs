public class Assignment
{
    public int LowerBound { get; set; }
    public int UpperBound { get; set; }

    public Assignment(string assignment)
    {
        LowerBound = int.Parse(assignment.Split("-")[0]);
        UpperBound = int.Parse(assignment.Split("-")[1]);
    }

    public bool FullyOverlaps(Assignment otherAssignment)
    {
        return (LowerBound <= otherAssignment.LowerBound && UpperBound >= otherAssignment.UpperBound);
    }

}