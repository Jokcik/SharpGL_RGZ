using System;
using System.Collections.Generic;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace SharpGL_RGZ.figures
{
    public class FigureTable
    {
        private readonly List<Polygon> _polygons;
        private float xc = 0;
        private float yc = 0;
        private float zc = 0;

        public FigureTable()
        {
            _polygons = LoadPrimitive.Load(
                "C:\\Users\\User\\RiderProjects\\SharpGL_RGZ\\SharpGL_RGZ\\obj_file\\Table_01_stock.obj");

            var count = 0;
            foreach (var polygon in _polygons)
            {
                foreach (var points in polygon.list)
                {
                    xc += points.Item1;
                    yc += points.Item2;
                    zc += points.Item3;
                    count += 1;
                }
            }

            xc /= count;
            yc /= count;
            zc /= count;

        }

        private Texture _texture = new Texture();

        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float scale, float z)
        {
            scale = 0.002f * scale;

            gl.Translate(ta, ty -0.14f, tz);
            gl.Scale(scale, scale, scale);
//            gl.Rotate(angleX, 1f, 0f, 0f);
//            gl.Rotate(angleY, 0f, 1f, 0f);
            gl.Translate(-xc, -yc, -zc);
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