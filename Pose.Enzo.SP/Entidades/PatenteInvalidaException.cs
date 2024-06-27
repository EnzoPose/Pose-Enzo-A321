using System;

namespace Entidades
{
    public class PatenteInvalidaException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor publico de la excepcion PatenteInvalidaException recibe mensaje como parametro
        /// </summary>
        /// <param name="mensaje">mensaje que inicializara el atributo de la clase base</param>
        public PatenteInvalidaException(string mensaje) :base (mensaje) { }
        /// <summary>
        /// Constructor publico de la excepcion PatenteInvalidaException recibe mensaje e innerException como parametro
        /// </summary>
        /// <param name="mensaje">mensaje que inicializara el atributo de la clase base</param>
        /// <param name="innerException">innerException que inicializara el atributo de la clase base</param>
        public PatenteInvalidaException(string mensaje, Exception innerException) :base (mensaje, innerException) { }
        #endregion
    }
}
