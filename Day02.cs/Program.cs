var lines = System.IO.File.ReadAllLines("input.txt").ToList();

// First Index = Opponent, Second Index = Me
int[, ] results = { { 4, 8, 3 }, { 1, 5, 9 }, { 7, 2, 6 } };


Console.WriteLine(lines.Sum(l => CalcScore(l)));






/////
int CalcScore(string match) =>  results[
        (int)ToAction(match.Split(" ")[0].Trim()[0]),
        (int)ToAction(match.Split(" ")[1].Trim()[0])
    ];

Actions ToAction(char action) => action switch
{
    'A' or 'X' => Actions.Rock,
    'B' or 'Y' => Actions.Paper,
    'C' or 'Z' => Actions.Scissors
};

enum Actions
{
    Rock = 0,
    Paper = 1,
    Scissors = 2
}