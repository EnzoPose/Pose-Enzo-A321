using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;


namespace Entidades
{
    [XmlInclude(typeof(Importador))]
    [XmlInclude(typeof(Exportador))]
    public class Shopping
    {
        #region Atributos
        private int _capacidadMaxima;
        private List<Comercio> _comercios;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del precio de los Exportadores
        /// </summary>
        public double PrecioDeExportadores
        {
            get { return ObtenerPrecio(EComercios.Exportador); }
            set { }
        }
        /// <summary>
        /// Propiedad del precio de los Importadores
        /// </summary>
        public double PrecioDeImportadores
        {
            get { return ObtenerPrecio(EComercios.Importador); }
            set { }
        }
        /// <summary>
        /// Propiedad del precio total del Shopping
        /// </summary>
        public double PrecioTotal
        {
            get { return ObtenerPrecio(EComercios.Ambos); }
            set { }
        }
        /// <summary>
        /// Propiedad de la capacidad maxima de comercios que pueden haber en el Shopping
        /// </summary>
        public int CapacidadMaxima
        {
            get { return _capacidadMaxima; }
            set { _capacidadMaxima = value; } 
        }
        /// <summary>
        /// Propiedad de la lista de Comercios del Shopping
        /// </summary>
        public List<Comercio> Comercios
        {
            get { return _comercios; }
            set { _comercios = value; }
        }

        #endregion
        /// <summary>
        /// Constructor privado que inicializara la lista de Comercios
        /// </summary>
        #region Constructores
        private Shopping()
        {
            _comercios = new List<Comercio>();
        }
        /// <summary>
        /// Constructor privado que inicializara la Capacidad maxima de negocios en el Shopping
        /// </summary>
        /// <param name="capacidadMaxima">Capacidad maxima de negocios</param>
        private Shopping(int capacidadMaxima)
            : this()
        {
            _capacidadMaxima = capacidadMaxima;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga implicita que retornara una nueva instancia de shopping
        /// </summary>
        /// <param name="capacidad">Capacidad maxima de negocios</param>
        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }
        /// <summary>
        /// Sobrecarga de operador de igualdad entre un Shopping y un Comercio
        /// </summary>
        /// <param name="shopping">Shopping a comparar</param>
        /// <param name="comercio">Comercio a comparar</param>
        /// <returns>Retornara True si el Comercio ya se encuentra en la lista de Comercios del Shopping, False en caso contrario</returns>
        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping._comercios.Contains(comercio);
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad entre un Shopping y un Comercio
        /// </summary>
        /// <param name="shopping">Shopping a comparar</param>
        /// <param name="comercio">Comercio a comparar</param>
        /// <returns>Retornara False si el Comercio ya se encuentra en la lista de Comercios del Shopping, True en caso contrario</returns>
        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }
        /// <summary>
        /// Sobrecarga del operador de Adicion entre un Shopping y un Comercio
        /// </summary>
        /// <param name="shopping">Shopping al que se le quiere agregar un comercio</param>
        /// <param name="comercio">Comercio que se quiere agregar al Shopping</param>
        /// <returns>Retornara el shopping tanto si se pudo agregar el comercio o si no se pudo</returns>
        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if (shopping != comercio)
            {
                if (shopping._comercios.Count < shopping._capacidadMaxima)
                {
                    shopping._comercios.Add(comercio);
                }
                else
                {
                    Console.WriteLine("No hay más lugar en el Shopping!!!");
                }
            }
            else
            {
                Console.WriteLine("El comercio ya está en el Shopping!!!");
            }

            return shopping;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve una cadena con todos los datos del shopping
        /// </summary>
        /// <param name="shopping">Shopping del cual se quieren saber sus datos</param>
        /// <returns>Retornara un string con todos los datos del Shopping</returns>
        public static string Mostrar(Shopping shopping)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nCapacidad del Shopping: {shopping._capacidadMaxima}");
            sb.AppendLine($"Total por Importadores: {shopping.PrecioDeImportadores}");
            sb.AppendLine($"Total por Exmportadores: {shopping.PrecioDeExportadores}");
            sb.AppendLine($"Total: {shopping.PrecioTotal}");
            sb.AppendLine($"************************");
            sb.AppendLine($"Listado de Comercios");
            sb.AppendLine($"************************");

            foreach (var comercio in shopping._comercios)
            {
                if (comercio is Exportador)
                {
                    sb.AppendLine(((Exportador)comercio).Mostrar());
                }
                else if (comercio is Importador)
                {
                    sb.AppendLine(((Importador)comercio).Mostrar());
                }
            }
          
            return sb.ToString();
        }
        /// <summary>
        /// Calcula el precio de un tipo de comercio seleccionado por parametro
        /// </summary>
        /// <param name="tipo">Tipo de comercio que se calculara su precio total (Importador, Exportador o Ambos)</param>
        /// <returns>Retornara el precio total del tipo seleccionado</returns>
        private double ObtenerPrecio(EComercios tipo)
        {
            double precioTotal = 0.0d;
            if(this._comercios.Count > 0)
            {
                if(tipo == EComercios.Ambos)
                {
                    foreach (Comercio comercio in this._comercios)
                    {
                        precioTotal += (double)comercio.PrecioAlquiler;
                    }
                }
                else  
                {
                    for(int i = 0; i < this._comercios.Count;i++)
                    {
                        if(tipo.ToString() == this._comercios[i].GetType().Name)
                        {
                            precioTotal += this._comercios[i].PrecioAlquiler;
                        }
                    }
                }
            }
            return precioTotal;
        }
        /// <summary>
        /// Guarda los datos de Shopping en un archivo.txt
        /// </summary>
        /// <param name="rutaArchivo">ruta del archivo .txt</param>
        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));
            }
        }
        /// <summary>
        /// Serializa los datos del shopping en un archivo.xml
        /// </summary>
        /// <param name="path">Ruta del archivo .xml</param>
        public void SerializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }
        /// <summary>
        /// Deserializa los datos del shopping en un archivo.xml
        /// </summary>
        /// <param name="path">Ruta del archivo .xml</param>
        public static Shopping DeserializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamReader streamReader = new StreamReader(path))
            {
                return (Shopping)xmlSerializer.Deserialize(streamReader);
            }
        }
        #endregion

    }
}
