namespace LIVE_DEMO
{
    partial class MAIN_FORM
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.openFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TREE = new System.Windows.Forms.TreeView();
            this.TB_Trans_X = new System.Windows.Forms.TrackBar();
            this.T_X = new System.Windows.Forms.Label();
            this.TB_Trans_Y = new System.Windows.Forms.TrackBar();
            this.T_Y = new System.Windows.Forms.Label();
            this.T_Z = new System.Windows.Forms.Label();
            this.TB_Trans_Z = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_TIME = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_TIME)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCT_CANVAS.BackColor = System.Drawing.Color.Black;
            this.PCT_CANVAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCT_CANVAS.Location = new System.Drawing.Point(11, 12);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1037, 392);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 60;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // openFile
            // 
            this.openFile.Font = new System.Drawing.Font("Myanmar Text", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFile.Location = new System.Drawing.Point(1264, 371);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(93, 36);
            this.openFile.TabIndex = 18;
            this.openFile.Text = "Load";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivos OBJ|*.obj";
            // 
            // TREE
            // 
            this.TREE.BackColor = System.Drawing.Color.White;
            this.TREE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TREE.Location = new System.Drawing.Point(1071, 418);
            this.TREE.Name = "TREE";
            this.TREE.Size = new System.Drawing.Size(287, 165);
            this.TREE.TabIndex = 20;
            this.TREE.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TREE_AfterSelect);
            // 
            // TB_Trans_X
            // 
            this.TB_Trans_X.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.TB_Trans_X.Location = new System.Drawing.Point(11, 639);
            this.TB_Trans_X.Minimum = -10;
            this.TB_Trans_X.Name = "TB_Trans_X";
            this.TB_Trans_X.Size = new System.Drawing.Size(1037, 45);
            this.TB_Trans_X.TabIndex = 21;
            this.TB_Trans_X.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // T_X
            // 
            this.T_X.AutoSize = true;
            this.T_X.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_X.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.T_X.Location = new System.Drawing.Point(20, 671);
            this.T_X.Name = "T_X";
            this.T_X.Size = new System.Drawing.Size(23, 24);
            this.T_X.TabIndex = 22;
            this.T_X.Text = "X";
            // 
            // TB_Trans_Y
            // 
            this.TB_Trans_Y.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.TB_Trans_Y.Location = new System.Drawing.Point(11, 574);
            this.TB_Trans_Y.Minimum = -10;
            this.TB_Trans_Y.Name = "TB_Trans_Y";
            this.TB_Trans_Y.Size = new System.Drawing.Size(1036, 45);
            this.TB_Trans_Y.TabIndex = 23;
            this.TB_Trans_Y.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // T_Y
            // 
            this.T_Y.AutoSize = true;
            this.T_Y.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Y.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.T_Y.Location = new System.Drawing.Point(20, 612);
            this.T_Y.Name = "T_Y";
            this.T_Y.Size = new System.Drawing.Size(23, 24);
            this.T_Y.TabIndex = 24;
            this.T_Y.Text = "Y";
            // 
            // T_Z
            // 
            this.T_Z.AutoSize = true;
            this.T_Z.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Z.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.T_Z.Location = new System.Drawing.Point(22, 546);
            this.T_Z.Name = "T_Z";
            this.T_Z.Size = new System.Drawing.Size(21, 24);
            this.T_Z.TabIndex = 26;
            this.T_Z.Text = "Z";
            this.T_Z.Click += new System.EventHandler(this.label1_Click);
            // 
            // TB_Trans_Z
            // 
            this.TB_Trans_Z.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.TB_Trans_Z.Location = new System.Drawing.Point(11, 504);
            this.TB_Trans_Z.Minimum = -10;
            this.TB_Trans_Z.Name = "TB_Trans_Z";
            this.TB_Trans_Z.Size = new System.Drawing.Size(1037, 45);
            this.TB_Trans_Z.TabIndex = 25;
            this.TB_Trans_Z.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(24, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "Animation";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // TB_TIME
            // 
            this.TB_TIME.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.TB_TIME.Location = new System.Drawing.Point(11, 443);
            this.TB_TIME.Maximum = 100;
            this.TB_TIME.Name = "TB_TIME";
            this.TB_TIME.Size = new System.Drawing.Size(1037, 45);
            this.TB_TIME.TabIndex = 30;
            this.TB_TIME.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1108, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 33;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1280, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 34);
            this.button2.TabIndex = 37;
            this.button2.Text = "Escal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1280, 191);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 34);
            this.button4.TabIndex = 38;
            this.button4.Text = "Rot";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1280, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 34);
            this.button3.TabIndex = 39;
            this.button3.Text = "Tran";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1264, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 33);
            this.button1.TabIndex = 40;
            this.button1.Text = "Rec";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btt
            // 
            this.btt.Location = new System.Drawing.Point(1264, 310);
            this.btt.Name = "btt";
            this.btt.Size = new System.Drawing.Size(93, 29);
            this.btt.TabIndex = 41;
            this.btt.Text = "Play";
            this.btt.UseVisualStyleBackColor = true;
            this.btt.Click += new System.EventHandler(this.button5_Click);
            // 
            // MAIN_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1370, 681);
            this.Controls.Add(this.btt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_TIME);
            this.Controls.Add(this.T_Z);
            this.Controls.Add(this.TB_Trans_Z);
            this.Controls.Add(this.T_Y);
            this.Controls.Add(this.TB_Trans_Y);
            this.Controls.Add(this.T_X);
            this.Controls.Add(this.TB_Trans_X);
            this.Controls.Add(this.TREE);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.PCT_CANVAS);
            this.Name = "MAIN_FORM";
            this.Text = "3D HELL";
            this.Load += new System.EventHandler(this.MAIN_FORM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Trans_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_TIME)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView TREE;
        private System.Windows.Forms.TrackBar TB_Trans_X;
        private System.Windows.Forms.Label T_X;
        private System.Windows.Forms.TrackBar TB_Trans_Y;
        private System.Windows.Forms.Label T_Y;
        private System.Windows.Forms.Label T_Z;
        private System.Windows.Forms.TrackBar TB_Trans_Z;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TB_TIME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btt;
    }
}

