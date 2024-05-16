using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Entidades
{
    public class Gato : Mascota
    {
        public Gato(string nombre, string raza) : base(nombre, raza) { }

        protected override string Ficha()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("====================== Gato ======================");
            datos.AppendLine(this.DatosCompletos());
            return datos.ToString();
        }

        public static bool operator ==(Gato g1, Gato g2)
        {
            return g1.Nombre == g2.Nombre && g1.Raza == g2.Raza;
        }

        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        public override bool Equals(object obj)
        {
            return obj is Gato gato && gato == this;
        }
    }
}