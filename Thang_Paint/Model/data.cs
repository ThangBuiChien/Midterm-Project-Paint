using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using Thang_Paint.Utils;

namespace Thang_Paint.Model
{
    public class data
    {
       


        public static data instance;

        public List<Shape> shapeList { get; set; }

        public Shape shapeToMove { get; set; }

        public System.Drawing.Rectangle rectangleRegion;

        public bool isMouseDown { get; set; }

        public bool isMovingShape { get; set; }

        public bool isMovingMouse { get; set; }

        public bool isDrawingCurve { get; set; }

        //hình nào
        public CurrentShape currentShape { get; set; }

        public bool isDrawingPolygon { get; set; }

      

        public bool isFill { get; set; }


        public bool isNotNone { get; set; }

        public bool isSelectAll { get; set; }

        public int pointToResize { get; set; }

        

        public Point cursorCurrent { get; set; }

        public Color colorCurrent { get; set; }

        public DashStyle dashStyleCurrent { get; set; }

        public HatchStyle hatchStyleCurrent { get; set; }

        public int lineSize { get; set; }


        private data()
        {
            shapeList = new List<Shape>();
            pointToResize = -1;
        }

        public static data getInstance()
        { 
            if (instance == null) instance = new data();
            return instance;
        }

        
        public void updatePointTail(Point p)
        {
            shapeList[shapeList.Count - 1].tailPoint = p;
        }

       
        public void addEntity(Shape shape)
        {
            shapeList.Add(shape);
        }

        
        public void offAllShapeSelected()
        {
            shapeList.ForEach(shape => shape.isSelected = false);
        }

       
        public Point distanceXY(Point x, Point y)
        {
            return new Point(y.X - x.X, y.Y - x.Y);
        }

        
        public void updateRectangleRegion(Point p)
        {
            rectangleRegion.Width = p.X - rectangleRegion.X;
            rectangleRegion.Height = p.Y - rectangleRegion.Y;
        }

       
    }

}
