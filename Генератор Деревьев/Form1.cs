using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Генератор_Деревьев
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void DrawF(int x, int y, int l, double a, Graphics g, int r1, int r2)
        {
            Random rand = new Random();
            double x1, y1;
            Pen C;
            if (l > 12)
                C = Pens.Brown;
            else
                C = Pens.Green;
            x1 = x + l * Math.Sin(a * Math.PI * 2 / 360.0);
            y1 = y + l * Math.Cos(a * Math.PI * 2 / 360.0);
            g.DrawLine(C, x, Height-y, (int)x1, Height - (int)y1);
            if (l > 8)
            {
                DrawF((int)x1, (int)y1, (int)(l / (1.3 + rand.NextDouble()/2)), a + r1 + (22 - rand.Next(45)), g, r1, r2) ;
                DrawF((int)x1, (int)y1, (int)(l / (1.3 + rand.NextDouble()/2)), a - r2 + (22 - rand.Next(45)), g, r1, r2);
                DrawF((int)x1, (int)y1, (int)(l / (1.2 + rand.NextDouble()/3)), a + (22 - rand.Next(45)), g, r1, r2);
            }
        }
            private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random rand = new Random();
            int r1 = rand.Next(40,120);
            int r2 = rand.Next(40,120);
            g.Clear(Color.Black);
            DrawF(Width/2, 0, 160, 0, g, r1,r2);
        }
    }
}
