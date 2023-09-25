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
    public partial class InscribirAlumno : Form
    {
        public InscribirAlumno()
        {
            InitializeComponent();
            string[] GMatutino = CapaDatos.ClaseDatos.MostrarGruposMatutino();
            string[] GVespertino = CapaDatos.ClaseDatos.MostrarGruposVespertino();
            string[] GInter1 = CapaDatos.ClaseDatos.MostrarGruposinter1();
            string[] GInter2 = CapaDatos.ClaseDatos.MostrarGruposinter2();
            string[] GNocturno = CapaDatos.ClaseDatos.MostrarGruposNocturno();
            for(int x=0;x<GMatutino.Length;x++){
                BOXM.Items.Add(GMatutino[x]);
            }
            for(int x=0;x<GVespertino.Length;x++){
                BOXV.Items.Add(GVespertino[x]);
            }
            for(int x=0;x<GInter1.Length;x++){
                BOXI1.Items.Add(GInter1[x]);
            }
            for(int x=0;x<GInter2.Length;x++){
                BOXI2.Items.Add(GInter2[x]);
            }
            for(int x=0;x<GNocturno.Length;x++){
                BOXN.Items.Add(GNocturno[x]);
            }
            
        }

        private void Binscribir_Click(object sender, EventArgs e)
        {
            if (CEDULA.Text != "" && CEDULA.Text != null && NOMBRE.Text != "" && NOMBRE.Text != null && CONTACTO.Text != "" && CONTACTO.Text != null && APELLIDO.Text != "" && APELLIDO.Text != null && BOXM.Text != null || BOXN.Text != null || BOXV.Text != null || BOXI1.Text != null || BOXI2.Text != null)
            {
                if (CEDULA.Text.Length == 8)
                {
                    try
                    {
                        CapaDatos.ClaseDatos.RegistrarUsuario(CEDULA.Text, NOMBRE.Text, APELLIDO.Text, "", CEDULA.Text, CONTACTO.Text, "Estudiante");
                        CapaDatos.ClaseDatos.inscripcion(CEDULA.Text, NOMBRE.Text, APELLIDO.Text);
                        if (BOXM.Text != "" && BOXM.Text != null)
                        {
                            CapaDatos.ClaseDatos.AgregarTOgrupo(CEDULA.Text, BOXM.Text);
                        }
                        if (BOXV.Text != "" && BOXV.Text != null)
                        {
                            CapaDatos.ClaseDatos.AgregarTOgrupo(CEDULA.Text, BOXV.Text);
                        }
                        if (BOXI1.Text != "" && BOXI1.Text != null)
                        {
                            CapaDatos.ClaseDatos.AgregarTOgrupo(CEDULA.Text, BOXI1.Text);
                        }
                        if (BOXI2.Text != "" && BOXI2.Text != null)
                        {
                            CapaDatos.ClaseDatos.AgregarTOgrupo(CEDULA.Text, BOXI2.Text);
                        }
                        if (BOXN.Text != "" && BOXN.Text != null)
                        {
                            CapaDatos.ClaseDatos.AgregarTOgrupo(CEDULA.Text, BOXN.Text);
                        }
                        MessageBox.Show("Alumno inscripto con exito");
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show("" + ex + "");
                    }

                }
                else
                {
                    MessageBox.Show("La cantidad de digitos en cedula no son validos");
                }

            }
            else
            {
                MessageBox.Show("Uno de los campos esta sin completar");
            }
        }

    }
}

