using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP.Administrador
{
    public partial class PersonalADM : Form
    {
        public PersonalADM()
        {
            InitializeComponent();
            dgvValidar.DataSource = CapaDatos.ClaseDatos.CargarUsuariosAValidar();
            dgvUsuarios.DataSource = CapaDatos.ClaseDatos.CargarUsuarios();
            dgvValidar.ReadOnly = true;
            dgvUsuarios.ReadOnly = true;
            dgvValidar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvValidar.Columns[2].HeaderText = "Nombre";
            dgvValidar.Columns[3].HeaderText = "Apellido";
            dgvUsuarios.Columns[2].HeaderText = "Nombre";
            dgvUsuarios.Columns[3].HeaderText = "Apellido";
        }

        private void btnAceptarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvValidar.Rows.Count != 1)
            {
                String Cedula = dgvValidar.CurrentRow.Cells["Cedula"].Value.ToString();
                String Contraseña = dgvValidar.CurrentRow.Cells["Contraseña"].Value.ToString();
                String Nombre = dgvValidar.CurrentRow.Cells["FirstName"].Value.ToString();
                String Apellido = dgvValidar.CurrentRow.Cells["LastName"].Value.ToString();
                String Email = dgvValidar.CurrentRow.Cells["Email"].Value.ToString();
                String Posicion = dgvValidar.CurrentRow.Cells["Posicion"].Value.ToString();
                String Contacto = dgvValidar.CurrentRow.Cells["Contacto"].Value.ToString();
                CapaDatos.ClaseDatos.CargarUsuario(Cedula, Nombre, Apellido, Email, Contraseña, Contacto, Posicion);
                CapaDatos.ClaseDatos.CargarRol(Posicion, Nombre, Apellido, Cedula);
                MessageBox.Show("Usuario cargado con exito");
                CapaDatos.ClaseDatos.RechazarUsuario(Cedula);
                dgvValidar.DataSource = CapaDatos.ClaseDatos.CargarUsuariosAValidar();
                dgvUsuarios.DataSource = CapaDatos.ClaseDatos.CargarUsuarios();

            }
            else
            {
                MessageBox.Show("Seleccione una fila", "ERROR");
            }
        }

        private void btnRechazarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvValidar.Rows.Count != 1)
            {
                String Cedula = dgvValidar.CurrentRow.Cells["Cedula"].Value.ToString();
                CapaDatos.ClaseDatos.RechazarUsuario(Cedula);
                MessageBox.Show("Usuario rechazado");
                dgvValidar.DataSource = CapaDatos.ClaseDatos.CargarUsuariosAValidar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "ERROR");
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count != 1)
            {
                String Cedula = dgvUsuarios.CurrentRow.Cells["Cedula"].Value.ToString();
                CapaDatos.ClaseDatos.EliminarUsuario(Cedula);
                MessageBox.Show("Usuario Desactivado con exito");
                dgvUsuarios.DataSource = CapaDatos.ClaseDatos.CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "ERROR");
            }
        }


    }
}
