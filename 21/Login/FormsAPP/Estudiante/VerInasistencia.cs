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

namespace Login.FormsAPP.Alumno
{
    
    public partial class AsistenciaA : Form
    {
        String AreaGlobal = "";  
        DateTime ActualFecha = DateTime.Now.Date;
        string FechaActual = "";
        public AsistenciaA(string areaaa)
        {
            InitializeComponent();
            AreaGlobal = areaaa;
            FechaActual = ActualFecha.ToString("yyyy/MM/dd");
            Console.WriteLine("EMPIEZA SECCION INASISTENCIAS");
            if (areaaa == "Administrador" || areaaa == "Adscripto")
            {
                dgvinasistencias.DataSource = CapaDatos.ClaseDatos.MostrarTodaslasInasitencias();
                dgvinasistencias.ClearSelection();
                dgvinasistencias.Columns[6].Width = 200;
                dgvinasistencias.Columns[3].HeaderText = "Desde";
                dgvinasistencias.Columns[4].HeaderText = "Hasta";
            }
            else
            {
                dgvinasistencias.DataSource = CapaDatos.ClaseDatos.MostrarTablaInasistencias();
                dgvinasistencias.ClearSelection();
                dgvinasistencias.Columns[5].Width = 258;
                dgvinasistencias.Columns[3].HeaderText = "Desde";
                dgvinasistencias.Columns[4].HeaderText = "Hasta";

            }
            actualizacion.Start();
        }

        private void actualizacion_Tick(object sender, EventArgs e)
        {
            actualizacion.Stop();
            CapaDatos.ClaseDatos.ExpirarReservas();
            CapaDatos.ClaseDatos.ExpirarReservas2();
            CapaDatos.ClaseDatos.EliminarFaltaVieja(FechaActual);
            if (AreaGlobal == "Administrador" || AreaGlobal == "Adscripto")
            {
                dgvinasistencias.DataSource = CapaDatos.ClaseDatos.MostrarTodaslasInasitencias();
                dgvinasistencias.ClearSelection();
                dgvinasistencias.Columns[6].Width = 200;
                dgvinasistencias.Columns[3].HeaderText = "Desde";
                dgvinasistencias.Columns[4].HeaderText = "Hasta";
            }
            else
            {
                dgvinasistencias.DataSource = CapaDatos.ClaseDatos.MostrarTablaInasistencias();
                dgvinasistencias.ClearSelection();
                dgvinasistencias.Columns[5].Width = 258;
                dgvinasistencias.Columns[3].HeaderText = "Desde";
                dgvinasistencias.Columns[4].HeaderText = "Hasta";

            }
            actualizacion.Start();
        }



    }
}
