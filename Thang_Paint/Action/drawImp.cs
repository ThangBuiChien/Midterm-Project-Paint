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
        IVIew viewPaint;

        data dataManager;


        public drawImp(IVIew viewPaint)
        {
            this.viewPaint = viewPaint;
            dataManager = data.getInstance();

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
            dataManager.shapeList.ForEach(shape =>
            {
                viewPaint.setDrawing(shape, g);
                if (shape.isSelected)
                {
                    drawRegionForShape(shape, g);
                }

            });
            if (dataManager.isMovingMouse)
            {
                using (Pen pen = new Pen(Color.DarkBlue, 1)
                {
                    DashPattern = new float[] { 3, 3, 3, 3 },
                    DashStyle = DashStyle.Custom
                })
                {
                    viewPaint.setDrawingRegionRectangle(pen, dataManager.rectangleRegion, g);
                }

            }
        }

        public void onClickDrawRectangle()
        {
            setDefaultToDraw();
            dataManager.currentShape = CurrentShapeStatus.Rectangle;
        }
        public void onClickDrawLine()
        {
            setDefaultToDraw();
            dataManager.currentShape = CurrentShapeStatus.Line;

        }

        public void onClickDrawElipse()
        {
            setDefaultToDraw();
            dataManager.currentShape = CurrentShapeStatus.Ellipse ;
        }

        public void onClickDrawCircle()
        {
            setDefaultToDraw();
            dataManager.currentShape = CurrentShapeStatus.Circle;
        }
        public void onClickDrawPolygon()
        {
            setDefaultToDraw();
            dataManager.currentShape = CurrentShapeStatus.Polygon;

        }

        public void onClickStopDrawing(MouseButtons mouse)
        {
            if (mouse == MouseButtons.Right)
            {
                if (dataManager.currentShape.Equals(CurrentShapeStatus.Polygon))
                {
                    CPolygon polygon = dataManager.shapeList[dataManager.shapeList.Count - 1] as CPolygon;
                    polygon.points.Remove(polygon.points[polygon.points.Count - 1]);
                    dataManager.isDrawingPolygon = false;
                   // FindRegion.setPointHeadTail(polygon);
                }
            }
        }
        public void onClickDrawGroup()
        {
            dataManager.offAllShapeSelected();
            //TODO: tìm ra những hình được chọn, đếm số lượng lớn hơn 1 thì nhóm lại với nhau
            if (dataManager.shapeList.Count(shape => shape.isSelected) > 1)
            {
                CGroupShape group = new CGroupShape();
                for (int i = 0; i < dataManager.shapeList.Count; i++)
                {
                    if (dataManager.shapeList[i].isSelected)
                    {
                        group.addShape(dataManager.shapeList[i]);
                        dataManager.shapeList.RemoveAt(i--);
                    }
                }
                TakeSpaceRegion.setPointHeadTail(group);
                group.isSelected = true;
                dataManager.shapeList.Add(group);
                viewPaint.refreshDrawing();
            }
        }

            public void onClickMouseDown(Point p)
       {
            dataManager.isSave = false;
            dataManager.isNotNone = true;
            if (dataManager.currentShape.Equals(CurrentShapeStatus.Void))
            {
                /*if (!(Control.ModifierKeys == Keys.Control))
                    dataManager.offAllShapeSelected();*/

                dataManager.offAllShapeSelected();
                viewPaint.refreshDrawing();
                handleClickToSelect(p);
            }
            else {

                handleClickToDraw(p);
            }
            
        }

        public void handleClickToSelect(Point p)
        {
            for (int i = 0; i < dataManager.shapeList.Count; ++i)
            {
                if (dataManager.pointToResize != -1)
                {
                    dataManager.shapeList[i].changePoint(dataManager.pointToResize);
                    dataManager.shapeToMove = dataManager.shapeList[i];
                    break;
                }
                else if (dataManager.shapeList[i].isHit(p))             //Cho hình đã chọn vô shape để di chuyển
                {
                    dataManager.shapeToMove = dataManager.shapeList[i];
                    dataManager.shapeList[i].isSelected = true;
                    break;
                    
                }

            }

            if (dataManager.pointToResize != -1)
            {
                dataManager.cursorCurrent = p;
            }
            else if (dataManager.shapeToMove != null)       //Nếu đúng là chức năng di chuyển thì dánh dấu rồi chuyển qua 
            {
                dataManager.isMovingShape = true;
                dataManager.cursorCurrent = p;
                viewPaint.setCursor(Cursors.Default);
                
                
            }
            else
            {
                dataManager.isMovingMouse = true;                               
                dataManager.rectangleRegion = new Rectangle(p, new Size(0, 0));
            }
        }



            public void onClickMouseMove(Point p)
            {
            if (dataManager.isMouseDown)
            {
                dataManager.updatePointTail(p);
                viewPaint.refreshDrawing();
            }
            else if (dataManager.isMovingShape)
            {
                viewPaint.movingShape(dataManager.shapeToMove, dataManager.distanceXY(dataManager.cursorCurrent, p));
                dataManager.cursorCurrent = p;
            }
            else if (dataManager.currentShape.Equals(CurrentShapeStatus.Void))
            {
                if (dataManager.isMovingMouse)
                {
                    dataManager.updateRectangleRegion(p);
                    viewPaint.refreshDrawing();
                }
                else
                {

                    //TODO: Kiếm tra xem trong danh sách tồn tại hình nào chứa điểm p không
                    if (dataManager.shapeList.Exists(shape => isInside(shape, p)))
                    {
                        viewPaint.setCursor(Cursors.SizeAll);
                    }
                    else
                    {
                        viewPaint.setCursor(Cursors.Default);
                    }

                }
            }
           

                if (dataManager.isDrawingPolygon)
                {
                    CPolygon polygon = dataManager.shapeList[dataManager.shapeList.Count - 1] as CPolygon;
                    polygon.points[polygon.points.Count - 1] = p;
                    polygon.findHeadTailPoint();
                    viewPaint.refreshDrawing();
                }
            }

        public void onClickMouseUp()
        {
            dataManager.isMouseDown = false;
             if (dataManager.isMovingShape)
            {
                dataManager.isMovingShape = false;
                dataManager.shapeToMove = null;
            }
            else if (dataManager.isMovingMouse)
            {
                dataManager.isMovingMouse = false;
                dataManager.offAllShapeSelected();

                //TODO: kiểm tra khi kéo chuột chọn một vùng thì có hình nào tồn tại bên
                //trong hay là không, nếu có thì hình đó được chọn
                for (int i = 0; i < dataManager.shapeList.Count; ++i)
                {
                    if (dataManager.shapeList[i].isInRegion(dataManager.rectangleRegion))
                    {
                        dataManager.shapeList[i].isSelected = true;
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
            dataManager.isMouseDown = true;
            dataManager.offAllShapeSelected();
            if (dataManager.currentShape.Equals(CurrentShapeStatus.Rectangle))
            {
                dataManager.addEntity(new cRectangle
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = dataManager.lineSize,
                    color = dataManager.colorCurrent,
                    dashStyle = dataManager.dashStyleCurrent,
                    brushStyle = dataManager.hatchStyleCurrent,
                    isFill = dataManager.isFill
                });
            }
            else if (dataManager.currentShape.Equals(CurrentShapeStatus.Line))
            {
                dataManager.addEntity(new CLine
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = dataManager.lineSize,
                    color = dataManager.colorCurrent,
                    dashStyle = dataManager.dashStyleCurrent,   
                    isFill = dataManager.isFill
                });
            }
            else if (dataManager.currentShape.Equals(CurrentShapeStatus.Ellipse))
            {
                dataManager.addEntity(new CElipse
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = dataManager.lineSize,
                    color = dataManager.colorCurrent,
                    dashStyle = dataManager.dashStyleCurrent,
                    brushStyle = dataManager.hatchStyleCurrent,
                    isFill = dataManager.isFill
                });
            }
            else if (dataManager.currentShape.Equals(CurrentShapeStatus.Circle))
            {
                dataManager.addEntity(new CCircle
                {
                    headPoint = p,
                    tailPoint = p,
                    contourWidth = dataManager.lineSize,
                    color = dataManager.colorCurrent,
                    dashStyle = dataManager.dashStyleCurrent,
                    brushStyle = dataManager.hatchStyleCurrent,
                    isFill = dataManager.isFill
                });
            }
            else if (dataManager.currentShape.Equals(CurrentShapeStatus.Polygon))
            {
                if (!dataManager.isDrawingPolygon)
                {
                    dataManager.isDrawingPolygon = true;
                    CPolygon polygon = new CPolygon
                    {
                        color = dataManager.colorCurrent,
                        contourWidth = dataManager.lineSize,
                        dashStyle = dataManager.dashStyleCurrent,
                        brushStyle = dataManager.hatchStyleCurrent,
                        isFill = dataManager.isFill

                    };
                    polygon.points.Add(p);
                    polygon.points.Add(p);
                    dataManager.shapeList.Add(polygon);
                }
                else
                {
                    CPolygon polygon = dataManager.shapeList[dataManager.shapeList.Count - 1] as CPolygon;
                    polygon.points[polygon.points.Count - 1] = p;
                    polygon.points.Add(p);
                }

                dataManager.isMouseDown = false;
            }
           
        }
        private void setDefaultToDraw()
        {
            dataManager.offAllShapeSelected();
            viewPaint.refreshDrawing();
            viewPaint.setCursor(Cursors.Default);
        }

       
    }
}
