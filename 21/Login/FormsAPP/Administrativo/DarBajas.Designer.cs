namespace Login.FormsAPP.Administrativo
{
    partial class DarBajas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Elementos = new System.Windows.Forms.DataGridView();
            this.BBajar = new System.Windows.Forms.Button();
            this.Reservas = new System.Windows.Forms.DataGridView();
            this.lblUsuariosRegistrados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Salones = new System.Windows.Forms.DataGridView();
            this.chMateriales = new System.Windows.Forms.CheckBox();
            this.chSalones = new System.Windows.Forms.CheckBox();
            this.actualizacion = new System.Windows.Forms.Timer(this.components);
            this.BValidar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Elementos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Salones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 154);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 82);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dar de Baja";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 923);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 77);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Seleccione los datos y aprete el boton rojo para eliminarlos";
            // 
            // Elementos
            // 
            this.Elementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Elementos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Elementos.Location = new System.Drawing.Point(18, 208);
            this.Elementos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Elementos.Name = "Elementos";
            this.Elementos.Size = new System.Drawing.Size(1314, 262);
            this.Elementos.TabIndex = 18;
            // 
            // BBajar
            // 
            this.BBajar.BackColor = System.Drawing.Color.Maroon;
            this.BBajar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.BBajar.ForeColor = System.Drawing.Color.White;
            this.BBajar.Location = new System.Drawing.Point(1097, 808);
            this.BBajar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BBajar.Name = "BBajar";
            this.BBajar.Size = new System.Drawing.Size(225, 62);
            this.BBajar.TabIndex = 19;
            this.BBajar.Text = "ELIMINAR";
            this.BBajar.UseVisualStyleBackColor = false;
            this.BBajar.Click += new System.EventHandler(this.BBajar_Click);
            // 
            // Reservas
            // 
            this.Reservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Reservas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Reservas.Location = new System.Drawing.Point(18, 515);
            this.Reservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Reservas.Name = "Reservas";
            this.Reservas.Size = new System.Drawing.Size(1314, 262);
            this.Reservas.TabIndex = 20;
            // 
            // lblUsuariosRegistrados
            // 
            this.lblUsuariosRegistrados.AutoSize = true;
            this.lblUsuariosRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariosRegistrados.ForeColor = System.Drawing.Color.White;
            this.lblUsuariosRegistrados.Location = new System.Drawing.Point(18, 178);
            this.lblUsuariosRegistrados.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuariosRegistrados.Name = "lblUsuariosRegistrados";
            this.lblUsuariosRegistrados.Size = new System.Drawing.Size(138, 25);
            this.lblUsuariosRegistrados.TabIndex = 23;
            this.lblUsuariosRegistrados.Text = "Inasistencias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 486);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Reservas";
            // 
            // Salones
            // 
            this.Salones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Salones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Salones.Location = new System.Drawing.Point(18, 515);
            this.Salones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Salones.Name = "Salones";
            this.Salones.Size = new System.Drawing.Size(1314, 262);
            this.Salones.TabIndex = 25;
            this.Salones.Visible = false;
            // 
            // chMateriales
            // 
            this.chMateriales.AutoSize = true;
            this.chMateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.chMateriales.ForeColor = System.Drawing.Color.White;
            this.chMateriales.Location = new System.Drawing.Point(22, 786);
            this.chMateriales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chMateriales.Name = "chMateriales";
            this.chMateriales.Size = new System.Drawing.Size(138, 29);
            this.chMateriales.TabIndex = 26;
            this.chMateriales.Text = "Materiales";
            this.chMateriales.UseVisualStyleBackColor = true;
            this.chMateriales.Click += new System.EventHandler(this.chMateriales_Click);
            // 
            // chSalones
            // 
            this.chSalones.AutoSize = true;
            this.chSalones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.chSalones.ForeColor = System.Drawing.Color.White;
            this.chSalones.Location = new System.Drawing.Point(22, 826);
            this.chSalones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chSalones.Name = "chSalones";
            this.chSalones.Size = new System.Drawing.Size(117, 29);
            this.chSalones.TabIndex = 27;
            this.chSalones.Text = "Salones";
            this.chSalones.UseVisualStyleBackColor = true;
            this.chSalones.Click += new System.EventHandler(this.chSalones_Click);
            // 
            // actualizacion
            // 
            this.actualizacion.Interval = 10000;
            this.actualizacion.Tick += new System.EventHandler(this.actualizacion_Tick);
            // 
            // BValidar
            // 
            this.BValidar.BackColor = System.Drawing.Color.ForestGreen;
            this.BValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.BValidar.ForeColor = System.Drawing.Color.White;
            this.BValidar.Location = new System.Drawing.Point(838, 808);
            this.BValidar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BValidar.Name = "BValidar";
            this.BValidar.Size = new System.Drawing.Size(225, 62);
            this.BValidar.TabIndex = 28;
            this.BValidar.Text = "VALIDAR";
            this.BValidar.UseVisualStyleBackColor = false;
            this.BValidar.Click += new System.EventHandler(this.BValidar_Click);
            // 
            // DarBajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1350, 1000);
            this.Controls.Add(this.BValidar);
            this.Controls.Add(this.chSalones);
            this.Controls.Add(this.chMateriales);
            this.Controls.Add(this.Salones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUsuariosRegistrados);
            this.Controls.Add(this.Reservas);
            this.Controls.Add(this.BBajar);
            this.Controls.Add(this.Elementos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DarBajas";
            this.Text = "DarBajas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Elementos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Salones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BBajar;
        private System.Windows.Forms.Label lblUsuariosRegistrados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chMateriales;
        private System.Windows.Forms.CheckBox chSalones;
        private System.Windows.Forms.Timer actualizacion;
        private System.Windows.Forms.Button BValidar;
        public System.Windows.Forms.DataGridView Elementos;
        public System.Windows.Forms.DataGridView Reservas;
        public System.Windows.Forms.DataGridView Salones;
    }
}