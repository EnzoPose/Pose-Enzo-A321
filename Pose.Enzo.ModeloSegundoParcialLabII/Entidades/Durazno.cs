﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public string Nombre
        {
            get { return this.GetType().Name; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
            set { }
        }


        public Durazno(string color, double peso, int cantPelusa)
            : base(color, peso)
        {
            _cantPelusa = cantPelusa;
        }

        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.FrutasToString());
            sb.AppendLine($"Cantidad de pelusa: {_cantPelusa}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return FrutasToString();
        }
    }
}
