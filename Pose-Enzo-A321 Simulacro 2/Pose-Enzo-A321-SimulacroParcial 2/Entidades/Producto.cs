using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public int CodigoDeBarra { get { return this._codigoDeBarra; } set { this._codigoDeBarra = value; } }

        public EMarcaProducto Marca { get { return this._marca; } set { this._marca = value; } }

        public float Precio { get { return this._precio; } set { this._precio = value; } }

        public abstract float CalcularCostoDeProduccion { get; set; }
        

        public Producto(int codigoBarra, float precio, EMarcaProducto marca)
        {
            this._codigoDeBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }

        public Producto()
        {

        }

        public virtual string Consumir()
        {
            return "Parte de una mezcla.";
        }


        private static string MostrarProducto(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Codigo de barras: {producto.CodigoDeBarra}");
            sb.AppendLine($"Marca: {producto.Marca}");
            sb.AppendFormat("Precio: {0:0.##}\n", producto.Precio);
            return sb.ToString();
        }

        /*mal
         * public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType();
        }*/
        /*
        public override bool Equals(object obj)
        {
            return obj is Producto producto && producto == this;
        }
        */
        public override bool Equals(object obj)
        {
            return obj is Producto producto && this == (Producto)obj;
        }
        public static bool operator ==(Producto producto1, Producto producto2)
        {
            return producto1.GetType() == producto2.GetType() && producto1.CodigoDeBarra == producto2.CodigoDeBarra
                && producto1.Marca == producto2.Marca;
        }
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1 == producto2);
        }
                    
        public static bool operator ==(Producto producto1, EMarcaProducto marca)
        {
            return producto1.Marca == marca;
        }

        public static bool operator !=(Producto producto1, EMarcaProducto marca)
        {
            return !(producto1 == marca);
        }

        public static explicit operator int(Producto producto)
        {
            return producto.CodigoDeBarra;
        }

        public static implicit operator string(Producto producto)
        {
            return MostrarProducto(producto);
        }
    }
}
