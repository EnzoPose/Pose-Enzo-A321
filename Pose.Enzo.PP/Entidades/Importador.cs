using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        #region Atributos
        private EPaises _paisOrigen;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Importador
        /// </summary>
        public Importador() { }

        /// <summary>
        /// Constructor de instancia de la clase Importador
        /// </summary>
        /// <param name="nombreComercio">Nombre del comercio</param>
        /// <param name="precioAlquiler">Precio del alquiler</param>
        /// <param name="comerciante">Comerciante</param>
        /// <param name="paisOrigen">Pais de origen</param>
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen)
            : base(nombreComercio, comerciante, precioAlquiler)
        {
            _paisOrigen = paisOrigen;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga de igualdad de la clase Importador
        /// </summary>
        /// <param name="i1">Importador 1</param>
        /// <param name="i2">Importador 2</param>
        /// <returns>Retornara True si los comercios de los importadores y los paises de origen son iguales, False en caso contrario</returns>
        public static bool operator ==(Importador i1, Importador i2)
        {
            return (Comercio)i1 == (Comercio)i2 && i1._paisOrigen== i2._paisOrigen;
        }

        /// <summary>
        /// Sobrecarga de desigualdad de la clase Importador
        /// </summary>
        /// <param name="i1">Importador 1</param>
        /// <param name="i2">Importador 2</param>
        /// <returns>Retornara False si los comercios de los importadores y los paises de origen son iguales, True en caso contrario</returns>
        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }

        /// <summary>
        /// Sobrecarga implicita de la clase Importador al enum EPaises
        /// </summary>
        /// <param name="importador">Importador que se convertira a EPaises</param>
        /// <returns>Retornara el pais de origen en el tipo de dato EPaises</returns>
        public static implicit operator EPaises(Importador importador)
        {
            return importador._paisOrigen;
        }
        #endregion

        /// <summary>
        /// Devolvera una cadena con los datos del Importador
        /// </summary>
        /// <returns>Retornara un string con todos los datos del Importador</returns>
        #region Metodos
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendLine($"Pais de Origen: {_paisOrigen}");

            return sb.ToString();
        }
        #endregion
    }
}
