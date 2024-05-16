using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Mascota
    {
        #region atributos
        private string _nombre;
        private string _raza;
        #endregion

        #region propiedades
        /// <summary>
        /// propiedades de lectura para el campo Nombre
        /// </summary>
        public string Nombre { get { return _nombre; } }

        /// <summary>
        /// propiedades de lectura para el campo Raza
        /// </summary>
        public string Raza { get { return _raza; } }
        #endregion

        #region constructor
        /// <summary>
        /// constructor para la clase Mascota
        /// </summary>
        /// <param name="nombre">Nombre de la mascota</param>
        /// <param name="raza">Raza de la mascota</param>
        public Mascota(string nombre, string raza)
        {
            this._nombre = nombre;
            this._raza = raza;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Metodo abstracto Ficha
        /// </summary>
        /// <returns></returns>
        protected abstract string Ficha();

        /// <summary>
        /// Devuelve los datos completos de la mascota
        /// </summary>
        /// <returns>retorna un string con los datos de la mascota</returns>
        protected string DatosCompletos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append($"Nombre: {this.Nombre}\nRaza: {this.Raza}");
            return datos.ToString();
        }

        #endregion
    }
}