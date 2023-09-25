namespace Login.FormsAPP
{
    partial class OPCIONES
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
            this.panelok = new System.Windows.Forms.Panel();
            this.PanelC = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Ayuda = new System.Windows.Forms.WebBrowser();
            this.Alertas = new System.Windows.Forms.CheckBox();
            this.inumet = new System.Windows.Forms.WebBrowser();
            this.panelok.SuspendLayout();
            this.PanelC.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelok
            // 
            this.panelok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.panelok.Controls.Add(this.inumet);
            this.panelok.Controls.Add(this.Alertas);
            this.panelok.Controls.Add(this.PanelC);
            this.panelok.Controls.Add(this.label1);
            this.panelok.Controls.Add(this.checkBox2);
            this.panelok.Controls.Add(this.Ayuda);
            this.panelok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelok.Location = new System.Drawing.Point(0, 0);
            this.panelok.Name = "panelok";
            this.panelok.Size = new System.Drawing.Size(900, 650);
            this.panelok.TabIndex = 1;
            // 
            // PanelC
            // 
            this.PanelC.BackColor = System.Drawing.Color.White;
            this.PanelC.Controls.Add(this.label2);
            this.PanelC.Location = new System.Drawing.Point(43, 108);
            this.PanelC.Name = "PanelC";
            this.PanelC.Size = new System.Drawing.Size(783, 52);
            this.PanelC.TabIndex = 4;
            this.PanelC.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(220, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "MANUAL DE USUARIO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "- Ayuda para el uso de la app, para aquellos usuarios que tengan dudas.";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(43, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(97, 29);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Ayuda";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Ayuda
            // 
            this.Ayuda.Location = new System.Drawing.Point(43, 108);
            this.Ayuda.MinimumSize = new System.Drawing.Size(20, 20);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(800, 464);
            this.Ayuda.TabIndex = 1;
            this.Ayuda.Url = new System.Uri("https://drive.google.com/file/d/10dX9phWMI_P6g7tJE_WDHLZ29LQvBshX/view", System.UriKind.Absolute);
            this.Ayuda.Visible = false;
            // 
            // Alertas
            // 
            this.Alertas.AutoSize = true;
            this.Alertas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alertas.ForeColor = System.Drawing.Color.White;
            this.Alertas.Location = new System.Drawing.Point(43, 147);
            this.Alertas.Name = "Alertas";
            this.Alertas.Size = new System.Drawing.Size(365, 29);
            this.Alertas.TabIndex = 5;
            this.Alertas.Text = "Verificar alertas metereologicas";
            this.Alertas.UseVisualStyleBackColor = true;
            this.Alertas.CheckedChanged += new System.EventHandler(this.Alertas_CheckedChanged);
            // 
            // inumet
            // 
            this.inumet.Location = new System.Drawing.Point(43, 186);
            this.inumet.MinimumSize = new System.Drawing.Size(20, 20);
            this.inumet.Name = "inumet";
            this.inumet.Size = new System.Drawing.Size(800, 464);
            this.inumet.TabIndex = 6;
            this.inumet.Url = new System.Uri("https://www.inumet.gub.uy/alerta", System.UriKind.Absolute);
            this.inumet.Visible = false;
            // 
            // OPCIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panelok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OPCIONES";
            this.Text = "Opciones";
            this.panelok.ResumeLayout(false);
            this.panelok.PerformLayout();
            this.PanelC.ResumeLayout(false);
            this.PanelC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.WebBrowser Ayuda;
        private System.Windows.Forms.Panel PanelC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Alertas;
        private System.Windows.Forms.WebBrowser inumet;
    }
}