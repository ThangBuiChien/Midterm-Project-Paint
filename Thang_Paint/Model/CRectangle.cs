using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Thang_Paint.Model
{
    public class cRectangle : Shape
    {
        public cRectangle()
        {
            name = "Rectagle";
        }

        public cRectangle(Color color)
        {
            name = "Rectagle";
            this.color = color;
        }



        protected override GraphicsPath gpPath {
            get
            {
                GraphicsPath path = new GraphicsPath();

                if (tailPoint.X < headPoint.X && tailPoint.Y < headPoint.Y)
                {
                    path.AddRectangle(new System.Drawing.Rectangle(tailPoint,
                        new Size(headPoint.X - tailPoint.X, headPoint.Y - tailPoint.Y)));
                }
                else if (headPoint.X > tailPoint.X && headPoint.Y < tailPoint.Y)
                {
                    path.AddRectangle(new System.Drawing.Rectangle(new Point(tailPoint.X, headPoint.Y),
                        new Size(headPoint.X - tailPoint.X, tailPoint.Y - headPoint.Y)));
                }
                else if (headPoint.X < tailPoint.X && headPoint.Y > tailPoint.Y)
                {
                    path.AddRectangle(new System.Drawing.Rectangle(new Point(headPoint.X, tailPoint.Y),
                        new Size(tailPoint.X - headPoint.X, headPoint.Y - tailPoint.Y)));
                }
                else
                {
                    path.AddRectangle(new System.Drawing.Rectangle(headPoint,
                        new Size(tailPoint.X - headPoint.X, tailPoint.Y - headPoint.Y)));
                }

                return path;
            }
        }

        public override object copy(Graphics gp)
        {
            return new cRectangle
            {
                headPoint = headPoint,
                tailPoint = tailPoint,
                contourWidth = contourWidth,
                isSelected = isSelected,
                color = color,
                name = name
            };
        }

        public override void Draw(Graphics gp)
        {
            using(GraphicsPath path = gpPath)
            {
                if (isFill)
                {
                    using (Brush b = new SolidBrush(color))
                    {
                        gp.FillPath(b, path);
                    }
                }
                else
                {
                    using (Pen p = new Pen(color, contourWidth))
                    {
                        gp.DrawPath(p, path);
                    }
                }
            }
        }

        public override bool isHit(Point p)
        {

            bool inside = false;
            using (GraphicsPath path = gpPath)
            {
                if (isFill)
                {
                    inside = path.IsVisible(p);
                }
                else
                {
                    using (Pen pen = new Pen(color, contourWidth + 3))
                    {
                        inside = path.IsOutlineVisible(p, pen);
                    }
                }
            }

            return inside;
        }
    }
}