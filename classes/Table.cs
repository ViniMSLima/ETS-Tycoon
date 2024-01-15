using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Net.Http.Headers;
using System.Windows.Forms;

public class Table : RoomStructure
{
    public Table()
    {
        this.Buy = false;
        this.img = Bitmap.FromFile("sprites/table/buy_table.png");
        this.Price = 20;
    }

    public override void Draw(Graphics g, float roomX, float roomY)
    {
        float h = 40, w = 90;

        Pen pen = new(Color.Red, 5f);

        PointF[] test = new PointF[]{
            new(0, 0),
            new(h, 0),
            new(h, w),
            new(0, w),
            new(0, 0),
        }.ToIsometric(roomX + 120, roomY + 145);

        this.Points = test;

        g.DrawImage(img, roomX, roomY, 200, 200
        );
    }

    public void ClickCheck(PointF point, Graphics g)
    {
        int num_vertices = this.Points.Length;
        double x = point.X, y = point.Y;
        bool inside = false;

        PointF p1 = this.Points[0], p2;

        for (int i = 1; i <= num_vertices; i++)
        {
            p2 = this.Points[i % num_vertices];

            float miny = p1.Y;
            if (p2.Y < p1.Y) miny = p2.Y;

            float maxy = p1.Y;
            if (p2.Y > p1.Y) maxy = p2.Y;

            float maxx = p1.X;
            if (p2.X > p1.X) maxx = p2.X;

            if (y > miny && y <= maxy && x <= maxx)
            {
                double x_intersection =
                (y - p1.Y) * (p2.X - p1.X) /
                (p2.Y - p1.Y) + p1.X;

                if (p1.X == p2.X || x <= x_intersection)
                    inside = !inside;
            }

            p1 = p2;
        }

        if (inside)
        {
            if (this.Buy == true)
                BuyApprentice(g);
            else
                BuyTable();
        }
    }

    public void BuyTable()
    {
        this.img = Bitmap.FromFile("sprites/table/buy_table_down.png");
        if (Player.Money >= this.Price)
        {
            this.Buy = true;
            Player.Money -= this.Price;
        }
        else
        {
            MessageBox.Show("Not enough money!");
            this.img = Bitmap.FromFile("sprites/table/buy_table.png");
        }
    }

    public void BuyCheck()
    {
        if (this.Buy)
            this.img = Bitmap.FromFile("sprites/table/table.png");
    }

    public void BuyApprentice(Graphics g)
    {
        Game.OpenApprenticeStore = true;
    }
}