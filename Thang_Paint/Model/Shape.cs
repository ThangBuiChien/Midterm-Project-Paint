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

namespace Thang_Paint.Model
{

    public abstract class Shape
    {

        public Point headPoint

        { get; set; }


        public Point tailPoint { get; set; }


        public abstract GraphicsPath gpPath { get; }


        public Color color { get; set; }

        public DashStyle dashStyle { get; set; }    

        public HatchStyle brushStyle { get; set; }


        public int contourWidth { get; set; }


        public string name { get; set; }


        public bool isFill { get; set; }


        public bool isSelected { get; set; }


        public virtual void Draw(Graphics gp)
        {
            using (GraphicsPath path = gpPath)
            {
                if (isFill)
                {
                    using (Brush b = new HatchBrush(brushStyle, Color.White, color))
                    {
                        gp.FillPath(b, path);
                    }
                }
                else
                {
                    using (Pen p = new Pen(color, contourWidth))
                    {
                        p.DashStyle = dashStyle;
                        gp.DrawPath(p, path);
                    }
                }
            }
        }

        public virtual bool isHit(Point p)
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


        public virtual void moveShape(Point distance)
        {
            headPoint = new Point(headPoint.X + distance.X, headPoint.Y + distance.Y);
            tailPoint = new Point(tailPoint.X + distance.X, tailPoint.Y + distance.Y);
        }
        public virtual bool isInRegion(Rectangle rectangle)
        {
            return headPoint.X >= rectangle.X &&
                tailPoint.X <= rectangle.X + rectangle.Width &&
                headPoint.Y >= rectangle.Y &&
                tailPoint.Y <= rectangle.Y + rectangle.Height;
        }
        public virtual Rectangle getRectangle()
        {
            return new Rectangle(headPoint.X,
                headPoint.Y,
                tailPoint.X - headPoint.X,
                tailPoint.Y - headPoint.Y);
        }

        public Rectangle getRectangle(Point a, Point b)
        {
            if (a.X > b.X)
            {
                int temp = a.X;
                a.X = b.X;
                b.X = temp;
            }
            if (a.Y > b.Y)
            {
                int temp = a.Y;
                a.Y = b.Y;
                b.Y = temp;
            }
            return new Rectangle(a.X, a.Y, b.X - a.X, b.Y - a.Y);
        }
       

    }
}