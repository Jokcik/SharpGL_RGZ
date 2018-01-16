using System.Collections.Generic;
using SharpGL;

namespace SharpGL_RGZ.figures
{
    public class FigureEarth
    {
        private readonly List<Polygon> _polygons = new List<Polygon>();

        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            var scale = 0.06f * 1f;

            gl.Translate(ta, ty, tz);
//            gl.Rotate(30, 0, 1f, 0);
            gl.Scale(scale * 20, scale * 13.5, scale);
            
            gl.Color(0.4f, 0.4f, 0.4f);
            gl.Begin(OpenGL.GL_QUADS);
            
            gl.Vertex(1f, -1f, 0f);
            gl.Vertex(-1f, -1f, 0f);
            gl.Vertex(-1f, 1f, 0f);
            gl.Vertex(1f, 1f, 0f);
            
            gl.End();

        }
    }
}