using SharpGL;

namespace SharpGL_RGZ.figures
{
    public class FigureTriangle
    {
        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            var scale = 0.06f * 1f;

            gl.Translate(ta, ty, tz);
            gl.Rotate(30, 0, 1f, 0);
            gl.Scale(scale, scale, scale);
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1f, 0, 0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0, 1f, 0);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0, 0, 1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.Color(1f, 0, 0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0, 0, 1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0, 1f, 0);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1f, 0, 0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0, 1f, 0);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0, 0, 1f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.Color(1f, 0, 0);
            gl.Vertex(0.0f, 1.0f, 0f);
            gl.Color(0, 1f, 0);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0, 1f, 1f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);

            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(1f, 0, 0);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0, 1f, 0);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0, 1f, 1f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0, 1f, 1f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.End();
        }
    }
}