namespace Login.FormsAPP.Administrador
{
    partial class Salones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV_Salones = new System.Windows.Forms.DataGridView();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboDia = new System.Windows.Forms.ComboBox();
            this.Bmostrar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Salones)).BeginInit();
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
            this.label2.Size = new System.Drawing.Size(382, 82);
            this.label2.TabIndex = 18;
            this.label2.Text = "SALONES";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 923);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 77);
            this.panel2.TabIndex = 1;
            // 
            // DGV_Salones
            // 
            this.DGV_Salones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Salones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_Salones.Location = new System.Drawing.Point(26, 174);
            this.DGV_Salones.Name = "DGV_Salones";
            this.DGV_Salones.RowTemplate.Height = 28;
            this.DGV_Salones.Size = new System.Drawing.Size(1302, 674);
            this.DGV_Salones.TabIndex = 2;
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(123, 868);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(127, 28);
            this.comboTurno.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(39, 868);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Turno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(291, 868);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dia:";
            // 
            // comboDia
            // 
            this.comboDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDia.FormattingEnabled = true;
            this.comboDia.Location = new System.Drawing.Point(351, 868);
            this.comboDia.Name = "comboDia";
            this.comboDia.Size = new System.Drawing.Size(121, 28);
            this.comboDia.TabIndex = 5;
            // 
            // Bmostrar
            // 
            this.Bmostrar.BackColor = System.Drawing.Color.Green;
            this.Bmostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bmostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bmostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Bmostrar.ForeColor = System.Drawing.Color.White;
            this.Bmostrar.Location = new System.Drawing.Point(528, 855);
            this.Bmostrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Bmostrar.Name = "Bmostrar";
            this.Bmostrar.Size = new System.Drawing.Size(225, 62);
            this.Bmostrar.TabIndex = 20;
            this.Bmostrar.Text = "Mostrar Salones\r\n";
            this.Bmostrar.UseVisualStyleBackColor = false;
            this.Bmostrar.Click += new System.EventHandler(this.Bmostrar_Click);
            // 
            // Salones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(114)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1350, 1000);
            this.Controls.Add(this.Bmostrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboDia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.DGV_Salones);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Salones";
            this.Text = "Salones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Salones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGV_Salones;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboDia;
        private System.Windows.Forms.Button Bmostrar;
    }
}