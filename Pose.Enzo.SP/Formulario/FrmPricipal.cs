using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Archivo;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Formulario
{
    /// <summary>
    /// Formulario principal para la gestión de patentes.
    /// </summary>
    public partial class FrmPricipal : Form
    {
        List<Patente> patentes;
        List<Thread> hilos;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmPricipal"/>.
        /// </summary>
        public FrmPricipal()
        {
            InitializeComponent();
            patentes = new List<Patente>();
            hilos = new List<Thread>();
        }

        /// <summary>
        /// Manejador del evento Load del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_Load(object sender, EventArgs e)
        {
            vistaPatente.finExposicion += ProximaPatente;
        }

        /// <summary>
        /// Manejador del evento FormClosing del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarSimulacion();
        }

        /// <summary>
        /// Manejador del evento Click del botón para agregar más patentes.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                List<Patente> listPatente = new List<Patente>
                {
                    new Patente("CP709WA", Tipo.Mercosur),
                    new Patente("DIB009", Tipo.Vieja),
                    new Patente("FD010GC", Tipo.Mercosur)
                };

                // Implementar acá el punto del botón +
                Task.Run(() =>
                {
                    Sql sql = new Archivo.Sql();
                    if (sql.Guardar(listPatente))
                    {
                        MessageBox.Show("¡Patentes guardadas en la base dedatos!");
                    }
                    else
                    {
                        MessageBox.Show("¡Error al guardar en la base de datos!");
                    }
                });

                Task.Run(() =>
                {
                    Xml xml = new Archivo.Xml();
                    if (xml.Guardar(listPatente))
                    {
                        MessageBox.Show("¡Patentes guardadas en el archivo xml!");
                    }
                    else
                    {
                        MessageBox.Show("¡Error al guardar en el archivo xml!");
                    }
                });

                Task.Run(() =>
                {
                    Texto txt = new Texto();
                    if (txt.Guardar(listPatente))
                    {
                        MessageBox.Show("¡Patentes guardadas en el archivo!");
                    }
                    else
                    {
                        MessageBox.Show("¡Patentes guardadas en el archivo!");
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde la base de datos SQL.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                Sql sql = new Sql();
                List<Patente> patentesSql = sql.Leer();
                patentes = patentesSql;
                IniciarSimulacion();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"¡Error al leer la base de datos! {ex.Message}");
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                Xml xml = new Xml();
                List<Patente> patentesXml = xml.Leer();
                patentes = patentesXml;
                IniciarSimulacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"¡Error al leer la base de datos! {ex.Message}");
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                Texto txt = new Texto();
                List<Patente> patentesTxt = txt.Leer();
                patentes = patentesTxt;
                IniciarSimulacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"¡Error al leer la base de datos! {ex.Message}");
            }
        }

        /// <summary>
        /// Inicia la simulación de visualización de patentes.
        /// </summary>
        private void IniciarSimulacion()
        {
            // Implementar el método FinalizarSimulación
            // que se encarga de finalizar todos los hilos activos
            FinalizarSimulacion();
            foreach(Control control in Controls)
            {
                if(control is Patentes.VistaPatente vistaPatente)
                {
                    ProximaPatente(vistaPatente);
                }
            }
        }

        /// <summary>
        /// Muestra la próxima patente en la vista.
        /// </summary>
        /// <param name="vistaPatente">La vista de la patente.</param>
        private void ProximaPatente(Patentes.VistaPatente vistaPatente)
        {
            // Inicializará un hilo parametrizado para el método MostrarPatente del objeto VistaPatente recibido.
            if(patentes.Count >0)
            {
                Patente proximaPatente = patentes[0];
                patentes.Remove(proximaPatente);
                Thread thread = new Thread(new ParameterizedThreadStart(vistaPatente.MostrarPatente));

                hilos.Add(thread);
                thread.Start(proximaPatente);

            }

            //Implementar acá el manejo de hilos
        }
        /// <summary>
        /// Metodo que finaliza la simulacion y corta el ciclo de vida de los hilos actuales y los limpia de la lista
        /// </summary>
        private void FinalizarSimulacion()
        {
            foreach(Thread hilo in this.hilos)
            {
                if (hilo.IsAlive)
                {
                    hilo.Join();
                }
            }
            hilos.Clear();
        }
    }
}
