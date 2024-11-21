using System;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class RoundedLabel : Label
{
    public int BorderRadius { get; set; } = 10; // Mặc định là 10px

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
            path.AddArc(this.Width - BorderRadius - 1, 0, BorderRadius, BorderRadius, 270, 90);
            path.AddArc(this.Width - BorderRadius - 1, this.Height - BorderRadius - 1, BorderRadius, BorderRadius, 0, 90);
            path.AddArc(0, this.Height - BorderRadius - 1, BorderRadius, BorderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(Color.Black, 2)) 
            {
                e.Graphics.DrawPath(pen, path);
            }

            using (Brush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, new Rectangle(0, 0, this.Width, this.Height), this.ForeColor, this.BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}

