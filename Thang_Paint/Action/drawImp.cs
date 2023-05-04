using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thang_Paint.Utils;
using Thang_Paint.view;
using Thang_Paint.Model;
using static System.Windows.Forms.LinkLabel;
using System.Drawing.Drawing2D;

namespace Thang_Paint.Action
{
    internal class drawImp : IDraw
    {
        IPaint viewPaint;

        data storeData;


        public drawImp(IPaint viewPaint)
        {
            this.viewPaint = viewPaint;
            storeData = data.getInstance();

        }

        public int Property
        {
            get => default;
            set
            {
            }
        }

        public void drawRegionForShape(Shape shape, Graphics g)
        {

            if (shape is CLine)
            {
                viewPaint.setDrawingLineSelected(shape, new SolidBrush(Color.DarkBlue), g);

            }
            else if (shape is CPolygon)
            {
                CPolygon polygon = (CPolygon)shape;
                for (int i = 0; i < polygon.points.Count; i++)
                {
                    viewPaint.setDrawingCurveSelected(polygon.points, new SolidBrush(Color.DarkBlue), g);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.DarkBlue, 1)
                {
                    DashPattern = new float[] { 3, 3, 3, 3 },
                    DashStyle = DashStyle.Custom
                })
                {
                    viewPaint.setDrawingRegionRectangle(pen, shape.getRectangle(shape.headPoint, shape.tailPoint), g);
                    /*viewPaint.setDrawingCurveSelected(TakeSpaceRegion.getControlPoints(shape),
                        new SolidBrush(Color.DarkBlue), g);*/
                }
            }
        }

        public void getDrawing(Graphics g)
        {
            storeData.shapeList.ForEach(shape =>
            {
                viewPaint.setDrawing(shape, g);
                if (shape.isSelected)
                {
                    drawRegionForShape(shape, g);
                }

            });
            if (storeData.isMovingMouse)
            {
                using (Pen pen = new Pen(Color.DarkBlue, 1)
                {
                    DashPattern = new float[] { 3, 3, 3, 3 },
                    DashStyle = DashStyle.Custom
                })
                {
                    viewPaint.setDrawingRegionRectangle(pen, storeData.rectangleRegion, g);
                }

            }
        }

        public void currentDrawRectangle()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Rectangle;
        }

        public void onClickDrawArc()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Arc;
        }
        public void currentDrawLine()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Line;

        }

        public void currentDrawElipse()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Ellipse ;
        }

        public void currentDrawCircle()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Circle;
        }
        public void currentDrawPolygon()
        {
            setDefaultToDraw();
            storeData.currentShape = CurrentShape.Polygon;

        }

        public void currentStopDrawing(MouseButtons mouse)
        {
            if (mouse == MouseButtons.Right)
            {
                if (storeData.currentShape.Equals(CurrentShape.Polygon))
                {
                    CPolygon polygon = storeData.shapeList[storeData.shapeList.Count - 1] as CPolygon;
                    polygon.points.Remove(polygon.points[polygon.points.Count - 1]);
                    storeData.isDrawingPolygon = false;
                   // FindRegion.setPointHeadTail(polygon);
                }
            }
        }
        public void currentDrawGroup()
        {
            if (storeData.shapeList.Count(shape => shape.isSelected) > 1)
            {
                CGroupShape group = new CGroupShape();
                for (int i = 0; i < storeData.shapeList.Count; i++)
                {
                    if (storeData.shapeList[i].isSelected)
                    {
                        group.addShape(storeData.shapeList[i]);
                        storeData.shapeList.RemoveAt(i--);
                    }
                }
                TakeSpaceRegion.setPointHeadTail(group);

                group.isSelected = true;
                storeData.shapeList.Add(group);
                viewPaint.refreshDrawing();
            }
        }
        public void currentStopDrawUnGroup()
        {
            if (storeData.shapeList.Find(shape => shape.isSelected) is CGroupShape)
            {
                CGroupShape group = (CGroupShape)storeData.shapeList.Find(shape => shape.isSelected);
                for(int i=0; i<group.Count; i++)
                {
                    storeData.shapeList.Add(group[i]);
                }
              
                storeData.shapeList.Remove(group);
            }   

                viewPaint.refreshDrawing();
        }

            public void currentMouseDown(Point p)
       {
            storeData.isNotNone = true;
            if (storeData.currentShape.Equals(CurrentShape.Void))
            { 
                storeData.offAllShapeSelected();
                viewPaint.refreshDrawing();
                handleClickToSelect(p);
            }
            else {

                handleClickToDraw(p);
            }
            
        }

        public void handleClickToSelect(Point p)
        {
            for (int i = 0; i < storeData.shapeList.Count; ++i)
            {
                
                if (storeData.shapeList[i].isHit(p))             //Cho hình đã chọn vô shape để di chuyển
                {
                    storeData.shapeToMove = storeData.shapeList[i];
                    storeData.shapeList[i].isSelected = true;
                    break;
                    
                }

            }

            
            if (storeData.shapeToMove != null)       //Nếu đúng là chức năng di chuyển thì dánh dấu rồi chuyển qua 
            {
                storeData.isMovingShape = true;
                storeData.cursorCurrent = p;
                viewPaint.setCursor(Cursors.Default);
                
                
            }
            else
            {
                storeData.isMovingMouse = true;                               
                storeData.rectangleRegion = new Rectangle(p, new Size(0, 0));
            }
        }



            public void currentMouseMove(Point p)
            {
            if (storeData.isMouseDown)
            {
                storeData.updatePointTail(p);
                viewPaint.refreshDrawing();
            }
            else if (storeData.isMovingShape)
            {
                viewPaint.movingShape(storeData.shapeToMove, storeData.distanceXY(storeData.cursorCurrent, p));
                storeData.cursorCurrent = p;
            }
            else if (storeData.currentShape.Equals(CurrentShape.Void))
            {
                if (storeData.isMovingMouse)
                {
                    storeData.updateRectangleRegion(p);
                    viewPaint.refreshDrawing();
                }
                else
                {

                    //TODO: Kiếm tra xem trong danh sách tồn tại hình nào chứa điểm p không
                    if (storeData.shapeList.Exists(shape => isInside(shape, p)))
                    {
                        viewPaint.setCursor(Cursors.SizeAll);
                    }
                    else
                    {
                        viewPaint.setCursor(Cursors.Default);
                    }

                }
            }
           

                if (storeData.isDrawingPolygon)
                {
                    CPolygon polygon = storeData.shapeList[storeData.shapeList.Count - 1] as CPolygon;
                    polygon.points[polygon.points.Count - 1] = p;
                    polygon.findHeadTailPoint();
                    viewPaint.refreshDrawing();
                }
            }

        public void currentMouseUp()
        {
            storeData.isMouseDown = false;
             if (storeData.isMovingShape)
            {
                storeData.isMovingShape = false;
                storeData.shapeToMove = null;
            }
            else if (storeData.isMovingMouse)
            {
                storeData.isMovingMouse = false;
                storeData.offAllShapeSelected();

                
                for (int i = 0; i < storeData.shapeList.Count; ++i)
                {
                    if (storeData.shapeList[i].isInRegion(storeData.rectangleRegion))
                    {
                        storeData.shapeList[i].isSelected = true;
                    }
                    
                }
                viewPaint.refreshDrawing();
            }

        }

        private bool isInside(Shape shape, Point p)
        {
            return shape.isHit(p);
        }
        private void handleClickToDraw(Point p)
        {
            storeData.isMouseDown = true;
            storeData.offAllShapeSelected();
            if (storeData.currentShape.Equals(CurrentShape.Rectangle))
            {
                storeData.addEntity(new cRectangle
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = storeData.lineSize,
                    color = storeData.colorCurrent,
                    dashStyle = storeData.dashStyleCurrent,
                    brushStyle = storeData.hatchStyleCurrent,
                    isFill = storeData.isFill
                });
            }
            else if (storeData.currentShape.Equals(CurrentShape.Line))
            {
                storeData.addEntity(new CLine
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = storeData.lineSize,
                    color = storeData.colorCurrent,
                    dashStyle = storeData.dashStyleCurrent,   
                    isFill = storeData.isFill
                });
            }
            else if (storeData.currentShape.Equals(CurrentShape.Ellipse))
            {
                storeData.addEntity(new CElipse
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = storeData.lineSize,
                    color = storeData.colorCurrent,
                    dashStyle = storeData.dashStyleCurrent,
                    brushStyle = storeData.hatchStyleCurrent,
                    isFill = storeData.isFill
                });
            }
            else if (storeData.currentShape.Equals(CurrentShape.Circle))
            {
                storeData.addEntity(new CCircle
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = storeData.lineSize,
                    color = storeData.colorCurrent,
                    dashStyle = storeData.dashStyleCurrent,
                    brushStyle = storeData.hatchStyleCurrent,
                    isFill = storeData.isFill
                });
            }
            else if (storeData.currentShape.Equals(CurrentShape.Arc))
            {
                storeData.addEntity(new CArc
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = storeData.lineSize,
                    color = storeData.colorCurrent,
                    dashStyle = storeData.dashStyleCurrent,
                    brushStyle = storeData.hatchStyleCurrent,
                    isFill = storeData.isFill
                });
            }
            else if (storeData.currentShape.Equals(CurrentShape.Polygon))
            {
                if (!storeData.isDrawingPolygon)
                {
                    storeData.isDrawingPolygon = true;
                    CPolygon polygon = new CPolygon
                    {
                        color = storeData.colorCurrent,
                        contourWidth = storeData.lineSize,
                        dashStyle = storeData.dashStyleCurrent,
                        brushStyle = storeData.hatchStyleCurrent,
                        isFill = storeData.isFill

                    };
                    polygon.points.Add(p);
                    polygon.points.Add(p);
                    storeData.shapeList.Add(polygon);
                }
                else
                {
                    CPolygon polygon = storeData.shapeList[storeData.shapeList.Count - 1] as CPolygon;
                    polygon.points[polygon.points.Count - 1] = p;
                    polygon.points.Add(p);
                }

                storeData.isMouseDown = false;
            }
           
        }
        private void setDefaultToDraw()
        {
            storeData.offAllShapeSelected();
            viewPaint.refreshDrawing();
            viewPaint.setCursor(Cursors.Default);
        }

       
    }
}
