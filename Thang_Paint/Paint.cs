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
using Thang_Paint.tools;
using Thang_Paint.view;

namespace Thang_Paint
{
    public partial class Paint : Form, Thang_Paint.view.IVIew
    {
        private drawImp drawImp;
        private Graphics gr;
        private updateImp updateImp;
        private float zoomFactor = 1.0f; // the current zoom factor, initialized to 100%

        

        public Paint()
        {
            InitializeComponent();
            initComponents();
            this.PLMain.setDoubleBuffered();
            gr = PLMain.CreateGraphics();
           

        }
        private void initComponents()
        {
            drawImp = new drawImp(this);
            //presenterAlter = new PresenterAlterImp(this);
            updateImp = new updateImp(this);
            updateImp.changeColor(Color.Black, gr);
            updateImp.changeDashStyle(DashStyle.Solid, gr);
            updateImp.changeBrushStyle(HatchStyle.Horizontal, gr);
            updateImp.changeSize(2, gr);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Paint_KeyDown);

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
            drawImp.currentDrawRectangle();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawImp.currentMouseDown(e.Location);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           // lbLocation.Text = e.Location.X + ", " + e.Location.Y + "px";
            drawImp.currentMouseMove(e.Location);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drawImp.currentMouseUp();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            drawImp.getDrawing(e.Graphics);
        }

        private void SBLineSize_Scroll(object sender, ScrollEventArgs e)
        {
            updateImp.changeSize(SBLineSize.Value , gr);
        }

        private void Paint_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            updateImp.selectMode();
        }

        private void SBZoom_Scroll(object sender, ScrollEventArgs e)
        {
            // calculate the new zoom factor based on the scrollbar's value

            //zoomFactor = 1.0f + (e.NewValue - e.OldValue) / 10.0f;
            zoomFactor = 1.0f + (float)SBZoom.Value / 100.0f;
            updateImp.changeZoom(zoomFactor,gr);
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
            updateImp.deleteShape();
        }

       

        private void btnLine_Click(object sender, EventArgs e)
        {
            drawImp.currentDrawLine();

        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            drawImp.currentDrawElipse();

        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            drawImp.currentDrawCircle();

        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            drawImp.currentDrawPolygon();
        }

        private void PLMain_MouseClick(object sender, MouseEventArgs e)
        {
            drawImp.currentStopDrawing(e.Button);

        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            drawImp.currentDrawGroup();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                updateImp.changeColor(colorDialog.Color, gr);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFilled_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            updateImp.changeFill(btn, gr);
        }

        private void cbDash_SelectedIndexChanged(object sender, EventArgs e)
        {
            DashStyle dashStyle = new DashStyle();
            if (cbDash.SelectedIndex == 0)
            {
                dashStyle = DashStyle.Solid;
            }
            else if (cbDash.SelectedIndex== 1)
            {
                dashStyle = DashStyle.Dash;
            }
            else if (cbDash.SelectedIndex== 2)
            {
                dashStyle = DashStyle.Dot;
            }
            else if (cbDash.SelectedIndex== 3)
            {
                dashStyle = DashStyle.DashDot;
            }
            else if (cbDash.SelectedIndex==4)
            {
                dashStyle = DashStyle.DashDotDot;
            }
            updateImp.changeDashStyle(dashStyle, gr);



        }

        private void Paint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                updateImp.selectMode();
                e.Handled = true;
            }
            if(e.KeyCode == Keys.Delete)
            {
                updateImp.deleteShape();

            }


        }

        private void Paint_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbBrushStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            HatchStyle brushStyle = new HatchStyle();
            if (cbBrushStyle.SelectedIndex == 0)
            {
                brushStyle = HatchStyle.Horizontal;
            }
            else if (cbBrushStyle.SelectedIndex == 1)
            {
                brushStyle = HatchStyle.BackwardDiagonal;
            }
            else if (cbBrushStyle.SelectedIndex == 2)
            {
                brushStyle = HatchStyle.Cross;
            }
            else if (cbBrushStyle.SelectedIndex == 3)
            {
                brushStyle = HatchStyle.DarkDownwardDiagonal;
            }
            else if (cbBrushStyle.SelectedIndex == 4)
            {
                brushStyle = HatchStyle.DottedGrid;
            }
            updateImp.changeBrushStyle(brushStyle, gr);

        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            updateImp.changePen(gr);

        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            drawImp.currentStopDrawUnGroup();

        }

        private void btcArc_Click(object sender, EventArgs e)
        {
            drawImp.onClickDrawArc();

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            updateImp.clearAll();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
