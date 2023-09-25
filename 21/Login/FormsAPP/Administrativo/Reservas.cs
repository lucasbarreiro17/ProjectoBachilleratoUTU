using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CapaDatos;

namespace Login.FormsAPP.Administrativo
{
    public partial class Reservas : Form
    {
        string turno = "yeyeye";

        public Reservas()
        {
            InitializeComponent();
            dateTimePicker1.Text = "";
            dateTimePicker1.MinDate = DateTime.Now.Date;
            dateTimePicker1.MaxDate = DateTime.Now.Date.AddDays(14);
            CapaDatos.ClaseDatos.LiberarReservas();
            sqlsalones();
            CapaDatos.ClaseDatos.CargarSalones();
            CapaDatos.ClaseDatos.CargarMateriales();
            string[] salones = CapaDatos.ClaseDatos.CargarSalones();
            string[] materiales = CapaDatos.ClaseDatos.CargarMateriales();
            string[] horariosreserva = CapaDatos.ClaseDatos.CargarHorarioEntrada();
            string[] horariossalida = CapaDatos.ClaseDatos.CargarHorarioSalida();
            for (int x = 0; x < salones.Length; x++)
            {
                comboBox1.Items.Add(salones[x]);
            }
            for (int x = 0; x < materiales.Length; x++)
            {
                comboBox2.Items.Add(materiales[x]);
            }
            for (int x = 0; x < horariosreserva.Length; x++)
            {
                comboBox3.Items.Add(horariosreserva[x]);
            }
            for (int x = 0; x < horariossalida.Length; x++)
            {
                comboBox4.Items.Add(horariossalida[x]);
            }
            string[] Turnos = new string[5];
            Turnos[0] = "Matutino";
            Turnos[1] = "Vespertino";
            Turnos[2] = "Vespertino inter 1";
            Turnos[3] = "Vespertino inter 2";
            Turnos[4] = "Nocturno";
            for (int x = 0; x < Turnos.Length; x++)
            {
                comboBox5.Items.Add(Turnos[x]);
            }
            actualizacion.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && comboBox2.Text == "")
            {
                MessageBox.Show("No esta reservando nada");
            }
            else
            {
                int error = 0;
                if (ConfirmarReserva.Checked)
                {
                    error = 0;
                    if (comboBox1.Text != "")
                    {
                        if (comboBox3.Text == "")
                        {
                            MessageBox.Show("Falta ingresar una hora de comienzo");
                            error = 1;
                        }
                        else
                        {
                            if (comboBox4.Text == "")
                            {
                                MessageBox.Show("Falta ingresar una hora de finalizacion");
                                error = 1;
                            }
                            else
                            {
                                DateTime HoraComienzo = DateTime.ParseExact(comboBox3.Text, "HH:mm:ss", null);
                                DateTime HoraFinal = DateTime.ParseExact(comboBox4.Text, "HH:mm:ss", null);
                                DateTime Fecha = DateTime.ParseExact(dateTimePicker1.Text, "yyyy/MM/dd", null);
                                DateTime ActualFecha = DateTime.Now.Date;
                                DateTime ActualHora = DateTime.Now;
                                int resultado1 = DateTime.Compare(HoraComienzo, HoraFinal);
                                if (resultado1 > 0)
                                {
                                    MessageBox.Show("Hora Invalida");
                                    error = 1;
                                }
                                else
                                {


                                    try
                                    {
                                        ClaseDatos.ReservarSalon(comboBox1.SelectedItem.ToString(), dateTimePicker1.Text, comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString());
                                        MessageBox.Show("Solicitud de reserva de salon realizada con exito");
                                        comboBox1.Text = null;
                                        comboBox2.Text = null;
                                        comboBox3.Text = null;
                                        comboBox4.Text = null;
                                    }
                                    catch (SystemException ex)
                                    {
                                        MessageBox.Show("Datos Invalidos" + ex + "", "ERROR");
                                    }

                                }
                            }
                        }
                    }
                    if (error == 0)
                    {
                        if (comboBox2.Text != "")
                        {
                            if (comboBox3.Text == "")
                            {
                                MessageBox.Show("Falta ingresar una hora de comienzo");
                            }
                            else
                            {
                                if (comboBox4.Text == "")
                                {
                                    MessageBox.Show("Falta ingresar una hora de finalizacion");
                                }
                                else
                                {
                                    DateTime HoraComienzo = DateTime.ParseExact(comboBox3.Text, "HH:mm:ss", null);
                                    DateTime HoraFinal = DateTime.ParseExact(comboBox4.Text, "HH:mm:ss", null);
                                    DateTime Fecha = DateTime.ParseExact(dateTimePicker1.Text, "yyyy/MM/dd", null);
                                    int resultado1 = DateTime.Compare(HoraComienzo, HoraFinal);
                                    if (resultado1 > 0)
                                    {
                                        MessageBox.Show("Hora Invalida");
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ClaseDatos.ReservarMaterial(comboBox2.SelectedItem.ToString(), dateTimePicker1.Text, comboBox3.SelectedItem.ToString(), comboBox4.SelectedItem.ToString());
                                            MessageBox.Show("Solicitud de reserva de material realizada con exito");
                                        }
                                        catch (SystemException ex)
                                        {
                                            MessageBox.Show("Datos Invalidos" + ex + "", "ERROR");
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
        }

        private void sqlsalones()
        {
            /* 
             MySqlConnection conexion = new MySqlConnection("server=localhost; database=login; uid=root; pwd=Nicolas911; port=3306");
             comboBox1.DataSource = null;
             comboBox1.Items.Clear();
             string sql = "SELECT IdNumeroSalon, IdNombre FROM reserva_salones ORDER BY IdNombre ASC";
             MySqlConnection con = conexion;
             con.Open();
             try
             {
                 MySqlCommand comand = new MySqlCommand(sql, con);
                 MySqlDataAdapter data = new MySqlDataAdapter(comand);
                 DataTable dt = new DataTable();
                 data.Fill(dt);
                 comboBox1.ValueMember = "IdNumeroSalon";
                 comboBox1.DisplayMember = "IdNombre";
                 comboBox1.DataSource = dt;

             }catch(MySqlException ex){
                 MessageBox.Show("error al cargar" + ex.Message);
             }
             finally
             {
                 con.Close();
             }
          */
            //hacer funcionar para cargar el combo box de salones (si funciona ya se puede copiar y pegar en todo combobox existente en el planeta tierra la puta madre)
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e, DataTable DaTa)
        {
            /*
            string[] Reservas = new string[100];
            for (int y = 0; y < 100; y++)
            {
                Reservas[y] = DaTa.Rows[y][0].ToString(); ;
                comboBox1.ValueMember = DaTa.Rows[y][1].ToString();
                comboBox1.DisplayMember = DaTa.Rows[y][0].ToString();
                comboBox1.DataSource = DaTa;
            }
             */




        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            string[] Reservas = new string[100];
            for (int y = 0; y < 100; y++)
            {
                Reservas[y] = DaTa.Rows[y][1].ToString(); ;
                comboBox1.Items.Add(Reservas[y]);
            }
             */
            /*
            for (int x = 0; x < NumeroMateriales; x++)
            {
                MATERIALES[x] = dtMateriales.Rows[x][0].ToString() + "-" + dtMateriales.Rows[x][1].ToString();
                Console.WriteLine(MATERIALES[x]);
            }
            comboBox2.DataSource = CapaDatos.ClaseDatos.CargarMateriales(conexion);
            */


        }

        private void ReservasADI_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            string[] Entrada = CapaDatos.ClaseDatos.CargarHorarioEntradaPorTurno(comboBox5.Text);
            string[] Salida = CapaDatos.ClaseDatos.CargarHorarioSalidaPorTurno(comboBox5.Text);
            if (comboBox5.Text != turno)
            {
                comboBox3.Items.Clear();
                for (int x = 0; x < Entrada.Length; x++)
                {
                    comboBox3.Items.Add(Entrada[x]);
                }
            }
            if (comboBox5.Text != turno)
            {
                comboBox4.Items.Clear();
                for (int x = 0; x < Salida.Length; x++)
                {
                    comboBox4.Items.Add(Salida[x]);
                }
            }
            CapaDatos.ClaseDatos.ExpirarReservas();
            CapaDatos.ClaseDatos.ExpirarReservas2();
            turno = comboBox5.Text;
            actualizacion.Start();
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            actualizacion.Start();
        }




    }//hacer lo mismo pero con los materiales
}
