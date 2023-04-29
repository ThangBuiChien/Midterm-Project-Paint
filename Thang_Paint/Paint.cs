using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thang_Paint.Action;
using Thang_Paint.Model;
using Thang_Paint.view;

namespace Thang_Paint
{
    public partial class Paint : Form, Thang_Paint.view.IVIew
    {
        private drawImp presenterDraw;
        private Graphics gr;
        private updateImp updateImp;
        private float zoomFactor = 1.0f; // the current zoom factor, initialized to 100%

        

        public Paint()
        {
            InitializeComponent();
            initComponents();
            gr = PLMain.CreateGraphics();

        }
        private void initComponents()
        {
            presenterDraw = new drawImp(this);
            //presenterAlter = new PresenterAlterImp(this);
            updateImp = new updateImp(this);
            updateImp.onClickSelectColor(Color.Black, gr);
            updateImp.onClickSelectSize(SBLineSize.Value + 1);
        }

        public void movingControlPoint(Shape shape, Point pointCurrent, Point previous, int indexPoint)
        {
            throw new NotImplementedException();
        }

        public void movingShape(Shape shape, Point distance)
        {
            shape.moveShape(distance);
            refreshDrawing();
        }

        public void refreshDrawing()
        {
            PLMain.Invalidate();
        }

        public void setColor(Color color)
        {
            PLMain.BackColor = color;
        }

        public void setColor(Button btn, Color color)
        {
            btn.BackColor = color;

        }

        public void setCursor(Cursor cursor)
        {
            PLMain.Cursor = cursor;
        }

        public void setDrawing(Shape shape, Graphics g)
        {
           g.ScaleTransform(zoomFactor, zoomFactor);
            shape.Draw(g);

        }

        public void setDrawingCurveSelected(List<Point> points, Brush brush, Graphics g)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                g.FillRectangle(brush, new System.Drawing.Rectangle(points[i].X - 4, points[i].Y - 4, 8, 8));
            }
        }

        public void setDrawingLineSelected(Shape shape, Brush brush, Graphics g)
        {
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.headPoint.X - 4, shape.headPoint.Y - 4, 8, 8));
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.tailPoint.X - 4, shape.tailPoint.Y - 4, 8, 8));
        }

            public void setDrawingRegionRectangle(Pen p, Rectangle rectangle, Graphics g)
        {
            g.DrawRectangle(p, rectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawRectangle();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseDown(e.Location);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           // lbLocation.Text = e.Location.X + ", " + e.Location.Y + "px";
            presenterDraw.onClickMouseMove(e.Location);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseUp();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            presenterDraw.getDrawing(e.Graphics);
        }

        private void SBLineSize_Scroll(object sender, ScrollEventArgs e)
        {
            updateImp.onClickSelectSize(SBLineSize.Value + 1);
        }

        private void Paint_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            updateImp.onClickSelectMode();
        }

        private void SBZoom_Scroll(object sender, ScrollEventArgs e)
        {
            // calculate the new zoom factor based on the scrollbar's value

            //zoomFactor = 1.0f + (e.NewValue - e.OldValue) / 10.0f;
            zoomFactor = 1.0f + (float)SBZoom.Value / 100.0f;
            updateImp.onClickSelectZoom(zoomFactor,gr);
            // force a repaint of the panel to update the graphics
            //   refreshDrawing();
           // PLMain.AutoScroll = true;
            //PLMain.Invalidate();
            




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            updateImp.onClickDeleteShape();
        }

       

        private void btnLine_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawLine();

        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawElipse();

        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawCircle();

        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPolygon();
        }

        private void PLMain_MouseClick(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickStopDrawing(e.Button);

        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawGroup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                updateImp.onClickSelectColor(colorDialog.Color, gr);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFilled_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            updateImp.onClickSelectFill(btn, gr);
        }
    }
}
