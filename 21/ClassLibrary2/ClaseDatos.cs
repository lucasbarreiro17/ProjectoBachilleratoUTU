using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class ClaseDatos
    {

        public static String CedulaUsuario = null;

        public static MySqlConnection StringConexion()
        {
            string server = "localhost";
            string database = "LMAN_Softwares";
            string user = "root";
            string password = "Lucas1234567890";
            string port = "3306";


            string connString = "server=" + server + ";database=" + database + ";username=" + user + ";pwd=" + password + ";port=" + port + ";";
            MySqlConnection ola = new MySqlConnection(connString);


            return (ola);
        }
        //llamar al methodo como variable para poder llamarlo en el mysql comand 
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------                  

        public static void EliminarReserva(string codigo)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand eliminar = new MySqlCommand("delete from reserva_materiales where IdOrden='" + codigo + "';", con);
            eliminar.ExecuteNonQuery();
            con.Close();
        }

        public static void EliminarReserva2(string codigo)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand eliminar = new MySqlCommand("delete from reserva_salones where IdOrden='" + codigo + "';", con);
            eliminar.ExecuteNonQuery();
            con.Close();
        }

        public static void ModificarReservaM(string codigo, string validar)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            if (validar == "NO")
            {
                MySqlCommand update = new MySqlCommand("UPDATE reserva_materiales SET Validado='1' WHERE IdOrden ='" + codigo + "';", con);
                update.ExecuteNonQuery();
            }
            else
            {
                MySqlCommand update = new MySqlCommand("UPDATE reserva_materiales SET Validado='0' WHERE IdOrden ='" + codigo + "';", con);
                update.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void ModificarReservaS(string codigo, string validar)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            if (validar == "NO")
            {
                MySqlCommand update = new MySqlCommand("UPDATE reserva_salones SET Validado='1' WHERE IdOrden ='" + codigo + "';", con);
                update.ExecuteNonQuery();
            }
            else
            {
                MySqlCommand update = new MySqlCommand("UPDATE reserva_salones SET Validado='0' WHERE IdOrden ='" + codigo + "';", con);
                update.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void EliminarFalta(string codigo,string grupo)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand eliminar = new MySqlCommand("delete from inasistencia_profesor where IdProfesor='" + codigo + "' and IdGrupo='"+grupo+"';", con);
            eliminar.ExecuteNonQuery();
            con.Close();
        }

        public static void EliminarFaltaVieja(string FechaActual)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand eliminar = new MySqlCommand("delete from inasistencia_profesor where Fecha<'" + FechaActual + "';", con);
            eliminar.ExecuteNonQuery();
            con.Close();
        }
        public static DataTable MostrarProfesores()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select * from profesores", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }
        public static DataTable MostrarSalonesOcupados(string Dia, string turno,string Fecha)
        {
            MySqlConnection con = StringConexion();
            Int32[] Salones = new Int32[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select s.NumeroSalon from salones s,salon_grupo sg,horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and s.CodigoSalon=sg.IdSalon and sg.IdGrupo = g.Siglas and sg.IdGrupo=hg.IdGrupo and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='" + turno + "' and hg.Dia='" + Dia + "' group by s.NumeroSalon;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetInt32(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != 0)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;
                Console.WriteLine(SalonesFiltrados[i]);
            }
            DataTable TablaPrincipal = new DataTable();
            TablaPrincipal.Clear();
            TablaPrincipal.Columns.Add("Numero Salon");
            TablaPrincipal.Columns.Add("Nombre del Salon");
            TablaPrincipal.Columns.Add("Grupo");
            TablaPrincipal.Columns.Add("Materia");
            TablaPrincipal.Columns.Add("Entrada");
            TablaPrincipal.Columns.Add("Salida");
            TablaPrincipal.Columns.Add("Profesor");
            int reserva = 0;
            con.Open();
            MySqlCommand VerificarReservas = new MySqlCommand("select * from reserva_salones rs where rs.Fecha='" + Fecha + "';", con);
            VerificarReservas.ExecuteNonQuery();
            MySqlDataReader reader1 = VerificarReservas.ExecuteReader();
            if (reader1.Read())
            {
                reserva = 1;
            }
            con.Close();
            for (int n = 0; n < SalonesFiltrados.Length; n++)
            {
                con.Open();
                if (reserva == 0)
                {
                    MySqlCommand SalonesOcupados = new MySqlCommand("select s.NumeroSalon as 'Numero Salon',s.Nombre,g.Siglas as Grupo,a.Nombre as Materia,MIN(h.Entrada) as Entrada,MAX(h.Salida) as Salida, concat(p.Nombre,' ',p.Apellido) as Profesor from salones s,salon_grupo sg,horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha,asignatura_profesor ap,profesores p where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and s.CodigoSalon=sg.IdSalon and sg.IdGrupo = g.Siglas and sg.IdGrupo=hg.IdGrupo and ap.IdAsignatura=hg.IdAsignatura and ap.IdProfesor = p.CI and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='" + turno + "' and hg.Dia='" + Dia + "' and s.NumeroSalon='" + SalonesFiltrados[n] + "' group by a.Nombre;", con);
                    SalonesOcupados.ExecuteNonQuery();
                    MySqlDataAdapter adp1 = new MySqlDataAdapter(SalonesOcupados);
                    adp1.SelectCommand = SalonesOcupados;
                    DataTable TablaSalones = new DataTable();
                    adp1.Fill(TablaSalones);
                    int o = 0;
                    foreach (DataRow row in TablaSalones.Rows)
                    {
                        DataRow Tabla = TablaSalones.Rows[o];
                        DataRow Insert = TablaPrincipal.NewRow();
                        Insert["Numero Salon"] = Convert.ToString(Tabla["Numero Salon"]);
                        Insert["Nombre del Salon"] = Convert.ToString(Tabla["Nombre"]);
                        Insert["Grupo"] = Convert.ToString(Tabla["Grupo"]);
                        Insert["Materia"] = Convert.ToString(Tabla["Materia"]);
                        Insert["Entrada"] = Convert.ToString(Tabla["Entrada"]);
                        Insert["Salida"] = Convert.ToString(Tabla["Salida"]);
                        Insert["Profesor"] = Convert.ToString(Tabla["Profesor"]);
                        TablaPrincipal.Rows.Add(Insert);
                        o++;
                    }
                }
                else {
                    MySqlCommand SalonesOcupados = new MySqlCommand("select s.NumeroSalon as 'Numero Salon',s.Nombre,g.Siglas as Grupo,a.Nombre as Materia,MIN(h.Entrada) as Entrada,MAX(h.Salida) as Salida, concat(p.Nombre,' ',p.Apellido) as Profesor from salones s,salon_grupo sg,horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha,asignatura_profesor ap,profesores p,reserva_salones rs where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and s.CodigoSalon=sg.IdSalon and sg.IdGrupo = g.Siglas and sg.IdGrupo=hg.IdGrupo and ap.IdAsignatura=hg.IdAsignatura and ap.IdProfesor = p.CI and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='"+turno+"' and hg.Dia='"+Dia+"' and s.NumeroSalon='"+SalonesFiltrados[n]+"' and rs.Fecha='"+Fecha+"' and rs.Idprofesor!= P.CI group by (a.Nombre);", con);
                    SalonesOcupados.ExecuteNonQuery();
                    MySqlDataAdapter adp1 = new MySqlDataAdapter(SalonesOcupados);
                    adp1.SelectCommand = SalonesOcupados;
                    DataTable TablaSalones = new DataTable();
                    adp1.Fill(TablaSalones);
                    int o = 0;
                    foreach (DataRow row in TablaSalones.Rows)
                    {
                        DataRow Tabla = TablaSalones.Rows[o];
                        DataRow Insert = TablaPrincipal.NewRow();
                        Insert["Numero Salon"] = Convert.ToString(Tabla["Numero Salon"]);
                        Insert["Nombre del Salon"] = Convert.ToString(Tabla["Nombre"]);
                        Insert["Grupo"] = Convert.ToString(Tabla["Grupo"]);
                        Insert["Materia"] = Convert.ToString(Tabla["Materia"]);
                        Insert["Entrada"] = Convert.ToString(Tabla["Entrada"]);
                        Insert["Salida"] = Convert.ToString(Tabla["Salida"]);
                        Insert["Profesor"] = Convert.ToString(Tabla["Profesor"]);
                        TablaPrincipal.Rows.Add(Insert);
                        o++;
                    }
                }     
                con.Close();
            }
            con.Open();
            MySqlCommand Reservas = new MySqlCommand("select s.NumeroSalon as 'Numero Salon',s.Nombre,g.Siglas as Grupo,a.Nombre as Materia,rs.HoraReserva as Entrada,rs.HoraFinalizacion as Salida, concat(p.Nombre,' ',p.Apellido) as Profesor from salones s,horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha,asignatura_profesor ap,profesores p,reserva_salones rs where a.IdAsignatura = ha.IdAsignatura and hg.Dia='" + Dia + "' and ha.IdAsignatura = hg.IdAsignatura and S.CodigoSalon=rs.IdCodigoSalon and h.Turno='" + turno + "'and ap.IdAsignatura=hg.IdAsignatura and ap.IdProfesor = p.CI and p.CI=rs.IdProfesor and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and rs.Fecha='" + Fecha + "' and rs.Validado='1' group by (s.NumeroSalon); ", con);
            Reservas.ExecuteNonQuery();
            
            MySqlDataAdapter adp2 = new MySqlDataAdapter(Reservas);
            adp2.SelectCommand = Reservas;
            DataTable TablaReserva = new DataTable();
            adp2.Fill(TablaReserva);
            int a = 0;
          
            foreach (DataRow row in TablaReserva.Rows)
            {
               
                DataRow Tabla = TablaReserva.Rows[a];
                DataRow Insert = TablaPrincipal.NewRow();
                Insert["Numero Salon"] = Convert.ToString(Tabla["Numero Salon"]);
                Insert["Nombre del Salon"] = Convert.ToString(Tabla["Nombre"]);
                Insert["Grupo"] = Convert.ToString(Tabla["Grupo"]);
                Insert["Materia"] = Convert.ToString(Tabla["Materia"]);
                Insert["Entrada"] = Convert.ToString(Tabla["Entrada"]);
                Insert["Salida"] = Convert.ToString(Tabla["Salida"]);
                Insert["Profesor"] = Convert.ToString(Tabla["Profesor"]);
                TablaPrincipal.Rows.Add(Insert);
                a++;
            }
            con.Close();
            return (TablaPrincipal);

        }

        public static String[] MostrarGruposMatutino()
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Matutino' group by g.siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;
                
            }
           
            return (SalonesFiltrados);

        }
        public static String[] MostrarGruposinter2()
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino inter 2' group by g.siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;

            }

            return (SalonesFiltrados);

        }
        public static String[] MostrarGruposVespertino()
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino' group by g.siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;

            }

            return (SalonesFiltrados);

        }
        public static String[] MostrarGruposinter1()
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino inter 2' group by g.siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;

            }

            return (SalonesFiltrados);

        }
        public static String[] MostrarGruposNocturno()
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Nocturno' group by g.siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;

            }

            return (SalonesFiltrados);

        }

        public static DataTable mostrarInasistencia()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DataTable Tabla = new DataTable();
            try
            {
                MySqlCommand Rellenar = new MySqlCommand("select ip.IdProfesor as Cedula,concat(p.Nombre,' ',p.Apellido) as Profesor,ip.IdGrupo as Grupo,ip.Motivo,ip.Fecha,ip.HoraE as Entrada,ip.HoraS as Salida from inasistencia_profesor ip,profesores p where ip.IdProfesor=p.CI;", con);
                Rellenar.ExecuteNonQuery();
                MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
                adp.SelectCommand = Rellenar;
                adp.Fill(Tabla);
                con.Close();
                return (Tabla);
            }
            catch (MySqlException ex)
            {
                con.Close();
                return (Tabla);
            }
        }

        public static DataTable mostrarReservas()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DataTable Tabla = new DataTable();
            try
            {
                MySqlCommand Rellenar = new MySqlCommand("select rm.IdOrden as Orden,rm.IdProfesor as Cedula,concat(p.Nombre,' ',p.Apellido) as Profesor,m.Nombre as Material,rm.Fecha,rm.HoraReserva as 'Hora Reserva',rm.HoraFinalizacion as 'Hora Finalizacion',if(rm.Validado=1,'SI','NO') as Validado from reserva_materiales rm,profesores p,materiales m where rm.IdProfesor=p.CI and rm.IdMaterial=m.codigo;", con);
                Rellenar.ExecuteNonQuery();
                MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
                adp.SelectCommand = Rellenar;
                adp.Fill(Tabla);
                con.Close();
                return (Tabla);
            }
            catch (MySqlException ex)
            {
                con.Close();
                return (Tabla);
            }
        }

        public static DataTable mostrarReservas2()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DataTable Tabla = new DataTable();
            try
            {
                MySqlCommand Rellenar = new MySqlCommand("select rs.IdOrden as Orden,rs.IdProfesor as Cedula,concat(p.Nombre,' ',p.Apellido) as Profesor,s.Nombre as Salon,rs.Fecha,rs.HoraReserva as 'Hora Reserva',rs.HoraFinalizacion as 'Hora Finalizacion',if(rs.Validado=1,'SI','NO') as Validado from reserva_salones rs,profesores p,salones s where rs.IdProfesor=p.CI and rs.IdCodigoSalon=s.CodigoSalon;", con);
                Rellenar.ExecuteNonQuery();
                MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
                adp.SelectCommand = Rellenar;
                adp.Fill(Tabla);
                con.Close();
                return (Tabla);
            }
            catch (MySqlException ex)
            {
                con.Close();
                return (Tabla);
            }
        }

        public static string CheckCargarAsignaturaProfesor(String Asignatura, String Profesor)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string ID = "";
            MySqlCommand SacarId = new MySqlCommand("select IdAsignatura from asignaturas where Nombre='" + Asignatura + "'", con);
            MySqlDataReader leer = SacarId.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                ID = leido;
            }
            con.Close();
            con.Open();
            string Existe = "";
            string comando = "select IdAsignatura from asignatura_profesor where IdAsignatura='" + ID + "'and IdProfesor='" + Profesor + "';";
            MySqlCommand Cargar = new MySqlCommand(comando, con);
            Cargar.ExecuteNonQuery();
            MySqlDataReader leer1 = Cargar.ExecuteReader();
            if (leer1.Read())
            {
                String leido = leer1.GetString(0);
                Existe = leido;
            }
            con.Close();
            return (Existe);
        }

        public static void CargarAsignaturaProfesor(String Asignatura, String Profesor)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string ID = "";
            MySqlCommand SacarId = new MySqlCommand("select IdAsignatura from asignaturas where Nombre='" + Asignatura + "'", con);
            MySqlDataReader leer = SacarId.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                ID = leido;
            }
            con.Close();
            con.Open();
            string comando = "insert into asignatura_profesor(IdAsignatura,IdProfesor) values(" + ID + "," + Profesor + ");";
            MySqlCommand Cargar = new MySqlCommand(comando, con);
            Console.WriteLine("" + comando + "");
            Cargar.ExecuteNonQuery();
            con.Close();
        }


        public static void CargarExtras(string IdGrupo, string IdAsignatura, string[] CodigosHorario, string Dia, string IdProfesor)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando1 = "insert into grupos_asignatura(IdGrupo,IdAsignatura) values('" + IdGrupo + "','" + IdAsignatura + "');";
            MySqlCommand grupos_asignatura = new MySqlCommand(comando1, con);
            Console.WriteLine("" + comando1 + "");
            grupos_asignatura.ExecuteNonQuery();
            con.Close();
            con.Open();
            for (int x = 0; x < CodigosHorario.Length; x++)
            {
                string comando2 = "insert into horarios_asignatura(IdAsignatura,CodigoHorario,Dia) values ('" + IdAsignatura + "','" + CodigosHorario[x] + "','" + Dia + "');";
                MySqlCommand horarios_asignatura = new MySqlCommand(comando2, con);
                horarios_asignatura.ExecuteNonQuery();
                Console.WriteLine("" + comando2 + "");
            }
            con.Close();
            con.Open();
            string comando3 = "insert into profesores_grupos(IdProfesor,IdGrupo) values('" + IdProfesor + "','" + IdGrupo + "');";
            MySqlCommand profesores_grupos = new MySqlCommand(comando3, con);
            profesores_grupos.ExecuteNonQuery();
            Console.WriteLine("" + comando3 + "");
            con.Close();
        }

        public static string[] CodigosHorarios(string Entrada, string Salida, string Turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando1 = "select count(h.Codigo) from horarios h where h.Entrada >= '" + Entrada + "' and h.Salida <= '" + Salida + "' and h.Turno='" + Turno + "';";
            int Numero = 0;
            MySqlCommand ContarGrupos = new MySqlCommand(comando1, con);
            MySqlDataReader leer = ContarGrupos.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                Numero = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            string comando2 = "select h.Codigo from horarios h where h.Entrada >= '" + Entrada + "' and h.Salida <= '" + Salida + "' and h.Turno='" + Turno + "';";
            MySqlCommand horarios = new MySqlCommand(comando2, con);
            horarios.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(horarios);
            adp.SelectCommand = horarios;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            string[] HORARIOS = new string[Numero];
            for (int x = 0; x < Numero; x++)
            {
                HORARIOS[x] = Tabla.Rows[x][0].ToString();

            }
            con.Close();
            return (HORARIOS);
        }
        public static int CantidadProfesores()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int Cantidad = 0;
            MySqlCommand CantidadProfesores = new MySqlCommand("select count(*) from profesores", con);
            MySqlDataReader leer = CantidadProfesores.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                Cantidad = Int32.Parse(leido);
            }
            con.Close();
            return (Cantidad);
        }

        public DataTable Datos(ClaseEntidad obje)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string query = "Select * from Usuarios where Cedula=@usuario and Contraseña=@contraseña;";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", obje.Usuario);
            cmd.Parameters.AddWithValue("@contraseña", obje.Contraseña);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            CedulaUsuario = obje.Usuario;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public static void LiberarInasistencias()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string FechaActual = DateTime.Now.Date.ToString("yyyy-MM-dd");
            MySqlCommand Salones1 = new MySqlCommand("delete from inasistencia_profesor where Fecha<'" + FechaActual + "';", con);
            con.Close();
        }
        public static void LiberarReservas()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string FechaActual = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string HoraActual = DateTime.Now.ToString("hh:mm:ss");
            Console.WriteLine(HoraActual);
            Console.WriteLine(FechaActual);
            MySqlCommand Salones1 = new MySqlCommand("delete from reserva_salones where Fecha<'" + FechaActual + "';", con);
            MySqlCommand Salones2 = new MySqlCommand("delete from reserva_salones where Fecha='" + FechaActual + "' and HoraFinalizacion<'" + HoraActual + "';", con);
            con.Close();
        }

        public static String[] CargarSalones()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroSalones = 0;
            MySqlCommand ContarSalones = new MySqlCommand("select count(*) from salones", con);
            MySqlDataReader leer = ContarSalones.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroSalones = Int32.Parse(leido);
            }
            con.Close();
            con.Open();

            String[] SALONES = new String[NumeroSalones];
            MySqlCommand CargarSalones = new MySqlCommand("select * from salones", con);
            MySqlDataAdapter adSalones = new MySqlDataAdapter(CargarSalones);
            DataTable dtSalones = new DataTable();
            adSalones.Fill(dtSalones);
            for (int x = 0; x < NumeroSalones; x++)
            {
                SALONES[x] = dtSalones.Rows[x][0].ToString() + "-" + dtSalones.Rows[x][2].ToString();
            }
            con.Close();
            return (SALONES);
        }

        public static String[] CargarSalonesNoUsados()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroSalones = 0;
            MySqlCommand ContarSalones = new MySqlCommand("select count(*) from salones s,salon_grupo sg where s.CodigoSalon!=sg.IdSalon group by S.Nombre;", con);
            MySqlDataReader leer = ContarSalones.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroSalones = Int32.Parse(leido);
            }
            con.Close();
            con.Open();

            String[] SALONES = new String[NumeroSalones];
            MySqlCommand CargarSalones = new MySqlCommand("select s.Nombre,s.NumeroSalon from salones s,salon_grupo sg where s.CodigoSalon!=sg.IdSalon group by S.Nombre;", con);
            MySqlDataAdapter adSalones = new MySqlDataAdapter(CargarSalones);
            DataTable dtSalones = new DataTable();
            adSalones.Fill(dtSalones);
            for (int x = 0; x < NumeroSalones; x++)
            {
                SALONES[x] = dtSalones.Rows[x][0].ToString();
                Console.WriteLine(SALONES[x]);
            }
            con.Close();
            return (SALONES);
        }
        public static int CIProfesor()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int ID = new int();
            MySqlCommand Verificar = new MySqlCommand("select P.CI from profesores P,Usuarios L where L.FirstName=P.Nombre and L.LastName=P.Apellido;", con);
            MySqlDataReader leer = Verificar.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                ID = Int32.Parse(leido);
            }
            con.Close();
            return (ID);
        }
        public static String[] CargarMateriales()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroMateriales = 0;
            MySqlCommand ContarMateriales = new MySqlCommand("select count(*) from materiales", con);
            MySqlDataReader leer = ContarMateriales.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroMateriales = Int32.Parse(leido);
            }
            con.Close();
            con.Open();

            String[] MATERIALES = new String[NumeroMateriales];
            MySqlCommand CargarMateriales = new MySqlCommand("select * from materiales", con);
            MySqlDataAdapter adMateriales = new MySqlDataAdapter(CargarMateriales);
            DataTable dtMateriales = new DataTable();
            adMateriales.Fill(dtMateriales);
            for (int x = 0; x < NumeroMateriales; x++)
            {
                MATERIALES[x] = dtMateriales.Rows[x][0].ToString() + "-" + dtMateriales.Rows[x][1].ToString();
                Console.WriteLine(MATERIALES[x]);
            }
            con.Close();
            return (MATERIALES);
        }

        public static String[] CargarGrupos()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroGrupos = 0;
            MySqlCommand ContarGrupos = new MySqlCommand("select count(*) from grupos", con);
            MySqlDataReader leer = ContarGrupos.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroGrupos = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroGrupos];
            MySqlCommand CargarGrupos = new MySqlCommand("select Siglas from grupos", con);
            MySqlDataAdapter adGrupos = new MySqlDataAdapter(CargarGrupos);
            DataTable dtGrupos = new DataTable();
            adGrupos.Fill(dtGrupos);
            for (int x = 0; x < NumeroGrupos; x++)
            {
                HORARIOS[x] = dtGrupos.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);

        }

        public static String[] CargarGruposProf(int CI)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroGrupos = 0;
            MySqlCommand ContarGrupos = new MySqlCommand("select count(*) from grupos g,grupos_asignatura ga,asignatura_profesor ap where g.Siglas=ga.IdGrupo and ap.IdAsignatura=ga.IdAsignatura and ap.IdProfesor='" + CI + "';", con);
            MySqlDataReader leer = ContarGrupos.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroGrupos = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroGrupos];
            MySqlCommand CargarGrupos = new MySqlCommand("select g.Siglas from grupos g,grupos_asignatura ga,asignatura_profesor ap where g.Siglas=ga.IdGrupo and ap.IdAsignatura=ga.IdAsignatura and ap.IdProfesor='" + CI + "';", con);
            MySqlDataAdapter adGrupos = new MySqlDataAdapter(CargarGrupos);
            DataTable dtGrupos = new DataTable();
            adGrupos.Fill(dtGrupos);
            for (int x = 0; x < NumeroGrupos; x++)
            {
                HORARIOS[x] = dtGrupos.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioEntradaProf(int CI)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios h,horarios_asignatura ha,asignatura_profesor ap where h.Codigo=ha.CodigoHorario and ha.IdAsignatura=ap.IdAsignatura and ap.IdProfesor='" + CI + "';", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Entrada from horarios h,horarios_asignatura ha,asignatura_profesor ap where h.Codigo=ha.CodigoHorario and ha.IdAsignatura=ap.IdAsignatura and ap.IdProfesor='" + CI + "' order by h.Entrada ASC;", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioSalidaProf(int CI)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios h,horarios_asignatura ha,asignatura_profesor ap  where h.Codigo=ha.CodigoHorario and ha.IdAsignatura=ap.IdAsignatura and ap.IdProfesor='" + CI + "';", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Salida from horarios h,horarios_asignatura ha,asignatura_profesor ap where h.Codigo=ha.CodigoHorario and ha.IdAsignatura=ap.IdAsignatura and ap.IdProfesor='" + CI + "' order by h.Salida ASC;", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioEntrada()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Entrada from horarios h order by h.Entrada ASC", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioSalida()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Salida from horarios h order by h.Salida ASC", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();
                Console.WriteLine(HORARIOS[x]);
            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioEntradaPorTurno(string turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios where Turno='" + turno + "';", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Entrada from horarios h where Turno='" + turno + "' order by h.Entrada ASC", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();

            }
            con.Close();
            return (HORARIOS);
        }
        public static String[] CargarHorarioSalidaPorTurno(string turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int NumeroHorarios = 0;
            MySqlCommand ContarHorarios = new MySqlCommand("select count(*) from horarios where Turno='" + turno + "';", con);
            MySqlDataReader leer = ContarHorarios.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                NumeroHorarios = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            String[] HORARIOS = new String[NumeroHorarios];
            MySqlCommand CargarHorarios = new MySqlCommand("select h.Salida from horarios h where Turno='" + turno + "' order by h.Salida ASC", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarHorarios);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < NumeroHorarios; x++)
            {
                HORARIOS[x] = dtHorarios.Rows[x][0].ToString();

            }
            con.Close();
            return (HORARIOS);
        }
        public static string VerificarReservaSalon(String Nombresalon, String Fecha, String Horareserva, String Horafinalizacion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int IdReservante = new int();
            string resultado = "";
            try
            {
                MySqlCommand VerificarReserva = new MySqlCommand("select P.CI from profesores P,Usuarios L where L.FirstName=P.Nombre and L.LastName=P.Apellido;", con);
                MySqlDataReader leer = VerificarReserva.ExecuteReader();
                if (leer.Read())
                {
                    String leido = leer.GetString(0);
                    IdReservante = Int32.Parse(leido);
                }
                con.Close();
                con.Open();
                Char[] IdSalon = Nombresalon.ToCharArray();
                String Salon = IdSalon[0].ToString() + IdSalon[1].ToString() + IdSalon[2].ToString() + IdSalon[3].ToString();
                MySqlCommand Reserva = new MySqlCommand("select IdReservante from reserva_salones where IdProfesor=@IdReservante and IdCodigoSalon=@IdSalon and Fecha=@Fecha and HoraReserva=@Horareserva and HoraFinalizacion=@Horafinalizacion and Validado=0) values (@IdReservante,@IdSalon,@Fecha,@Horareserva,@Horafinalizacion,0);", con);
                Reserva.Parameters.AddWithValue("@IdReservante", IdReservante);
                Reserva.Parameters.AddWithValue("@IdSalon", Salon);
                Reserva.Parameters.AddWithValue("@Fecha", Fecha);
                Reserva.Parameters.AddWithValue("@Horareserva", Horareserva);
                Reserva.Parameters.AddWithValue("@Horafinalizacion", Horafinalizacion);
                Reserva.ExecuteNonQuery();
                con.Close();
                con.Open();
                MySqlDataReader leer1 = Reserva.ExecuteReader();
                if (leer1.Read())
                {
                    String leido = leer1.GetString(0);
                    resultado = leido;
                }
                con.Close();
                return (resultado);
            }
            catch (MySqlException ex)
            {
                resultado = "";
                con.Close();
                return (resultado);
            }
        }
        public static void ReservarSalon(String Nombresalon, String Fecha, String Horareserva, String Horafinalizacion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int IdReservante = new int();
            MySqlCommand VerificarReserva = new MySqlCommand("select P.CI from profesores P where P.CI='"+CedulaUsuario+"';", con);
            MySqlDataReader leer = VerificarReserva.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                IdReservante = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            Char[] IdSalon = Nombresalon.ToCharArray();
            String Salon = IdSalon[0].ToString() + IdSalon[1].ToString() + IdSalon[2].ToString() + IdSalon[3].ToString();
            string comando = "insert into reserva_salones(IdProfesor,IdCodigoSalon,Fecha,HoraReserva,HoraFinalizacion,Validado) values ('"+IdReservante+"','"+Salon+"','"+Fecha+"','"+Horareserva+"','"+Horafinalizacion+"',0);";
            MySqlCommand Reserva = new MySqlCommand(comando, con);
            Reserva.ExecuteNonQuery();
            Console.WriteLine("" + comando + "");

            con.Close();
        }
        public static string VerificarReservaSalonProf(String IdReservante, String Nombresalon, String Fecha, String Horareserva, String Horafinalizacion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string resultado = "";
            try
            {
                Char[] IdSalon = Nombresalon.ToCharArray();
                String Salon = IdSalon[0].ToString() + IdSalon[1].ToString() + IdSalon[2].ToString() + IdSalon[3].ToString();
                MySqlCommand Reserva = new MySqlCommand("select IdReservante from reserva_salones where IdProfesor=@IdReservante and IdCodigoSalon=@IdSalon and Fecha=@Fecha and HoraReserva=@Horareserva and HoraFinalizacion=@Horafinalizacion and Validado=0) values (@IdReservante,@IdSalon,@Fecha,@Horareserva,@Horafinalizacion,0);", con);
                Reserva.Parameters.AddWithValue("@IdReservante", IdReservante);
                Reserva.Parameters.AddWithValue("@IdSalon", Salon);
                Reserva.Parameters.AddWithValue("@Fecha", Fecha);
                Reserva.Parameters.AddWithValue("@Horareserva", Horareserva);
                Reserva.Parameters.AddWithValue("@Horafinalizacion", Horafinalizacion);
                Reserva.ExecuteNonQuery();
                con.Close();
                con.Open();
                MySqlDataReader leer1 = Reserva.ExecuteReader();
                if (leer1.Read())
                {
                    String leido = leer1.GetString(0);
                    resultado = leido;
                }
                con.Close();
                return (resultado);
            }
            catch (MySqlException ex)
            {
                resultado = "";
                con.Close();
                return (resultado);
            }


        }
        public static void ReservarSalonProf(String IdReservante, String Nombresalon, String Fecha, String Horareserva, String Horafinalizacion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            Char[] IdSalon = Nombresalon.ToCharArray();
            String Salon = IdSalon[0].ToString() + IdSalon[1].ToString() + IdSalon[2].ToString() + IdSalon[3].ToString();
            string comando = "insert into reserva_salones(IdProfesor,IdCodigoSalon,Fecha,HoraReserva,HoraFinalizacion,Validado) values ('"+IdReservante+"','"+Salon+"','"+Fecha+"','"+Horareserva+"','"+Horafinalizacion+"',0);";
            MySqlCommand Reserva = new MySqlCommand(comando,con);
            Reserva.ExecuteNonQuery();
            Console.WriteLine("" + comando + "");
            con.Close();
        }
        public static void ReservarMaterial(String Nombrematerial, String Fecha, String Horareserva, String Horafinalizacion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int IdReservante = new int();
            MySqlCommand VerificarReserva = new MySqlCommand("select P.CI from profesores P,Usuarios L where L.FirstName=P.Nombre and L.LastName=P.Apellido;", con);
            MySqlDataReader leer = VerificarReserva.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                IdReservante = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            Char[] IdMaterial = Nombrematerial.ToCharArray();
            String Material = IdMaterial[0].ToString() + IdMaterial[1].ToString() + IdMaterial[2].ToString() + IdMaterial[3].ToString();
            string comando = "insert into reserva_materiales(IdProfesor,IdMaterial,Fecha,HoraReserva,HoraFinalizacion,Validado) values ('" + IdReservante + "','" + Material + "','" + Fecha + "','" + Horareserva + "','" + Horafinalizacion + "',0);";
            MySqlCommand Reserva = new MySqlCommand(comando, con);
            Console.WriteLine("" + comando + "");
            Reserva.ExecuteNonQuery();

            con.Close();
        }

        public static string RegistrarUsuario(string Cedula, string Nombre, string Apellido, string Email, string Contraseña, string Numero, string Posicion)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            try
            {
                MySqlCommand Registrar = new MySqlCommand("insert into validar_registro (Cedula, Contraseña, Firstname, LastName, Posicion, Email,Contacto) values (@Cedula,@Contraseña,@FirstName,@LastName,@Posicion,@Email,@Contacto);", con);
                Registrar.Parameters.AddWithValue("@Cedula", Cedula);
                Registrar.Parameters.AddWithValue("@Contraseña", Contraseña);
                Registrar.Parameters.AddWithValue("@FirstName", Nombre);
                Registrar.Parameters.AddWithValue("@LastName", Apellido);
                Registrar.Parameters.AddWithValue("@Posicion", Posicion);
                Registrar.Parameters.AddWithValue("@Email", Email);
                Registrar.Parameters.AddWithValue("@Contacto", Numero);
                Registrar.ExecuteNonQuery();
                con.Close();
                return ("1");
            }
            catch (MySqlException ex)
            {
                con.Close();
                return (ex.ToString());
            }

        }

        public static void inscripcion(string cedula, string nombre, string apellido)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando="insert into alumnos (CI, Nombre, Apellido) values ('"+cedula+"','"+nombre+"','"+apellido+"');";
            MySqlCommand AgregarAlumno = new MySqlCommand(comando, con);
            AgregarAlumno.ExecuteNonQuery();
            Console.WriteLine("" + comando + "");
            con.Close();
        }

        public static void AgregarTOgrupo(string cedula, string grupo)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando="insert into alumnos_grupos(IdAlumno,IdGrupo) values ('" + cedula + "','"+grupo+"')";
            MySqlCommand AgregarAlGrupo = new MySqlCommand(comando, con);
            AgregarAlGrupo.ExecuteNonQuery();
            Console.WriteLine("" + comando + "");
            con.Close();
        }

        public static void CargarUsuario(string Cedula, string Nombre, string Apellido, string Email, string Contraseña, string Numero, string Posicion)
        {

            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand utp = new MySqlCommand("delete from Usuarios where Cedula = '" + Cedula + "';", con);
            MySqlCommand ok = new MySqlCommand("delete from validar_registro where Cedula = '" + Cedula + "';", con);
            string comando = "insert into Usuarios  (Cedula, Contraseña, Firstname, LastName, Posicion, Email,Contacto) values ('" + Cedula + "','" + Contraseña + "','" + Nombre + "','" + Apellido + "','" + Posicion + "','" + Email + "','" + Numero + "');";
            MySqlCommand Registrar = new MySqlCommand(comando, con);
            Console.WriteLine("" + comando + "");
            ok.ExecuteNonQuery();
            utp.ExecuteNonQuery();
            Registrar.ExecuteNonQuery();

            con.Close();
        }


        public static void EliminarUsuario(string Cedula)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int CI = int.Parse(Cedula);
            string comando="UPDATE Usuarios SET Posicion='Inactivo' WHERE Cedula ='" + CI + "';";
            MySqlCommand Registrar = new MySqlCommand(comando, con);
            Registrar.ExecuteNonQuery();
            con.Close();
        }
        public static void RechazarUsuario(string Cedula)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int CI = int.Parse(Cedula);
            MySqlCommand Registrar = new MySqlCommand("delete from validar_registro where Cedula = '" + CI + "';", con);
            Registrar.ExecuteNonQuery();
            con.Close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        // INASISTENCIA:
        public static DataTable MostrarTodaslasInasitencias()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select P.Nombre,P.Apellido,IP.Fecha,IP.HoraE,IP.HoraS,IP.IdGrupo,IP.Motivo from inasistencia_profesor IP,profesores P where P.CI=IP.IdProfesor;", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);

            con.Close();
            return (Tabla);

        }

        public static DataTable MostrarTablaInasistencias()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            String GRUPO = "aaa";
            MySqlCommand Recuperargrupo = new MySqlCommand("select AP.IdGrupo from alumnos_grupos AP where AP.IdAlumno='" + CedulaUsuario + "';", con);
            Recuperargrupo.ExecuteNonQuery();
            MySqlDataReader leer = Recuperargrupo.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                GRUPO = leido;
                Console.WriteLine(GRUPO);
            }
            con.Close();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select P.Nombre,P.Apellido,IP.Fecha,IP.HoraE,IP.HoraS,IP.Motivo from inasistencia_profesor IP,profesores P where P.CI=IP.IdProfesor and IP.IdGrupo = '" + GRUPO + "';", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();

            return (Tabla);

        }
        public static void AvisarInasistencia(string motivo, string idgrupo, string hentrada, string hsalida, string fecha)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int ID = new int();
            MySqlCommand VerificarAviso = new MySqlCommand("select P.CI from profesores P,Usuarios L where L.FirstName=P.Nombre and L.LastName=P.Apellido;", con);
            MySqlDataReader leer = VerificarAviso.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                ID = Int32.Parse(leido);
            }
            con.Close();
            con.Open();
            MySqlCommand Reserva = new MySqlCommand("insert into inasistencia_profesor(Idprofesor,Idgrupo,Motivo,Fecha,HoraE,HoraS) values (@Idprofesor,@Idgrupo,@Motivo,@Fecha,@HoraE,@HoraS);", con);
            Reserva.Parameters.AddWithValue("@Idprofesor", ID);
            Reserva.Parameters.AddWithValue("@Idgrupo", idgrupo);
            Reserva.Parameters.AddWithValue("@Motivo", motivo);
            Reserva.Parameters.AddWithValue("@Fecha", fecha);
            Reserva.Parameters.AddWithValue("@HoraE", hentrada);
            Reserva.Parameters.AddWithValue("@HoraS", hsalida);
            Reserva.ExecuteNonQuery();
            con.Close();
        }

        public static void AvisarInasistenciaADS(string ID, string motivo, string idgrupo, string entrada, string salida, string fecha)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Reserva = new MySqlCommand("insert into inasistencia_profesor(Idprofesor,Idgrupo,Motivo,Fecha,HoraE,HoraS) values (@Idprofesor,@Idgrupo,@Motivo,@Fecha,@HoraE,@HoraS);", con);
            Reserva.Parameters.AddWithValue("@Idprofesor", ID);
            Reserva.Parameters.AddWithValue("@Idgrupo", idgrupo);
            Reserva.Parameters.AddWithValue("@Motivo", motivo);
            Reserva.Parameters.AddWithValue("@Fecha", fecha);
            Reserva.Parameters.AddWithValue("@HoraE", entrada);
            Reserva.Parameters.AddWithValue("@HoraS", salida);
            Reserva.ExecuteNonQuery();
            // AHORA VOY A ELIMINAR TODA RESERVA CORRESPONDIENTE A LA CEDULA EN EL RANGO HORARIO DE LA FALTA.
            MySqlCommand BorrarReservas = new MySqlCommand("DELETE  FROM reserva_materiales WHERE IdProfesor = '" + ID + "' AND Fecha = '" + fecha + "' AND HoraReserva = '" + entrada + "' AND HoraFinalizacion = '" + salida + "';", con);
            BorrarReservas.ExecuteNonQuery();
            MySqlCommand BorrarReservasSalones = new MySqlCommand("DELETE  FROM reserva_salones WHERE IdProfesor = '" + ID + "' AND Fecha = '" + fecha + "' AND HoraReserva = '" + entrada + "' AND HoraFinalizacion = '" + salida + "';", con);
            BorrarReservasSalones.ExecuteNonQuery();
            con.Close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------
        // HORARIOS:

        public static DataTable MostrarHorarios(string DIA, string Turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            String GRUPO = "aaa";
            MySqlCommand Recuperargrupo = new MySqlCommand("select AP.IdGrupo from alumnos_grupos AP where AP.IdAlumno='" + CedulaUsuario + "';", con);
            Recuperargrupo.ExecuteNonQuery();
            MySqlDataReader leer = Recuperargrupo.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                GRUPO = leido;
                Console.WriteLine(GRUPO);
            }
            //
            con.Close();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select g.Siglas as Grupo,a.Nombre as Materia,MIN(h.Entrada) as Entrada,MAX(h.Salida) as Salida, concat(p.Nombre,' ',p.Apellido) as Profesor from horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha,asignatura_profesor ap,profesores p where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and ap.IdAsignatura=hg.IdAsignatura and ap.IdProfesor = p.CI and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='" + Turno + "' and hg.Dia='" + DIA + "' and g.Siglas='" + GRUPO + "' group by a.Nombre;", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);
        }
        public static DataTable MostrarHorariosGeneral(string Dia, string turno)
        {
            MySqlConnection con = StringConexion();
            String[] Salones = new String[300];
            con.Open();
            MySqlCommand SalonesOcupadosContar = new MySqlCommand("select g.Siglas from horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='" + turno + "' and hg.Dia='" + Dia + "' group by g.Siglas;", con);
            SalonesOcupadosContar.ExecuteNonQuery();
            MySqlDataReader reader = SalonesOcupadosContar.ExecuteReader();
            DataTable TTT = reader.GetSchemaTable();
            int x = 0;
            while (reader.HasRows)
            {

                while (reader.Read())
                {
                    Salones[x] = reader.GetString(0);
                    x++;

                }
                reader.NextResult();
            }
            con.Close();
            int Contador = 0;
            for (int y = 0; y < Salones.Length; y++)
            {
                if (Salones[y] != null)
                {
                    Contador++;

                }
                else
                {
                    y = 300;
                }
            }
            Console.WriteLine(Contador.ToString());
            string[] SalonesFiltrados = new string[Contador];
            for (int i = 0; i < Contador; i++)
            {
                SalonesFiltrados[i] = Salones[i].ToString(); ;
                Console.WriteLine(SalonesFiltrados[i]);
            }
            DataTable TablaPrincipal = new DataTable();
            TablaPrincipal.Clear();
            TablaPrincipal.Columns.Add("Grupo");
            TablaPrincipal.Columns.Add("Materia");
            TablaPrincipal.Columns.Add("Entrada");
            TablaPrincipal.Columns.Add("Salida");
            TablaPrincipal.Columns.Add("Profesor");

            for (int n = 0; n < SalonesFiltrados.Length; n++)
            {
                con.Open();
                MySqlCommand SalonesOcupados = new MySqlCommand("select g.Siglas as Grupo,a.Nombre as Materia,MIN(h.Entrada) as Entrada,MAX(h.Salida) as Salida, concat(p.Nombre,' ',p.Apellido) as Profesor from horarios_grupo hg,horarios h,grupos g,asignaturas a,horarios_asignatura ha,asignatura_profesor ap,profesores p where a.IdAsignatura = ha.IdAsignatura and ha.IdAsignatura = hg.IdAsignatura and ap.IdAsignatura=hg.IdAsignatura and ap.IdProfesor = p.CI and hg.IdHorario=h.Codigo and g.Siglas=hg.IdGrupo and h.Turno='" + turno + "' and hg.Dia='" + Dia + "' and g.Siglas='" + SalonesFiltrados[n] + "' group by a.Nombre;", con);
                SalonesOcupados.ExecuteNonQuery();
                MySqlDataAdapter adp1 = new MySqlDataAdapter(SalonesOcupados);
                adp1.SelectCommand = SalonesOcupados;
                DataTable TablaSalones = new DataTable();
                adp1.Fill(TablaSalones);
                int o = 0;
                foreach (DataRow row in TablaSalones.Rows)
                {
                    DataRow Tabla = TablaSalones.Rows[o];
                    DataRow Insert = TablaPrincipal.NewRow();
                    Insert["Grupo"] = Convert.ToString(Tabla["Grupo"]);
                    Insert["Materia"] = Convert.ToString(Tabla["Materia"]);
                    Insert["Entrada"] = Convert.ToString(Tabla["Entrada"]);
                    Insert["Salida"] = Convert.ToString(Tabla["Salida"]);
                    Insert["Profesor"] = Convert.ToString(Tabla["Profesor"]);
                    TablaPrincipal.Rows.Add(Insert);
                    o++;
                }
                con.Close();
            }
            return (TablaPrincipal);

        }
        public static DataTable MostrarHorariosProfesor(string DIA, string Turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select G.Siglas as Grupo,A.Nombre as Materia,H.Entrada,H.salida from asignaturas A,asignatura_profesor AP,horarios_asignatura HA,horarios_grupo HG,horarios H,grupos G where G.Siglas=HG.IdGrupo and HG.IdHorario=H.Codigo and HG.IdAsignatura=AP.IdAsignatura and AP.IdAsignatura = A.IdAsignatura and H.Codigo = HA.CodigoHorario and A.IdAsignatura = AP.IdAsignatura and HA.IdAsignatura = A.IdAsignatura and AP.IdProfesor='"+CedulaUsuario+"' and HA.Dia = '"+DIA+"' and H.Turno = '"+Turno+"';", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }
        public static DataTable MostrarHorariosProfesorGeneral(string DIA, string Turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select A.Nombre,H.Entrada,H.salida,P.Nombre,P.Apellido from asignaturas A,asignatura_profesor AP,horarios_asignatura HA,horarios H,profesores P where AP.IdProfesor=P.CI and AP.IdAsignatura = A.IdAsignatura and H.Codigo = HA.CodigoHorario and A.IdAsignatura = AP.IdAsignatura and HA.IdAsignatura = A.IdAsignatura and HA.Dia = '" + DIA + "' and H.Turno = '" + Turno + "';", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }

        public static DataTable BuscarAlumnoMetodo(string DIA, string horario, string CI)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select G.Siglas,P.Nombre,A.Nombre,S.NumeroSalon,L.Contacto from grupos G,profesores P,asignaturas A,salones S,Usuarios L,salon_grupo SG,asignatura_profesor AP,horarios_asignatura HA,horarios H,grupos_asignatura GA where G.Siglas = SG.IdGrupo and L.Cedula = '" + CI + "' and S.CodigoSalon = SG.IdSalon and P.CI=AP.IdProfesor and A.IdAsignatura = AP.IdAsignatura and HA.IdAsignatura = A.IdAsignatura and HA.CodigoHorario = H.Codigo and GA.IdAsignatura = A.IdAsignatura and GA.IdGrupo = G.Siglas and H.Entrada = '" + horario + "' and HA.Dia = '" + DIA + "' ;", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }

        public static DataTable CargarUsuariosAValidar()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DataTable Tabla = new DataTable();
            try
            {
                MySqlCommand Rellenar = new MySqlCommand("select * from validar_registro", con);
                Rellenar.ExecuteNonQuery();
                MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
                adp.SelectCommand = Rellenar;
                adp.Fill(Tabla);
                con.Close();
                return (Tabla);
            }
            catch (MySqlException ex)
            {
                con.Close();
                return (Tabla);
            }
        }
        public static DataTable CargarUsuarios()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select * from Usuarios U where U.Posicion != 'Administrador' and U.Posicion !='Inactivo'", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }
        public static string[] CargarAsignaturas()
        {

            int cantidad = 0;
            MySqlConnection con = StringConexion();
            if (con.State.ToString() != "Open")
            {
                con.Open();
            }
            if (con.State.ToString() == "Open")
            {
                MySqlCommand contar = new MySqlCommand("select count(*) from asignaturas", con);
                contar.ExecuteNonQuery();
                MySqlDataReader leer = contar.ExecuteReader();
                if (leer.Read())
                {
                    String leido = leer.GetString(0);
                    cantidad = int.Parse(leido);
                }
            }
            con.Close();
            con.Open();
            string[] asignaturas = new string[cantidad];
            MySqlCommand Rellenar = new MySqlCommand("select Nombre from asignaturas", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            for (int x = 0; x < cantidad; x++)
            {
                asignaturas[x] = Tabla.Rows[x][0].ToString();
            }
            con.Close();
            return asignaturas;
        }

        public static void AñadirAsignatura(string nombre)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando = "insert into asignaturas(Nombre) values('" + nombre + "');";
            MySqlCommand añadir = new MySqlCommand(comando, con);
            Console.WriteLine("" + comando + "");
            añadir.ExecuteNonQuery();
            con.Close();
        }

        public static void añadirgrupoBD(string siglas, string nombre)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("insert into grupos(Siglas,Nombre) values('" + siglas + "','" + nombre + "');", con);
            Rellenar.ExecuteNonQuery();
            con.Close();
        }

        public static int ContarProfesores()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int cantidad = 0;
            MySqlCommand contar = new MySqlCommand("select count(*) from profesores", con);
            contar.ExecuteNonQuery();
            MySqlDataReader leer = contar.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                cantidad = int.Parse(leido);
            }
            con.Close();
            return (cantidad);

        }

        public static DataTable CargarProfesores()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand Rellenar = new MySqlCommand("select * from profesores", con);
            Rellenar.ExecuteNonQuery();
            MySqlDataAdapter adp = new MySqlDataAdapter(Rellenar);
            adp.SelectCommand = Rellenar;
            DataTable Tabla = new DataTable();
            adp.Fill(Tabla);
            con.Close();
            return (Tabla);

        }

        public static void BajarAvisos(int numero, string fecha)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int repetir = 0;
            MySqlCommand RecibirDias = new MySqlCommand("select repetir from avisos where numero='" + numero + "';", con);
            RecibirDias.ExecuteNonQuery();
            MySqlDataReader leer = RecibirDias.ExecuteReader();
            if (leer.Read())
            {
                String leido = leer.GetString(0);
                repetir = int.Parse(leido);
            }
            repetir = repetir - 1;
            MySqlCommand BajarAvisos = new MySqlCommand("replace into avisos (fecha,repetir) values ('" + fecha + "','" + repetir + "') where numero='" + numero + "' and fecha<'" + fecha + "';", con);
            BajarAvisos.ExecuteNonQuery();
            MySqlCommand Borrar = new MySqlCommand("replace into avisos (aviso,fecha,repetir) values ('','" + fecha + "',7) where repetir=<0;", con);
            Borrar.ExecuteNonQuery();
            con.Close();
        }

        public static void avisos_home(int numero, string aviso, string fecha, string dia)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand BorrarAnterior = new MySqlCommand("delete from avisos where numero='" + numero + "';", con);
            BorrarAnterior.ExecuteNonQuery();
            MySqlCommand Rellenar = new MySqlCommand("insert into avisos (numero,aviso,fecha,repetir) values ('" + numero + "','" + aviso + "','" + fecha + "','" + dia + "');", con);
            Rellenar.ExecuteNonQuery();
            con.Close();
        }

        public static string[] Cargar_Avisos()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string[] P = new string[5];
            MySqlCommand CargarAviso = new MySqlCommand("select aviso from avisos order by numero ASC", con);
            MySqlDataAdapter adHorarios = new MySqlDataAdapter(CargarAviso);
            DataTable dtHorarios = new DataTable();
            adHorarios.Fill(dtHorarios);
            for (int x = 0; x < 5; x++)
            {
                P[x] = dtHorarios.Rows[x][0].ToString();
            }
            con.Close();
            return P;
        }

        public static void EliminarAvisos(string fecha)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand ELIMINAR = new MySqlCommand("delete from avisos", con);
            ELIMINAR.ExecuteNonQuery();
            for (int x = 0; x < 5; x++)
            {
                MySqlCommand RECARGAR = new MySqlCommand("insert into avisos(numero,aviso,fecha,repetir) values('" + x + "','','" + fecha + "','7')", con);
                RECARGAR.ExecuteNonQuery();
            }
            con.Close();
        }
        public static void CargarRol(string rol, string Nombre, string Apellido, string Cedula)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            
            if (rol == "Profesor")
            {
                string comando = "insert into profesores (CI,Nombre,Apellido) values ('" + Cedula + "','" + Nombre + "','" + Apellido + "');";
                MySqlCommand Registrar = new MySqlCommand(comando, con);
                Console.WriteLine("" + comando + "");
                Registrar.ExecuteNonQuery();

            }
            if (rol == "Administrativo" || rol == "Adscripto")
            {
                string comando = "insert into funcionarios (CI,Nombre,Apellido,Rol) values ('" + Cedula + "','" + Nombre + "','" + Apellido + "','" + rol + "');";
                MySqlCommand Registrar = new MySqlCommand(comando, con);
                Console.WriteLine("" + comando + "");
                Registrar.ExecuteNonQuery();

            }
            con.Close();
        }
        public static int AñadirMateriales(string Codigo, string Nombre, string Cantidad)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            int error = 0;
            try
            {
                string comando = "insert into materiales(Codigo,Nombre,Cantidad) values ('" + Codigo + "','" + Nombre + "','" + Cantidad + "');";
                MySqlCommand Registrar = new MySqlCommand(comando, con);
                Registrar.ExecuteNonQuery();
                Console.WriteLine("" + comando + "");
                con.Close();
                return (error);
            }
            catch (MySqlException ex)
            {
                con.Close();
                error = 1;
                return (error);
            }
        }

        public static string AñadirGrupo(string Nombre, string Siglas, string SalonNombre)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string error = "0";
            try
            {
                char[] salon = SalonNombre.ToCharArray();
                string IDS = salon[0].ToString() + salon[1].ToString() + salon[2].ToString() + salon[3].ToString();
                string comando1 = "insert into grupos(Siglas,Nombre) values ('" + Siglas + "','" + Nombre + "');";
                string comando2 = "insert into salon_grupo(IdGrupo,IdSalon) values ('" + Siglas + "','" + IDS + "');";
                MySqlCommand InsertarGrupo = new MySqlCommand(comando1 + ' ' + comando2, con);
                InsertarGrupo.ExecuteNonQuery();
                Console.WriteLine("" + comando1 + "");
                Console.WriteLine("" + comando2 + "");
                con.Close();
                error = "1";
                return (error);
            }
            catch (MySqlException ex)
            {
                con.Close();
                Console.WriteLine(ex);
                error = ex.ToString(); ;
                return (error);
            }
        }



        public static void AñadirSalones(string Codigo, string Numero, string Nombre, string Capacidad)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string comando = "insert into salones(CodigoSalon,NumeroSalon,Nombre,Capacidad) values (" + Codigo + "," + Numero + ",'" + Nombre + "','" + Capacidad + "');";
            MySqlCommand Registrar = new MySqlCommand(comando, con);
            Console.WriteLine("" + comando + "");
            Registrar.ExecuteNonQuery();
            con.Close();
        }

        public static string IdAsignatura(string Nombre, string CIProfesor)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string Id = "";
            try
            {
                MySqlCommand IdA = new MySqlCommand("select a.IdAsignatura from asignaturas a,asignatura_profesor ap where a.Nombre='" + Nombre + "' and a.IdAsignatura=ap.IdAsignatura and ap.IdProfesor='" + CIProfesor + "';", con);
                IdA.ExecuteNonQuery();
                MySqlDataReader leer = IdA.ExecuteReader();
                if (leer.Read())
                {
                    String leido = leer.GetString(0);
                    Id = leido;
                }
                con.Close();
                return (Id);
            }
            catch (MySqlException ex)
            {
                con.Close();
                Id = "ERROR";
                return (Id);
            }
        }



        public static string IdHorario(string Entrada, string Salida, string Turno)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string Id = "";
            try
            {
                MySqlCommand IdA = new MySqlCommand("select Codigo from horarios where Entrada>='" + Entrada + "' and Salida<='" + Salida + "' and Turno='" + Turno + "';", con);
                IdA.ExecuteNonQuery();
                MySqlDataReader leer = IdA.ExecuteReader();
                if (leer.Read())
                {
                    String leido = leer.GetString(0);
                    Id = leido;
                }
                con.Close();
                return (Id);
            }
            catch (MySqlException ex)
            {
                con.Close();
                Id = "ERROR";
                return (Id);
            }
        }
        public static string AñadirHorario(string Grupo, string Horario, string Asignatura, string Dia)
        {
            MySqlConnection con = StringConexion();
            con.Open();
            string error = "1";
            try
            {
                string comando = "insert into horarios_grupo(IdGrupo,IdHorario,IdAsignatura,Dia) values ('" + Grupo + "','" + Horario + "','" + Asignatura + "','" + Dia + "');";
                MySqlCommand Registrar = new MySqlCommand(comando, con);
                Console.WriteLine("" + comando + "");
                Registrar.ExecuteNonQuery();
                error = "1";
                con.Close();
                return (error);
            }
            catch (MySqlException ex)
            {
                con.Close();
                error = ex.ToString();
                return (error);
            }
        }

        public static void ExpirarReservas()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DateTime Dia = DateTime.UtcNow.Date;
            int Hora = DateTime.UtcNow.Hour;
            String Hoy = Dia.ToString("dd/MM/yyyy");
            MySqlCommand Expirar1 = new MySqlCommand("delete  from reserva_materiales RM where RM.HoraFinalizacion<" + Hora + "", con);
            con.Close();
        }
        public static DataTable GruposMatutino()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand matutino = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Matutino' group by g.siglas;", con);
            matutino.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(matutino);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }

        public static DataTable GruposVespertino()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand vespertino = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino' group by g.siglas;", con);
            vespertino.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(vespertino);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }

        public static DataTable GruposIntermedio1()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand intermedio1 = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino inter 1' group by g.siglas;", con);
            intermedio1.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(intermedio1);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }

        public static DataTable GruposIntermedio2()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand intermedio2 = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Vespertino inter 2' group by g.siglas;", con);
            intermedio2.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(intermedio2);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }

        public static DataTable GruposNocturno()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            MySqlCommand nocturno = new MySqlCommand("select g.Siglas from grupos g,horarios_grupo hg,horarios h where g.Siglas=hg.IdGrupo and hg.IdHorario=h.Codigo and h.Turno='Nocturno' group by g.siglas;", con);
            nocturno.ExecuteNonQuery();
            MySqlDataAdapter da1 = new MySqlDataAdapter(nocturno);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            con.Close();
            return dt;
        }


        public static int nuevacontraseña(string cedula, string contraseña, string nuevacontraseña)
        {
            int ok = 0;
            MySqlConnection con = StringConexion();
            con.Open();
            try
            {
                MySqlCommand confirmar = new MySqlCommand("UPDATE [LOW_PRIORITY] [IGNORE] SET Contraseña = '" + nuevacontraseña + "' WHERE Cedula = '" + cedula + "' AND Contraseña = '" + contraseña + "' ", con);
                confirmar.ExecuteNonQuery();
                ok = 1;
                con.Close();
                return ok;
            }
            catch (MySqlException ex)
            {
                con.Close();
                return ok;
            }
        }
        public static void ExpirarReservas2()
        {
            MySqlConnection con = StringConexion();
            con.Open();
            DateTime Dia = DateTime.UtcNow.Date;
            int Hora = DateTime.UtcNow.Hour;
            String Hoy = Dia.ToString("dd/MM/yyyy");
            MySqlCommand Expirar1 = new MySqlCommand("Delete from reserva_salones where HoraFinalizacion<" + Hora + "", con);
            con.Close();
        }
    }


}



