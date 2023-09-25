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
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
            string[] Asignatura = CapaDatos.ClaseDatos.CargarAsignaturas();
            string[] HorariosEntrada = CapaDatos.ClaseDatos.CargarHorarioEntrada();
            string[] HorariosSalida = CapaDatos.ClaseDatos.CargarHorarioSalida();
            string[] Grupos = CapaDatos.ClaseDatos.CargarGrupos();
            string[] Turnos = new string[5];
            Turnos[0] = "Matutino";
            Turnos[1] = "Vespertino";
            Turnos[2] = "Vespertino inter 1";
            Turnos[3] = "Vespertino inter 2";
            Turnos[4] = "Nocturno";
            string[] Dias = new string[6];
            Dias[0] = "Lunes";
            Dias[1] = "Martes";
            Dias[2] = "Miercoles";
            Dias[3] = "Jueves";
            Dias[4] = "Viernes";
            Dias[5] = "Sabado";
            for (int x = 0; x < Dias.Length; x++)
            {
                comboDia.Items.Add(Dias[x]);
            }
            for (int x = 0; x < Turnos.Length; x++)
            {
                comboTurnos.Items.Add(Turnos[x]);
            }

            for (int x = 0; x < Asignatura.Length; x++)
            {
                comboAsignaturas.Items.Add(Asignatura[x]);
            }
            for (int x = 0; x < HorariosEntrada.Length; x++)
            {

                comboEntrada.Items.Add(HorariosEntrada[x]);
            }
            for (int x = 0; x < HorariosSalida.Length; x++)
            {
                comboSalida.Items.Add(HorariosSalida[x]);
            }
            for (int x = 0; x < Grupos.Length; x++)
            {
                comboGrupo.Items.Add(Grupos[x]);
            }

            DataTable Profesores = CapaDatos.ClaseDatos.MostrarProfesores();
            int cantidad = CapaDatos.ClaseDatos.CantidadProfesores();
            string[] PROF = new string[cantidad];
            for (int x = 0; x < cantidad; x++)
            {
                PROF[x] = "" + Profesores.Rows[x][0].ToString() + "-" + Profesores.Rows[x][1].ToString() + " " + Profesores.Rows[x][2].ToString() + "";
                CBprofesores.Items.Add(PROF[x]);
            }
            for (int x = 0; x < cantidad; x++)
            {
                PROF[x] = "" + Profesores.Rows[x][0].ToString() + "-" + Profesores.Rows[x][1].ToString() + " " + Profesores.Rows[x][2].ToString() + "";
                comboProfesor.Items.Add(PROF[x]);
            }
            string[] Salones = CapaDatos.ClaseDatos.CargarSalones();
            for (int x = 0; x < Salones.Length; x++)
            {
                CBSalon.Items.Add(Salones[x]);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
           
            if (CHasignatura.Checked)
            {
                if (NombreAsignatura.Text != "" && CBprofesores.Text != "")
                {
                    CapaDatos.ClaseDatos.AñadirAsignatura(NombreAsignatura.Text);
                    char[] CedulaDocente = CBprofesores.Text.ToCharArray();
                    string Cedula = CedulaDocente[0].ToString() + CedulaDocente[1].ToString() + CedulaDocente[2].ToString() + CedulaDocente[3].ToString() + CedulaDocente[4].ToString() + CedulaDocente[5].ToString() + CedulaDocente[6].ToString() + CedulaDocente[7].ToString();
                    CapaDatos.ClaseDatos.CargarAsignaturaProfesor(NombreAsignatura.Text, Cedula);
                    MessageBox.Show("Asignatura agregada con exito");
                    ContenedorSalon.Visible = false;
                    ContenedorHorario.Visible = false;
                    ContenedorMaterial.Visible = false;
                    ContenedorAsignatura.Visible = false;
                    CHmaterial.Checked = false;
                    CHhorario.Checked = false;
                    CHsalon.Checked = false;
                    CHasignatura.Checked = false;
                }
                else
                {
                    MessageBox.Show("Los campo no puede estar vacio");
                }
            }
            else if (CHmaterial.Checked)
            {
                if (CodigoMaterial.Text != "" && NombreMaterial.Text != "" && CantidadMaterial.Text != "")
                {
                    int error = CapaDatos.ClaseDatos.AñadirMateriales(CodigoMaterial.Text, NombreMaterial.Text, CantidadMaterial.Text);
                    if (error == 1)
                    {
                        MessageBox.Show("Error al cargar el material,verifique la informacion ingresada");
                    }
                    else
                    {
                        MessageBox.Show("Material agregado con exito");
                        ContenedorSalon.Visible = false;
                        ContenedorHorario.Visible = false;
                        ContenedorMaterial.Visible = false;
                        ContenedorAsignatura.Visible = false;
                        CHmaterial.Checked = false;
                        CHhorario.Checked = false;
                        CHsalon.Checked = false;
                        CHasignatura.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }
            }
            else if (CHhorario.Checked)
            {
                if (comboAsignaturas.Text != "" && comboEntrada.Text != "" && comboSalida.Text != "" && comboGrupo.Text != "" && comboProfesor.Text != "" && comboTurnos.Text != "" && comboDia.Text != "")
                {
                    char[] CedulaDocente = comboProfesor.Text.ToCharArray();
                    string Cedula = CedulaDocente[0].ToString() + CedulaDocente[1].ToString() + CedulaDocente[2].ToString() + CedulaDocente[3].ToString() + CedulaDocente[4].ToString() + CedulaDocente[5].ToString() + CedulaDocente[6].ToString() + CedulaDocente[7].ToString();
                    string IdAsignatura = CapaDatos.ClaseDatos.IdAsignatura(comboAsignaturas.Text, Cedula);
                    if (IdAsignatura == "ERROR")
                    {
                        MessageBox.Show("Verifique que el profesor ingresado de la materia " + comboAsignaturas.Text + "", "ERROR");
                    }
                    else
                    {

                        string IdHorario = CapaDatos.ClaseDatos.IdHorario(comboEntrada.Text, comboSalida.Text, comboTurnos.Text);
                        if (IdHorario == "ERROR")
                        {
                            MessageBox.Show("Verifique que las horas correspondan al turno ingresado", "ERROR");
                        }
                        else
                        {
                            string existe = CapaDatos.ClaseDatos.CheckCargarAsignaturaProfesor(comboAsignaturas.Text, Cedula);
                            if (existe != "")
                            {
                                string[] CodigosHorarios = CapaDatos.ClaseDatos.CodigosHorarios(comboEntrada.Text, comboSalida.Text, comboTurnos.Text);
                                string error = "";
                                for (int x = 0; x<CodigosHorarios.Length; x++)
                                {
                                    error = CapaDatos.ClaseDatos.AñadirHorario(comboGrupo.Text, CodigosHorarios[x], IdAsignatura, comboDia.Text);
                                }
                                if (error == "1")
                                {


                                    CapaDatos.ClaseDatos.CargarExtras(comboGrupo.Text, IdAsignatura, CodigosHorarios, comboDia.Text, Cedula);




                                    MessageBox.Show("Horario agregado con exito");
                                    comboAsignaturas.Text = "";
                                    comboDia.Text = "";
                                    comboEntrada.Text = "";
                                    comboSalida.Text = "";
                                    comboTurnos.Text = "";
                                    comboGrupo.Text = "";
                                    comboProfesor.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Verifique que los horarios no esten ya ocupados"+error+"", "ERROR");
                                }

                            }
                            else
                            {
                                MessageBox.Show("El profesor no da esta materia");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }
            }
            else if (CHsalon.Checked)
            {
                if (CodigoSalon.Text != "" && NumeroSalon.Text != "" && NombreSalon.Text != "" && CapacidadSalon.Text != "")
                {
                    CapaDatos.ClaseDatos.AñadirSalones(CodigoSalon.Text, NumeroSalon.Text, NombreSalon.Text, CapacidadSalon.Text);
                    MessageBox.Show("Salon agregado con exito");
                    NumeroSalon.Text = "";
                    NombreSalon.Text = "";
                    CodigoSalon.Text = "";
                    CapacidadSalon.Text = "";
                }

                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }
            }
            else if (CHGrupo.Checked)
            {
                if (txtNombre.Text != "" && txtSiglas.Text != "" && CBSalon.Text != "")
                {
                    string error = CapaDatos.ClaseDatos.AñadirGrupo(txtNombre.Text, txtSiglas.Text, CBSalon.Text);
                    if (error != "1")
                    {
                        MessageBox.Show("Error al cargar grupo,el grupo " + txtSiglas.Text + " ya existe:"+error+"");
                    }
                    else
                    {
                        
                        MessageBox.Show("Grupo agregado con exito");
                        txtSiglas.Text = "";
                        txtNombre.Text = "";
                        CBSalon.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }
            }
        }
        private void CHasignatura_Click(object sender, EventArgs e)
        {
            ContenedorSalon.Visible = false;
            ContenedorHorario.Visible = false;
            ContenedorMaterial.Visible = false;
            ContenedorAsignatura.Visible = true;
            ContenedorGrupo.Visible = false;
            //
            CHGrupo.Checked = false;
            CHmaterial.Checked = false;
            CHhorario.Checked = false;
            CHsalon.Checked = false;
            CHasignatura.Checked = true;
        }

        private void CHmaterial_Click(object sender, EventArgs e)
        {
            ContenedorSalon.Visible = false;
            ContenedorHorario.Visible = false;
            ContenedorMaterial.Visible = true;
            ContenedorAsignatura.Visible = false;
            ContenedorGrupo.Visible = false;
            //
            CHGrupo.Checked = false;
            CHasignatura.Checked = false;
            CHhorario.Checked = false;
            CHsalon.Checked = false;
            CHmaterial.Checked = true;
        }

        private void CHhorario_Click(object sender, EventArgs e)
        {
            ContenedorSalon.Visible = false;
            ContenedorHorario.Visible = true;
            ContenedorMaterial.Visible = false;
            ContenedorAsignatura.Visible = false;
            ContenedorGrupo.Visible = false;
            //
            CHGrupo.Checked = false;
            CHasignatura.Checked = false;
            CHmaterial.Checked = false;
            CHsalon.Checked = false;
            CHhorario.Checked = true;
        }

        private void CHsalon_Click(object sender, EventArgs e)
        {
            ContenedorSalon.Visible = true;
            ContenedorHorario.Visible = false;
            ContenedorMaterial.Visible = false;
            ContenedorAsignatura.Visible = false;
            ContenedorGrupo.Visible = false;
            //
            CHGrupo.Checked = false;
            CHhorario.Checked = false;
            CHmaterial.Checked = false;
            CHasignatura.Checked = false;
            CHsalon.Checked = true;
        }

        private void CHGrupo_Click(object sender, EventArgs e)
        {
            ContenedorSalon.Visible = false;
            ContenedorHorario.Visible = false;
            ContenedorMaterial.Visible = false;
            ContenedorAsignatura.Visible = false;
            ContenedorGrupo.Visible = true;
            //
            CHGrupo.Checked = true;
            CHhorario.Checked = false;
            CHmaterial.Checked = false;
            CHasignatura.Checked = false;
            CHsalon.Checked = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Actualizar_Tick(object sender, EventArgs e)
        {
            Actualizar.Stop();
            string turno = comboTurnos.Text;
            if (turno != "")
            {
                string[] HorariosEntrada = CapaDatos.ClaseDatos.CargarHorarioEntradaPorTurno(turno);
                string[] HorariosSalida = CapaDatos.ClaseDatos.CargarHorarioSalidaPorTurno(turno);
                comboEntrada.Items.Clear();
                comboSalida.Items.Clear();
                for (int x = 0; x < HorariosEntrada.Length; x++)
                {

                    comboEntrada.Items.Add(HorariosEntrada[x]);
                }
                for (int x = 0; x < HorariosSalida.Length; x++)
                {
                    comboSalida.Items.Add(HorariosSalida[x]);
                }

            }
            
        }

        private void comboTurnos_Enter(object sender, EventArgs e)
        {
         
        }

        private void comboTurnos_Leave(object sender, EventArgs e)
        {
            Actualizar.Start();
        }

     


    }
}
