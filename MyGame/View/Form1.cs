using MyGame.GameModel;
namespace MyGame.View;

public class GameWindow: Form
{
    private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
    
    public GameWindow()
    {
        ClientSize = new Size(32 * 12, 32 * 12);
        FormBorderStyle = FormBorderStyle.FixedDialog;

        var imagesDirectory = new DirectoryInfo("Images");
        foreach (var e in imagesDirectory.GetFiles("*.png"))
            bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Black, 0, 0, 512, 512);
        e.Graphics.DrawImage(bitmaps["floor_1x2.png"], new Point(32, 32));
        e.Graphics.DrawImage(bitmaps["floor_1x2.png"], new Point(64, 32));
        e.Graphics.DrawImage(bitmaps["Player_f1.png"], new Point(280, 280));
        e.Graphics.ResetTransform();
    }
    
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = "Triad of the minds";
        DoubleBuffered = true;
    }
}