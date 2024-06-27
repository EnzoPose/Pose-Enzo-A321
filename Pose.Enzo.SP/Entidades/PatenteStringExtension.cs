using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PatenteStringExtension
    {
        #region Atributos
        public const string patente_vieja = "^[A-Z]{3}[0-9]{3}$";
        public const string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";

        static Regex rgx_v = new Regex(patente_vieja);
        static Regex rgx_n = new Regex(patente_mercosur);
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de clase que valida si una patentte es valida
        /// </summary>
        /// <param name="str">Codigo de la patente a validar</param>
        /// <returns>Retornara una patente de alguno de los tipos validos(Vieja, Mercosur) si todo sale bien. O lanzara una Excepcion si el formato no es valido</returns>
        /// <exception cref="PatenteInvalidaException">Excepcion que marca que se lanza si la patente ingresada no es valida</exception>
        public static Patente ValidarPatente(this string str)
        {
            if (rgx_v.IsMatch(str))
            {
                return new Patente(str,Tipo.Vieja);
            }
            else if (rgx_n.IsMatch(str))
            {
                return new Patente(str, Tipo.Mercosur);
            }
            else
            {
                throw new PatenteInvalidaException($"{str} no cumple el formato");
            }
        }
        #endregion
    }
}
