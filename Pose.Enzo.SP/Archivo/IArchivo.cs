using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    /// <summary>
    /// Interfaz IArchivo creara firmas para las clases Sql, Texto y Xml
    /// </summary>
    public interface IArchivo
    {
        #region Firmas
        /// <summary>
        /// Firma del metodo Guardar que guardara los datos de la lista de patentes
        /// </summary>
        /// <param name="datos">datos que se desean guardar</param>
        /// <returns>retornara true si salio bien o false en caso contrario</returns>
        bool Guardar(List<Patente> datos);
        /// <summary>
        /// Firma del metodo Leer que leera los datos de un archivo o bbdd x
        /// </summary>
        /// <returns>Retornara la lista de patentes de ese archivo o bbdd x</returns>
        List<Patente> Leer();
        #endregion
    }
}
