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


        protected abstract GraphicsPath gpPath { get; }


        public Color color { get; set; }

        public DashStyle dashStyle { get; set; }    

        public HatchStyle brushStyle { get; set; }


        public int contourWidth { get; set; }


        public string name { get; set; }


        public bool isFill { get; set; }


        public bool isSelected { get; set; }


        public abstract void Draw(Graphics gp);
        public abstract bool isHit(Point p);


        public abstract object copy(Graphics gp);

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
        public Rectangle getRectangle()
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
        public virtual void changePoint(int index)
        {
            if (index == 0 || index == 1 || index == 3)
            {
                Point point = headPoint;
                headPoint = tailPoint;
                tailPoint = point;
            }
            if (index == 2)
            {
                int a = tailPoint.X;
                int b = headPoint.Y;
                headPoint = new Point(headPoint.X, tailPoint.Y);
                tailPoint = new Point(a, b);
            }
            if (index == 5)
            {
                int a = headPoint.X;
                int b = tailPoint.Y;
                headPoint = new Point(tailPoint.X, headPoint.Y);
                tailPoint = new Point(a, b);
            }
        }

    }
}