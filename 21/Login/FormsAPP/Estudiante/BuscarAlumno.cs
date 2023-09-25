using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP.Adscripto
{
    public partial class BuscarAlumno : Form
    {
        public BuscarAlumno()
        {
            InitializeComponent();
            string[] horariosreserva = CapaDatos.ClaseDatos.CargarHorarioEntrada();
            string[] horariossalida = CapaDatos.ClaseDatos.CargarHorarioSalida();
            string[] horarios = new string[horariosreserva.Length];
            for (int x = 0; x < horariosreserva.Length; x++)
            {
                horarios[x] = horariosreserva[x] + "-" + horariossalida[x];
            }
            for (int x = 0; x < horarios.Length; x++)
            {
                comboHorario.Items.Add(horarios[x]);
            }
            string[] DIAS = new string[6];
            DIAS[0] = "Lunes";
            DIAS[1] = "Martes";
            DIAS[2] = "Miercoles";
            DIAS[3] = "Jueves";
            DIAS[4] = "Viernes";
            DIAS[5] = "Sabado";
            for (int x = 0; x < DIAS.Length; x++)
            {
                comboDias.Items.Add(DIAS[x]);
            }


        }

        private void BusarBoton_Click(object sender, EventArgs e)
        {
            DataTable Ver = new DataTable();
            int error = 0;
            try
            {
                char[] horarios = comboHorario.Text.ToCharArray();
                string Hentrada = "" + horarios[0].ToString() + horarios[1].ToString() + horarios[2].ToString() + horarios[3].ToString() + horarios[4].ToString() + "";
                Ver = CapaDatos.ClaseDatos.BuscarAlumnoMetodo(comboDias.Text, Hentrada, BuscarCI.Text);
                error = 0;
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Falta ingresar los datos", "Error");
                error = 1;
            }

            if (error == 0)
            {
                try
                {
                    string salon = Ver.Rows[0][3].ToString();
                    string profesor = Ver.Rows[0][1].ToString();
                    string asignatura = Ver.Rows[0][2].ToString();
                    string grupo = Ver.Rows[0][0].ToString();
                    string contacto = Ver.Rows[0][4].ToString();
                    // muestro los datos:
                    LnomGrupo.Text = "" + grupo + "";
                    LnomAsignatura.Text = "" + asignatura + "";
                    LnomProfesor.Text = "" + profesor + "";
                    LnomSalon.Text = "" + salon + "";
                    Lnum1.Text = "" + contacto + "";
                }
                catch (SystemException ex)
                {
                    MessageBox.Show("El alumno no se encuentra en el centro educativo", "Error");
                }
            }
        }
    }
}
