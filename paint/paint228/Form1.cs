﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint228
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        private class ArrayPoints
        {
            private int index = 0;
            private Point[] points;
            public ArrayPoints(int size)
            
            
            {
                if(size<=0) { size = 2; }
                points = new Point[size];
            
            }
            public void SetPoint(int x, int y)
            {
                if(index >= points.Length)
                {
                    index = 0;
                }
                points[index] = new Point(x, y);
                index++;
            }
            public void ResetPoints()
            {
                index = 0;
            }
            public int GetCountPoints()
            {
                return index;
            }

            public Point[] GetPoints()
            {
                return points;
            }

        }
        bool isMouse = false;

        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap map = new Bitmap(100,100);
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map);

            //pen.StartCap = paint228.Drawning.Drawning2D.LineCap.Round;
            //pen.EndCap = paint228.Drawning.Drawning2D.LineCap.Round;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse= true;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse= false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse)
            {
                return;
            }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);



            }
        }

        private void RedBtn(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void GrnBtn(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void YelwBtn(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void Trash(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox1.BackColor);
            pictureBox1.Image = map;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
