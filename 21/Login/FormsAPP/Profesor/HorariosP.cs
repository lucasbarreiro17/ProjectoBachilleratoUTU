using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP.Profesor
{
    public partial class HorariosP : Form
    {
        string areaglobal = null;
        public HorariosP(string area)
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
                comboTurno.Items.Add(Turnos[x]);
            }
            areaglobal = area;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Dias.Text != "" && comboTurno.Text != "")
            {
                if (areaglobal == "Administrativo" || areaglobal == "Administrador" || areaglobal == "Adscripto")
                {
                    dgvHorarios.DataSource = CapaDatos.ClaseDatos.MostrarHorariosGeneral(Dias.Text, comboTurno.Text);
                    dgvHorarios.ClearSelection();
                    dgvHorarios.Columns[2].HeaderText = "Entrada";
                    dgvHorarios.Columns[3].HeaderText = "Salida";
                }
                else
                {
                    dgvHorarios.DataSource = CapaDatos.ClaseDatos.MostrarHorariosProfesor(Dias.Text, comboTurno.Text);
                    dgvHorarios.ClearSelection();
                    dgvHorarios.Columns[3].HeaderText = "Salida";
                }
            }
            else
            {
                MessageBox.Show("Ingrese dia y turno");
            }
        }
    }
}
