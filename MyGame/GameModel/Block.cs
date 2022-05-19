namespace MyGame.GameModel;

public class Block : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand();
    }
    
    public string GetImageFileName()
    {
        return "floor_1.png";
    }
    
    public int GetDrawingPriority()
    {
        return 1;
    }

    public Size GetHitbox()
    {
        return new Size(40, 40);
    }
}