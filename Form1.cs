using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Лаба_8__Крива_Леві__варіант_17
{
    public partial class Form1 : Form
    {
        int i;
        GraphicsPath path;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            i = 0;// need for iteration
            path = new GraphicsPath();
            //g = pictureBox1.CreateGraphics();
        }

        void Draw_Levy(GraphicsPath path, float x1, float x2, float y1, float y2, int i)
        {
            float x3, y3;

            if (i == 0)// if we go on end, we add coordinats point
                path.AddLine(x1, y1, x2, y2);
            else
            {
                x3 = (x1 + x2) / 2 + (y2 - y1) / 2;//
                y3 = (y1 + y2) / 2 - (x2 - x1) / 2;

                Draw_Levy(path, x1, x3, y1, y3, i - 1);
                Draw_Levy(path, x2, x3, y2, y3, i - 1);
            }
        }

        void Build(int iterations)
        {
            path = new GraphicsPath();
            Draw_Levy(path, Width / 2 - 100, Width / 2 + 100, Height / 2, Height / 2, iterations);//get start location
        }

        private void pictureBox1_Click(object sender, EventArgs e)// when user click on pictureBox we draw next step 
        {
            if (i < 20)
                Build(++i);
            pictureBox1.Refresh();
            //g.DrawPath(Pens.Lime, path);
        }

        private void button1_Click(object sender, EventArgs e)// back button, return previous image
        {
            if (i > 0)
                Build(--i);
            pictureBox1.Refresh();
            //g.DrawPath(Pens.Lime, path);
        }
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            Build(i);
            //g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            //g.DrawPath(Pens.Lime, path);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawPath(Pens.Lime, path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}