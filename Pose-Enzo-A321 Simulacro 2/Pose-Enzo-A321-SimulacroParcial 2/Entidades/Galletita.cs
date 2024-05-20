using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected static bool _deConsumo;
        protected float _peso;

        public override float CalcularCostoDeProduccion 
        {
            get 
            {
                return _precio * 0.33f; 
            }
            set 
            {
                _precio = value;
            }
        }

        static Galletita()
        {
            _deConsumo = true;
        }
        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso) 
            : base(codigoBarra,precio,marca)
        {
            _peso = peso;
        }

        public Galletita()
        {

        }

        private static string MostrarGalletita(Galletita galletita)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((string)galletita);
            sb.AppendLine($"Peso: {galletita._peso}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible";
        }
    }
}
