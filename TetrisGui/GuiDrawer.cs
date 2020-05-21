using Microsoft.SmallBasic.Library;

namespace Tetris
{
    class GuiDrawer : IDrawer
    {
        const int POINT_SIZE = 20;

        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = "DarkBlue";
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * POINT_SIZE, y * POINT_SIZE, POINT_SIZE, POINT_SIZE);
        }

        public void HidePoint(int x, int y)
        {
            GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * POINT_SIZE, y * POINT_SIZE, POINT_SIZE, POINT_SIZE);
        }

        public void InitField()
        {
            GraphicsWindow.Width = Field.Width * POINT_SIZE;
            GraphicsWindow.Height = Field.Height * POINT_SIZE;
            GraphicsWindow.BackgroundColor = "LightBlue";
        }

        public void WriteGameOver()
        {
            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.FontSize = 20;
            GraphicsWindow.DrawText(Field.Width * POINT_SIZE / 2 - 50, Field.Height * POINT_SIZE / 2, "G A M E  O V E R");
        }
    }
}
