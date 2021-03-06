namespace MyGame.GameModel;

public class Monster : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand();
    }
    
    public string GetImageFileName()
    {
        return "Ogre_f0.png";
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public Size GetHitbox()
    {
        return new Size(128, 128);
    }
}