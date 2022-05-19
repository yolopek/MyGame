using System.Diagnostics;

namespace MyGame.GameModel;

public class CreatureMapCreator
{
    public static ICreature[,] CreateMap(string map, string separator = "\r\n")
    {
        var rows = map.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
        var result = new ICreature[rows[0].Length, rows.Length];
        for (var x = 0; x < rows[0].Length; x++)
        {
            for (var y = 0; y < rows.Length; y++)
            {
                result[x, y] = CreateCreatureBySymbol(rows[y][x]);
            }
        }

        return result;
    }

    public static ICreature CreateCreatureBySymbol(char symbol)
    {
        switch (symbol)
        {
            case 'W':
                return new Block();
            case ' ':
                return null;
            default:
                throw new Exception("Wrong object!");
        }
    }
}