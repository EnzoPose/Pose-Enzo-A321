using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string Nombre
        {
            get { return this.GetType().Name; }
            set { }
        }

        public override bool TieneCarozo
        {
            get { return false; }
            set { }
        }
        public string ProvinciaOrigen
        {
            get { return _provinciaOrigen; }
            set { _provinciaOrigen = value; }
        }


        public Manzana() : base() { }

        public Manzana( string color, double peso , string provinciaOrigen)
            :base(color,peso)
        {
            _provinciaOrigen = provinciaOrigen;
        }

        bool IDeserializar.Xml(string path, out Fruta fruta)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));
                using (StreamReader streamReader = new StreamReader(path))
                {
                    fruta = (Manzana)xmlSerializer.Deserialize(streamReader);
                    return true;
                }
            }
            catch (Exception)
            {
                fruta = null;
                return false;
            }
        }

        public bool Xml(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    xmlSerializer.Serialize(streamWriter, this);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.FrutasToString());
            sb.AppendLine($"Provincia de origen {_provinciaOrigen}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return FrutasToString();
        }
    }
}
