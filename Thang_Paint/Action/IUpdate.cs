using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thang_Paint.Action
{
    internal interface IUpdate
    {

        void changeMode();

       
        void changeColor(Color color, Graphics g);

       
        void changeSize(int size, Graphics g);

        void changeDashStyle(DashStyle dashStyle, Graphics g);

       
        void changeFill(Button btn, Graphics g);

        void changePen(Graphics g);


        void changeZoom(float zoomFactor, Graphics g);
         void deleteShape();

    }
}
