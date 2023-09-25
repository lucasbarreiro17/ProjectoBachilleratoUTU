
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Login.FormsAPP;
using Login.FormsAPP.Administrador;
using Login.FormsAPP.Administrativo;
using Login.FormsAPP.Adscripto;
using Login.FormsAPP.Alumno;
using Login.FormsAPP.Profesor;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using MySql.Data.MySqlClient;



namespace Login
{

    public partial class Principal : Form
    {

        ClaseEntidad objeuser = new ClaseEntidad();
        ClaseNegocio objnuser = new ClaseNegocio();

        public static string usuario_nombre;
        public static string area;

        public static string areaGlobal = null;
        public static int x = 1;
        public static int s = 1;
        public static int a = 1;
        public static int Conf = 0;
        public static int register = 0;



        //===============================================================[ SENTENCIA LOGEO ]==================================================================================================//

        void Logeo()
        {
            DataTable dt = new DataTable();
            objeuser.Usuario = txtUsuario.Text;
            objeuser.Contraseña = txtContraseña.Text;
            dt = objnuser.CNegocio(objeuser);


            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido/a " + dt.Rows[0][2].ToString(), "Tu rol es " + dt.Rows[0][4], MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][3].ToString();
                area = dt.Rows[0][4].ToString();

                FormsAPP.Alumno.HorariosA Fhorarios = new FormsAPP.Alumno.HorariosA(area);

                //acultarlo para que se logee
                BcerrarS.Visible = true;
                Bescape.Visible = false;
                ContenedorBotones.Visible = true;
                txtNombre.Visible = false;
                panel1.Visible = false;
                button3.Visible = false;
                areaGlobal = area;
                ContenedorGeneral.BackColor = Color.Transparent;
                cargarForms(area); // METODO QUE DEFINE LOS FORMS.
                carusuario(area); // EXAMINADOR DEL ROL PERTINENTE.      
                TamañoDefecto();

            }
            else
            {
                if (txtUsuario.Text == "CEDULA" || txtUsuario.Text == null)
                {
                    MessageBox.Show("No se lleno el campo de usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtContraseña.Text == "CONTRASEÑA" || txtContraseña.Text == null)
                {
                    MessageBox.Show("No se lleno el campo de contraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        //===================================================================[ FIN SENTENCIA LOGEO ]==========================================================================================//
        //===================================================================[ COMIENZO DEL PROGRAMA ]========================================================================================//


        public Principal(string area)
        {
            //-------------------------
            InitializeComponent();//---
            //-------------------------
            comboBoxRol.Items.Add("Profesor");
            comboBoxRol.Items.Add("Administrativo");
            comboBoxRol.Items.Add("Adscripto");
            comboBoxRol.Items.Add("Administrador");
        }




        //======[ EXAMINADOR DEL ROL PERTINENTE PARA SABER QUE MOSTRAR ]=======//

        public void carusuario(string areax)
        {
            switch (areax)
            {
                case "Adscripto":
                    // oculto botones.
                    ContenedorH.Visible = false;
                    ContenedorHerramientas.Visible = true;
                    ContenedorA.Visible = true;
                    button1.Visible = true;
                    Bhorarios.Visible = false;
                    BhorariosP.Visible = false;
                    Bblog.Visible = true;
                    Basis2.Visible = true;
                    BasistenciasA.Visible = false;
                    BreservasADI.Visible = false;
                    Baviso.Visible = true;
                    Bbuscar.Visible = true;
                    button2.Visible = false;
                    Bagregar.Visible = false;
                    Binscribir.Visible = true;
                    Bconsultas.Visible = false;
                    button5.Visible = true;
                    Bsalones.Visible = true;
                    break;
                case "Estudiante":
                    // oculto botones.
                    ContenedorH.Visible = true;
                    ContenedorHerramientas.Visible = false;
                    ContenedorA.Visible = true;
                    button1.Visible = true;
                    Bhorarios.Visible = true;
                    BhorariosP.Visible = false;
                    Bblog.Visible = true;
                    Basis2.Visible = true;
                    BasistenciasA.Visible = false;
                    BreservasADI.Visible = false;
                    Baviso.Visible = false;
                    Bbuscar.Visible = false;
                    button2.Visible = false;
                    Bagregar.Visible = false;
                    Binscribir.Visible = false;
                    Bconsultas.Visible = false;
                    button5.Visible = true;
                    Bsalones.Visible = true;
                    break;
                case "Administrador":
                    // oculto botones.
                    ContenedorH.Visible = true;
                    ContenedorHerramientas.Visible = true;
                    ContenedorA.Visible = true;
                    button1.Visible = true;
                    Bhorarios.Visible = true;
                    BhorariosP.Visible = true;
                    Bblog.Visible = true;
                    Basis2.Visible = true;
                    BasistenciasA.Visible = true;
                    BreservasADI.Visible = false;
                    Baviso.Visible = true;
                    Bbuscar.Visible = false;
                    button2.Visible = true;
                    Bagregar.Visible = true;
                    Binscribir.Visible = false;
                    Bconsultas.Visible = false;
                    button5.Visible = true;
                    Bsalones.Visible = true;
                    break;
                case "Profesor":
                    // oculto botones.
                    ContenedorH.Visible = true;
                    ContenedorHerramientas.Visible = true;
                    ContenedorA.Visible = true;
                    button1.Visible = true;
                    Bhorarios.Visible = false;
                    BhorariosP.Visible = true;
                    Bblog.Visible = true;
                    Basis2.Visible = false;
                    BasistenciasA.Visible = true;
                    BreservasADI.Visible = true;
                    Baviso.Visible = false;
                    Bbuscar.Visible = false;
                    button2.Visible = false;
                    Bagregar.Visible = false;
                    Binscribir.Visible = false;
                    Bconsultas.Visible = false;
                    button5.Visible = true;
                    Bsalones.Visible = true;
                    break;
                case "Administrativo":
                    // oculto botones.
                    ContenedorH.Visible = false;
                    ContenedorHerramientas.Visible = true;
                    ContenedorA.Visible = true;
                    button1.Visible = true;
                    Bhorarios.Visible = false;
                    BhorariosP.Visible = false;
                    Bblog.Visible = true;
                    Basis2.Visible = true;
                    BasistenciasA.Visible = false;
                    BreservasADI.Visible = false;
                    Baviso.Visible = true;
                    Bbuscar.Visible = false;
                    button2.Visible = false;
                    Bagregar.Visible = false;
                    Binscribir.Visible = false;
                    Bconsultas.Visible = true;
                    button5.Visible = true;
                    Bsalones.Visible = true;
                    break;
                default:
                    MessageBox.Show("Su usuario fue desactivado,no puede ingresar al programa.");
                this.Contenedor.Controls.Remove(FasistenciaP);
                this.Contenedor.Controls.Remove(Fblog);
                this.Contenedor.Controls.Remove(Fopciones);
                this.Contenedor.Controls.Remove(Freservas);
                this.Contenedor.Controls.Remove(Finscribir);
                this.Contenedor.Controls.Remove(Fbuscar);
                this.Contenedor.Controls.Remove(Fagregar);
                this.Contenedor.Controls.Remove(FhorariosA);
                this.Contenedor.Controls.Remove(Fhome);
                this.Contenedor.Controls.Remove(Fbajas);
                this.Contenedor.Controls.Remove(Fsalones);
                this.Contenedor.Controls.Remove(FasistenciaA);
                this.Contenedor.Controls.Remove(Fhprofesor);
                this.Contenedor.Controls.Remove(Fpersonal);
                this.Contenedor.Controls.Remove(Faviso);
                

                Bescape.Visible = true;
                BcerrarS.Visible = false;
                ContenedorBotones.Visible = false;
                txtNombre.Visible = true;
                panel1.Visible = true;
                ContenedorGeneral.BackColor = Color.Black;
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = false;
                txtConfirmar.UseSystemPasswordChar = false;
                //copio el bloque de codigo del register para hacer todo visible.
                label3.Visible = true;
                label9.Visible = false;
                txtApellido.Visible = false;
                txtContraseña.Visible = true;
                textNombre.Visible = false;
                txtEmail.Visible = false;
                comboBoxRol.Visible = false;
                textContacto.Visible = false;
                txtConfirmar.Visible = false;
                BtnLogin.Visible = true;
                btnSalir.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button3.Visible = true;
                label8.Visible = false;
                txtROL.Visible = false;
                BtnRegister.Visible = false;
                linkRegister.Visible = true;
                LinkContraseña.Visible = true;
                txtContraseña.Text = "CONTRASEÑA";
                txtUsuario.Text = "CEDULA";


                    break;
            }

        }
        //-----------------------------------------------[CASO ASISTENCIAS]-------------------------------------------------------------//



        private void BAsistenciaGeneral_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                x = 0;
                s = 1;
                a = 1;
                //
                if (ContenedorH.Visible == false && Bconsultas.Visible == true)
                {
                    // ES UN ADMINISTRATIVO:
                    ContenedorA.Size = new System.Drawing.Size(300, 100);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                }
                else if (BreservasADI.Visible == true && Bhorarios.Visible == false)
                {
                    // ES UN PROFESOR:
                    ContenedorA.Size = new System.Drawing.Size(300, 100);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                }
                else if (ContenedorHerramientas.Visible == false)
                {
                    //ES UN ESTUDIANTE:
                    ContenedorA.Size = new System.Drawing.Size(300, 100);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                }
                else if (ContenedorHerramientas.Visible == true && ContenedorH.Visible == false && Bbuscar.Visible == true)
                {
                    //ES UN ADSCRIPTO:
                    ContenedorA.Size = new System.Drawing.Size(300, 100);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                }
                else if(button2.Visible == true)
                {
                    //ES UN ADMIN:
                    ContenedorA.Size = new System.Drawing.Size(300, 150);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                }

            }
            else
            {
                x = 1;
                ContenedorA.Size = new System.Drawing.Size(300, 50);
            }
        }

        //-----------------------------------------------[CASO HERRAMIENTAS]-------------------------------------------------------------//

        private void Bherramientas_Click(object sender, EventArgs e)
        {
            if (s == 1)
            {
                s = 0;
                x = 1;
                a = 1;
                if (ContenedorH.Visible == false && Bconsultas.Visible == true)
                {
                    // ES UN ADMINISTRATIVO:
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 150);
                }
                else if (BreservasADI.Visible == true && Bhorarios.Visible == false)
                {
                    // ES UN PROFESOR:
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 100);
                }
                else if (ContenedorHerramientas.Visible == true && ContenedorH.Visible == false && Bbuscar.Visible == true)
                {
                    //ES UN ADSCRIPTO:
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 200);
                }
                else if (button2.Visible == true)
                {
                    //ES UN ADMIN:
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 200);
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 50);
                }
            }
            else
            {
                s = 1;
                ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
            }
        }

        //-----------------------------------------------[CASO HORARIOS]-------------------------------------------------------------//

        private void BHorariosGeneral_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                a = 0;
                s = 1;
                x = 1;

                if (BreservasADI.Visible == true && Bhorarios.Visible == false)
                {
                    // ES UN PROFESOR:
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 100);
                }
                else if (ContenedorHerramientas.Visible == false)
                {
                    //ES UN ESTUDIANTE:
                    ContenedorH.Size = new System.Drawing.Size(300, 100);
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                }
                else if (ContenedorHerramientas.Visible == true && ContenedorH.Visible == false && Bbuscar.Visible == true)
                {
                    //ES UN ADSCRIPTO:
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 100);
                }
                else if (button2.Visible == true)
                {
                    //ES UN ADMIN:
                    ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
                    ContenedorA.Size = new System.Drawing.Size(300, 50);
                    ContenedorH.Size = new System.Drawing.Size(300, 150);
                }
            }
            else
            {
                a = 1;
                ContenedorH.Size = new System.Drawing.Size(300, 50);
            }
        }

        //============[ FIN EXAMINADOR ]=================//

        //==========================================================================[ DISEÑO ]================================================================================================//

        private void TamañoDefecto()
        {
            // LE PONGO EL TAMAÑO MINIMO A LOS CONTENEDORES POR DEFECTO:
            ContenedorA.Size = new System.Drawing.Size(300, 50);
            ContenedorHerramientas.Size = new System.Drawing.Size(300, 50);
            ContenedorH.Size = new System.Drawing.Size(300, 50);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Bminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //==============[ PARA QUE SE PUEDA MOVER LA VENTANA A TRAVEZ DE PANEL ]=========================//

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //==============================[ FIN VENTANA QUE SE MUEVE ]======================================//

        private void Bescape_MouseEnter(object sender, EventArgs e)
        {
            Bescape.BackColor = Color.Red;
        }

        private void Bescape_MouseLeave(object sender, EventArgs e)
        {
            Bescape.BackColor = Color.Transparent;
        }

        /* SENTENCIAS A PARTIR DE AQUI:
         * 1) DEFINO FORMS PARA PODER LLAMARLOS.
         * 2) LOS FORMS SE CARGARGARAN DENTRO DEL PANEL LLAMADO CONTENEDOR.
         * 3) LOS PANELES SE CARGARAN DEPENDIENDO DEL BOTON QUE SE TOQUE(DENTRO DEL PANEL CONBOTONES) CUANDO EL PROGRAMA ESTE EN EJECUCION.
         */

        HorariosP Fhprofesor = null;
        HOME Fhome = null;
        PersonalADM Fpersonal = null;
        AsistenciaA FasistenciaA = null;
        HorariosA FhorariosA = null;
        OPCIONES Fopciones = null;
        MandarInasistencia FasistenciaP = null;
        Reservas Freservas = null;
        BuscarAlumno Fbuscar = null;
        BLOG Fblog = null;
        AvisoHome Faviso = null;
        Agregar Fagregar = null;
        InscribirAlumno Finscribir = null;
        Salones Fsalones = null;
        DarBajas Fbajas = null;
        

        public void cargarForms(string areaaa)
        {
            Fhome = new HOME() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fpersonal = new PersonalADM() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FasistenciaA = new AsistenciaA(areaaa) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FhorariosA = new HorariosA(areaaa) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fopciones = new OPCIONES(areaaa) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FasistenciaP = new MandarInasistencia(areaaa) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Freservas = new Reservas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fbuscar = new BuscarAlumno() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fblog = new BLOG() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fhprofesor = new HorariosP(areaaa) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Faviso = new AvisoHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fagregar = new Agregar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Finscribir = new InscribirAlumno() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fsalones = new Salones() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Fbajas = new DarBajas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        }





        private void button5_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Add(Fopciones);
            Fopciones.Show();
        }

        private void Bblog_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Fblog);
            Fblog.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Fhome);
            Fhome.Show();
        }

        private void Bhorarios_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(FhorariosA);
            FhorariosA.Show();
        }

        private void BhorariosP_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Fhprofesor);
            Fhprofesor.Show();
        }

        private void Basis2_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(FasistenciaA);
            FasistenciaA.Show();
        }

        private void BasistenciasA_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(FasistenciaP);
            FasistenciaP.Show();
        }

        private void BreservasADI_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Freservas);
            Freservas.Show();
        }

        private void Baviso_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Add(Faviso);
            Faviso.Show();
        }

        private void Bbuscar_Click_1(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Fbuscar);
            Fbuscar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Add(Fpersonal);
            Fpersonal.Show();
        }


        //=========================================================[ SENTENCIA DE COMO ESTAN HECHOS LOS BOTONES DESPLEGABLES ]========================================================//


        

        //======================================================================[ FIN BOTONES DESPLEGABLES ]==========================================================================//

        private void Bagregar_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Add(Fagregar);
            Fagregar.Show();
        }

        //=====================================================================================[ FIN DISEÑO ]=================================================================================//

        //========================================================================================[ LOGIN ]===================================================================================//

        private void BtnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void BtnRegister_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnRegister_Click(sender, e);//llama al evento click del boton
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Logeo();
        }

        //========================================================================================[ REGISTER ]================================================================================//

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "APELLIDO" && txtConfirmar.Text != "CONFIRMAR  CONTRASEÑA" && txtContraseña.Text != "CONTRASEÑA" && txtEmail.Text != "EMAIL" && textContacto.Text != "" && comboBoxRol.Text != null && txtUsuario.Text != "CEDULA" && textNombre.Text != "NOMBRE" && txtApellido.Text != null && txtConfirmar.Text != null && txtContraseña.Text != null && txtEmail.Text != null && textContacto.Text != null && txtUsuario.Text != null && textNombre.Text != null)
            {
                if (txtContraseña.Text == txtConfirmar.Text)
                {
                    if (txtUsuario.Text.Length == 8)
                    {
                        if (comboBoxRol.Text != "")
                        {
                            try
                            {
                                String consulta = CapaDatos.ClaseDatos.RegistrarUsuario(txtUsuario.Text, textNombre.Text, txtApellido.Text, txtEmail.Text, txtContraseña.Text, textContacto.Text, comboBoxRol.Text);
                                if (consulta == "1")
                                {
                                    register = 0;
                                    MessageBox.Show("Solicitud de registro enviada con exito");
                                    txtContraseña.UseSystemPasswordChar = false;
                                    txtConfirmar.UseSystemPasswordChar = false;
                                    txtApellido.Text = "APELLIDO";
                                    txtConfirmar.Text = "CONFIRMAR  CONTRASEÑA";
                                    txtContraseña.Text = "CONTRASEÑA";
                                    txtEmail.Text = "EMAIL";
                                    textContacto.Text = "NUMERO DE CONTACTO";
                                    comboBoxRol.Text = null;
                                    txtUsuario.Text = "CEDULA";
                                    textNombre.Text = "NOMBRE";


                                    // OCULTO TODOS LOS COMPONENTES DEL REGISTER Y HAGO VISIBLE TODOS LOS DEL LOGIN.

                                    label3.Visible = true;
                                    label9.Visible = false;
                                    txtApellido.Visible = false;
                                    txtContraseña.Visible = true;
                                    textNombre.Visible = false;
                                    txtEmail.Visible = false;
                                    comboBoxRol.Visible = false;
                                    textContacto.Visible = false;
                                    txtConfirmar.Visible = false;
                                    BtnLogin.Visible = true;
                                    btnSalir.Visible = false;
                                    label4.Visible = false;
                                    label5.Visible = false;
                                    label6.Visible = false;
                                    label7.Visible = false;
                                    label8.Visible = false;
                                    txtROL.Visible = false;
                                    BtnRegister.Visible = false;
                                    linkRegister.Visible = true;
                                    LinkContraseña.Visible = true;
                                }
                                else
                                {
                                    char[] error = consulta.ToCharArray();
                                    string codigoerror = error[39].ToString() + error[40].ToString() + error[41].ToString() + error[42].ToString() + error[43].ToString() + error[44].ToString() + error[45].ToString() + error[46].ToString() + error[47].ToString() + error[48].ToString();
                                    if (codigoerror == "0x80004005")
                                    {
                                        MessageBox.Show("Ya existe una solicitud de registro con esta cedula", "ERROR");
                                    }
                                }

                            }
                            catch (SystemException ex)
                            {
                                MessageBox.Show("" + ex + "");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol, PORFAVOR");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de digitos en cedula no son validos");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
            else
            {
                MessageBox.Show("Uno de los campos esta sin completar");
            }

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "CEDULA")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = true;
            }

        }

        private void txtConfirmar_Enter(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "CONFIRMAR  CONTRASEÑA")
            {
                txtConfirmar.Text = "";
                txtConfirmar.ForeColor = Color.DimGray;
                txtConfirmar.UseSystemPasswordChar = true;
            }
        }

        private void txtApellido_Enter(object sender, EventArgs e)
        {
            if (txtApellido.Text == "APELLIDO")
            {
                txtApellido.Text = "";
                txtApellido.ForeColor = Color.DimGray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "EMAIL")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.DimGray;
            }
        }

        private void textContacto_Enter(object sender, EventArgs e)
        {
            if (textContacto.Text == "NUMERO DE CONTACTO")
            {
                textContacto.Text = "";
                textContacto.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "CEDULA";
                txtUsuario.ForeColor = Color.DimGray;
            }
            else
            {
                if (register == 1)
                {
                    txtContraseña.Text = txtUsuario.Text;
                    txtConfirmar.Text = txtUsuario.Text;
                    txtContraseña.UseSystemPasswordChar = true;
                    txtConfirmar.UseSystemPasswordChar = true;
                }
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirmar_Leave(object sender, EventArgs e)
        {
            if (txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "CONFIRMAR  CONTRASEÑA";
                txtConfirmar.ForeColor = Color.DimGray;
                txtConfirmar.UseSystemPasswordChar = false;
            }
        }



        private void txtApellido_Leave(object sender, EventArgs e)
        {
            if (txtApellido.Text == "")
            {
                txtApellido.Text = "APELLIDO";
                txtApellido.ForeColor = Color.DimGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "EMAIL";
                txtEmail.ForeColor = Color.DimGray;
            }
        }

        private void textContacto_Leave(object sender, EventArgs e)
        {
            if (textContacto.Text == "")
            {
                textContacto.Text = "NUMERO DE CONTACTO";
                textContacto.ForeColor = Color.DimGray;
            }
        }



        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // HAGO VISIBLE TODOS LOS COMPONENETES DEL REGISTER Y OCULTO TODOS LOS DEL LOGIN.

            //combobox del register

            register = 1;
            label3.Visible = false;
            label9.Visible = true;
            txtApellido.Visible = true;
            txtContraseña.Visible = true;
            textNombre.Visible = true;
            txtEmail.Visible = true;
            comboBoxRol.Visible = true;
            textContacto.Visible = true;
            txtConfirmar.Visible = true;
            BtnLogin.Visible = false;
            btnSalir.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            txtROL.Visible = true;
            BtnRegister.Visible = true;
            linkRegister.Visible = false;
            LinkContraseña.Visible = false;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void txtConfirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void textContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void comboBoxRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnLogin_Click(sender, e);//llama al evento click del boton
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            txtConfirmar.Text = "CONFIRMAR CONTRASEÑA";
            txtContraseña.Text = "CONTRASEÑA";
            txtContraseña.UseSystemPasswordChar = false;
            txtConfirmar.UseSystemPasswordChar = false;
            register = 0;
            label3.Visible = true;
            label9.Visible = false;
            txtApellido.Visible = false;
            txtContraseña.Visible = true;
            txtEmail.Visible = false;
            textNombre.Visible = false;
            comboBoxRol.Visible = false;
            textContacto.Visible = false;
            txtConfirmar.Visible = false;
            BtnLogin.Visible = true;
            btnSalir.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            txtROL.Visible = false;
            BtnRegister.Visible = false;
            linkRegister.Visible = true;
            LinkContraseña.Visible = true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textNombre.Text == "NOMBRE")
            {
                textNombre.Text = "";
                textNombre.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text == "")
            {
                textNombre.Text = "NOMBRE";
                textNombre.ForeColor = Color.DimGray;
            }
        }

        private void BcerrarS_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea Cerrar Sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Contenedor.Controls.Remove(FasistenciaP);
                this.Contenedor.Controls.Remove(Fblog);
                this.Contenedor.Controls.Remove(Fopciones);
                this.Contenedor.Controls.Remove(Freservas);
                this.Contenedor.Controls.Remove(Finscribir);
                this.Contenedor.Controls.Remove(Fbuscar);
                this.Contenedor.Controls.Remove(Fagregar);
                this.Contenedor.Controls.Remove(FhorariosA);
                this.Contenedor.Controls.Remove(Fhome);
                this.Contenedor.Controls.Remove(Fbajas);
                this.Contenedor.Controls.Remove(Fsalones);
                this.Contenedor.Controls.Remove(FasistenciaA);
                this.Contenedor.Controls.Remove(Fhprofesor);
                this.Contenedor.Controls.Remove(Fpersonal);
                this.Contenedor.Controls.Remove(Faviso);
                

                Bescape.Visible = true;
                BcerrarS.Visible = false;
                ContenedorBotones.Visible = false;
                txtNombre.Visible = true;
                panel1.Visible = true;
                ContenedorGeneral.BackColor = Color.Black;
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = false;
                txtConfirmar.UseSystemPasswordChar = false;
                //copio el bloque de codigo del register para hacer todo visible.
                label3.Visible = true;
                label9.Visible = false;
                txtApellido.Visible = false;
                txtContraseña.Visible = true;
                textNombre.Visible = false;
                txtEmail.Visible = false;
                comboBoxRol.Visible = false;
                textContacto.Visible = false;
                txtConfirmar.Visible = false;
                BtnLogin.Visible = true;
                btnSalir.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button3.Visible = true;
                label8.Visible = false;
                txtROL.Visible = false;
                BtnRegister.Visible = false;
                linkRegister.Visible = true;
                LinkContraseña.Visible = true;
                txtContraseña.Text = "CONTRASEÑA";
                txtUsuario.Text = "CEDULA";
            }
            else if (dialogResult == DialogResult.No)
            {
                //no cierra nada.
            }
        }

        private void BcerrarS_MouseEnter(object sender, EventArgs e)
        {
            BcerrarS.BackColor = Color.Orange;
        }

        private void BcerrarS_MouseLeave(object sender, EventArgs e)
        {
            BcerrarS.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DodgerBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void BHorariosGeneral_MouseEnter(object sender, EventArgs e)
        {
            BHorariosGeneral.BackColor = Color.DodgerBlue;
        }

        private void BHorariosGeneral_MouseLeave(object sender, EventArgs e)
        {
            BHorariosGeneral.BackColor = Color.Transparent;
        }

        private void Bhorarios_MouseEnter(object sender, EventArgs e)
        {
            Bhorarios.BackColor = Color.DodgerBlue;
        }

        private void Bhorarios_MouseLeave(object sender, EventArgs e)
        {
            Bhorarios.BackColor = Color.Transparent;
        }

        private void BhorariosP_MouseEnter(object sender, EventArgs e)
        {
            BhorariosP.BackColor = Color.DodgerBlue;
        }

        private void BhorariosP_MouseLeave(object sender, EventArgs e)
        {
            BhorariosP.BackColor = Color.Transparent;
        }

        private void Bblog_MouseEnter(object sender, EventArgs e)
        {
            Bblog.BackColor = Color.DodgerBlue;
        }

        private void Bblog_MouseLeave(object sender, EventArgs e)
        {
            Bblog.BackColor = Color.Transparent;
        }

        private void BAsistenciaGeneral_MouseEnter(object sender, EventArgs e)
        {
            BAsistenciaGeneral.BackColor = Color.DodgerBlue;
        }

        private void BAsistenciaGeneral_MouseLeave(object sender, EventArgs e)
        {
            BAsistenciaGeneral.BackColor = Color.Transparent;
        }

        private void Basis2_MouseEnter(object sender, EventArgs e)
        {
            Basis2.BackColor = Color.DodgerBlue;
        }

        private void Basis2_MouseLeave(object sender, EventArgs e)
        {
            Basis2.BackColor = Color.Transparent;
        }

        private void BasistenciasA_MouseEnter(object sender, EventArgs e)
        {
            BasistenciasA.BackColor = Color.DodgerBlue;
        }

        private void BasistenciasA_MouseLeave(object sender, EventArgs e)
        {
            BasistenciasA.BackColor = Color.Transparent;
        }

        private void Bherramientas_MouseEnter(object sender, EventArgs e)
        {
            Bherramientas.BackColor = Color.DodgerBlue;
        }

        private void Bherramientas_MouseLeave(object sender, EventArgs e)
        {
            Bherramientas.BackColor = Color.Transparent;
        }

        private void BreservasADI_MouseEnter(object sender, EventArgs e)
        {
            BreservasADI.BackColor = Color.DodgerBlue;
        }

        private void BreservasADI_MouseLeave(object sender, EventArgs e)
        {
            BreservasADI.BackColor = Color.Transparent;
        }

        private void Baviso_MouseEnter(object sender, EventArgs e)
        {
            Baviso.BackColor = Color.DodgerBlue;
        }

        private void Baviso_MouseLeave(object sender, EventArgs e)
        {
            Baviso.BackColor = Color.Transparent;
        }

        private void Bbuscar_MouseEnter(object sender, EventArgs e)
        {
            Bbuscar.BackColor = Color.DodgerBlue;
        }

        private void Bbuscar_MouseLeave(object sender, EventArgs e)
        {
            Bbuscar.BackColor = Color.Transparent;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.DodgerBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void Bagregar_MouseEnter(object sender, EventArgs e)
        {
            Bagregar.BackColor = Color.DodgerBlue;
        }

        private void Bagregar_MouseLeave(object sender, EventArgs e)
        {
            Bagregar.BackColor = Color.Transparent;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.DodgerBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Transparent;
        }

        private void Bminimizar_MouseEnter(object sender, EventArgs e)
        {
            Bminimizar.BackColor = Color.Gray;
        }

        private void Bminimizar_MouseLeave(object sender, EventArgs e)
        {
            Bminimizar.BackColor = Color.Transparent;
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtConfirmar.UseSystemPasswordChar == true && txtConfirmar.UseSystemPasswordChar == true)
            {
                txtnuevaContra.UseSystemPasswordChar = false;
                txtConfirmar.UseSystemPasswordChar = false;
                txtContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtnuevaContra.UseSystemPasswordChar = true;
                txtConfirmar.UseSystemPasswordChar = true;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void LinkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label3.Visible = false;
            button4.Visible = true;
            label10.Visible = true;
            BtnLogin.Visible = false;
            label11.Visible = true;
            txtnuevaContra.Visible = true;
            linkRegister.Visible = false;
            LinkContraseña.Visible = false;
            SalirRepass.Visible = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            if (CapaDatos.ClaseDatos.nuevacontraseña(txtUsuario.Text, txtContraseña.Text, txtnuevaContra.Text) == 1)
            {// la onda es comparar aca si la contraseña actual ingresada es igual a la que esta en mysql teniendo como atributo a coincidir la cedula.
                label3.Visible = true;
                label10.Visible = false;
                txtnuevaContra.Visible = false;
                button4.Visible = false;
                label11.Visible = false;
                label11.Visible = false;
                BtnLogin.Visible = true;
                linkRegister.Visible = true;
                LinkContraseña.Visible = true;
                MessageBox.Show("contraseña cambiada con exito");
            }
            else
            {
                MessageBox.Show("La contraseña o la cedula son incorrectas");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void txtnuevaContra_Enter(object sender, EventArgs e)
        {
            if (txtnuevaContra.Text == "NUEVA CONTRASEÑA")
            {
                txtnuevaContra.Text = "";
                txtnuevaContra.ForeColor = Color.DimGray;
                txtnuevaContra.UseSystemPasswordChar = true;
            }
        }

        private void txtnuevaContra_Leave(object sender, EventArgs e)
        {
            if (txtnuevaContra.Text == "")
            {
                txtnuevaContra.Text = "NUEVA CONTRASEÑA";
                txtnuevaContra.ForeColor = Color.DimGray;
                txtnuevaContra.UseSystemPasswordChar = false;
            }
        }



        private void SalirRepass_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label9.Visible = false;
            txtApellido.Visible = false;
            txtContraseña.Visible = true;
            textNombre.Visible = false;
            txtEmail.Visible = false;
            comboBoxRol.Visible = false;
            textContacto.Visible = false;
            txtConfirmar.Visible = false;
            BtnLogin.Visible = true;
            btnSalir.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            txtROL.Visible = false;
            BtnRegister.Visible = false;
            linkRegister.Visible = true;
            LinkContraseña.Visible = true;

            label3.Visible = true;
            button4.Visible = false;
            label10.Visible = false;
            BtnLogin.Visible = true;
            label11.Visible = false;
            txtnuevaContra.Visible = false;
            linkRegister.Visible = true;
            LinkContraseña.Visible = true;
            SalirRepass.Visible = false;
        }

        private void txtnuevaContra_MouseEnter(object sender, EventArgs e)
        {
            /*
            if (txtnuevaContra.Text == "NUEVA CONTRASEÑA")
            {
                txtnuevaContra.Text = "";
                txtnuevaContra.ForeColor = Color.DimGray;
                txtnuevaContra.UseSystemPasswordChar = false;
            }
             */
        }

        private void txtnuevaContra_MouseLeave(object sender, EventArgs e)
        {
            /*
            if (txtnuevaContra.Text == "")
            {
                txtnuevaContra.Text = "NUEVA CONTRASEÑA";
                txtnuevaContra.ForeColor = Color.DimGray;
                txtnuevaContra.UseSystemPasswordChar = false;
            }
             */

        }

        private void Binscribir_MouseEnter(object sender, EventArgs e)
        {
            Binscribir.BackColor = Color.DodgerBlue;
        }

        private void Binscribir_MouseLeave(object sender, EventArgs e)
        {
            Binscribir.BackColor = Color.Transparent;
        }

        private void Bsalones_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Add(Fsalones);
            Fsalones.Show();
        }

        private void Binscribir_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Add(Finscribir);
            Finscribir.Show();
        }

        private void Bsalones_MouseEnter(object sender, EventArgs e)
        {
            Bsalones.BackColor = Color.DodgerBlue;
        }

        private void Bsalones_MouseLeave(object sender, EventArgs e)
        {
            Bsalones.BackColor = Color.Transparent;
        }

        private void Bconsultas_Click(object sender, EventArgs e)
        {
            this.Contenedor.Controls.Remove(FasistenciaP);
            this.Contenedor.Controls.Remove(FasistenciaA);
            this.Contenedor.Controls.Remove(Fopciones);
            this.Contenedor.Controls.Remove(Freservas);
            this.Contenedor.Controls.Remove(Fhprofesor);
            this.Contenedor.Controls.Remove(Faviso);
            this.Contenedor.Controls.Remove(Fblog);
            this.Contenedor.Controls.Remove(Fhome);
            this.Contenedor.Controls.Remove(Finscribir);
            this.Contenedor.Controls.Remove(FhorariosA);
            this.Contenedor.Controls.Remove(Fbajas);
            this.Contenedor.Controls.Remove(Fagregar);
            this.Contenedor.Controls.Remove(Fpersonal);
            this.Contenedor.Controls.Remove(Fbuscar);
            this.Contenedor.Controls.Remove(Fsalones);
            this.Contenedor.Controls.Add(Fbajas);
            Fbajas.Show();
        }

        private void Bconsultas_MouseEnter(object sender, EventArgs e)
        {
            Bconsultas.BackColor = Color.DodgerBlue;
        }

        private void Bconsultas_MouseLeave(object sender, EventArgs e)
        {
            Bconsultas.BackColor = Color.Transparent;
        }



        //==============================================================================[ FIN REGISTER Y LOGIN ]==============================================================================//




    }
}
//=================================================================================[ FIN PROGRAMA ]===================================================================================//