using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouOpenedTheBox
{


    public class Scene
    {
        private Figures figure;
        public Pen pen2 = new Pen(Color.Orange);
        public int angle;

        
        public Scene(Figures figures)
        {
            figure = figures;
        }

        public void Draw(Graphics graphics, int viewWidth, int viewHeight, bool rotX, bool rotY, bool rotZ)
        {
            graphics.Clear(Color.FromArgb(0, 0, 0));
            graphics.DrawLine(new Pen(Color.Yellow), 0, viewHeight / 2, viewWidth, viewHeight / 2);
            graphics.DrawLine(new Pen(Color.Yellow), viewWidth / 2, 0, viewWidth / 2, viewHeight);





            var projected = new Vertex[figure.Points.Length];
            for (var i = 0; i < figure.Points.Length; i++)
            {
                var vertex = figure.Points[i];

             
                var transformed = vertex;
                

                if(rotX && rotY && rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateY(angle).RotateZ(angle);
                }
                else if(rotX && rotY && !rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateY(angle);
                }
                else if (rotX && !rotY && rotZ)
                {
                    transformed = vertex.RotateX(angle).RotateZ(angle);
                }
                else if (rotX && !rotY && !rotZ)
                {
                    transformed = vertex.RotateX(angle);
                }
                else if(!rotX && rotY && !rotZ)
                {
                    transformed = vertex.RotateY(angle);
                }
                else if(!rotX && !rotY && rotZ)
                {
                    transformed = vertex.RotateZ(angle);
                }
                else if (!rotX && rotY && rotZ)
                {
                    transformed = vertex.RotateY(angle).RotateZ(angle);
                }

                projected[i] = transformed.Project(viewWidth, viewHeight, 256, 6);
            }

            for (var j = 0; j < 6; j++)
            {
                graphics.DrawLine(pen2,
                    (int)projected[figure.Sides[j, 0]].X,
                    (int)projected[figure.Sides[j, 0]].Y,
                    (int)projected[figure.Sides[j, 1]].X,
                    (int)projected[figure.Sides[j, 1]].Y);

                graphics.DrawLine(pen2,
                    (int)projected[figure.Sides[j, 1]].X,
                    (int)projected[figure.Sides[j, 1]].Y,
                    (int)projected[figure.Sides[j, 2]].X,
                    (int)projected[figure.Sides[j, 2]].Y);

                graphics.DrawLine(pen2,
                    (int)projected[figure.Sides[j, 2]].X,
                    (int)projected[figure.Sides[j, 2]].Y,
                    (int)projected[figure.Sides[j, 3]].X,
                    (int)projected[figure.Sides[j, 3]].Y);

                graphics.DrawLine(pen2,
                    (int)projected[figure.Sides[j, 3]].X,
                    (int)projected[figure.Sides[j, 3]].Y,
                    (int)projected[figure.Sides[j, 0]].X,
                    (int)projected[figure.Sides[j, 0]].Y);
            }
            angle++;
        }
    }
}
