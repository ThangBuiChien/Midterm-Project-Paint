using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Thang_Paint
{
    public class CCircle : CElipse
    {
        public CCircle()
        {
            name = "Circle";
        }

        public CCircle(Color color)
        {
            name = "Circle";
            this.color = color;
        }

        protected override GraphicsPath gpPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                double radius = Math.Round(Math.Sqrt(Math.Pow((headPoint.X - tailPoint.X), 2)
                    + Math.Pow((headPoint.Y - tailPoint.Y), 2)), 1);

                if (tailPoint.X < headPoint.X && tailPoint.Y < headPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(tailPoint,
                        new Size((int)radius, (int)radius)));

                }

                else if (headPoint.X > tailPoint.X && headPoint.Y < tailPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(new Point(tailPoint.X, headPoint.Y),
                        new Size((int)radius, (int)radius)));
                }
                else if (headPoint.X < tailPoint.X && headPoint.Y > tailPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(new Point(headPoint.X, tailPoint.Y),
                        new Size((int)radius, (int)radius)));
                }
                else
                {
                    path.AddEllipse(new System.Drawing.Rectangle(headPoint,
                        new Size((int)radius, (int)radius)));
                }
                return path;
            }
        }

    }
}