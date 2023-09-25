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
    public partial class Salones : Form
    {
        string FechaActual = "";
        public Salones()
        {
            InitializeComponent();
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
                comboTurno.Items.Add(Turnos[x]);
            }
           
        }

        private void Bmostrar_Click(object sender, EventArgs e)
        {
            DateTime ActualFecha = DateTime.Now.Date;
            FechaActual = ActualFecha.ToString("yyyy/MM/dd");
            DGV_Salones.DataSource = CapaDatos.ClaseDatos.MostrarSalonesOcupados(comboDia.Text, comboTurno.Text,FechaActual);
            this.DGV_Salones.Sort(this.DGV_Salones.Columns["Numero Salon"], ListSortDirection.Ascending);
            DGV_Salones.Columns[6].Width = 175;
            DGV_Salones.Columns[3].Width = 150;
        }


    }
}
