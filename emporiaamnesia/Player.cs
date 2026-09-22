class Player
{
   

    public int Row {get; set;}
    
    public int Col {get; set;}

    public Backpack backpack {get; } = new();

    public Player(int startRow, int startCol)
    {
        Row = startRow;
        Col = startCol;
        backpack.Items.Add(new Item { Name = "\nCheck", Description = "En check värd 25 000 kr" });
        backpack.Items.Add(new Item { Name = "\nKvitto", Description = "Ett kvitto från kemtvätt med numret 1337 på." });
    }
}