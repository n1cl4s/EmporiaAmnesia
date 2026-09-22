class Game
{

  bool isRunning = true;
  Player player = new(2, 0); // starting position
  Map map = new();
  Menu menu = new();


  public void Start()
  {
    // game start
    while (isRunning)
    {
      PlayTurn();
    }
  }

  Location CurrentLocation() // location is an object of type Location (i e Toilet stall, Foyer, ...)
  {
    return map.GetLocation(player.Row, player.Col); // player.Row and playerCol is the player position - not player location...
  }

  void PlayTurn()
  {
    Location location = CurrentLocation();

    Console.WriteLine($"\n=== {location.Name} ===");
    Console.WriteLine(location.Description);

    int choice = menu.ShowAndGetChoice();

    switch (choice)
    {
      case 1:
        // Available directions are defined in each location
        List<string> directions = location.Directions.ToList();

        Console.WriteLine("Vart vill du gå?", directions);
        string selectedDirection = Console.ReadLine()!;

        switch (selectedDirection)
        {
          case "Norr":
            TryMovePlayer(-1, 0);
            break;
          case "Söder":
            TryMovePlayer(1, 0);
            break;
          case "Väster":
            TryMovePlayer(0, -1);
            break;
          case "Öster":
            TryMovePlayer(0, 1);
            break;
        }
        break;
      case 2:
        Console.WriteLine(location.Description); // we could change this for a more detailed description
        break;
      case 3:
        if (location.Items.Count == 0)
        {
          Console.WriteLine("Det finns inga föremål här.");
          break;
        }

        Console.WriteLine("Vilket föremål vill du ta?");
        for (int i = 0; i < location.Items.Count; i++)
        {
          Console.WriteLine($"{i + 1}. {location.Items[i].Name}");
        }

        Console.Write("> ");
        int.TryParse(Console.ReadLine(), out int itemChoice);

        if (itemChoice >= 1 && itemChoice <= location.Items.Count)
        {
          Item takenItem = location.Items[itemChoice - 1];
          player.backpack.Items.Add(takenItem);
          location.Items.Remove(takenItem);
          Console.WriteLine($"Du tog: {takenItem.Name}");
        }
        else
        {
          Console.WriteLine("Ogiltigt val.");
        }
        break;
      case 4:
        // Call location action (if there is any)
        break;
      case 5:
        if (player.backpack.Items.Count == 0)
        {
          Console.WriteLine("Ryggsäcken är tom.");
        }
        else
        {
          Console.WriteLine("I ryggsäcken har du:");
          foreach (Item item in player.backpack.Items)
          {
            Console.WriteLine($"- {item.Name}: {item.Description}");
          }
        }
        break;
      case 9:
        isRunning = false; // stop game loop and exit
        Console.WriteLine("Spelet avslutas.");
        break;
    }

    if (choice != 9)
    {
      Console.WriteLine("\nTryck Enter för att fortsätta");
      Console.ReadLine();
    }
  }

  private void TryMovePlayer(int rowMove, int colMove)
  {
    if (rowMove != 0 && colMove != 0)
    {
      Console.WriteLine("Du kan bara flytta dig i en rikning i taget");
    }
    else if (map.PositionExists(player.Row + rowMove, player.Col + colMove))
    {
      player.Row = player.Row + rowMove;
      player.Col = player.Col + colMove;
    }
    else
    {
      Console.WriteLine("Ogiltig position");
    }

  }

}