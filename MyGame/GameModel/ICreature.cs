namespace MyGame.GameModel;

public interface ICreature
{
    string GetImageFileName();
    CreatureCommand Act(int x, int y);

    int GetDrawingPriority();

    Size GetHitbox();
}