using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login.FormsAPP
{
    public partial class OPCIONES : Form
    {
       public string areaglobal = "";
        public OPCIONES(string areaaa)
        {
            InitializeComponent();
            areaglobal = areaaa;
            if (areaglobal == "Estudiante")
            {
                Ayuda.Navigate("https://drive.google.com/file/d/10dX9phWMI_P6g7tJE_WDHLZ29LQvBshX/view");
            }
            if (areaglobal == "Administrador")
            {
                Ayuda.Navigate("https://drive.google.com/file/d/1jFZ4jVKnsNLwwzbZpMYQ8Y0YpO67YuW8/view");
            }
            if (areaglobal == "Adscripto")
            {
                Ayuda.Navigate("https://drive.google.com/file/d/1J48IJhgJwT-hcIx3JnY7VQGob2Lsfy4o/view");
            }
            if (areaglobal == "Profesor")
            {
                Ayuda.Navigate("https://drive.google.com/file/d/1jYrK3GSltlcCofH85S_9EcBXAkqwUGnf/view");
            }
        }

        
        // cambia el color del panel (no lo probe si funciona)


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Ayuda.Visible = true;
                PanelC.Visible = true;
                Alertas.Visible = false;
	//aqui cambiaria la propiedad url segun el rol de usuario para que le salga el manual de usuario
	//segun su rol
            }
            else if (checkBox2 != null)
            {
                Ayuda.Visible = false;
                PanelC.Visible = false;
                Alertas.Visible = true;
                // ayuda es un webbrowser lo mismo que se usa en blog
	//la onda es hacer abrir pdf (conseguir la forma de abrirlo como un url), le di vueltas y
	//llegue a la conclucion de que si subo el pdf al drive lo abro y copio el link se podria hacer
	//hacer que el que obtenga el link solo pueda ver el contenido.
            }
        }

        private void Alertas_CheckedChanged(object sender, EventArgs e)
        {
            if (Alertas.Checked)
            {
                Ayuda.Visible = false;
                PanelC.Visible = false;
                inumet.Visible = true;

            }
            else if (Alertas != null)
            {
                inumet.Visible = false;
            }
        }

        

      
    }
}
