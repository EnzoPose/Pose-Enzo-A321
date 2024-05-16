using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        private int _edad;
        private bool _esAlfa;

        public Perro(string nombre, string raza) :
            this(nombre, raza, 0, false)
        { }


        public Perro(string nombre, string raza, int edad, bool esAlfa) :
             base(nombre, raza)
        {
            this._edad = edad;
            this._esAlfa = esAlfa;
        }

        protected override string Ficha()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("====================== Perro ======================");
            datos.AppendLine(this.DatosCompletos());
            datos.Append($"Edad: {this._edad}\nEs alfa: {this._esAlfa}\n");
            return datos.ToString();
        }



        public static bool operator ==(Perro p1, Perro p2)
        { return p1.Nombre == p2.Nombre && p1.Raza == p2.Raza && p1._edad == p2._edad; }

        public static bool operator !=(Perro p1, Perro p2)
        { return !(p1 == p2); }

        public static explicit operator int(Perro perro)
        {
            return perro._edad;
        }

        public override string ToString()
        {
            return this.Ficha();
        }

        public override bool Equals(object obj)
        {
            return obj is Perro perro && perro == this;
        }
        public override int GetHashCode()
        {
            return this.Nombre.GetHashCode();
        }
    }

}