namespace Login.FormsAPP
{
    partial class HOME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOME));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.AvisoTxt = new System.Windows.Forms.Label();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.actualizacion = new System.Windows.Forms.Timer(this.components);
            this.LABEL = new System.Windows.Forms.Label();
            this.IMGL = new System.Windows.Forms.ImageList(this.components);
            this.Timg = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 55);
            this.label2.TabIndex = 16;
            this.label2.Text = "Avisos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 100);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 600);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 50);
            this.panel2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Aqui se publicaran diferentes avisos de la institucion con el fin de informar a e" +
    "studiantes y funcionarios";
            // 
            // AvisoTxt
            // 
            this.AvisoTxt.AutoSize = true;
            this.AvisoTxt.BackColor = System.Drawing.Color.White;
            this.AvisoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvisoTxt.Location = new System.Drawing.Point(62, 135);
            this.AvisoTxt.Name = "AvisoTxt";
            this.AvisoTxt.Size = new System.Drawing.Size(22, 29);
            this.AvisoTxt.TabIndex = 19;
            this.AvisoTxt.Text = "-";
            // 
            // TIMER
            // 
            this.TIMER.Interval = 1000;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // actualizacion
            // 
            this.actualizacion.Interval = 5000;
            this.actualizacion.Tick += new System.EventHandler(this.actualizacion_Tick);
            // 
            // LABEL
            // 
            this.LABEL.BackColor = System.Drawing.Color.White;
            this.LABEL.ImageList = this.IMGL;
            this.LABEL.Location = new System.Drawing.Point(325, 366);
            this.LABEL.Name = "LABEL";
            this.LABEL.Size = new System.Drawing.Size(250, 200);
            this.LABEL.TabIndex = 20;
            // 
            // IMGL
            // 
            this.IMGL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMGL.ImageStream")));
            this.IMGL.TransparentColor = System.Drawing.Color.Transparent;
            this.IMGL.Images.SetKeyName(0, "DISTANCIA.png");
            this.IMGL.Images.SetKeyName(1, "FAMILIA.png");
            this.IMGL.Images.SetKeyName(2, "MANOS.png");
            this.IMGL.Images.SetKeyName(3, "TAPABOCAS.png");
            this.IMGL.Images.SetKeyName(4, "VESTIMENTA.png");
            // 
            // Timg
            // 
            this.Timg.Interval = 1000;
            this.Timg.Tick += new System.EventHandler(this.Timg_Tick_1);
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.LABEL);
            this.Controls.Add(this.AvisoTxt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HOME";
            this.Text = "HOME";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label AvisoTxt;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer actualizacion;
        private System.Windows.Forms.Label LABEL;
        private System.Windows.Forms.ImageList IMGL;
        private System.Windows.Forms.Timer Timg;

    }
}