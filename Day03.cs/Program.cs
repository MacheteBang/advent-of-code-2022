var lines = File.ReadAllLines("input.txt");


int totalPriority = 0;

foreach (string line in lines)
{
    string left = line.Substring(0, line.Length / 2);
    string right = line.Substring(line.Length / 2);

    totalPriority += GetValueFromCharacter(FindCommonCharacter(left, right));

    // Console.WriteLine(line);
    // Console.WriteLine(left);
    // Console.WriteLine(right);
    // Console.WriteLine(FindCommonCharacter(left, right));
    // Console.WriteLine(GetValueFromCharacter(FindCommonCharacter(left, right)));
    // Console.WriteLine();
}

Console.WriteLine($"Total Priority: {totalPriority}");








char FindCommonCharacter(string left, string right) => left.Where(c => right.Contains(c)).FirstOrDefault();
int GetValueFromCharacter(char character) => character switch
{
    >= 'a' and <= 'z' => (int)character - 96,
    >= 'A' and <= 'Z' => (int)character - 38,
    _ => 0
};