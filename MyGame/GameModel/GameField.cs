namespace MyGame.GameModel;

public class GameField
{
    public List<CreatureAnimation> Movements = new List<CreatureAnimation>();

    public void BeginAct()
    {
        Movements.Clear();
        for (var x = 0; x < GameInfo.MapWidth / 40; x++)
        {
            for (var y = 0; y < GameInfo.MapHeight / 40; y++)
            {
                var creature = GameInfo.Map[x, y];
                if (creature is null) continue;
                var command = creature.Act(x, y);

                Movements.Add(new CreatureAnimation()
                {
                    Command = command,
                    Creature = creature,
                    Location = new Point(x * creature.GetHitbox().Width, y * creature.GetHitbox().Height),
                    TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY)
                });
            }
        }

        Movements = Movements.OrderByDescending(i => i.Creature.GetDrawingPriority()).ToList();
    }
}