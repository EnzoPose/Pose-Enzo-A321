using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Patentes
{
    #region Delegados
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);
    public delegate void MostrarPatente(object patente);
    #endregion

    public partial class VistaPatente : UserControl
    {
        #region Eventos
        public event FinExposicionPatente finExposicion;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de VistaPatente
        /// </summary>
        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)Tipo.Mercosur];
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que ira actualizando las patentes en pantalla cada 1.5 segundos
        /// </summary>
        /// <param name="patente">Patente que se mostrara por pantalla</param>
        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    // Llama al hilo principal para actualizar la interfaz de usuario.
                    lblPatenteNro.Invoke(new MostrarPatente(MostrarPatente), patente);

                    Thread.Sleep(1500);

                    // Dispara el evento de que finalizó la exposición de la patente.
                    finExposicion.Invoke(this);
                }
                catch (Exception) { }
            }
            else
            {
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();
            }

        }
    }
    #endregion
}
