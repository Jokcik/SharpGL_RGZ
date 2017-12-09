using System.Drawing;
using System.Windows.Forms;
using SharpGL;
using SharpGL_RGZ.figures;

namespace SharpGL_RGZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        private readonly FigureHummer _figureHummer1 = new FigureHummer();
        private readonly FigureTable _figureTable = new FigureTable();
        
        private Point _currentLocation = new Point(0, 0);
        private float _angleX;
        private float _angleY;
        private float z;

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            var gl = openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_BLEND);           // Разрешить прозрачность.
            gl.Enable(OpenGL.GL_POINT_SMOOTH);   // Разрешить сглаживание точек.
            gl.Enable(OpenGL.GL_COLOR_MATERIAL); // Отключить перелевание цвета.
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.PointSize(16);             // Размер точки.
            gl.LineWidth(2);              // Толщина линий.
        
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1f, 1f, 1f, 1f);
            
            
            gl.LoadIdentity();
            _figureHummer1.Draw(gl, 0, 0, z, _angleX, _angleY, 1f, 0);
            gl.LoadIdentity();
            _figureTable.Draw(gl, 0, 0, -10f + z, _angleX, _angleY, 1f, 0);
            

            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }
        
        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _angleY += (e.Location.X - _currentLocation.X) / 1.0f;
            _angleX += (e.Location.Y - _currentLocation.Y) / 1.0f;
            _currentLocation = e.Location;
        }
        
        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _currentLocation = e.Location;
        }
        
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            z += e.Delta > 0 ? 0.1f : -0.1f;
            base.OnMouseWheel(e);
        }
    }
}
