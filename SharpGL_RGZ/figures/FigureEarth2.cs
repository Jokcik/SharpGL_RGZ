using System.Collections.Generic;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace SharpGL_RGZ.figures
{
    public class FigureEarth2
    {
        private readonly List<Polygon> _polygons;

        public FigureEarth2()
        {
            _polygons = LoadPrimitive.Load(
                "C:\\Users\\User\\RiderProjects\\SharpGL_RGZ\\SharpGL_RGZ\\obj_file\\Rockwall.obj");
        }

        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            var scale =  1;

            gl.Translate(ta, ty, tz);
//            gl.Rotate(40, 0, 1f, 0);
//            gl.Rotate(30, 0f, 0f, 1);
            gl.Scale(scale * 2, scale * 1.3f, scale);
            gl.Color(0.5f, 0.5f, 0.5f);
            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                foreach (var points in polygon.list)
                {
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                }
                gl.End();
            }
            
//            foreach (var polygon in _polygons)
//            {
//                gl.Begin(OpenGL.GL_LINE_STRIP);
//                gl.Color(0f, 0, 0f);
//                foreach (var points in polygon.list)
//                {
//                    gl.Vertex(points.Item1, points.Item2, points.Item3);
//                }
//                gl.End();
//            }
        }
    }
}