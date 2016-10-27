using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Лаба_8__Графік
{
    public partial class Form3 : Form
    {
        float x_start, x_finish, a;
        int scale;
        Point location_for_label_X, location_for_label_Y;
        GraphicsPath system_coordinat, grad, function, pidpis;
        public Form3()
        {
            InitializeComponent();
            system_coordinat = new GraphicsPath();
            function = new GraphicsPath();//graf of function
            pidpis = new GraphicsPath();// numbers with axises
            grad = new GraphicsPath();// save net for char
            location_for_label_X = new Point();// coordinats char X with axis OX
            location_for_label_Y = new Point();//coordinats char Y with axis OY
            scale = 20;
        }
        public Form3(float x1, float x2, float a) : this()
        {
            x_start = x1;
            x_finish = x2;
            this.a = a;
        }
        /// <summary>
        /// Draw two axis: OX and OY, there are have direct
        /// </summary>
        private void Draw_system_coordinat()
        {
            system_coordinat.AddLine(0, (Height / 2), Width, (Height / 2));// Paint axis OX
            system_coordinat.StartFigure();
            system_coordinat.AddLine((Width / 2), 0, (Width / 2), Height);//Paint axis OY
            system_coordinat.StartFigure();
            system_coordinat.AddLine(new PointF((Width / 2), 0), new PointF((Width / 2) - 10, 10));//Draw  left part of arrow of OY
            system_coordinat.AddLine(new PointF((Width / 2), 0), new PointF((Width / 2) + 10, 10));// right part of arrow of OY
            system_coordinat.StartFigure();
            system_coordinat.AddLine(new PointF(Width - 15, (Height / 2)), new PointF(Width - 30, (Height / 2) - 10));//higher part of arrow of OX
            system_coordinat.AddLine(new PointF(Width - 15, (Height / 2)), new PointF(Width - 30, (Height / 2) + 10));//lower part of arrow of OX
            system_coordinat.StartFigure();


            location_for_label_X.X = Width - 40;
            location_for_label_X.Y = Height / 2 + 20;
            label_axis_X.Location = location_for_label_X;

            location_for_label_Y.X = Width / 2 + 30;
            location_for_label_Y.Y = 10;
            label_axis_Y.Location = location_for_label_Y;
        }
        /// <summary>
        /// Draw net
        /// </summary>
        void Draw_grad()
        {
            for (float i = 0; i < Width / 2; i += scale)//Draw vertical lines
            {
                grad.AddLine(new PointF((Width / 2) + i, 0), new PointF((Width / 2) + i, Height)); // Draw right part
                grad.StartFigure();
                grad.AddLine(new PointF((Width / 2) - i, 0), new PointF((Width / 2) - i, Height));// Left part
                grad.StartFigure();
            }
            for (float i = 0; i < Height / 2; i += scale)//Draw  horizontal lines
            {
                grad.AddLine(new PointF(0, (Height / 2) + i), new PointF(Width, (Height / 2) + i));//Higher part
                grad.StartFigure();
                grad.AddLine(new PointF(0, (Height / 2) - i), new PointF(Width, (Height / 2) - i));//lower part
                grad.StartFigure();
            }
        }

        /// <summary>
        /// Draw function
        /// </summary>
        void Draw_grafic_of_function()
        {
            float i;
            if (Width / 2 + x_start * scale < 0)//check whether coordinats does no go over screen
                i = -Width / (2 * scale) - 10;
            else
                i = x_start;
            for (; (i < x_finish) && (i * scale < Width); i += 0.01f)
            {
                function.AddLine
                    (
                    new PointF((Width / 2) + scale * i, ((Height / 2) - scale * Count_mean_function(i, a))),//first point 
                    new PointF((Width / 2) + scale * (i + 0.01f), ((Height / 2) - scale * Count_mean_function(i + 0.01f, a))//second point
                    ));
                function.StartFigure();
            }
        }

        /// <summary>
        /// formula for count
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private float Count_mean_function(float x, float a)
        {
            return (float)Math.Exp(a * Math.Sin(x) + Math.Cos(x));
        }
        /// <summary>
        /// maximuz button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(scale + 10 >= 100))
            {
                scale += 10;
                Repaint_function();
            }
        }

        /// <summary>
        /// minimuz buttoon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(scale - 10 <= 10))
            {
                scale -= 10;
                Repaint_function();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw_system_coordinat();
            Draw_grad();
            Draw_grafic_of_function();
            e.Graphics.DrawPath(new Pen(Color.LightGray), grad);//Draw net
            e.Graphics.DrawPath(new Pen(Color.Black), system_coordinat); // Draw system of coordinat
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 0, 0, 255), 3), function); // Draw our grafic
            for (float i = 0; i < Height; i += scale) // Insert number near to axis OY
            {
                e.Graphics.DrawString(
                    "-" + (i / scale + 1), // number is less zero
                    new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    new PointF(Width / 2 - 15, Height / 2 + i + scale));
                e.Graphics.DrawString(//number is high zero
                    "" + i / scale,
                    new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    new PointF(Width / 2 - 12, Height / 2 - i));
            }

            for (float i = scale; i < Width; i += scale)// Insert number next to axis OX
            {
                e.Graphics.DrawString(//numuber is lezz zero
                    "-" + (i / scale),
                    new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    new PointF(Width / 2 - i, Height / 2 + 15)
                    );
                e.Graphics.DrawString(//number is high zero
                    "" + i / scale,
                    new Font(FontFamily.GenericSansSerif, 5, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    new PointF(Width / 2 + i, Height / 2 + 15)
                    );
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Repaint_function();
        }
        private void Repaint_function()
        {
            system_coordinat.Reset();
            grad.Reset();
            pidpis.Reset();
            function.Reset();
            Refresh();
        }
        
        
    }
}
