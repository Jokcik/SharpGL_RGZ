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
         
        private readonly FigureHouse _figureHouse = new FigureHouse();
        private readonly FigureHummer _figureHummer = new FigureHummer();
        private readonly FigureTable _figureTable = new FigureTable();
        private readonly FigureDver _figureDver = new FigureDver();
        private readonly FigureParallelepiped _figureParallelepiped = new FigureParallelepiped();
        private readonly FigureTriangle _figureTriangle = new FigureTriangle();
        
        private Point _currentLocation = new Point(0, 0);
        private float _angleX;
        private float _angleY;
        private float z = -1f;

        private float[] _black = {0f, 0f, 0f, 1f};
        
        private readonly FigureSphere _figureSphere1 = new FigureSphere();
        private readonly FigureSphere _figureSphere2 = new FigureSphere();
        private readonly FigureSphere _figureSphere3 = new FigureSphere();

        private readonly FigureFonar _figureFonar1 = new FigureFonar();
        private readonly FigureFonar _figureFonar2 = new FigureFonar();

        private readonly FigureTrava _figureTrava1 = new FigureTrava();
        private readonly FigureCloud _figureCloud = new FigureCloud();
        
        private float[] _l0pos = {-1.3f, 0.7f, -2.5f, 1.0f};
        private float[] _l1pos = {-0.34f, -0.08f, -0.95f, 1.0f};
        private float[] _l2pos = {0.34f, -0.08f, -0.95f, 1.0f};
        
        private float[] _light0Scpecular = {1.0f, 1.0f, 1.0f, 1.0f};
        private float[] _light0Ambient = {0.8f, 0.8f, 0.8f, 1f};
        private float[] _light0Diffuse = {1f, 1f, 1f, 1f};
        
        private float[] _light1Scpecular = {1f, 1f, 1f, 1f};
        private float[] _light1Ambient = {0.5f, 0.5f, 0.5f, 1f};
        private float[] _light1Diffuse = {0.6f, 0.6f, 0.6f, 0.6f};
        
        private float[] _light2Scpecular = {0.1f, 0.1f, 0.1f, 0.5f};
        private float[] _light2Ambient = {0.1f, 0.1f, 0.1f, 0.5f};
        private float[] _light2Diffuse = {0.1f, 0.1f, 0.1f, 0.5f};
        
        
        private float[] _sRef = {0.1f, 0.1f, 0.1f, 1.0f};

        public void init()
        {
            _l2pos = new[] {0.34f + x1, -0.08f + y1, -0.95f + z1, 1.0f};
        }
        
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            init();
            var gl = openGLControl1.OpenGL;
            
            gl.Enable(OpenGL.GL_LIGHTING);
//            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, _black);
            
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1f, 1f, 1f, 1f);
            
            gl.Enable(OpenGL.GL_BLEND);           // Разрешить прозрачность.
            gl.Enable(OpenGL.GL_POINT_SMOOTH);   // Разрешить сглаживание точек.
            gl.Enable(OpenGL.GL_COLOR_MATERIAL); // Отключить перелевание цвета.
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.PointSize(16);             // Размер точки.
            gl.LineWidth(2);              // Толщина линий.
        
            gl.LoadIdentity();
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, _l0pos);
            _figureSphere1.Draw(gl, _l0pos[0], _l0pos[1], _l0pos[2], 0, 0, 2f, 0);
            gl.LoadIdentity();
            
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_POSITION, _l1pos);
//            _figureSphere2.Draw(gl, _l1pos[0], _l1pos[1], _l1pos[2], 0, 0, 0.1f, 0);
//            gl.LoadIdentity();
            _figureFonar1.Draw(gl, _l1pos[0] - 0.006f, _l1pos[1] - 0.1f, _l1pos[2], 0, 0, 0.03f, 0);
            gl.LoadIdentity();

            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_POSITION, _l2pos);
//            _figureSphere3.Draw(gl, _l2pos[0], _l2pos[1], _l2pos[2], 0, 0, 0.1f, 0);
//            gl.LoadIdentity();
            _figureFonar2.Draw(gl, _l2pos[0] + 0.006f, _l2pos[1] - 0.1f, _l2pos[2], 0, 0, 0.03f, 0);
            gl.LoadIdentity();
            
            if (checkBox1.Checked)
            {
                gl.Enable(OpenGL.GL_LIGHT0);
            }
            else
            {
                gl.Disable(OpenGL.GL_LIGHT0);                
            }

            if (checkBox2.Checked)
            {
                gl.Enable(OpenGL.GL_LIGHT1);
            }
            else
            {
                gl.Disable(OpenGL.GL_LIGHT1);                
            }

            if (checkBox3.Checked)
            {
                gl.Enable(OpenGL.GL_LIGHT2);                
            }
            else
            {
                gl.Disable(OpenGL.GL_LIGHT2);                
            }
            
//            gl.LoadIdentity();
//            _figureHouse.Draw(gl, 0, 0, z, _angleX, _angleY, 1f, 0);
//            gl.LoadIdentity();
//            _figureTable.Draw(gl, 0, 0, z, _angleX, _angleY, 1f, 0);
//            gl.LoadIdentity();
//            _figureDver.Draw(gl, 0, 0, 0.16f + z, _angleX, _angleY, 1f, 0);
//            gl.LoadIdentity();
//            _figureParallelepiped.Draw(gl, 0.29f, -0.13f, -0.55f);
//            gl.LoadIdentity();
//            _figureTriangle.Draw(gl, 0.29f, -0.04f, -0.55f);    
            gl.LoadIdentity();
            _figureHummer.Draw(gl, -0.29f, -0.17f, -0.55f);
            gl.LoadIdentity();
            _figureCloud.Draw(gl, 0f, 0f, -5.55f);
            
            gl.LoadIdentity();
            _figureTrava1.Draw(gl, 0, -0.55f, z - 1f, _angleX, 0, 0.5f, 0);
            gl.LoadIdentity();
            _figureTrava1.Draw(gl, 1f, -0.55f, z - 1f, _angleX, 0, 0.5f, 0);
            gl.LoadIdentity();
            _figureTrava1.Draw(gl, -1f, -0.55f, z - 1f, _angleX, 0, 0.5f, 0);
            gl.LoadIdentity();
            _figureTrava1.Draw(gl, -1.6f, -0.55f, z - 3f, _angleX, 0, 0.5f, 0);
            gl.LoadIdentity();
            _figureTrava1.Draw(gl, 1.6f, -0.55f, z - 3f, _angleX, 0, 0.5f, 0);
            
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, _light0Diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, _light0Ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, _light0Scpecular);
            
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_DIFFUSE, _light1Diffuse);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, _light1Ambient);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPECULAR, _light1Scpecular);
            
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_DIFFUSE, _light2Diffuse);
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_AMBIENT, _light2Ambient);
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_SPECULAR, _light2Scpecular);
            
            gl.Color(0.5f, 0.5f, 0.5f);
            gl.LoadIdentity();
            gl.Translate(0, -0.125f, z);
            var tea = new SharpGL.SceneGraph.Primitives.Teapot();
            tea.Draw(gl, 14, 0.01, OpenGL.GL_FILL);
            
            
            gl.ColorMaterial(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT_AND_DIFFUSE);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, _sRef);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, 64);
        
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
        
        private static float x1 = 0;
        private static float y1 = 0;
        
        private static float x2 = 0;
        private static float y2 = 0;
        
        private static float x3 = 0;
        private static float y3 = 0;
        
        private static float z1 = 0;
        private static float z2 = 0;
        
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        { 
            switch (e.KeyCode)
            {
                case Keys.Q:
                    if (e.Shift)
                    {
                        x1 += 0.01f;
                    }
                    else 
                    {
                        x1 -= 0.01f;
                    }
                    break;
                case Keys.W:
                    if (e.Shift)
                    {
                        y1 += 0.01f;
                    }
                    else
                    {
                        y1 -= 0.01f;
                    }
                    break;
                case Keys.R:
                    if (e.Shift)
                    {
                        z1 += 0.01f;
                    }
                    else
                    {
                        z1 -= 0.01f;
                    }
                    break;
                case Keys.A:
                    if (e.Shift)
                    {
                        x2 += 0.05f;
                    }
                    else
                    {
                        x2 -= 0.05f;
                    }
                    break;
                case Keys.S:
                    if (e.Shift)
                    {
                        y2 += 0.05f;
                    }
                    else
                    {
                        y2 -= 0.05f;
                    }
                    break;
                case Keys.Z:
                    if (e.Shift)
                    {
                        x3 += 0.05f;
                    }
                    else
                    {
                        x3 -= 0.05f;
                    }
                    break;
                case Keys.X:
                    if (e.Shift)
                    {
                        y3 += 0.05f;
                    }
                    else
                    {
                        y3 -= 0.05f;
                    }
                    break;
            }
        }

    }
}
