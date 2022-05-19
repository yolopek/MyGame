using System.Media;
using MyGame.GameModel;
namespace MyGame.View;

public class GameWindow: Form
{
    private int tickCount;
    private readonly GameField gameField;
    private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
    private readonly HashSet<Keys> pressedKeys = new HashSet<Keys>();

    public GameWindow()
    {
        gameField = new GameField();
        ClientSize = new Size(GameInfo.MapWidth, GameInfo.MapHeight);
        FormBorderStyle = FormBorderStyle.FixedDialog;

        var imagesDirectory = new DirectoryInfo("Images");
        foreach (var e in imagesDirectory.GetFiles("*.png"))
            bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);

        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 15;
        timer.Tick += TimerTick;
        timer.Start();
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Black, 0, 0, GameInfo.MapWidth, GameInfo.MapHeight);
        foreach (var model in gameField.Movements)
            e.Graphics.DrawImage(bitmaps[model.Creature.GetImageFileName()], model.Location);
        e.Graphics.ResetTransform();
    }
    
    private void TimerTick(object sender, EventArgs args)
    {
        if (tickCount == 0) gameField.BeginAct();
        foreach (var model in gameField.Movements)
            model.Location = new Point(model.Location.X + 4 * model.Command.DeltaX,
                model.Location.Y + 4 * model.Command.DeltaY);
        tickCount++;
        if (tickCount == 8)
            tickCount = 0;
        Invalidate();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        pressedKeys.Add(e.KeyCode);
        PlayerControl.KeyPressed = e.KeyCode;
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        pressedKeys.Remove(e.KeyCode);
        PlayerControl.KeyPressed = pressedKeys.Any() ? pressedKeys.Min() : Keys.None;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = "Triad of the minds";
        DoubleBuffered = true;
    }
}