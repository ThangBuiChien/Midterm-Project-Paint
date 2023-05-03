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



        public override GraphicsPath gpPath {
            get
            {
                GraphicsPath path = new GraphicsPath();

                // Define the coordinates of the rectangle corners
                float x1 = Math.Min(headPoint.X, tailPoint.X);
                float y1 = Math.Min(headPoint.Y, tailPoint.Y);
                float x2 = Math.Max(headPoint.X, tailPoint.X);
                float y2 = Math.Max(headPoint.Y, tailPoint.Y);

                RectangleF rect = new RectangleF(x1, y1, x2 - x1, y2 - y1);
                path.AddRectangle(rect);

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
                dashStyle = dashStyle,
                brushStyle = brushStyle,
                name = name
            };
        }

        public override void Draw(Graphics gp)
        {
            using(GraphicsPath path = gpPath)
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