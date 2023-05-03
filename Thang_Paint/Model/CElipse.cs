using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;

using Thang_Paint.Model;
namespace Thang_Paint
{
    public class CElipse : cRectangle
    {
        public CElipse()
        {
            name = "Ellipse";
        }

        public CElipse(Color color)
        {
            name = "Ellipse";
            this.color = color;
        }

        public override GraphicsPath gpPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();

                // Define the center point and dimensions of the ellipse
                float centerX = (headPoint.X + tailPoint.X) / 2f;
                float centerY = (headPoint.Y + tailPoint.Y) / 2f;
                float width = Math.Abs(headPoint.X - tailPoint.X);
                float height = Math.Abs(headPoint.Y - tailPoint.Y);

                // Add the ellipse to the path
                RectangleF rect = new RectangleF(centerX - width / 2f, centerY - height / 2f, width, height);
                path.AddEllipse(rect);
                return path;
            }
        }


    }
}