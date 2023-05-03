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

        public override GraphicsPath gpPath
        {
            get
            {

                GraphicsPath path = new GraphicsPath();
                int rx2 = ((tailPoint.X - headPoint.X) + (tailPoint.Y - headPoint.Y)) / 2;
                path.AddEllipse(new Rectangle(headPoint.X, headPoint.Y, rx2, rx2));
                tailPoint = new Point(headPoint.X + rx2, headPoint.Y + rx2);
                return path;
            }
        }

    }
}