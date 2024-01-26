using System.Collections.Generic;
using System.Drawing;

using MotherClasses;

namespace EtsTycoon
{
    public class CharactersStore
    {
        public static int StoreIndex { get; set; } = 0;
        public static int RightButton { get; set; } = 2;
        public static int LeftButton { get; set; } = 3;
        public static PointF[] Btn1 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.135f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.135f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
            };
        public static PointF[] Btn2 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f),
                new(Game.Pb.Width * 0.82f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f + Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.82f + Game.Pb.Width * 0.05f,  Game.Pb.Height * 0.4f),
            };
        public static PointF[] Btn3 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.217f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.217f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };
        public static PointF[] Btn4 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.427f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.427f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };
        public static PointF[] Btn5 { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.637f,  Game.Pb.Height * 0.62f),
                new(Game.Pb.Width * 0.637f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.637f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f + Game.Pb.Height * 0.1f),
                new(Game.Pb.Width * 0.637f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.62f),
            };
        public static PointF[] Close { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f),
                new(Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.1f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.1f,  Game.Pb.Height * 0.2f),
            };

        public static List<Image> Images { get; set; } = new()
        {
            Bitmap.FromFile("./sprites/backgrounds/storeBackground.png"),
            Bitmap.FromFile("./sprites/backgrounds/storeCard.png"),
            Bitmap.FromFile("./sprites/button/leftButton.png"),
            Bitmap.FromFile("./sprites/button/rightButton.png"),
            Bitmap.FromFile("./sprites/button/leftButtonClicked.png"),
            Bitmap.FromFile("./sprites/button/rightButtonClicked.png"),
            Bitmap.FromFile("./sprites/coin/Coin.gif"),
            Bitmap.FromFile("./sprites/button/esc_button.png")
        };

        public static void Draw(Graphics g, string storeType)
        {
            g.DrawImage(Images[0],
                Game.Pb.Width * 0.1f,
                Game.Pb.Height * 0.1f,
                Game.Pb.Width * 0.8f,
                Game.Pb.Height * 0.8f
            );
            g.DrawImage(Images[7],
                Game.Pb.Width * 0.12f,
                Game.Pb.Height * 0.2f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.195f,
                Game.Pb.Height * 0.25f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[0],
                Game.Pb.Width * 0.217f,
                Game.Pb.Height * 0.62f,
                Game.Pb.Width * 0.15f,
                Game.Pb.Height * 0.1f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.405f,
                Game.Pb.Height * 0.25f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[0],
                Game.Pb.Width * 0.427f,
                Game.Pb.Height * 0.62f,
                Game.Pb.Width * 0.15f,
                Game.Pb.Height * 0.1f
            );
            g.DrawImage(Images[1],
                Game.Pb.Width * 0.615f,
                Game.Pb.Height * 0.25f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.5f
            );
            g.DrawImage(Images[0],
                Game.Pb.Width * 0.637f,
                Game.Pb.Height * 0.62f,
                Game.Pb.Width * 0.15f,
                Game.Pb.Height * 0.1f
            );
            g.DrawImage(Images[RightButton],
                Game.Pb.Width * 0.135f,
                Game.Pb.Height * 0.4f,
                Game.Pb.Width * 0.05f,
                Game.Pb.Height * 0.2f
            );
            g.DrawImage(Images[LeftButton],
                Game.Pb.Width * 0.82f,
                Game.Pb.Height * 0.4f,
                Game.Pb.Width * 0.05f,
                Game.Pb.Height * 0.2f
            );

            if (storeType == "Instructor")
            {

                g.DrawImage(Game.Instructors[StoreIndex].img[0],
                    Game.Pb.Width * 0.190f,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                g.DrawImage(Game.Instructors[StoreIndex + 1].img[0],
                    Game.Pb.Width * 0.400f,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                g.DrawImage(Game.Instructors[StoreIndex + 2].img[0],
                    Game.Pb.Width * 0.610f,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                DrawText(g, "Name: " + Game.Instructors[StoreIndex].Name, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Instructors[StoreIndex].Age, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "Boost: " + Game.Instructors[StoreIndex].Boost, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Instructors[StoreIndex].Salary, new(Game.Pb.Width * 0.265f, Game.Pb.Height * 0.655f), 25);

                DrawText(g, "Name: " + Game.Instructors[StoreIndex + 1].Name, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Instructors[StoreIndex + 1].Age, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "Boost: " + Game.Instructors[StoreIndex + 1].Boost, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Instructors[StoreIndex + 1].Salary, new(Game.Pb.Width * 0.475f, Game.Pb.Height * 0.655f), 25);

                DrawText(g, "Name: " + Game.Instructors[StoreIndex + 2].Name, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Instructors[StoreIndex + 2].Age, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "Boost: " + Game.Instructors[StoreIndex + 2].Boost, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Instructors[StoreIndex + 2].Salary, new(Game.Pb.Width * 0.685f, Game.Pb.Height * 0.655f), 25);

                RightButton = 2;
                LeftButton = 3;
            }
            else if(storeType == "Apprentice")
            {
                g.DrawImage(Game.Apprentices[StoreIndex].Img[0],
                Game.Pb.Width * 0.190f,
                Game.Pb.Height * 0.2f,
                Game.Pb.Width * 0.2f,
                Game.Pb.Height * 0.4f
            );

                g.DrawImage(Game.Apprentices[StoreIndex + 1].Img[0],
                    Game.Pb.Width * 0.400f,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                g.DrawImage(Game.Apprentices[StoreIndex + 2].Img[0],
                    Game.Pb.Width * 0.610f,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                DrawText(g, "Name: " + Game.Apprentices[StoreIndex].Name, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Apprentices[StoreIndex].Age, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "C/sec: " + Game.Apprentices[StoreIndex].CoinPerSecond, new(Game.Pb.Width * 0.210f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Apprentices[StoreIndex].Salary, new(Game.Pb.Width * 0.265f, Game.Pb.Height * 0.655f), 25);

                DrawText(g, "Name: " + Game.Apprentices[StoreIndex + 1].Name, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Apprentices[StoreIndex + 1].Age, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "C/sec: " + Game.Apprentices[StoreIndex + 1].CoinPerSecond, new(Game.Pb.Width * 0.420f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Apprentices[StoreIndex + 1].Salary, new(Game.Pb.Width * 0.475f, Game.Pb.Height * 0.655f), 25);

                DrawText(g, "Name: " + Game.Apprentices[StoreIndex + 2].Name, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + Game.Apprentices[StoreIndex + 2].Age, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "C/sec: " + Game.Apprentices[StoreIndex + 2].CoinPerSecond, new(Game.Pb.Width * 0.630f, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + Game.Apprentices[StoreIndex + 2].Salary, new(Game.Pb.Width * 0.685f, Game.Pb.Height * 0.655f), 25);

                RightButton = 2;
                LeftButton = 3;
            }
            else 
            {

            }
        }

        public static bool ClickCheck(PointF point, PointF[] a, Structure b, Graphics g)
        {

            int num_vertices = a.Length;
            double x = point.X, y = point.Y;
            bool inside = false;

            PointF p1 = a[0], p2;

            for (int i = 1; i <= num_vertices; i++)
            {
                p2 = a[i % num_vertices];

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

            if (inside && Game.OpenApprenticeStore != null)
            {
                if (point.Y < 300)
                {
                    Game.OpenApprenticeStore = null;
                }
                if (point.X > 1581)
                {
                    LeftButton = 5;
                    if (StoreIndex < 15)
                    {
                        StoreIndex++;
                    }
                }
                else if (point.X > 1224)
                {
                    b.BuyCharacter(g, StoreIndex + 2);
                }
                else if (point.X > 821)
                {
                    b.BuyCharacter(g, StoreIndex + 1);

                }
                else if (point.X > 418)
                {
                    b.BuyCharacter(g, StoreIndex);

                }
                else if (point.X < 350)
                {
                    RightButton = 4;
                    if (StoreIndex > 0)
                    {
                        StoreIndex--;
                    }

                }
            }
            else if (inside && Game.OpenInstructorStore != null)
            {
                if (point.Y < 300)
                {
                    Game.OpenInstructorStore = null;
                }
                if (point.X > 1581)
                {
                    LeftButton = 5;
                    if (StoreIndex < 6)
                    {
                        StoreIndex++;
                    }
                }
                else if (point.X > 1224)
                {
                    b.BuyCharacter(g, StoreIndex + 2);
                }
                else if (point.X > 821)
                    b.BuyCharacter(g, StoreIndex + 1);

                else if (point.X > 418)
                {
                    b.BuyCharacter(g, StoreIndex);

                }
                else if (point.X < 350)
                {
                    RightButton = 4;
                    if (StoreIndex > 0)
                    {
                        StoreIndex--;
                    }
                }
            }

            return inside;
        }

        public static void DrawText(Graphics g, string text, PointF point, int Size)
        {
            Color textColor = Color.BlanchedAlmond;
            SolidBrush textBrush = new(textColor);

            Font font = new("Arial", Size, FontStyle.Bold);
            g.DrawString(text, font, textBrush, point);
        }

        internal static void ClickCheckAll(Point location, Structure OpenStore, Graphics g)
        {
            ClickCheck(location, Btn1, OpenStore, g);
            ClickCheck(location, Btn2, OpenStore, g);
            ClickCheck(location, Btn3, OpenStore, g);
            ClickCheck(location, Btn4, OpenStore, g);
            ClickCheck(location, Btn5, OpenStore, g);
            ClickCheck(location, Close, OpenStore, g);
        }
    }
}
