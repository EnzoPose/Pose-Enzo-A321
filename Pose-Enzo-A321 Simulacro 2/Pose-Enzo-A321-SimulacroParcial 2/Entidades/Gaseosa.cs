using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected static bool _deConsumo;
        protected float _litros;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return _precio * 0.42f;
            }
            set
            {
                _precio = value;
            }
        }

        static Gaseosa() { _deConsumo = true; }
        public Gaseosa() { }
        
        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca,float litros)
        : base(codigoBarra,precio,marca)
        {
            _litros = litros;
        }

        public Gaseosa(Producto producto, float litros) 
            : base(producto.CodigoDeBarra,producto.Precio,producto.Marca)
        {
            _litros = litros;
        }

        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);
            sb.AppendLine($"Litros: {_litros}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
    }
}
