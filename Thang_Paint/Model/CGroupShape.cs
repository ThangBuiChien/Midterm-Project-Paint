﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Thang_Paint.Model;
using static System.Windows.Forms.LinkLabel;

namespace Thang_Paint
{
    public class CGroupShape : Shape
    {
        private List<Shape> shapes;

        public CGroupShape()
        {
            name = "Group";
            shapes = new List<Shape>();

        }

        public Shape this[int index]
        {
            get
            {
                return shapes[index];
            }
            set
            {
                shapes[index] = value;
            }
        }

        protected override GraphicsPath gpPath => throw new NotImplementedException();

        private GraphicsPath[] graphicsPaths
        {
            get
            {
                GraphicsPath[] paths = new GraphicsPath[shapes.Count];

                for (int i = 0; i < shapes.Count; i++)
                {
                    GraphicsPath path = new GraphicsPath();
                    if (shapes[i] is CLine)
                    {
                        CLine line = (CLine)shapes[i];
                        path.AddLine(line.headPoint, line.tailPoint);
                    }

                    else if (shapes[i] is CElipse)
                    {
                        CElipse ellipse = (CElipse)shapes[i];
                        path.AddEllipse(new Rectangle(ellipse.headPoint.X,
                            ellipse.headPoint.Y,
                            ellipse.tailPoint.X - ellipse.headPoint.X,
                            ellipse.tailPoint.Y - ellipse.headPoint.Y));
                    }
                    else if (shapes[i] is cRectangle)
                    {
                        cRectangle rect = (cRectangle)shapes[i];

                        path.AddRectangle(new RectangleF(rect.headPoint.X,
                            rect.headPoint.Y,
                            rect.tailPoint.X - rect.headPoint.X,
                            rect.tailPoint.Y - rect.headPoint.Y));
                    }
                    else if (shapes[i] is CPolygon)
                    {
                        CPolygon polygon = (CPolygon)shapes[i];
                        path.AddPolygon(polygon.points.ToArray());
                    }
                    else if (shapes[i] is CGroupShape)
                    {
                        CGroupShape group = (CGroupShape)shapes[i];
                        for (int j = 0; j < group.graphicsPaths.Length; j++)
                        {
                            path.AddPath(group.graphicsPaths[j], false);
                        }
                    }
                    paths[i] = path;
                }

                return paths;
            }
        }

        public override object copy(Graphics gp)
        {
            CGroupShape group = new CGroupShape
            {
                headPoint = headPoint,
                tailPoint = tailPoint,
                isSelected = isSelected,
                name = name,
                color = color,
                contourWidth = contourWidth
            };
            for (int i = 0; i < shapes.Count; i++)
            {
                group.shapes.Add(shapes[i].copy(gp) as Shape);
            }
            return group;
        }
        
        public override void Draw(Graphics gp)
        {
            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i] is cRectangle || shapes[i] is CElipse || shapes[i] is CPolygon)
                    {
                        if (shapes[i].isFill)
                        {
                            using (Brush brush = new SolidBrush(shapes[i].color))
                            {
                                gp.FillPath(brush, path);
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(shapes[i].color, shapes[i].contourWidth))
                            {
                                gp.DrawPath(pen, path);
                            }
                        }
                    }
                    else if (shapes[i] is CGroupShape)
                    {
                        CGroupShape group = (CGroupShape)shapes[i];
                        group.Draw(gp);
                    }
                    else
                    {
                        using (Pen pen = new Pen(shapes[i].color, shapes[i].contourWidth))
                        {
                            gp.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        public override bool isHit(Point p)
        {
            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i] is cRectangle || shapes[i] is CElipse)
                    {
                        if (((cRectangle)shapes[i]).isFill)
                        {
                            using (Brush brush = new SolidBrush(Color.Black))
                            {
                                if (path.IsVisible(p))
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(Color.Black, contourWidth + 3))
                            {
                                if (path.IsOutlineVisible(p, pen))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else if (!(shapes[i] is CGroupShape))
                    {
                        using (Pen pen = new Pen(Color.Black, contourWidth + 3))
                        {
                            if (path.IsOutlineVisible(p, pen))
                            {
                                return true;
                            }
                        }
                    }
                    else if (shapes[i] is CGroupShape)
                    {
                        CGroupShape group = (CGroupShape)shapes[i];
                        return group.isHit(p);
                    }
                }
            }
            return false;
        }
        public void addShape(Shape shape)
        {
            shapes.Add(shape);
        }
        public int Count
        {
            get
            {
                return shapes.Count;
            }
        }
        public override void moveShape(Point distance)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i] is CGroupShape)
                {
                    CGroupShape group = (CGroupShape)shapes[i];
                    group.moveShape(distance);
                }
                else
                {
                    shapes[i].moveShape(distance);
                }
            }
            base.moveShape(distance);
        }

        public static void setPointHeadTail(CGroupShape group)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;




            for (int i = 0; i < group.Count; i++)
            {
                Shape shape = group[i];

                /*if (shape.headPoint.X < minX) minX = shape.headPoint.X;
                if (shape.headPoint.Y < maxX) minY = shape.headPoint.Y;
                if (shape.tailPoint.X > minX) minY = shape.tailPoint.X;
                if (shape.tailPoint.Y > maxY) maxY = shape.tailPoint.Y;*/

                if (shape.headPoint.X < minX) minX = shape.headPoint.X;
                if (shape.tailPoint.X < minX) minX = shape.tailPoint.X;
                if (shape.headPoint.Y < minY) minY = shape.headPoint.Y;
                if (shape.tailPoint.Y < minY) minY = shape.tailPoint.Y;
                if (shape.headPoint.X > maxX) maxX = shape.headPoint.X;
                if (shape.tailPoint.X > maxX) maxX = shape.tailPoint.X;
                if (shape.headPoint.Y > maxY) maxY = shape.headPoint.Y;
                if (shape.tailPoint.Y > maxY) maxY = shape.tailPoint.Y;
            }
            group.headPoint = new Point(minX, minY);
            group.tailPoint = new Point(maxX, maxY);
        }
    }
}