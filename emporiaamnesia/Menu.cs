class Menu
{
    private List<string> options = [
        "1. Förflytta dig",
        "2. Undersök platsen",
        "3. Ta ett föremål",
        "4. Interagera",
        "5. Titta i ryggsäcken",
        "9. Avsluta spelet"
    ];

    public int ShowAndGetChoice()
    {
        Console.WriteLine("\n== Vad vill du göra?");
        Console.WriteLine(string.Join("\n", options));
        Console.Write("> ");
        string? input = Console.ReadLine();
        int.TryParse(input, out int choice);
        return choice;
    }
}