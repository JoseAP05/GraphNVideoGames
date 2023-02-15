namespace Pac_Man_Nightmare
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Map_PB = new System.Windows.Forms.PictureBox();
            this.Player_PB = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Map_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // Map_PB
            // 
            this.Map_PB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Map_PB.Location = new System.Drawing.Point(1, 0);
            this.Map_PB.Name = "Map_PB";
            this.Map_PB.Size = new System.Drawing.Size(500, 500);
            this.Map_PB.TabIndex = 0;
            this.Map_PB.TabStop = false;
            this.Map_PB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Map_PB_PreviewKeyDown);
            // 
            // Player_PB
            // 
            this.Player_PB.BackColor = System.Drawing.Color.Yellow;
            this.Player_PB.Location = new System.Drawing.Point(238, 282);
            this.Player_PB.Name = "Player_PB";
            this.Player_PB.Size = new System.Drawing.Size(12, 12);
            this.Player_PB.TabIndex = 1;
            this.Player_PB.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player_PB);
            this.Controls.Add(this.Map_PB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Map_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_PB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Map_PB;
        private System.Windows.Forms.PictureBox Player_PB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

