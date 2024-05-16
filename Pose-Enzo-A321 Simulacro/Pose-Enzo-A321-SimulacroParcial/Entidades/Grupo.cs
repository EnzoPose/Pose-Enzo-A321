using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        private List<Mascota> _mascotas;
        private string _nombre;
        static ETipoManda _tipo;

        static Grupo()
        {
            _tipo = ETipoManda.Unica;
        }

        private Grupo()
        {
            this._mascotas = new List<Mascota>();
        }

        public Grupo(string nombre) :
            this()
        {
            this._nombre = nombre;
        }

        public Grupo(string nombre, ETipoManda tipo) :
            this(nombre)
        {
            _tipo = tipo;
        }

        public ETipoManda Tipo { get { return _tipo; } }

        public static bool operator ==(Grupo grupo, Mascota mascota)
        {
            return grupo._mascotas.Contains(mascota);
        }

        public static bool operator !=(Grupo grupo, Mascota mascota)
        {
            return !(grupo == mascota);
        }

        public static Grupo operator +(Grupo grupo, Mascota mascota)
        {
            if (grupo != mascota)
            {
                grupo._mascotas.Add(mascota);
            }
            else
            {
                Console.WriteLine("La mascota ya se encuentra en el grupo!");
            }
            return grupo;
        }

        public static Grupo operator -(Grupo grupo, Mascota mascota)
        {
            if (grupo == mascota)
            {
                grupo._mascotas.Remove(mascota);
            }
            else
            {
                Console.WriteLine("La mascota no forma parte del grupo");
            }
            return grupo;
        }

        public static implicit operator string(Grupo grupo)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($" *** Manada: {grupo._nombre} - Tipo: {grupo.Tipo} - Integrantes: {grupo._mascotas.Count} ***");
            foreach (Mascota mascota in grupo._mascotas)
            {
                datos.Append(mascota.ToString());
                datos.Append('\n');
            }
            datos.AppendLine("***********************************************************");

            return datos.ToString();
        }

    }
}