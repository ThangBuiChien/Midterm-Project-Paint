﻿using System;
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

        protected override GraphicsPath gpPath
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

        public override object copy(Graphics gp)
        {
            CPolygon polygon = new CPolygon
            {
                headPoint = headPoint,
                tailPoint = tailPoint,
                isSelected = isSelected,
                name = name,
                color = color,
                contourWidth = contourWidth,
                dashStyle = dashStyle,
                brushStyle = brushStyle,
                isFill = isFill
            };
            points.ForEach(point => polygon.points.Add(point));
            return polygon;
        }

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

        public override bool isHit(Point p)
        {

            bool inside = false;
            using (GraphicsPath path = gpPath)
            {
                if (!isFill)
                {
                    using (Pen pen = new Pen(color, contourWidth + 3))
                    {
                        inside = path.IsOutlineVisible(p, pen);
                    }
                }
                else
                {
                    inside = path.IsVisible(p);
                }
            }
            return inside;
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
            Point tempHead = points[0];
            Point tempTail= points[0];
            for (int i = 1; i < points.Count; i++)
            {
                if(tempHead.X < points[i].X && tempHead.Y < points[i].Y)
                {
                    tempHead = points[i];   
                }
                else if (tempHead.X > points[i].X && tempHead.Y > points[i].Y)
                {
                    tempTail = points[i];
                }
            }

            headPoint = tempHead;
            tailPoint = tempTail;
        }

    }
}