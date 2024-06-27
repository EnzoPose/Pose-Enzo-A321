using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public delegate void Delegado(object sender);
    [XmlInclude(typeof(Fruta))]
    [XmlInclude(typeof(Manzana))]
    public class Cajon<T> : ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        public event Delegado eventoPrecio;


        public List<T> Elementos
        {
            get { return _elementos; }
        }

        public double PrecioTotal
        {
            get 
            {
                double precioTotal = _precioUnitario * _elementos.Count; 
                if(precioTotal > 55)
                {
                    eventoPrecio.Invoke(precioTotal);
                }
                return precioTotal;
            }
            set { }
        }

        public Cajon()
        {
            _elementos = new List<T>(); 
        }

        public Cajon(int capacidad)
            :this()
        {
            _capacidad = capacidad;
        }

        public Cajon(double precioUnitario, int capacidad)
            :this(capacidad)
        {
            _precioUnitario = precioUnitario;
        }

        public bool Xml(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cajon<T>));

                using (StreamWriter sw = new StreamWriter(path))
                {
                    xmlSerializer.Serialize(sw, this);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cantidad total de elementos: {_elementos.Count}");
            sb.AppendLine($"Precio total: {PrecioTotal}");
            foreach (T element in _elementos)
            {
                sb.AppendLine(element.ToString());
            }
            return sb.ToString();
        }

        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
            if(cajon._elementos.Count < cajon._capacidad)
            {
                cajon.Elementos.Add(elemento);
            }
            else
            {
                throw new CajonLlenoException("El cajon ya se encuentra lleno");
            }
            return cajon;
        }
    }
}
