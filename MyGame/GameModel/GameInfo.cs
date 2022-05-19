using System.Data;
using System.Net.Mime;

namespace MyGame.GameModel;

public class GameInfo
{
    public const int MapHeight = 720;
    public const int MapWidth = 1280;
    public static ICreature[,] Map;

    private static readonly string WorkingDirectory =
        new DirectoryInfo("Maps").GetFiles("firstMap.txt").First().ToString();

    static readonly string MapScheme = File.ReadAllText(WorkingDirectory);

    public static void CreateMap()
    {
        Map = CreatureMapCreator.CreateMap(MapScheme);
    }
}