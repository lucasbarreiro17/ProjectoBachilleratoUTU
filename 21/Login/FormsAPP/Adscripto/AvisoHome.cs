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
    public partial class AvisoHome : Form
    {
        public AvisoHome()
        {
            InitializeComponent();
            actualizacion.Start();
            DateTime F = DateTime.Now.Date;
            string fecha = F.ToString("yyyy/MM/dd");
            //CapaDatos.ClaseDatos.
            string[] cargarTB = CapaDatos.ClaseDatos.Cargar_Avisos();
            textBox1.Text = cargarTB[0];
            textBox2.Text = cargarTB[1];
            textBox3.Text = cargarTB[2];
            textBox4.Text = cargarTB[3];
            textBox5.Text = cargarTB[4];
            String[] dias = new String[7];
            for (int x = 0; x < 7; x++)
            {
                int y = x + 1;
                if (y == 1)
                {
                    dias[x] = "" + y + " Dia";
                }
                else
                {
                    dias[x] = "" + y + " Dias";
                }
            }
            for (int x = 0; x < 7; x++)
            {
                comboBox1.Items.Add(dias[x]);
                comboBox2.Items.Add(dias[x]);
                comboBox3.Items.Add(dias[x]);
                comboBox4.Items.Add(dias[x]);
                comboBox5.Items.Add(dias[x]);
            }
        }

        private void BAviso_Click(object sender, EventArgs e)
        {
            int enviado = 0;
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Al menos un campo debe contener un aviso");
            }
            else
            {
                if (textBox1.Text != "")
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Ingrese la duracion del aviso");
                    }
                    else
                    {
                        char[] dias = comboBox1.Text.ToCharArray();
                        string repetir = dias[0].ToString();
                        DateTime F = DateTime.Now.Date;
                        string fecha = F.ToString("yyyy/MM/dd");
                        CapaDatos.ClaseDatos.avisos_home(1, textBox1.Text, fecha, repetir);
                        enviado++;
                    }

                }
                else
                {
                    string vacio = "";
                    DateTime F = DateTime.Now.Date;
                    string fecha = F.ToString("yyyy/MM/dd");
                    CapaDatos.ClaseDatos.avisos_home(1, vacio, fecha, "7");
                }
                if (textBox2.Text != "")
                {
                    if (comboBox2.Text == "")
                    {
                        MessageBox.Show("Ingrese la duracion del aviso");
                    }
                    else
                    {
                        char[] dias = comboBox2.Text.ToCharArray();
                        string repetir = dias[0].ToString();
                        DateTime F = DateTime.Now.Date;
                        string fecha = F.ToString("yyyy/MM/dd");
                        CapaDatos.ClaseDatos.avisos_home(2, textBox2.Text, fecha, repetir);
                        enviado++;
                    }

                }
                else
                {
                    string vacio = "";
                    DateTime F = DateTime.Now.Date;
                    string fecha = F.ToString("yyyy/MM/dd");
                    CapaDatos.ClaseDatos.avisos_home(2, vacio, fecha, "7");
                }
                if (textBox3.Text != "")
                {
                    if (comboBox3.Text == "")
                    {
                        MessageBox.Show("Ingrese la duracion del aviso");
                    }
                    else
                    {
                        char[] dias = comboBox3.Text.ToCharArray();
                        string repetir = dias[0].ToString();
                        DateTime F = DateTime.Now.Date;
                        string fecha = F.ToString("yyyy/MM/dd");
                        CapaDatos.ClaseDatos.avisos_home(3, textBox3.Text, fecha, repetir);
                        enviado++;
                    }

                }
                else
                {
                    string vacio = "";
                    DateTime F = DateTime.Now.Date;
                    string fecha = F.ToString("yyyy/MM/dd");
                    CapaDatos.ClaseDatos.avisos_home(3, vacio, fecha, "7");
                }
                if (textBox4.Text != "")
                {
                    if (comboBox4.Text == "")
                    {
                        MessageBox.Show("Ingrese la duracion del aviso");
                    }
                    else
                    {
                        char[] dias = comboBox4.Text.ToCharArray();
                        string repetir = dias[0].ToString();
                        DateTime F = DateTime.Now.Date;
                        string fecha = F.ToString("yyyy/MM/dd");
                        CapaDatos.ClaseDatos.avisos_home(4, textBox4.Text, fecha, repetir);
                        enviado++;
                    }
                }
                else
                {
                    string vacio = "";
                    DateTime F = DateTime.Now.Date;
                    string fecha = F.ToString("yyyy/MM/dd");
                    CapaDatos.ClaseDatos.avisos_home(4, vacio, fecha, "7");
                }
                if (textBox5.Text != "")
                {
                    if (comboBox5.Text == "")
                    {
                        MessageBox.Show("Ingrese la duracion del aviso");
                    }
                    else
                    {
                        char[] dias = comboBox5.Text.ToCharArray();
                        string repetir = dias[0].ToString();
                        DateTime F = DateTime.Now.Date;
                        string fecha = F.ToString("yyyy/MM/dd");
                        CapaDatos.ClaseDatos.avisos_home(5, textBox5.Text, fecha, repetir);
                        enviado++;
                    }
                }
                else
                {
                    string vacio = "";
                    DateTime F = DateTime.Now.Date;
                    string fecha = F.ToString("yyyy/MM/dd");
                    CapaDatos.ClaseDatos.avisos_home(5, vacio, fecha, "7");
                }
                if (enviado > 0)
                {
                    MessageBox.Show("Aviso/s enviado/s con exito");
                }
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            var pregunta = MessageBox.Show("¿Esta seguro de que quiere eliminar todos los avisos?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pregunta == DialogResult.Yes)
            {
                DateTime F = DateTime.Now.Date;
                string fecha = F.ToString("yyyy/MM/dd");
                CapaDatos.ClaseDatos.EliminarAvisos(fecha);
                string[] cargarTB = CapaDatos.ClaseDatos.Cargar_Avisos();
                textBox1.Text = "";
                comboBox1.Text = null;
                textBox2.Text = "";
                comboBox2.Text = null;
                textBox3.Text = "";
                comboBox3.Text = null;
                textBox4.Text = "";
                comboBox4.Text = null;
                textBox5.Text = "";
                comboBox5.Text = null;
                MessageBox.Show("Todos los avisos fueron eliminados con exito");
            }


        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            if(textBox1.Text == ""){
                comboBox1.Text = null;
            }else if(textBox2.Text == ""){
                comboBox2.Text = null;
            }else if(textBox3.Text == ""){
                comboBox3.Text = null;
            }else if(textBox4.Text == ""){
                comboBox4.Text = null;
            }else if(textBox5.Text == ""){
                comboBox5.Text = null;
            }
            actualizacion.Start();
        }
    }
}
