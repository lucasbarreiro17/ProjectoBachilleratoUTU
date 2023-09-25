using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP.Alumno
{
    public partial class HorariosA : Form
    {
        string areaglobal = null;
        public HorariosA(string area)
        {
            InitializeComponent();
            string[] DIAS = new string[6];
            DIAS[0] = "Lunes";
            DIAS[1] = "Martes";
            DIAS[2] = "Miercoles";
            DIAS[3] = "Jueves";
            DIAS[4] = "Viernes";
            DIAS[5] = "Sabado";
            for (int x = 0; x < DIAS.Length; x++)
            {
                Dias.Items.Add(DIAS[x]);
            }
            string[] Turnos = new string[5];
            Turnos[0] = "Matutino";
            Turnos[1] = "Vespertino";
            Turnos[2] = "Vespertino inter 1";
            Turnos[3] = "Vespertino inter 2";
            Turnos[4] = "Nocturno";
            for (int x = 0; x < Turnos.Length; x++)
            {
                comboBox1.Items.Add(Turnos[x]);
            }
            areaglobal = area;
        }

        private void Bmostrar_Click(object sender, EventArgs e)
        {


            if (Dias.Text != "" && comboBox1.Text != "")
            {
                if (areaglobal == "Administrativo" || areaglobal == "Administrador" || areaglobal == "Adscripto")
                {
                    dgvHorarios.DataSource = CapaDatos.ClaseDatos.MostrarHorariosGeneral(Dias.Text, comboBox1.Text);
                    dgvHorarios.ClearSelection();

                }
                else
                {
                    dgvHorarios.DataSource = CapaDatos.ClaseDatos.MostrarHorarios(Dias.Text, comboBox1.Text);
                    dgvHorarios.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Seleccione Dia y Turno");
            }

        }
    }
}
