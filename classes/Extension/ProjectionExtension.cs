using System.Drawing;
using System.Linq;
using System;

namespace Extension
{
    public static class ProjectionExtension
    {
        public static PointF[] ToIsometric(this PointF[] pts, float x, float y)
        {
            return pts
                .Select(p => new PointF(MathF.Sqrt(2) / 2 * (p.X - p.Y) + x, -1 / MathF.Sqrt(6) * (p.X + p.Y) + y))
                .ToArray();
        }
    }
}