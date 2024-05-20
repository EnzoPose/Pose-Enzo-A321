using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Harina))]
    [XmlInclude(typeof(Jugo))]
    [XmlInclude(typeof(Gaseosa))]
    [XmlInclude(typeof(Galletita))]
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        public sbyte Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }

        public List<Producto> Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }

        public float ValorEstanteTotal
        {
            get { return GetValorEstante(); }
            set { }
        }

        private Estante()
        {
            _productos = new List<Producto>();
        }

        public Estante(sbyte capacidad) : this()
        {
            _capacidad = capacidad;
        }

        public List<Producto> GetProductos()
        {
            return _productos;
        }

        public static string MostrarEstante(Estante estante)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Capacidad: {estante._capacidad}\n");
            if (estante._productos.Count > 0)
            {
                foreach (Producto item in estante._productos)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            else
            {
                sb.AppendLine("El estante no posee productos");
            }

            return sb.ToString();
        }

        public static void GuardarEstante(Estante estante, string rutaArchivo)
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
                streamWriter.WriteLine(MostrarEstante(estante));
            }
        }

        public static void SerializarEstante(Estante estante, string rutaArchivo)
        { 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(streamWriter, estante);
            }
        }

        public static Estante DeserializarEstante(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));

            using(StreamReader streamReader = new StreamReader(rutaArchivo))
            {
                return  (Estante)xmlSerializer.Deserialize(streamReader);
            }
        }

        public static bool operator ==(Estante estante, Producto producto)
        {
            return estante._productos.Contains(producto);
        }
        public static bool operator !=(Estante estante, Producto producto)
        {
            return !(estante == producto);
        }
        public static bool operator +(Estante estante, Producto producto)
        {
            bool resultado = false;
            if (estante._productos.Count < estante.Capacidad
                && estante != producto)
            {
                estante._productos.Add(producto);
                resultado = true;
            }
            return resultado;
        }

        public static Estante operator -(Estante estante, Producto producto)
        {
            if (estante == producto)
            {
                estante._productos.Remove(producto);
            }
            return estante;
        }

        public static Estante operator -(Estante estante, ETipoProducto tipo)
        {
            List<Producto> productosCopy = estante._productos.ToList();
            if (tipo == ETipoProducto.Todos)
            {
                productosCopy.Clear();
            }
            else
            {
                if (estante._productos.Count > 0)
                {
                    foreach (Producto item in estante._productos)
                    {
                        if (tipo.ToString() == item.GetType().Name)
                        {
                            productosCopy.Remove(item);
                        }
                    }
                }
            }
            estante._productos = productosCopy;

            return estante;
        }
        /*
            public static Estante operator -(Estante estante, ETipoProducto tipo)
            {
                if(tipo == ETipoProducto.Todos)
                {
                    estante._productos.Clear();   
                }
                else
                {
                    for(int i = 0; i < estante._productos.Count; i++)
                    {
                        if(tipo.ToString() == estante._productos[i].GetType().Name)
                        {
                            estante._productos.RemoveAt(i);
                            i--;
                        }
                    }
                        
                }
            }
         */

        public float GetValorEstante(ETipoProducto tipo)
        {
            float acumulador = 0.0f;
            if (this._productos.Count > 0)
            {
                if (tipo == ETipoProducto.Todos)
                {
                    foreach (Producto item in this._productos)
                    {
                        acumulador += item.CalcularCostoDeProduccion;
                    }
                }
                else
                {
                    foreach (Producto item in this._productos)
                    {
                        if (item.GetType().Name == tipo.ToString())
                        {
                            acumulador += item.CalcularCostoDeProduccion;
                        }
                    }
                }
            }
            return acumulador;
        }

        public float GetValorEstante()
        {
            return GetValorEstante(ETipoProducto.Todos);
        }

        

        
    }
}
