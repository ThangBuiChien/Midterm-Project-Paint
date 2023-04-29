using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thang_Paint.Model;

namespace Thang_Paint.Action
{
    interface IDraw
    {
        void getDrawing(Graphics g);
        void onClickMouseDown(Point p);
        void onClickMouseMove(Point p);
        void onClickMouseUp();
        void onClickDrawLine();
        void onClickDrawRectangle();
        void onClickDrawElipse();
        void onClickDrawCircle();

        void drawRegionForShape(Shape shape, Graphics g);

    }
}
