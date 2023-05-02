using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thang_Paint.Model;

namespace Thang_Paint.Action
{
    interface IDraw
    {
        void getDrawing(Graphics g);
        void currentMouseDown(Point p);
        void currentMouseMove(Point p);
        void currentMouseUp();
        void currentDrawLine();
        void currentDrawRectangle();
        void currentDrawElipse();
        void currentDrawCircle();
        void currentDrawPolygon();
        void currentStopDrawing(MouseButtons mouse);
        void currentDrawGroup();
        void currentStopDrawUnGroup();


        void drawRegionForShape(Shape shape, Graphics g);

    }
}
