using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace Login.FormsAPP.Profesor
{
    public partial class MandarInasistencia : Form
    {
        string areaGlobal = "";
        public MandarInasistencia(string areaaaa)
        {
            InitializeComponent();

            FechaInasistencia.Text = "";
            FechaInasistencia.MinDate = DateTime.Now.Date;
            FechaInasistencia.MaxDate = DateTime.Now.Date.AddDays(30);
            areaGlobal = areaaaa;
            if (areaaaa == "Administrador" || areaaaa == "Adscripto")
            {
                comboBox3.Visible = true;
                label6.Visible = true;
                int profesores = CapaDatos.ClaseDatos.ContarProfesores();
                DataTable dt = CapaDatos.ClaseDatos.CargarProfesores();
                string[] tablaprofesores = new string[profesores];
                for (int x = 0; x < profesores; x++)
                {
                    tablaprofesores[x] = dt.Rows[x][0].ToString() + "-" + dt.Rows[x][1].ToString() + " " + dt.Rows[x][2].ToString();
                    comboBox3.Items.Add(tablaprofesores[x]);
                }
                string[] grupos = CapaDatos.ClaseDatos.CargarGrupos();
                for (int x = 0; x < grupos.Length; x++)
                {
                    GruposInasistencia.Items.Add(grupos[x]);
                }
                string[] horariosentrada = CapaDatos.ClaseDatos.CargarHorarioEntrada();
                string[] horariossalida = CapaDatos.ClaseDatos.CargarHorarioSalida();

                for (int x = 0; x < horariosentrada.Length; x++)
                {
                    comboBox1.Items.Add(horariosentrada[x]);
                }
                for (int x = 0; x < horariossalida.Length; x++)
                {
                    comboBox2.Items.Add(horariossalida[x]);
                }
            }
            else
            {
                int CI = CapaDatos.ClaseDatos.CIProfesor();
                comboBox3.Visible = false;
                label6.Visible = false;
                string[] grupos = CapaDatos.ClaseDatos.CargarGruposProf(CI);
                for (int x = 0; x < grupos.Length; x++)
                {
                    GruposInasistencia.Items.Add(grupos[x]);
                }
                string[] horariosentrada = CapaDatos.ClaseDatos.CargarHorarioEntradaProf(CI);
                string[] horariossalida = CapaDatos.ClaseDatos.CargarHorarioSalidaProf(CI);

                for (int x = 0; x < horariosentrada.Length; x++)
                {
                    comboBox1.Items.Add(horariosentrada[x]);
                }
                for (int x = 0; x < horariossalida.Length; x++)
                {
                    comboBox2.Items.Add(horariossalida[x]);
                }
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Falta ingresar una hora de comienzo");
                }
                else
                {


                    if (Motivo.Text == "")
                    {
                        MessageBox.Show("Falta ingresar motivo");
                    }
                    else
                    {
                        if (comboBox2.Text == "")
                        {
                            MessageBox.Show("Falta ingresar una hora de finalizacion");
                        }
                        else
                        {
                            if (GruposInasistencia.Text == "")
                            {
                                MessageBox.Show("Falta ingresar un grupo");
                            }
                            else
                            {
                                if (areaGlobal == "Administrador" || areaGlobal == "Adscripto")
                                {
                                    if (comboBox3.Text == "")
                                    {
                                        MessageBox.Show("Falta ingresar un profesor");
                                    }
                                    else
                                    {
                                        DateTime HoraComienzo = DateTime.ParseExact(comboBox1.Text, "HH:mm:ss", null);
                                        DateTime HoraFinal = DateTime.ParseExact(comboBox2.Text, "HH:mm:ss", null);
                                        DateTime Fecha = DateTime.ParseExact(FechaInasistencia.Text, "yyyy/MM/dd", null);
                                        DateTime ActualFecha = DateTime.Now.Date;
                                        DateTime ActualHora = DateTime.Now;
                                        int resultado1 = DateTime.Compare(Fecha, ActualFecha);
                                        int resultado2 = DateTime.Compare(HoraComienzo, ActualHora);
                                        int resultado = DateTime.Compare(HoraComienzo, HoraFinal);
                                        if (resultado > 0)
                                        {
                                            MessageBox.Show("HORAS INVALIDAS");
                                        }
                                        else
                                        {
                                            char[] cedula = comboBox3.Text.ToCharArray();
                                            string CEDULA = cedula[0].ToString() + cedula[1].ToString() + cedula[2].ToString() + cedula[3].ToString() + cedula[4].ToString() + cedula[5].ToString() + cedula[6].ToString() + cedula[7].ToString();
                                            CapaDatos.ClaseDatos.AvisarInasistenciaADS(CEDULA, Motivo.Text, GruposInasistencia.Text, comboBox1.Text, comboBox2.Text, FechaInasistencia.Text);
                                            MessageBox.Show("Aviso enviado con exito");
                                            Motivo.Text = null;
                                            comboBox1.Text = null;
                                            comboBox2.Text = null;
                                            GruposInasistencia.Text = null;
                                            comboBox3.Text = null;
                                        }
                                    }
                                }
                                else
                                {
                                    DateTime HoraComienzo = DateTime.ParseExact(comboBox1.Text, "HH:mm:ss", null);
                                    DateTime HoraFinal = DateTime.ParseExact(comboBox2.Text, "HH:mm:ss", null);
                                    int resultado = DateTime.Compare(HoraComienzo, HoraFinal);
                                    if (resultado > 0)
                                    {
                                        MessageBox.Show("HORAS INVALIDAS");
                                    }
                                    else
                                    {
                                        CapaDatos.ClaseDatos.AvisarInasistencia(Motivo.Text, GruposInasistencia.Text, comboBox1.Text, comboBox2.Text, FechaInasistencia.Text);
                                        MessageBox.Show("Aviso de inasistencia enviada");
                                        Motivo.Text = null;
                                        comboBox1.Text = null;
                                        comboBox2.Text = null;
                                        GruposInasistencia.Text = null;
                                        comboBox3.Text = null;
                                    }

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta confirmar");
            }
        }

        private void label5_DragLeave(object sender, EventArgs e)
        {

        }

        private void Motivo_Click(object sender, EventArgs e)
        {

        }

        private void Motivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Motivo.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            GruposInasistencia.Text = null;
            comboBox3.Text = null;
        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            CapaDatos.ClaseDatos.ExpirarReservas();
            CapaDatos.ClaseDatos.ExpirarReservas2();
            actualizacion.Start();
        }




    }
}
