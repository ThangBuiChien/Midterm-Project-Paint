using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thang_Paint.Model;

namespace Thang_Paint.Utils
{
    internal class TakeSpaceRegion
    {
            public static void setPointHeadTail(CGroupShape group)
            {
                int minX = int.MaxValue, minY = int.MaxValue;
                int maxX = int.MinValue, maxY = int.MinValue;

           


                for (int i = 0; i < group.Count; i++)
                {
                    Shape shape = group[i];
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
