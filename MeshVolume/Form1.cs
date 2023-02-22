using Steema.TeeChart.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart.Tools;
using System.Drawing.Drawing2D;

namespace MeshVolume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeChart();
        }

        private void InitializeChart()
        {
            float a = tChart1.Height / 3;
            var ds = new DrawSphere(tChart1, 2 * a / 3, -a / 2, -a / 2, a / 2);
            var pts = ds.SphereCoordinates();


            var surface = new Points3D(tChart1.Chart);

            surface.LinePen.Visible = false;
            surface.Pointer.HorizSize = 2;
            surface.Pointer.VertSize = 2;


            for (int i = 0; i < pts.GetLength(0); i++)
            {
                for (int j = 0; j < pts.GetLength(1); j++)
                {
                    var pt = pts[i, j];

                    surface.Add(pt.X, pt.Y, pt.Z);
                }
            }

            var aspect = tChart1.Aspect;
            aspect.View3D = true;
            aspect.Chart3DPercent = 100;
            aspect.Zoom = 70;
            aspect.Orthogonal = false;

            tChart1.Zoom.Direction = Steema.TeeChart.ZoomDirections.None;
            tChart1.Legend.Visible = false;
            tChart1.Tools.Add(typeof(Rotate));
        }

        //private void splitContainer1_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    g.SmoothingMode = SmoothingMode.AntiAlias;

        //    float a = splitContainer1.Panel1.Height / 3;
        //    DrawSphere ds = new DrawSphere(splitContainer1.Panel1, a, 0, 0, -a / 2);
        //    ds.DrawIsometricView(g);
        //    ds = new DrawSphere(splitContainer1.Panel1, 2 * a / 3, -a / 2, -a / 2, a / 2);
        //    ds.DrawIsometricView(g);
        //}
    }
}