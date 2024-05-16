using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pose_Enzo_A321_SimulacroParcial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Perro perroUno = new Perro("Jamón", "Salchicha");
            Perro perroDos = new Perro("Milanesa", "Cruza", 13, true);
            Gato gatoUno = new Gato("Copito", "Angora");
            Gato gatoDos = new Gato("Santa", "Cruza");
            Grupo grupoUno = new Grupo("Río", ETipoManda.Mixta);
            grupoUno += perroUno;
            grupoUno += perroDos;
            grupoUno += perroUno;
            grupoUno += gatoUno;
            grupoUno += gatoDos;
            Console.WriteLine(grupoUno);
            grupoUno -= perroDos;
            grupoUno -= perroDos;
            Console.WriteLine(grupoUno);
            if (perroUno.Equals("perroUno"))
                Console.WriteLine("Son la misma mascota");
            else
                Console.WriteLine("No son la misma mascota");
            if (perroUno.Equals(perroUno))
                Console.WriteLine("Son la misma mascota");
            else
                Console.WriteLine("No son la misma mascota");
            Console.ReadLine();
        }
    }
}
