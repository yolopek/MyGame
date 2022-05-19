namespace MyGame.GameModel;

public class PlayerControl
{
    public static Keys KeyPressed;
}

public class Player : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var moveCommand = new CreatureCommand();
        switch (PlayerControl.KeyPressed)
        {
            case Keys.W when y > 0:
                moveCommand.DeltaY = -5;
                break;
            case Keys.S when y < GameInfo.MapHeight - 1:
                moveCommand.DeltaY = 5;
                break;
            case Keys.D when x < GameInfo.MapWidth - 1:
                moveCommand.DeltaX = 5;
                break;
            case Keys.A when x > 0:
                moveCommand.DeltaX = -5;
                break;
        }

        return moveCommand;
    }
    
    public string GetImageFileName()
    {
        return "Player_f0.png";
    }
    
    public int GetDrawingPriority()
    {
        return 0;
    }

    public Size GetHitbox()
    {
        return new Size(128, 128);
    }
}