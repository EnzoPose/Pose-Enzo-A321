using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        #region Atributos
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        static protected Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del atributo _cantidadDeEmpleados
        /// </summary>
        public int CantidadDeEmpleados
        {
            get 
            {
                if(_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1,101);
                }
                return _cantidadDeEmpleados; 
            }
            set { }
        }
        /// <summary>
        /// Propiedad del atributo _comerciante
        /// </summary>
        public Comerciante Comerciante 
        {
            get { return _comerciante; } 
            set { _comerciante = value; }
        }
        /// <summary>
        /// Propiedad del atributo _nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        /// <summary>
        /// Propiedad del atributo _precioAlquiler 
        /// </summary>
        public float PrecioAlquiler
        {
            get { return _precioAlquiler; }
            set { _precioAlquiler = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// constructor estatico de la clase Comercio
        /// </summary>
        static Comercio()
        {
            _generadorDeEmpleados = new Random();
        }
        /// <summary>
        /// constructor publico vacio de la clase Comercio
        /// </summary>
        public Comercio()
        {

        }

        /// <summary>
        /// constructor de instancia de la clase Comercio
        /// </summary>
        /// <param name="precioAlquiler">Precio del alquiler</param>
        /// <param name="nombreComercio">Nombre del comercio</param>
        /// <param name="nombre">Nombre del comerciante</param>
        /// <param name="apellido">Apellido del comerciante</param>
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido)
        {
            _precioAlquiler = precioAlquiler;
            _nombre = nombreComercio;
            _comerciante = new Comerciante(nombre,apellido);
        }

        /// <summary>
        /// constructor de instancia de la clase Comercio
        /// </summary>
        /// <param name="nombre">nombre del comercio</param>
        /// <param name="comerciante">El comerciante en si</param>
        /// <param name="precioAlquiler">Precio del alquiler</param>
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) 
            : this(precioAlquiler, nombre, comerciante.Nombre, comerciante.Apellido)
        {
            
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga del operador de igualdad 
        /// </summary>
        /// <param name="c1">Comerciante 1</param>
        /// <param name="c2">Comerciante 2</param>
        /// <returns>Retornara True si el nombre del comercio y los comerciantes son iguales, False en caso contrario</returns>
        public static bool operator ==(Comercio c1, Comercio c2)
        {
            return c1.Nombre == c2.Nombre && c1.Comerciante == c2.Comerciante;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad
        /// </summary>
        /// <param name="c1">Comerciante 1</param>
        /// <param name="c2">Comerciante 2</param>
        /// <returns>Retornara False si el nombre del comercio y los comerciantes son iguales, True en caso contrario</returns>
        public static bool operator !=(Comercio c1, Comercio c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Sobrecarga explicita del operador string
        /// </summary>
        /// <param name="comercio">Comercio que se desea castear a string</param>
        /// <returns>Retornara una cadena con todos los datos del comercio</returns>
        public static explicit operator string(Comercio comercio)
        {
            return comercio.Mostrar();
        }

        /// <summary>
        /// Sobrecarga del metodo Equals
        /// </summary>
        /// <param name="obj">objeto que se quiere comparar</param>
        /// <returns>Retornara true si el objeto es del tipo comercio y si es igual al comercio con el que se le compara</returns>
        public override bool Equals(object obj)
        {
            return obj is Comercio comercio && this == (Comercio)obj;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo privado que devuelve una cadena de texto con todos los datos del comercio
        /// </summary>
        /// <returns>Retornara todos los datos del comercio</returns>
        private string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Nombre: {this.Nombre}");
            stringBuilder.AppendLine((string)this.Comerciante);
            stringBuilder.Append($"Cantidad de empleados: {this.CantidadDeEmpleados}");
            return stringBuilder.ToString();
        }
        #endregion
    }
}
