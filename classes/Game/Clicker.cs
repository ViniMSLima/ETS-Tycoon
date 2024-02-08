using System.Drawing;

using Extension;

namespace EtsTycoon
{
    public class Clicker
    {
        public static PointF[] Points { get; set; }
        public static int H { get; set; }
        public static int W { get; set; }

        public static bool Clicks(PointF point)
            => ContainsClick(point, Points);
        
        public static void UpdateClickBox(float roomX, float roomY)
        {
            H = 400;
            W = 625;

            PointF[] points = new PointF[]{
                new(0, 0),
                new(H, 0),
                new(H, W),
                new(0, W),
                new(0, 0),
            }.ToIsometric(roomX, roomY);

            Points = points;
        }
    
        public static bool ContainsClick(PointF point, PointF[] area)
        {
            int num_vertices = area.Length;

            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = area[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = area[i % num_vertices];

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

            return inside;
        }
    }
}
