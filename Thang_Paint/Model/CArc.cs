using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Thang_Paint
{
    public class CArc : Model.Shape
    {
        public CArc()
        {
            name = "Arc";
        }

        public CArc(Color color)
        {
            name = "Arc";
            this.color = color;
        }

        public override GraphicsPath gpPath {


            get
            {
                GraphicsPath path = new GraphicsPath();
                int startAngle = (headPoint.Y > tailPoint.Y) ? 0 : 180;
                int sweepAngle = 180;

                Rectangle rect = new Rectangle(
                    Math.Min(headPoint.X, tailPoint.X),
                    Math.Min(headPoint.Y, tailPoint.Y),
                    Math.Abs(tailPoint.X - headPoint.X),
                    Math.Abs(tailPoint.Y - headPoint.Y)
                );
                if (rect.Height == 0) rect.Height = 1;
                if (rect.Width == 0) rect.Width = 1;
                path.AddArc(rect, startAngle, sweepAngle);


                return path;

            }

        }

       


        
    }
}