using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        protected static bool _deConsumo;
        protected ETipoHarina _tipo;
        public override float CalcularCostoDeProduccion
        {
            get
            {
                return _precio * 0.60f;
            }
            set
            {
                _precio = value;
            }
        }

        public Harina() { }
        static Harina()
        {
            _deConsumo = false;
        }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo)
            : base(codigoBarra, precio, marca)
        {
            _tipo = tipo;
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);
            sb.AppendLine($"Tipo: {this._tipo}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarHarina();
        }
    }
}
