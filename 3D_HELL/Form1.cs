using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LIVE_DEMO
{
    public partial class MAIN_FORM : Form
    {
        Rasterization raster;
        Random random;
        
        int modelIndex;
        int transform;
        bool animate;
        int initialFrame;
        int finalFrame;

        
        public MAIN_FORM()
        {
            InitializeComponent();
            TB_TIME.Cursor = Cursors.NoMoveHoriz;

        }
                    
        private void BTN_EXE_Click(object sender, EventArgs e)
        {

            animate = !animate;

            if(animate == true)
            btt.BackColor = Color.Green;

            if(animate == false)
            btt.BackColor = Color.Maroon;
        }




        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (raster == null)
                return;
            if (animate)
                raster.Animate(TB_TIME.Value, initialFrame);
            raster.Render();
            PCT_CANVAS.Invalidate();
            if (animate)
            {
                if (TB_TIME.Value==TB_TIME.Maximum)
                    TB_TIME.Value = 0;
                else
                    TB_TIME.Value++;
                label1.Text = "Animation : " + ConvertirMilisegundosAString(TB_TIME.Value * TIMER.Interval);
            }
                


        }

        private void MAIN_FORM_Load(object sender, EventArgs e)
        {
           
            random = new Random();
            transform = 0;
            animate = false;
            initialFrame = -1;
            finalFrame = -1;
            TB_TIME.Maximum=(10000/TIMER.Interval)+1;

        }
        private String formatTranslation(String text)
        {
            return new string(text.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                string filePath = openFileDialog1.FileName;
                List<Vertex> vertexes = new List<Vertex>();
                List<Triangle> triangles = new List<Triangle>();
                StreamReader streamReader = new StreamReader(filePath);
               
                using (streamReader) {
                    string line;
                    while((line = streamReader.ReadLine()) != null)
                    {
                        List<int> indexes = new List<int>();
                        if (line.StartsWith("v "))
                        {
                            string[] tokens = line.Split(' ');
                            float x = float.Parse(tokens[1]);
                            float y = float.Parse(tokens[2]);
                            float z = float.Parse(tokens[3]);
                            Vertex ver = new Vertex(x, y, z);
                            vertexes.Add(ver);
                            
                        }
                        else if (line.StartsWith("f "))
                        {
                            
                            string[] aux = line.Split(' ');
                            for(int i=1; i<aux.Length; i++)
                            {
                                indexes.Add(int.Parse(aux[i].Split('/')[0])-1);
                            }
                            Triangle triangle = new Triangle(indexes[0], indexes[1], indexes[2],GetRandomColor());
                            
                            triangles.Add(triangle);
                            
                        }
                    }
                }
                if(raster == null)
                {
                    raster = new Rasterization(PCT_CANVAS.Size, vertexes, triangles);
                    PCT_CANVAS.Image = raster.Canvas;
                    TreeNode node = new TreeNode(GetFileName(filePath));
                    node.Tag = 0;
                    modelIndex = 0;
                    TREE.Nodes.Add(node);
                }
                else
                {
                    TreeNode node = new TreeNode(GetFileName(filePath));
                    node.Tag = raster.AddModel(vertexes, triangles);
                    modelIndex = (int)node.Tag;
                    TREE.Nodes.Add(node);
                    
                    
                }
            }
        }

        public string GetFileName(string filePath)
        {
            int lastSlashIndex = filePath.LastIndexOf('\\');
            int lastBackslashIndex = filePath.LastIndexOf('/');

            int lastIndex = Math.Max(lastSlashIndex, lastBackslashIndex);

            if (lastIndex == -1)
            {
                return filePath;
            }
            else
            {
                return filePath.Substring(lastIndex + 1);
            }
        }


        public Color GetRandomColor()
            {
            
                 int randomNumber = random.Next(0, 5);

                switch (randomNumber)
                {
                    case 0:
                        return Color.Cyan;
                    case 1:
                        return Color.GreenYellow;
                    case 2:
                        return Color.Violet;
                    case 3:
                        return Color.YellowGreen;
                    case 4:
                        return Color.Magenta;
                    case 5:
                        return Color.DarkOrange;
                    case 6:
                        return Color.DimGray;
                    case 7:
                        return Color.RosyBrown;
                    default:
                        throw new InvalidOperationException("Unexpected random number.");
                }
            }
        
        public static void PrintArray(string[] array)
        {
            Console.WriteLine();
            Console.Write("[ ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write(" ]");
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (raster == null)
                return;
            

            if (initialFrame == -1)
            {
                button1.BackColor = Color.Green;
                initialFrame = TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);

            }
            else if (finalFrame == -1)
            {
                finalFrame = TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);
                for (int i = 0; i < raster.instances.Count; i++)
                {
                    Instance ints = raster.instances[i];
                    for (int j = 0; j < ints.transformations.Count; j++)
                    {
                        label2.Text += ints.transformations[j].ToString();

                    }
                }
                raster.CalculateSteps(initialFrame, finalFrame);
                button1.BackColor = Color.Maroon;



            }

            else
            {
                Console.WriteLine("ERROR");
            }
            
        }

        private void TREE_AfterSelect(object sender, TreeViewEventArgs e)
        {
            modelIndex = (int)TREE.SelectedNode.Tag;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(raster != null) {
                Vertex t = new Vertex(TB_Trans_X.Value, TB_Trans_Y.Value, TB_Trans_Z.Value);
                switch (transform)
                {
                    case 1:
                        raster.Rotate(t, modelIndex);
                        break;
                    case 2:
                        raster.Translate(t, modelIndex);
                        break;
                    case 3:
                        float value = ((float)TB_Trans_X.Value) / 100;
                        raster.Scales(value, modelIndex);
                        break;
                    default: 
                        break;
                }
            }
              
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            label1.Text = "Time : " + ConvertirMilisegundosAString(TB_TIME.Value * TIMER.Interval);
        }
        public static string ConvertirMilisegundosAString(long milisegundos)
        {
            int segundos = (int)(milisegundos / 1000); 
            
            segundos = segundos % 60; 
            int milisegRestantes = (int)(milisegundos % 1000); 

            string resultado =  segundos.ToString() + " seconds.";

            return resultado;
        }



        private void button2_Click(object sender, EventArgs e)
        {

       
           
            TB_Trans_Y.Visible = false;
            TB_Trans_Z.Visible = false;
          
            TB_Trans_X.Maximum = 200;
            TB_Trans_X.Minimum = 0;
            TB_Trans_X.Value = 100;
            transform = 3;
            T_X.Text = "Scaling";
            T_Y.Text = "";
            T_Z.Text = "";
            button2.BackColor = Color.DarkGreen;
            button3.BackColor = Color.Black;
            button4.BackColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            int maximum = 10;
            int minimum = -10;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 2;
            T_X.Text = "X Translation";
            T_Y.Text = "Y Translation";
            T_Z.Text = "Z Translation";
            button3.BackColor = Color.DarkGreen;
            button2.BackColor = Color.Black;
            button4.BackColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            int maximum = 360;
            int minimum = 0;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 1;
            T_X.Text = "X";
            T_Y.Text = "Y";
            T_Z.Text = "Z";
            button4.BackColor = Color.DarkGreen;
            button3.BackColor = Color.Black;
            button2.BackColor = Color.Black;
        }

        private void BTN_EXE_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TB_Trans_X.Maximum = 200;
            TB_Trans_X.Minimum = 0;
            TB_Trans_X.Value = 100;
            transform = 3;
            T_X.Text = "Size";
            T_Y.Text = "";
            T_Z.Text = "";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int maximum = 360;
            int minimum = 0;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 1;
            T_X.Text = "X";
            T_Y.Text = "Y";
            T_Z.Text = "Z";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (raster == null)
                return;


            if (initialFrame == -1)
            {
                button1.BackColor = Color.DimGray;
                initialFrame = TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);

            }
            else if (finalFrame == -1)
            {
                finalFrame = TB_TIME.Value;
                raster.SaveFrame(TB_TIME.Value);
                for (int i = 0; i < raster.instances.Count; i++)
                {
                    Instance ints = raster.instances[i];
                    for (int j = 0; j < ints.transformations.Count; j++)
                    {
                        label2.Text += ints.transformations[j].ToString();

                    }
                }
                raster.CalculateSteps(initialFrame, finalFrame);
                button1.BackColor = Color.Red;



            }

            else
            {
                Console.WriteLine("ERROR");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            animate = !animate;

            if (animate == true)
                btt.BackColor = Color.DimGray;

            if (animate == false)
                btt.BackColor = Color.Red;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int maximum = 10;
            int minimum = -10;
            int value = 0;
            TB_Trans_X.Maximum = maximum;
            TB_Trans_Y.Maximum = maximum;
            TB_Trans_Z.Maximum = maximum;
            TB_Trans_X.Minimum = minimum;
            TB_Trans_Y.Minimum = minimum;
            TB_Trans_Z.Minimum = minimum;
            TB_Trans_X.Value = value;
            TB_Trans_Y.Value = value;
            TB_Trans_Z.Value = value;
            TB_Trans_Y.Visible = true;
            TB_Trans_Z.Visible = true;
            transform = 2;
            T_X.Text = "X";
            T_Y.Text = "Y";
            T_Z.Text = "Z";
        }
    }
}
