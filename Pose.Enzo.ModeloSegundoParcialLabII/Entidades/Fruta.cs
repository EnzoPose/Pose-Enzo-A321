using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;

        public string Color
        {
            get { return _color; } 
            set { _color = value; }
        }
        public double Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public abstract bool TieneCarozo { get; set; }


        public Fruta() { }

        public Fruta(string color, double peso)
        {
            _color = color;
            _peso = peso;
        }

        protected virtual string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Color: {_color} Peso: {_peso.ToString("F2")}");
            return sb.ToString();
        }
    }
}
