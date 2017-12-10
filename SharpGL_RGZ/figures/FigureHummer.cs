using System.Collections.Generic;
using SharpGL;

namespace SharpGL_RGZ.figures
{
    public class FigureHummer
    {
        private readonly List<Polygon> _polygons;

        public FigureHummer()
        {
            _polygons = LoadPrimitive.Load("C:\\Users\\User\\RiderProjects\\SharpGL_RGZ\\SharpGL_RGZ\\obj_file\\Hammer.obj");
        }

        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            var scale = 0.003f * 1;

            gl.Translate(ta, ty, tz);
            gl.Rotate(90, 0f, 0f, 1f);
            gl.Rotate(15, 0f, 0f, -0.1f);
            gl.Scale(scale, scale, scale);
            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(polygon.color.R, polygon.color.G, polygon.color.B);
                foreach (var points in polygon.list)
                {
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                }

                gl.End();
            }

            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Color(0, 0, 0);
                foreach (var points in polygon.list)
                {
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                }

                gl.End();
            }
        }
    }
}