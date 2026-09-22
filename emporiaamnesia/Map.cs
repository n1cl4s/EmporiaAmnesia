class Map
{
    private Location?[][] locations =
    {
        new Location?[] { null, null, new Escalator1(), new Roof(), null },
        new Location?[] { new Foyer(), new Escalator2(), new CorridorA(), null, null },
        new Location?[] { new ToiletStall(), null, new OutsideDryCleaner(), new CorridorB(), null },
        new Location?[] { null, null, new DryCleaner(), new SecurityOffice(), new TaxiStation() },
    };

    public Location GetLocation(int row, int col)
    {
        return locations[row][col]!;
    }

    public bool PositionExists(int row, int col)
    {
        if(row < 0 || row >= locations.Length) // is row out of bounds?
        {
          return false;  
        }

        if (col < 0 || col >= locations[row].Length) // is col out of bounds
        {
         return false;   
        }

        if (locations[row][col] == null) // is positions on a null cell
        {
            return false;
        }

    return true;
    }
}
