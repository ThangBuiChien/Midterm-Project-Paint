using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Thang_Paint.Model;
using static System.Windows.Forms.LinkLabel;

namespace Thang_Paint
{
    public class CLine : Shape
    {
        public CLine()
        {
            name = "Line";
        }

        public CLine(Color color)
        {
            name = "Line";
            this.color = color;
        }
        public override GraphicsPath gpPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(headPoint, tailPoint);
                return path;
            }
        }

        public override object copy(Graphics gp)
        {
            return new CLine
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
                using (Pen pen = new Pen(color, contourWidth))
                {
                    pen.DashStyle = dashStyle;
                    gp.DrawPath(pen, path);
                }
            }
        }

        public override bool isHit(Point p)
        {
            bool inside = false;
            using (GraphicsPath path = gpPath)
            {
                using (Pen pen = new Pen(color, contourWidth + 3))
                {
                    inside = path.IsOutlineVisible(p, pen);
                }
            }
            return inside;
        }
    }
}