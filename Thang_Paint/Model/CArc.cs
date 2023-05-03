using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                    int startAngle = 0;
                    int sweepAngle = -180;

                    if (headPoint.Y > tailPoint.Y)
                    {
                        startAngle = 0;
                        sweepAngle = 180;
                    }
                    if (Math.Abs(tailPoint.Y - headPoint.Y) == 0 && Math.Abs(tailPoint.X - headPoint.X) == 0)
                    {
                        Rectangle rect = new Rectangle(
                         Math.Min(headPoint.X, tailPoint.X),
                         Math.Min(headPoint.Y, tailPoint.Y),
                         Math.Abs(tailPoint.X - headPoint.X + 10),
                         Math.Abs(tailPoint.Y - headPoint.Y + 10));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else if (Math.Abs(tailPoint.Y - headPoint.Y) == 0)
                    {
                        Rectangle rect = new Rectangle(
                         Math.Min(headPoint.X, tailPoint.X),
                         Math.Min(headPoint.Y, tailPoint.Y),
                         Math.Abs(tailPoint.X - headPoint.X),
                         Math.Abs(tailPoint.Y - headPoint.Y + 10));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else if (Math.Abs(tailPoint.X - headPoint.X) == 0)
                    {
                        Rectangle rect = new Rectangle(
                        Math.Min(headPoint.X, tailPoint.X),
                        Math.Min(headPoint.Y, tailPoint.Y),
                        Math.Abs(tailPoint.X - headPoint.X + 10),
                        Math.Abs(tailPoint.Y - headPoint.Y));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else
                    {
                        Rectangle rect = new Rectangle(
                          Math.Min(headPoint.X, tailPoint.X),
                          Math.Min(headPoint.Y, tailPoint.Y),
                          Math.Abs(tailPoint.X - headPoint.X),
                          Math.Abs(tailPoint.Y - headPoint.Y));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }

                    return path;
                }
            
        }

        public override object copy(Graphics gp)
        {
            return new CArc
            {
                headPoint = headPoint,
                tailPoint = tailPoint,
                contourWidth = contourWidth,
                isSelected = isSelected,
                color = color,
                dashStyle = dashStyle,
                name = name
            };
        }

        public override void Draw(Graphics gp)
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

        public override bool isHit(Point p)
        {
           bool inside = false;
            using (GraphicsPath path = gpPath)
            {
                if (!isFill)
                {
                    using (Pen pen = new Pen(this.color, this.contourWidth + 3))
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

        
    }
}