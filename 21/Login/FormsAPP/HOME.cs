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
    public partial class HOME : Form
    {
        string[] Avisos = CapaDatos.ClaseDatos.Cargar_Avisos();
        int segundos2 = 0;
        int SEGUNDOS = 0;
        public HOME()
        {
            InitializeComponent();
            VerAvisos();
            actualizacion.Start();
            Timg.Start();
        }

        public void VerAvisos()
        {
            Avisos = CapaDatos.ClaseDatos.Cargar_Avisos();
            if (Avisos[0] == "" && Avisos[1] == "" && Avisos[2] == "" && Avisos[3] == "" && Avisos[4] == "")
            {
                TIMER.Enabled = false;
                AvisoTxt.Text = "No hay avisos";
            }
            else
            {
                TIMER.Enabled = true;
            }
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            SEGUNDOS++;
            if (SEGUNDOS == 1)
            {
                if (Avisos[0] != "")
                {
                    AvisoTxt.Text = Avisos[0];
                }
                else
                {
                    SEGUNDOS = SEGUNDOS + 5;
                }

            }
            if (SEGUNDOS == 6)
            {
                if (Avisos[1] != "")
                {
                    AvisoTxt.Text = Avisos[1];
                }
                else
                {
                    SEGUNDOS = SEGUNDOS + 5;
                }
            }
            if (SEGUNDOS == 11)
            {
                if (Avisos[2] != "")
                {
                    AvisoTxt.Text = Avisos[2];
                }
                else
                {
                    SEGUNDOS = SEGUNDOS + 5;
                }
            }
            if (SEGUNDOS == 16)
            {
                if (Avisos[3] != "")
                {
                    AvisoTxt.Text = Avisos[3];
                }
                else
                {
                    SEGUNDOS = SEGUNDOS + 5;
                }
            }
            if (SEGUNDOS == 21)
            {
                if (Avisos[4] != "")
                {
                    AvisoTxt.Text = Avisos[4];
                }
                else
                {
                    SEGUNDOS = SEGUNDOS + 5;
                }
            }
            if (SEGUNDOS == 26)
            {
                SEGUNDOS = 0;
            }

        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            VerAvisos();
            CapaDatos.ClaseDatos.ExpirarReservas();
            CapaDatos.ClaseDatos.ExpirarReservas2();
            actualizacion.Start();

        }



        private void Timg_Tick_1(object sender, EventArgs e)
        {
            Timg.Start();
            segundos2++;
            if (segundos2 == 1)
            {
                LABEL.ImageIndex = 0;
            } if (segundos2 == 6)
            {
                LABEL.ImageIndex = 1;
            } if (segundos2 == 11)
            {
                LABEL.ImageIndex = 2;
            } if (segundos2 == 16)
            {
                LABEL.ImageIndex = 3;
            } if (segundos2 == 21)
            {
                LABEL.ImageIndex = 4;
            } if (segundos2 == 26)
            {
                segundos2 = 0;
            }
        }

    }
}
