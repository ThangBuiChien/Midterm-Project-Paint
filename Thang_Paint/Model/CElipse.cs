using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;

using Thang_Paint.Model;
namespace Thang_Paint
{
    public class CElipse : cRectangle
    {
        public CElipse()
        {
            name = "Ellipse";
        }

        public CElipse(Color color)
        {
            name = "Ellipse";
            this.color = color;
        }

        protected override GraphicsPath gpPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();

                

                if (tailPoint.X < headPoint.X && tailPoint.Y < headPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(tailPoint,
                        new Size(headPoint.X - tailPoint.X, headPoint.Y - tailPoint.Y)));
                }
                else if (headPoint.X > tailPoint.X && headPoint.Y < tailPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(new Point(tailPoint.X, headPoint.Y),
                        new Size(headPoint.X - tailPoint.X, tailPoint.Y - headPoint.Y)));
                }
                else if (headPoint.X < tailPoint.X && headPoint.Y > tailPoint.Y)
                {
                    path.AddEllipse(new System.Drawing.Rectangle(new Point(headPoint.X, tailPoint.Y),
                        new Size(tailPoint.X - headPoint.X, headPoint.Y - tailPoint.Y)));
                }
                else
                {
                    path.AddEllipse(new System.Drawing.Rectangle(headPoint,
                        new Size(tailPoint.X - headPoint.X, tailPoint.Y - headPoint.Y)));
                }

                return path;
            }
        }


    }
}