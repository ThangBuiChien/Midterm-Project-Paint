namespace Thang_Paint
{
    partial class Paint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.PLMain = new System.Windows.Forms.Panel();
            this.SBLineSize = new System.Windows.Forms.HScrollBar();
            this.btnSelect = new System.Windows.Forms.Button();
            this.SBZoom = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnElipse = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btcArc = new System.Windows.Forms.Button();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFilled = new System.Windows.Forms.Button();
            this.cbDash = new System.Windows.Forms.ComboBox();
            this.cbBrushStyle = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPen = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUngroup = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "rectangle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PLMain
            // 
            this.PLMain.AutoScroll = true;
            this.PLMain.BackColor = System.Drawing.Color.PeachPuff;
            this.PLMain.Location = new System.Drawing.Point(12, 174);
            this.PLMain.Name = "PLMain";
            this.PLMain.Size = new System.Drawing.Size(1758, 510);
            this.PLMain.TabIndex = 0;
            this.PLMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.PLMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PLMain_MouseClick);
            this.PLMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.PLMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.PLMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // SBLineSize
            // 
            this.SBLineSize.Location = new System.Drawing.Point(106, 46);
            this.SBLineSize.Name = "SBLineSize";
            this.SBLineSize.Size = new System.Drawing.Size(83, 25);
            this.SBLineSize.TabIndex = 2;
            this.SBLineSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SBLineSize_Scroll);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(20, 26);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SBZoom
            // 
            this.SBZoom.Location = new System.Drawing.Point(116, 101);
            this.SBZoom.Name = "SBZoom";
            this.SBZoom.Size = new System.Drawing.Size(83, 25);
            this.SBZoom.TabIndex = 4;
            this.SBZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SBZoom_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zoom Factor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(20, 87);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(23, 31);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 23);
            this.btnLine.TabIndex = 8;
            this.btnLine.Text = "line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Line Width";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnElipse
            // 
            this.btnElipse.Location = new System.Drawing.Point(145, 31);
            this.btnElipse.Name = "btnElipse";
            this.btnElipse.Size = new System.Drawing.Size(75, 23);
            this.btnElipse.TabIndex = 10;
            this.btnElipse.Text = "Elipse";
            this.btnElipse.UseVisualStyleBackColor = true;
            this.btnElipse.Click += new System.EventHandler(this.btnElipse_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(145, 87);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(75, 23);
            this.btnCircle.TabIndex = 11;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btcArc
            // 
            this.btcArc.Location = new System.Drawing.Point(282, 31);
            this.btcArc.Name = "btcArc";
            this.btcArc.Size = new System.Drawing.Size(75, 23);
            this.btcArc.TabIndex = 12;
            this.btcArc.Text = "Arc";
            this.btcArc.UseVisualStyleBackColor = true;
            this.btcArc.Click += new System.EventHandler(this.btcArc_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(282, 87);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(75, 23);
            this.btnPolygon.TabIndex = 13;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(130, 26);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 14;
            this.btnGroup.Text = "Group ";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(483, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 80);
            this.button2.TabIndex = 15;
            this.button2.Text = "color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFilled
            // 
            this.btnFilled.Location = new System.Drawing.Point(21, 87);
            this.btnFilled.Name = "btnFilled";
            this.btnFilled.Size = new System.Drawing.Size(87, 32);
            this.btnFilled.TabIndex = 16;
            this.btnFilled.Text = "brush";
            this.btnFilled.UseVisualStyleBackColor = true;
            this.btnFilled.Click += new System.EventHandler(this.btnFilled_Click);
            // 
            // cbDash
            // 
            this.cbDash.FormattingEnabled = true;
            this.cbDash.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.cbDash.Location = new System.Drawing.Point(317, 47);
            this.cbDash.Name = "cbDash";
            this.cbDash.Size = new System.Drawing.Size(121, 24);
            this.cbDash.TabIndex = 17;
            this.cbDash.SelectedIndexChanged += new System.EventHandler(this.cbDash_SelectedIndexChanged);
            // 
            // cbBrushStyle
            // 
            this.cbBrushStyle.FormattingEnabled = true;
            this.cbBrushStyle.Items.AddRange(new object[] {
            "Horizontal",
            "Backward Diagonal",
            "Cross",
            "Dark Downward Diagonal",
            "Dotted Grid",
            "Horizontal Brick"});
            this.cbBrushStyle.Location = new System.Drawing.Point(317, 98);
            this.cbBrushStyle.Name = "cbBrushStyle";
            this.cbBrushStyle.Size = new System.Drawing.Size(121, 24);
            this.cbBrushStyle.TabIndex = 18;
            this.cbBrushStyle.SelectedIndexChanged += new System.EventHandler(this.cbBrushStyle_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnElipse);
            this.panel1.Controls.Add(this.btnCircle);
            this.panel1.Controls.Add(this.btcArc);
            this.panel1.Controls.Add(this.btnPolygon);
            this.panel1.Location = new System.Drawing.Point(55, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 166);
            this.panel1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Shape";
            // 
            // btnPen
            // 
            this.btnPen.Location = new System.Drawing.Point(21, 31);
            this.btnPen.Name = "btnPen";
            this.btnPen.Size = new System.Drawing.Size(87, 32);
            this.btnPen.TabIndex = 20;
            this.btnPen.Text = "pen";
            this.btnPen.UseVisualStyleBackColor = true;
            this.btnPen.Click += new System.EventHandler(this.btnPen_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnFilled);
            this.panel2.Controls.Add(this.btnPen);
            this.panel2.Location = new System.Drawing.Point(455, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 166);
            this.panel2.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Drawing tools";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.SBLineSize);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbBrushStyle);
            this.panel3.Controls.Add(this.SBZoom);
            this.panel3.Controls.Add(this.cbDash);
            this.panel3.Location = new System.Drawing.Point(872, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(628, 166);
            this.panel3.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Properties";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Brush Style";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dash Style";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUngroup);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btnGroup);
            this.panel4.Controls.Add(this.btnSelect);
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Location = new System.Drawing.Point(609, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 166);
            this.panel4.TabIndex = 23;
            // 
            // btnUngroup
            // 
            this.btnUngroup.Location = new System.Drawing.Point(130, 87);
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(75, 23);
            this.btnUngroup.TabIndex = 23;
            this.btnUngroup.Text = "Ungroup ";
            this.btnUngroup.UseVisualStyleBackColor = true;
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Object";
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 725);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PLMain);
            this.KeyPreview = true;
            this.Name = "Paint";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Paint_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Paint_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel PLMain;
        private System.Windows.Forms.HScrollBar SBLineSize;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.HScrollBar SBZoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnElipse;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btcArc;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFilled;
        private System.Windows.Forms.ComboBox cbDash;
        private System.Windows.Forms.ComboBox cbBrushStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUngroup;
    }
}