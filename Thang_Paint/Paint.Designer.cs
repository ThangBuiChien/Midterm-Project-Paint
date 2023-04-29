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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 84);
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
            this.PLMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PLMain.Location = new System.Drawing.Point(297, 145);
            this.PLMain.Name = "PLMain";
            this.PLMain.Size = new System.Drawing.Size(812, 538);
            this.PLMain.TabIndex = 0;
            this.PLMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.PLMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PLMain_MouseClick);
            this.PLMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.PLMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.PLMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // SBLineSize
            // 
            this.SBLineSize.Location = new System.Drawing.Point(868, 87);
            this.SBLineSize.Name = "SBLineSize";
            this.SBLineSize.Size = new System.Drawing.Size(83, 25);
            this.SBLineSize.TabIndex = 2;
            this.SBLineSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SBLineSize_Scroll);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(95, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SBZoom
            // 
            this.SBZoom.Location = new System.Drawing.Point(868, 31);
            this.SBZoom.Name = "SBZoom";
            this.SBZoom.Size = new System.Drawing.Size(83, 25);
            this.SBZoom.TabIndex = 4;
            this.SBZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SBZoom_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(764, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zoom Factor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(95, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(231, 24);
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
            this.label2.Location = new System.Drawing.Point(764, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Line Width";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnElipse
            // 
            this.btnElipse.Location = new System.Drawing.Point(339, 24);
            this.btnElipse.Name = "btnElipse";
            this.btnElipse.Size = new System.Drawing.Size(75, 23);
            this.btnElipse.TabIndex = 10;
            this.btnElipse.Text = "Elipse";
            this.btnElipse.UseVisualStyleBackColor = true;
            this.btnElipse.Click += new System.EventHandler(this.btnElipse_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Location = new System.Drawing.Point(339, 84);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(75, 23);
            this.btnCircle.TabIndex = 11;
            this.btnCircle.Text = "Circle";
            this.btnCircle.UseVisualStyleBackColor = true;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btcArc
            // 
            this.btcArc.Location = new System.Drawing.Point(463, 24);
            this.btcArc.Name = "btcArc";
            this.btcArc.Size = new System.Drawing.Size(75, 23);
            this.btcArc.TabIndex = 12;
            this.btcArc.Text = "Arc";
            this.btcArc.UseVisualStyleBackColor = true;
            // 
            // btnPolygon
            // 
            this.btnPolygon.Location = new System.Drawing.Point(463, 84);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(75, 23);
            this.btnPolygon.TabIndex = 13;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.UseVisualStyleBackColor = true;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(591, 24);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 14;
            this.btnGroup.Text = "Group ";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 65);
            this.button2.TabIndex = 15;
            this.button2.Text = "color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFilled
            // 
            this.btnFilled.Location = new System.Drawing.Point(115, 367);
            this.btnFilled.Name = "btnFilled";
            this.btnFilled.Size = new System.Drawing.Size(100, 75);
            this.btnFilled.TabIndex = 16;
            this.btnFilled.Text = "filled";
            this.btnFilled.UseVisualStyleBackColor = true;
            this.btnFilled.Click += new System.EventHandler(this.btnFilled_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 725);
            this.Controls.Add(this.btnFilled);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.btnPolygon);
            this.Controls.Add(this.btcArc);
            this.Controls.Add(this.btnCircle);
            this.Controls.Add(this.btnElipse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SBZoom);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.SBLineSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PLMain);
            this.Name = "Paint";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Paint_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}