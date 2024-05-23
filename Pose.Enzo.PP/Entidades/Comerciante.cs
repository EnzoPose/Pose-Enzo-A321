using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        #region Atributos
        private string _apellido;
        private string _nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        /// <summary>
        /// Propiedad del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase comerciante
        /// </summary>
        public Comerciante() { }
        /// <summary>
        /// Constructor de la clase comerciante
        /// </summary>
        /// <param name="nombre">Nombre del comerciante</param>
        /// <param name="apellido">Apellido del comerciante</param>
        public Comerciante(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga implicita de tipo string
        /// </summary>
        /// <param name="comerciante">Comerciante al cual se lo casteara implicitamente a String</param>
        /// <returns>Retornara una cadena formateada con el nombre y apellido del comerciante</returns>
        public static implicit operator string(Comerciante comerciante)
        {
            return $"Comerciante: {comerciante.Nombre}, {comerciante.Apellido}";
        }

        /// <summary>
        /// Sobrecarga de operador igualdad que compara si dos comerciantes son iguales
        /// </summary>
        /// <param name="c1">Comerciante 1</param>
        /// <param name="c2">Comerciante 2</param>
        /// <returns>Retornara True si el nombre y apellido de los 2 comerciantes son iguales, False en caso contrario</returns>
        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            return (c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido);
        }

        /// <summary>
        /// Sobrecarga de operador desigualdad que compara si dos comerciantes son iguales
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>Retornara False si el nombre y apellido de los 2 comerciantes son iguales, True en caso contrario</returns>
        public static bool operator !=(Comerciante c1, Comerciante c2)
        {
            return !(c1 == c2);
        }
        #endregion
    }
}
