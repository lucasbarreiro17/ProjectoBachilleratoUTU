namespace Login.FormsAPP.Administrador
{
    partial class PersonalADM
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
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.dgvValidar = new System.Windows.Forms.DataGridView();
            this.btnAceptarUsuario = new System.Windows.Forms.Button();
            this.btnRechazarUsuario = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.lblValidarUsuarios = new System.Windows.Forms.Label();
            this.lblUsuariosRegistrados = new System.Windows.Forms.Label();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblUsuarios.Location = new System.Drawing.Point(40, 10);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(283, 55);
            this.lblUsuarios.TabIndex = 16;
            this.lblUsuarios.Text = "USUARIOS\r\n";
            // 
            // dgvValidar
            // 
            this.dgvValidar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvValidar.Location = new System.Drawing.Point(50, 170);
            this.dgvValidar.Name = "dgvValidar";
            this.dgvValidar.Size = new System.Drawing.Size(580, 180);
            this.dgvValidar.TabIndex = 17;
            // 
            // btnAceptarUsuario
            // 
            this.btnAceptarUsuario.BackColor = System.Drawing.Color.Green;
            this.btnAceptarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAceptarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnAceptarUsuario.Location = new System.Drawing.Point(669, 209);
            this.btnAceptarUsuario.Name = "btnAceptarUsuario";
            this.btnAceptarUsuario.Size = new System.Drawing.Size(150, 40);
            this.btnAceptarUsuario.TabIndex = 18;
            this.btnAceptarUsuario.Text = "Aceptar Usuario";
            this.btnAceptarUsuario.UseVisualStyleBackColor = false;
            this.btnAceptarUsuario.Click += new System.EventHandler(this.btnAceptarUsuario_Click);
            // 
            // btnRechazarUsuario
            // 
            this.btnRechazarUsuario.BackColor = System.Drawing.Color.Maroon;
            this.btnRechazarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechazarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRechazarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnRechazarUsuario.Location = new System.Drawing.Point(669, 280);
            this.btnRechazarUsuario.Name = "btnRechazarUsuario";
            this.btnRechazarUsuario.Size = new System.Drawing.Size(150, 40);
            this.btnRechazarUsuario.TabIndex = 19;
            this.btnRechazarUsuario.Text = "Rechazar Usuario";
            this.btnRechazarUsuario.UseVisualStyleBackColor = false;
            this.btnRechazarUsuario.Click += new System.EventHandler(this.btnRechazarUsuario_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsuarios.Location = new System.Drawing.Point(50, 394);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(580, 171);
            this.dgvUsuarios.TabIndex = 20;
            // 
            // lblValidarUsuarios
            // 
            this.lblValidarUsuarios.AutoSize = true;
            this.lblValidarUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidarUsuarios.ForeColor = System.Drawing.Color.White;
            this.lblValidarUsuarios.Location = new System.Drawing.Point(58, 151);
            this.lblValidarUsuarios.Name = "lblValidarUsuarios";
            this.lblValidarUsuarios.Size = new System.Drawing.Size(124, 16);
            this.lblValidarUsuarios.TabIndex = 21;
            this.lblValidarUsuarios.Text = "Validar Usuarios";
            // 
            // lblUsuariosRegistrados
            // 
            this.lblUsuariosRegistrados.AutoSize = true;
            this.lblUsuariosRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariosRegistrados.ForeColor = System.Drawing.Color.White;
            this.lblUsuariosRegistrados.Location = new System.Drawing.Point(58, 375);
            this.lblUsuariosRegistrados.Name = "lblUsuariosRegistrados";
            this.lblUsuariosRegistrados.Size = new System.Drawing.Size(159, 16);
            this.lblUsuariosRegistrados.TabIndex = 22;
            this.lblUsuariosRegistrados.Text = "Usuarios Registrados";
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.Maroon;
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(669, 458);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(150, 48);
            this.btnEliminarUsuario.TabIndex = 23;
            this.btnEliminarUsuario.Text = "Desactivar Usuario\r\n";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel1.Controls.Add(this.lblUsuarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 100);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 600);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 50);
            this.panel2.TabIndex = 25;
            // 
            // PersonalADM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.lblUsuariosRegistrados);
            this.Controls.Add(this.lblValidarUsuarios);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnRechazarUsuario);
            this.Controls.Add(this.btnAceptarUsuario);
            this.Controls.Add(this.dgvValidar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonalADM";
            this.Text = "Personal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.DataGridView dgvValidar;
        private System.Windows.Forms.Button btnAceptarUsuario;
        private System.Windows.Forms.Button btnRechazarUsuario;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label lblValidarUsuarios;
        private System.Windows.Forms.Label lblUsuariosRegistrados;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}