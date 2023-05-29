#region Rows
//All the crate stacks
var stacks = new List<Stack<char>>() {
    new Stack<char>(new[] { 'H', 'B', 'V', 'W', 'N', 'M', 'L', 'P' }),
    new Stack<char>(new[] { 'M', 'Q', 'H' }),
    new Stack<char>(new[] { 'N', 'D', 'B', 'G', 'F', 'Q', 'M', 'L' }),
    new Stack<char>(new[] { 'Z', 'T', 'F', 'Q', 'M', 'W', 'G' }),
    new Stack<char>(new[] { 'M', 'T', 'H', 'P' }),
    new Stack<char>(new[] { 'C', 'B', 'M', 'J', 'D', 'H', 'G', 'T' }),
    new Stack<char>(new[] { 'M', 'N', 'B', 'F', 'V', 'R' }),
    new Stack<char>(new[] { 'P', 'L', 'H', 'M', 'R', 'G', 'S' }),
    new Stack<char>(new[] { 'P', 'D', 'B', 'C', 'N' })
};
#endregion

//Input text
var Input = File.ReadAllText("C:\\Users\\cewin.eriksson\\source\\repos\\AoC 2022 Day 5\\Input\\Input.txt");

//Input text without newlines
var Split = Input.Split("\n").ToArray();

//Change this to false if you want the answer to part 2
bool Part1 = false;

//Part 1
if(Part1 == true)
{
    foreach (var row in Split)
    {
        //Splits the text again on spaces
        var A = row.Split(" ").ToArray();

        //How many crates to move
        int NoMove = int.Parse(A[1]);

        //The rows to move to and from
        int NoFrom = int.Parse(A[3]);
        int NoTo = int.Parse(A[5]);

        //moves all the crates
        while(NoMove-- > 0)
        {
            stacks[NoTo - 1].Push(stacks[NoFrom - 1].Pop());
        }
    }

    //Prints the answer
    Console.WriteLine("Answer part 1: " + string.Join("", stacks.Select(x => x.Peek())));
}
else
{
    //Part 2
    foreach (var row in Split)
    {
        //Splits the text again on spaces
        var A = row.Split(" ").ToArray();

        //How many crates to move
        int NoMove = int.Parse(A[1]);

        //The rows to move to and from
        int NoFrom = int.Parse(A[3]);
        int NoTo = int.Parse(A[5]);

        //Temporary stack for the moved items
        var MoveStack = new Stack<char>();

        //Moves the crates into the temporary stack
        while(NoMove-- > 0)
        {
            MoveStack.Push(stacks[NoFrom - 1].Pop());
        }

        //Moves the crates from the temporary stack back into the destination column
        while(MoveStack.Count > 0)
        {
            stacks[NoTo - 1].Push(MoveStack.Pop());
        }
    }
    //Prints the answer
    Console.WriteLine("Answer part 2: " + string.Join("", stacks.Select(x => x.Peek())));
}