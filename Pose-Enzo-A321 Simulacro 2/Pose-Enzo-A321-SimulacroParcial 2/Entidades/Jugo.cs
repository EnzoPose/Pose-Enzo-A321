using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        static bool _deConsumo;
        protected ESaborJugo _sabor;

        public override float CalcularCostoDeProduccion
        {
            get 
            {
                return _precio * 0.4f;
            }
            set
            {
                _precio = value;
            }
        }

        public Jugo()
        {

        }
        static Jugo()
        {
            _deConsumo = true;
        }

        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor) : base(codigoBarra, precio, marca)
        {
            {
                this._sabor = sabor;
            }
        }
        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);
            sb.AppendLine($"Sabor: {_sabor}");
            sb.AppendLine($"De consumo {_deConsumo}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }
    }
}
