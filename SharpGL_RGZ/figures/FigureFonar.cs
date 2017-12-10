using System.Collections.Generic;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace SharpGL_RGZ.figures
{
    public class FigureFonar
    {
        private readonly List<Polygon> _polygons;

        public FigureFonar()
        {
            _polygons = LoadPrimitive.Load(
                "C:\\Users\\User\\RiderProjects\\SharpGL_RGZ\\SharpGL_RGZ\\obj_file\\Jubilife City Street Lamp.obj");
        }

        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float scale, float z)
        {
            scale = 0.1f * scale;

            gl.Translate(ta, ty, tz);
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
        }
    }
}