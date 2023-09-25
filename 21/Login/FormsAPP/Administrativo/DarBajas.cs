using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP.Administrativo
{
    public partial class DarBajas : Form
    {
        public DarBajas()
        {
            InitializeComponent();
            chMateriales.Checked = true;
            Elementos.ReadOnly = true;
            Reservas.ReadOnly = true;
            Salones.ReadOnly = true;
            actualizacion.Start();
            
            //------------------inasistencias--------------------
            Elementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            /*
            Elementos.Columns[1].HeaderText = "Codigo";
            Elementos.Columns[2].HeaderText = "Cedula";
            Elementos.Columns[3].HeaderText = "IdGrupo";
            Elementos.Columns[4].HeaderText = "Motivo";
            Elementos.Columns[5].HeaderText = "Fecha";
            Elementos.Columns[6].HeaderText = "Inicio";
            Elementos.Columns[7].HeaderText = "Finalizacion";
             */ 
            Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            //------------------reservas-------------------------
            Reservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            /*
            Reservas.Columns[1].HeaderText = "Codigo";
            Reservas.Columns[2].HeaderText = "Cedula";
            Reservas.Columns[3].HeaderText = "Id";
            Reservas.Columns[4].HeaderText = "Fecha";
            Reservas.Columns[5].HeaderText = "Inicio";
            Reservas.Columns[6].HeaderText = "Finalizacion";
             */ 
            Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
            //-------------------reservasalones-------------------
            Salones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            /*
            Salones.Columns[1].HeaderText = "Codigo";
            Salones.Columns[2].HeaderText = "Cedula";
            Salones.Columns[3].HeaderText = "Id";
            Salones.Columns[4].HeaderText = "Fecha";
            Salones.Columns[5].HeaderText = "Inicio";
            Salones.Columns[6].HeaderText = "Finalizacion";
             */ 
            Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();


            Elementos.Columns[3].Width = 233;
            Salones.Columns[3].Width = 133;
            Reservas.Columns[3].Width = 133;
        }

        private void BBajar_Click(object sender, EventArgs e)
        {
            if (Reservas.Rows.Count != 1 && chMateriales.Checked==true)
            {
                String Codigo = Reservas.CurrentRow.Cells["Orden"].Value.ToString();
                CapaDatos.ClaseDatos.EliminarReserva(Codigo);
                MessageBox.Show("Eliminado con exito");
                Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();
                Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
                Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            }
            else if (Salones.Rows.Count != 1 && chSalones.Checked == true)
            {
                string codigo = Salones.CurrentRow.Cells["Orden"].Value.ToString();
                CapaDatos.ClaseDatos.EliminarReserva2(codigo);
                MessageBox.Show("Eliminado con exito");
                Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();
                Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
                Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            }
            else if (Elementos.Rows.Count != 1)
            {
                string codigo = Elementos.CurrentRow.Cells["Cedula"].Value.ToString();
                string grupo = Elementos.CurrentRow.Cells["Grupo"].Value.ToString();
                CapaDatos.ClaseDatos.EliminarFalta(codigo,grupo);
                MessageBox.Show("Eliminado con exito");
                Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();
                Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
                Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "ERROR");
            }
        }

        private void chMateriales_Click(object sender, EventArgs e)
        {
            if(chSalones.Checked == true){
                chSalones.Checked = false;
                Reservas.Visible = true;
                Salones.Visible = false;
            }
            else
            {
                chMateriales.Checked = true;
                Reservas.Visible = true;
            }
            
        }

        private void chSalones_Click(object sender, EventArgs e)
        {
            if(chMateriales.Checked == true){
                chMateriales.Checked = false;
                Reservas.Visible = false;
                Salones.Visible = true;
            }
            else
            {
                chSalones.Checked = true;
                Salones.Visible = true;
            }
            
        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            CapaDatos.ClaseDatos.ExpirarReservas();
            CapaDatos.ClaseDatos.ExpirarReservas2();
            actualizacion.Start();
        }

        private void BValidar_Click(object sender, EventArgs e)
        {
            if (Reservas.Rows.Count != 1 && chMateriales.Checked == true)
            {
                String Codigo = Reservas.CurrentRow.Cells["Orden"].Value.ToString();
                String Validado = Reservas.CurrentRow.Cells["Validado"].Value.ToString();
                CapaDatos.ClaseDatos.ModificarReservaM(Codigo,Validado);
                MessageBox.Show("Modificado con exito");
                Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();
                Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
                Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            }
            else if (Salones.Rows.Count != 1 && chSalones.Checked == true)
            {
                String Codigo = Salones.CurrentRow.Cells["Orden"].Value.ToString();
                String Validado = Salones.CurrentRow.Cells["Validado"].Value.ToString();
                CapaDatos.ClaseDatos.ModificarReservaS(Codigo, Validado);
                MessageBox.Show("Modificado con exito");
                Salones.DataSource = CapaDatos.ClaseDatos.mostrarReservas2();
                Reservas.DataSource = CapaDatos.ClaseDatos.mostrarReservas();
                Elementos.DataSource = CapaDatos.ClaseDatos.mostrarInasistencia();
            }
        }
    }
}
