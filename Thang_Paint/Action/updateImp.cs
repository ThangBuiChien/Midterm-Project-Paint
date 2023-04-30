using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thang_Paint.Model;
using Thang_Paint.Utils;
using Thang_Paint.view;

namespace Thang_Paint.Action
{
    internal class updateImp : IUpdate
    {
        IVIew viewPaint;

        data dataManager;

        public updateImp(IVIew viewPaint)
        {
            this.viewPaint = viewPaint;
            dataManager = data.getInstance();
            
        }

        public void onClickSelectMode()
        {
            dataManager.offAllShapeSelected();
            viewPaint.refreshDrawing();
            dataManager.currentShape = CurrentShapeStatus.Void;
            viewPaint.setCursor(Cursors.Default);
        }

        public void onClickSelectColor(System.Drawing.Color color, Graphics g)
        {
            dataManager.colorCurrent = color;
           // viewPaint.setColor(color);
            foreach (Shape item in dataManager.shapeList)
            {
                if (item.isSelected)
                {
                    item.color = color;
                    viewPaint.setDrawing(item, g);
                }
            }
        }

        public void onClickSelectSize(int size)
        {
            dataManager.lineSize = size;
        }

        public void onClickSelectFill(Button btn, Graphics g)
        {
            dataManager.isFill = !dataManager.isFill;
            if (btn.BackColor.Equals(Color.LightCyan))
                viewPaint.setColor(btn, SystemColors.Control);
            else
                viewPaint.setColor(btn, Color.LightCyan);
        }

        public void onClickSelectZoom(float zoomFactor, Graphics g)
        {
            //dataManager.offAllShapeSelected();
            g.ScaleTransform(zoomFactor, zoomFactor);
            g.ResetTransform();
            viewPaint.refreshDrawing();



        }
        public void onClickDeleteShape()
        {
            for (int i = 0; i < dataManager.shapeList.Count; i++)
            {
                if (dataManager.shapeList[i].isSelected)
                {
                    dataManager.shapeList.RemoveAt(i--);
                }
            }
            viewPaint.refreshDrawing();
        }

        public void onClickSelectDashStyle(DashStyle dashStyle, Graphics g)
        {
            dataManager.dashStyleCurrent = dashStyle;
            foreach (Shape item in dataManager.shapeList)
            {
                if (item.isSelected)
                {
                    item.dashStyle = dashStyle;
                    viewPaint.setDrawing(item, g);

                }
            }
            viewPaint.refreshDrawing();

        }

        public void onClickSelectBrushStyle(HatchStyle hatchStyle, Graphics g)
        {
            dataManager.hatchStyleCurrent = hatchStyle;
            foreach (Shape item in dataManager.shapeList)
            {
                if (item.isSelected)
                {
                    item.brushStyle = hatchStyle;
                    viewPaint.setDrawing(item, g);

                }
            }
            viewPaint.refreshDrawing();

        }

        public void onClickSelectPen(Graphics g)
        {
            dataManager.isFill = false;
        }
    }
}
