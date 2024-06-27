using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace SP
{

    public partial class ModeloSegundoParcial : Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public Cajon<Manzana> c_manzanas;
        public Cajon<Banana> c_bananas;
        public Cajon<Durazno> c_duraznos;

        public ModeloSegundoParcial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Nombre, Apellido");
        }

        //Crear una instancia de cada clase e inicializar los atributos del form _manzana, _banana y _durazno. 
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("verde", 2, "rio negro");
            this._banana = new Banana("amarillo", 5, "ecuador");
            this._durazno = new Durazno("rojo", 2.5, 53);

            MessageBox.Show(this._manzana.ToString());
            MessageBox.Show(this._banana.ToString());
            MessageBox.Show(this._durazno.ToString());

        }

        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
       
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_manzanas = new Cajon<Manzana>(1.58, 3);
            this.c_bananas = new Cajon<Banana>(15.96, 4);
            this.c_duraznos = new Cajon<Durazno>(21.5, 1);

            this.c_manzanas += new Manzana("roja", 1, "neuquen");
            this.c_manzanas += this._manzana;
            this.c_manzanas += new Manzana("amarilla", 3, "san juan");

            this.c_bananas += new Banana("verde", 3, "brasil");
            this.c_bananas += this._banana;

            this.c_duraznos += this._durazno;

            MessageBox.Show(this.c_manzanas.ToString());
            MessageBox.Show(this.c_bananas.ToString());
            MessageBox.Show(this.c_duraznos.ToString());

        }

        //Implementar (implicitamente) ISerializar en Cajon y manzana
        //Implementar (explicitamente) IDeserializar en manzana
        //Los archivos .xml guardarlos en el escritorio
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;
            string escritorioPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaArchivoXmlManzana = Path.Combine(escritorioPath, "Manzana.xml");
            string rutaArchivoXmlCajonManzana = Path.Combine(escritorioPath, "CajonManzana.xml");
            // AGREGAR
            // Serealizacion implicita de manzana
            if (this._manzana.Xml(rutaArchivoXmlManzana))
            {
                MessageBox.Show("Manzana serializada OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

            // Deserealizacion explicita de manzana
            if (((IDeserializar)this._manzana).Xml(rutaArchivoXmlManzana, out aux))
            {
                MessageBox.Show("Manzana deserializada OK"); 
                // Agregar
            }
            else
            {
                MessageBox.Show("NO Deserializado");
            }

            // Serealizacion de cajon de manzanas
            if (this.c_manzanas.Xml(rutaArchivoXmlCajonManzana))
            {
                MessageBox.Show("Cajon de Manzanas serializado OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_manzanas += this._manzana;
            }
            catch (CajonLlenoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            //Asociar manejador de eventos y crearlo en la clase Manejadora (de instancia).
            // Llamar a la excepcion correspondiente
            // AGREGAR
            c_bananas.eventoPrecio += new Delegado(new ManejadorEventos().Manejadora);

            try
            {
                this.c_bananas += new Banana("verde", 2, "argentina");

                this.c_bananas += new Banana("amarilla", 4, "ecuador");

                MessageBox.Show(this.c_bananas.PrecioTotal.ToString());
            }

            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Obtener de la base de datos (ModeloSegundoParcial) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        // Mostrarlo por mensaje de dialogo
        private void btnPunto6_Click(object sender, EventArgs e) 
        {
            MessageBox.Show(ObtenerListadoFrutas());
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            // AGREGAR
            if (AgregarFrutas(this))
            {
                MessageBox.Show("Se agregaron las frutas a la Base de Datos");
            }
            else
            {

                MessageBox.Show("NO se agregaron las frutas a la Base de Datos"); 
            }
        }

        //Obtener de la base de datos (msp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        private static string ObtenerListadoFrutas()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                SqlCommand sqlCom = new SqlCommand();
                SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-JP7CUHO\\SQLEXPRESS;Initial Catalog=ModeloSegundoParcial;Integrated Security=True");
                using (sqlCom = new SqlCommand())
                {
                    sqlCom.Connection = conexion;
                    sqlCom.CommandType = System.Data.CommandType.Text;

                    string consulta = "SELECT id, nombre, peso, precio FROM frutas";
                    sqlCom.CommandText = consulta;

                    conexion.Open();

                    using (SqlDataReader sqlRead = sqlCom.ExecuteReader())
                    {
                        while (sqlRead.Read())
                        {
                            sb.AppendLine("Id:" + sqlRead["id"].ToString() + " - " +
                                "Nombre:" + sqlRead["nombre"].ToString() + " - " +
                                "Peso:" + sqlRead["peso"].ToString() + " - " +
                                "Precio:" + sqlRead["precio"].ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                sb.Clear();
                sb.AppendLine($"Error al obtener los elementos de la BBDD {ex.Message}");
            }
            catch (Exception ex)
            {
                sb.Clear();
                sb.AppendLine($"Error inesperado {ex.Message}");
            }
            return sb.ToString();
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        private static bool AgregarFrutas(ModeloSegundoParcial frm)
        {
            string connectionString = "Data Source=DESKTOP-JP7CUHO\\SQLEXPRESS;Initial Catalog=ModeloSegundoParcial;Integrated Security=True";
            string query = "INSERT INTO frutas (nombre, peso, precio) VALUES (@nombre, @peso, @precio)";
            try
            {
                using(SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();


                    foreach (Manzana manzana in frm.c_manzanas.Elementos)
                    {
                        using (SqlCommand sqlCom = new SqlCommand(query, conexion))
                        {
                            sqlCom.Parameters.AddWithValue("@nombre", manzana.Nombre);
                            sqlCom.Parameters.AddWithValue("@peso", manzana.Peso);
                            sqlCom.Parameters.AddWithValue("@precio", (float)frm.c_manzanas.PrecioTotal);
                            sqlCom.ExecuteNonQuery();
                            sqlCom.Parameters.Clear();
                        }
                    }
                    foreach (Banana banana in frm.c_bananas.Elementos)
                    {
                        using (SqlCommand sqlCom = new SqlCommand(query, conexion))
                        {
                            sqlCom.Parameters.AddWithValue("@nombre", banana.Nombre);
                            sqlCom.Parameters.AddWithValue("@peso", banana.Peso);
                            sqlCom.Parameters.AddWithValue("@precio", (float)frm.c_bananas.PrecioTotal);
                            sqlCom.ExecuteNonQuery();
                            sqlCom.Parameters.Clear();
                        }
                    }

                    foreach (Durazno durazno in frm.c_duraznos.Elementos)
                    {
                        using (SqlCommand sqlCom = new SqlCommand(query, conexion))
                        {
                            sqlCom.Parameters.AddWithValue("@nombre", durazno.Nombre);
                            sqlCom.Parameters.AddWithValue("@peso", durazno.Peso);
                            sqlCom.Parameters.AddWithValue("@precio", (float)frm.c_duraznos.PrecioTotal);
                            sqlCom.ExecuteNonQuery();
                            sqlCom.Parameters.Clear();
                        }
                    }
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al obtener los elementos de la BBDD {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado {ex.Message}");
                return false;
            }
        }
    }
}
