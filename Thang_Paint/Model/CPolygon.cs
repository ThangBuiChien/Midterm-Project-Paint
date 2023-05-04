using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Thang_Paint
{
    public class CPolygon : Model.Shape
    {
        public List<Point> points;

        public CPolygon()
        {
            name = "Polygon";
            points = new List<Point>();
        }

        public CPolygon(Color color)
        {
            name = "Polygon";
            this.color = color;
            points = new List<Point>();
        }

        public override GraphicsPath gpPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                if (points.Count < 3)
                {
                    path.AddLine(points[0], points[1]);
                }
                else
                {
                    path.AddPolygon(points.ToArray());
                }

                return path;
            }
        }

       //Draw function for Polygon

        public override void Draw(Graphics gp)
        {
            using (GraphicsPath path = gpPath)
            {
                if (!isFill)
                {
                    using (Pen pen = new Pen(color, contourWidth))
                    {
                        pen.DashStyle = dashStyle;
                        gp.DrawPath(pen, path);
                    }
                }
                else
                {
                    using (Brush b = new HatchBrush(brushStyle, Color.White, color))
                    {
                        if (points.Count < 3)
                        {
                            using (Pen pen = new Pen(color, contourWidth))
                            {
                                gp.DrawPath(pen, path);
                            }
                        }
                        else
                        {
                            gp.FillPath(b, path);
                        }
                    }
                }
            }
        }

        
        public override void moveShape(Point distance)
        {
            base.moveShape(distance);
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + distance.X, points[i].Y + distance.Y);
            }
        }

        public void findHeadTailPoint()
        {
            int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X < minX) minX = points[i].X;
                if (points[i].X > maxX) maxX = points[i].X;
                if (points[i].Y < minY) minY = points[i].Y;
                if (points[i].Y > maxY) maxY = points[i].Y;
            }

            headPoint = new Point(minX, minY);
            tailPoint = new Point(maxX, maxY);
        }

    }
}