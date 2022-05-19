using MyGame.GameModel;
using MyGame.View;
namespace MyGame;

static class Program
{
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        GameInfo.CreateMap();
        Application.Run(new GameWindow());
    }
}