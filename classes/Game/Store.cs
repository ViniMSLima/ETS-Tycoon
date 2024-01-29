using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Characters;
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

            if (storeType == "Instructor") DrawCharacters(g, Game.Instructors);
            else DrawCharacters(g, Game.Apprentices); 
        }

        public static void DrawCharacters<T>(Graphics g, List<T> list) where T : CharactersData
        {
            float position1 = 0.210f;
            float position2 = 0.190f;

            for (int i = 0; i < 3; i++)
            {
                CharactersData character = list[StoreIndex + i];

                g.DrawImage(character.Img[0],
                    Game.Pb.Width * position2,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                DrawText(g, "Name: " + character.Name, new(Game.Pb.Width * position1, Game.Pb.Height * 0.550f), 15);
                DrawText(g, "Age: " + character.Age, new(Game.Pb.Width * position1, Game.Pb.Height * 0.575f), 15);
                DrawText(g, "C/sec: " + character.Gain, new(Game.Pb.Width * position1, Game.Pb.Height * 0.600f), 15);
                DrawText(g, "R$" + character.Salary, new(Game.Pb.Width * (position1 + 0.0475f), Game.Pb.Height * 0.655f), 25);

                position1 += 0.210f;
                position2 += 0.210f;
            }

            RightButton = 2;
            LeftButton = 3;
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

            var list = new Structure();

            if(Game.OpenApprenticeStore != null)
                list = Game.OpenApprenticeStore;
            else if(Game.OpenInstructorStore != null)
                list = Game.OpenInstructorStore;

            if (inside && list != null)
            {
                if (point.Y < Game.Pb.Height * 0.3)
                {
                    list = null;
                    Game.OpenApprenticeStore = null;
                    Game.OpenInstructorStore = null;
                }
                else if (point.X > Game.Pb.Width * 0.8234375)
                {
                    LeftButton = 5;
                    if (StoreIndex < 15)
                    {
                        StoreIndex++;
                    }
                }
                else if (point.X > Game.Pb.Width * 0.635417)
                {
                    b.BuyCharacter(g, StoreIndex + 2);
                    Sound.PlaySFX1(0);
                }
                else if (point.X > Game.Pb.Width * 0.42760417)
                {
                    b.BuyCharacter(g, StoreIndex + 1);
                    Sound.PlaySFX1(0);

                }
                else if (point.X > Game.Pb.Width * 0.2177083)
                {
                    b.BuyCharacter(g, StoreIndex);
                    Sound.PlaySFX1(0);

                }
                else if (point.X < Game.Pb.Width * 0.1822917)
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

            Font font = new("Arial", Size * Game.Pb.Width * 0.0006f, FontStyle.Bold);
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
