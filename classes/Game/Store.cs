using System.Collections.Generic;
using System.Drawing;

using MotherClasses;
using Characters;
using Extension;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Markup;

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
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.2f + Game.Pb.Height * 0.05f),
                new(Game.Pb.Width * 0.12f + Game.Pb.Width * 0.15f,  Game.Pb.Height * 0.2f),
            };
        public static PointF[] BuyCart { get; set; } =
            new PointF[]{
                new(Game.Pb.Width * 0.687f,  Game.Pb.Height * 0.86f),
                new(Game.Pb.Width * 0.687f,  Game.Pb.Height * 0.86f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.687f + Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.86f + Game.Pb.Height * 0.08f),
                new(Game.Pb.Width * 0.687f + Game.Pb.Width * 0.12f,  Game.Pb.Height * 0.86f),
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
            Bitmap.FromFile("./sprites/button/esc_button.png"),
            Bitmap.FromFile("./sprites/backgrounds/cart.png")
        };

        public static bool Double { get; set; } = false;
        public static List<int> Cart { get; set; } = new();

        public static void Draw(Graphics g, string storeType)
        {
            g.DrawImage(Bitmap.FromFile("./sprites/black_filter.png"), 0, 0);

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

            if (Double)
            {
                g.DrawImage(Images[8],
                    Game.Pb.Width * 0.1f,
                    Game.Pb.Height * 0.72f,
                    Game.Pb.Width * 0.8f,
                    Game.Pb.Height * 0.7f
                );

                var cartPosition = Game.Pb.Width * 0.2f;
                var Price = 0;

                foreach (int CartItem in Cart)
                {
                    Text.DrawText(g, Game.Apprentices[CartItem].Name, new(cartPosition, Game.Pb.Height * 0.88f), 20);
                    cartPosition += Game.Pb.Width * 0.3f; ;
                    Price += Game.Apprentices[CartItem].Salary;
                }

                Text.DrawText(g, "R$ " + Price.ToString(), new(Game.Pb.Width * 0.72f, Game.Pb.Height * 0.88f), 20);

                Pen pen = new(Color.Red, 5f);
                g.DrawPolygon(pen, BuyCart);
            }
        }

        public static void DrawCharacters<T>(Graphics g, List<T> list) where T : CharactersData
        {
            float position1 = 0.210f;
            float position2 = 0.190f;

            float cardPosition = 0.195f;
            float cardPosition2 = 0.217f;

            int j = 3;
            if (list.Count < 3)
                j = list.Count;

            for (int i = 0; i < j; i++)
            {
                CharactersData character = list[StoreIndex + i];

                g.DrawImage(Images[1],
                    Game.Pb.Width * cardPosition,
                    Game.Pb.Height * 0.25f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.5f
                );

                g.DrawImage(Images[0],
                    Game.Pb.Width * cardPosition2,
                    Game.Pb.Height * 0.62f,
                    Game.Pb.Width * 0.15f,
                    Game.Pb.Height * 0.1f
                );

                g.DrawImage(character.Img[0],
                    Game.Pb.Width * position2,
                    Game.Pb.Height * 0.2f,
                    Game.Pb.Width * 0.2f,
                    Game.Pb.Height * 0.4f
                );

                Text.DrawText(g, "Name: " + character.Name, new(Game.Pb.Width * position1, Game.Pb.Height * 0.550f), 15);
                Text.DrawText(g, "Age: " + character.Age, new(Game.Pb.Width * position1, Game.Pb.Height * 0.575f), 15);
                Text.DrawText(g, character.GainType + ": " + character.Gain, new(Game.Pb.Width * position1, Game.Pb.Height * 0.600f), 15);
                Text.DrawText(g, "R$" + character.Salary, new(Game.Pb.Width * (position1 + 0.0475f), Game.Pb.Height * 0.655f), 25);

                position1 += 0.210f;
                position2 += 0.210f;

                cardPosition += 0.210f;
                cardPosition2 += 0.210f;
            }

            RightButton = 2;
            LeftButton = 3;
        }

        public static bool ClickCheck(PointF point, PointF[] a, Structure b)
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
            int storeSize = 0;

            if (Game.OpenApprenticeStore != null)
            {
                list = Game.OpenApprenticeStore;
                storeSize = Game.Apprentices.Count;
            }
            else if (Game.OpenInstructorStore != null)
            {
                list = Game.OpenInstructorStore;
                storeSize = Game.Instructors.Count;
            }

            if (inside && list != null)
            {
                if (point.Y > 0.8f * Game.Pb.Height)
                {
                    if (Cart.Count < 2)
                        MessageBox.Show("Select more apprentices, need two");
                    else
                        b.BuyCharacter(0);
                }
                else if (point.Y < Game.Pb.Height * 0.3)
                {
                    Game.OpenApprenticeStore = null;
                    Game.OpenInstructorStore = null;
                    Cart = new() { };
                }
                else if (point.X > Game.Pb.Width * 0.8234375)
                {
                    LeftButton = 5;

                    if (StoreIndex < storeSize - 3)
                        StoreIndex++;
                    else
                        StoreIndex = 0;
                }
                else if (point.X > Game.Pb.Width * 0.635417)
                {
                    if (storeSize > 2)
                    {
                        if (Double)
                        {
                            if (Cart.Count < 2)
                                Cart.Add(StoreIndex + 2);
                            else
                                MessageBox.Show("Cart is full, buy or close the store");
                        }
                        else
                        {
                            b.BuyCharacter(StoreIndex + 2);
                            Sound.PlaySFX1(0);
                        }
                    }
                }
                else if (point.X > Game.Pb.Width * 0.42760417)
                {
                    if (storeSize > 1)
                    {
                        if (Double)
                        {
                            if (Cart.Count < 2)
                                Cart.Add(StoreIndex + 1);
                            else
                                MessageBox.Show("Cart is full, buy or close the store");
                        }
                        else
                        {
                            b.BuyCharacter(StoreIndex + 1);
                            Sound.PlaySFX1(0);
                        }
                    }

                }
                else if (point.X > Game.Pb.Width * 0.2177083)
                {
                    if (storeSize > 0)
                    {
                        if (Double)
                        {
                            if (Cart.Count < 2)
                                Cart.Add(StoreIndex);
                            else
                                MessageBox.Show("Cart is full, buy or close the store");
                        }
                        else
                        {
                            b.BuyCharacter(StoreIndex);
                            Sound.PlaySFX1(0);
                        }
                    }
                }
                else if (point.X < Game.Pb.Width * 0.1822917)
                {
                    RightButton = 4;
                    if (StoreIndex > 0)
                        StoreIndex--;
                    else
                        StoreIndex = storeSize - 3;
                }
            }

            return inside;
        }

        internal static void ClickCheckAll(Point location, Structure OpenStore)
        {
            ClickCheck(location, Btn1, OpenStore);
            ClickCheck(location, Btn2, OpenStore);
            ClickCheck(location, Btn3, OpenStore);
            ClickCheck(location, Btn4, OpenStore);
            ClickCheck(location, Btn5, OpenStore);
            ClickCheck(location, Close, OpenStore);

            if (Double)
                ClickCheck(location, BuyCart, OpenStore);
        }
    }
}


//SQL
//lowcode
//html
//css
//devops
//mongoDB
//powerBI
//Angular
//github