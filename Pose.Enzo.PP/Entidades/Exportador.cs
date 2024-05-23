using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        #region Atributos
        private ETipoProducto _tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de instancia de la clase Exportador
        /// </summary>
        public Exportador() { }

        /// <summary>
        /// Constructor de insttancia de la clase Exportador
        /// </summary>
        /// <param name="nombreComercio">Nombre del comercio</param>
        /// <param name="precioAlquiler">Precio del alquiler</param>
        /// <param name="comerciante">Comerciante</param>
        /// <param name="tipo">Tipo de producto</param>
        public Exportador(string nombreComercio,float precioAlquiler, Comerciante comerciante, ETipoProducto tipo) 
            :base(nombreComercio, comerciante, precioAlquiler)
        {
            _tipo = tipo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga de igualdad de la clase Exportador
        /// </summary>
        /// <param name="e1">Exportador 1</param>
        /// <param name="e2">Exportador 2</param>
        /// <returns>Retornara True si los comercios son iguales y los tipos de producto son iguales, False en caso contrario</returns>
        public static bool operator ==(Exportador e1, Exportador e2) 
        { 
            return (Comercio)e1 == (Comercio)e2 && e1._tipo == e2._tipo;
        }

        /// <summary>
        /// Sobrecarga de desigualdad de la clase Exportador
        /// </summary>
        /// <param name="e1">Exportador 1</param>
        /// <param name="e2">Exportador 2</param>
        /// <returns>Retornara False si los comercios son iguales y los tipos de producto son iguales, True en caso contrario</returns>
        public static bool operator !=(Exportador e1, Exportador e2) 
        { 
            return !(e1 == e2); 
        }

        /// <summary>
        /// Sobrecarga implicita de la clase Exportador al enum ETipoProducto
        /// </summary>
        /// <param name="exportador">Exportador que se convertira a ETipoProducto</param>
        /// <returns>Retornara el tipo de producto del exportador</returns>
        public static implicit operator ETipoProducto(Exportador exportador)
        {
            return exportador._tipo;
        }
        #endregion
        
        #region Metodos
        /// <summary>
        /// Devolvera un string con todos los datos del Exportador
        /// </summary>
        /// <returns>Retornara una cadena con todos los datos del Exportador</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendLine($"Tipo de producto: {_tipo}");

            return sb.ToString();
        }
        #endregion
    }
}
