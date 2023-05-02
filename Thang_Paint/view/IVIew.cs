using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Thang_Paint.Model;

namespace Thang_Paint.view
{
    
        interface IVIew
        {
            
            void refreshDrawing();  

           
            void setCursor(Cursor cursor);

           
            void setColor(Color color);

            
            void setColor(Button btn, Color color);

           
            void setDrawing(Shape shape, Graphics g);

            void setDrawingLineSelected(Shape shape, Brush brush, Graphics g);

            void setDrawingRegionRectangle(Pen p, Rectangle rectangle, Graphics g);

        
            void movingShape(Shape shape, Point distance);

      //  void setDrawingCurveSelected(List<Point> points, Brush brush, Graphics g);

    }

}
