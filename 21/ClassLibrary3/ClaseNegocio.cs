using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class ClaseNegocio
    {
        ClaseDatos objd = new ClaseDatos();
        public DataTable CNegocio(ClaseEntidad obje)
        {
            return objd.Datos(obje);
        }
    }
}
