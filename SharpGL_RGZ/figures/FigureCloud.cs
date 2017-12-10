using System.Collections.Generic;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace SharpGL_RGZ.figures
{
    public class FigureCloud
    {
        private readonly List<Polygon> _polygons;

        public FigureCloud()
        {
            _polygons = LoadPrimitive.Load(
                "C:\\Users\\User\\RiderProjects\\SharpGL_RGZ\\SharpGL_RGZ\\obj_file\\3DCloudModels.obj");
        }

        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            var scale = 0.002f * 1;

            gl.Translate(ta, ty, tz);
            gl.Rotate(40, 0, 1f, 0);
//            gl.Rotate(30, 0f, 0f, 1);
            gl.Scale(scale, scale , scale);
            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0f, 0, 0.5f);
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