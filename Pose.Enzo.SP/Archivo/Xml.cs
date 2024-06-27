using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    [XmlInclude(typeof(Patente))]
    public class Xml : IArchivo
    {
        #region Metodos

        /// <summary>
        /// Guarda en un archivo xml una lista de patentes
        /// </summary>
        /// <param name="datos">lista de patentes a guardar</param>
        /// <returns>retornara true si se pudo guardar o false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                string escritorioPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); 
                string rutaArchivoPatentes = Path.Combine(escritorioPath, "patentes.xml");
                
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Patente>));
                
                using(StreamWriter sw = new StreamWriter(rutaArchivoPatentes))
                {
                    xmlSerializer.Serialize(sw, datos);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Lee un archivo xml y retorna la lista de patentes que tiene
        /// </summary>
        /// <returns>retornara la lista de patentes del archivo xml</returns>
        public List<Patente> Leer()
        {
            try
            {
                string escritorioPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string rutaArchivoPatentes = Path.Combine(escritorioPath, "patentes.xml");

                XmlSerializer xmlSerializer = new XmlSerializer (typeof(List<Patente>));
                using(StreamReader sr = new StreamReader(rutaArchivoPatentes))
                {
                    List<Patente> listaPatentes =  (List<Patente>)xmlSerializer.Deserialize(sr);
                    return listaPatentes;
                }
            }
            catch (Exception) 
            {
                return new List<Patente>();
            }
        }
        #endregion
    }
}
