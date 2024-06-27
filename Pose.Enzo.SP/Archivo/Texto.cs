using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Archivo
{
    public class Texto : IArchivo
    {
        #region Metodos

        /// <summary>
        /// Guarda los dattos de una lista de patentes en un archivo txt
        /// </summary>
        /// <param name="datos">datos que se guardaran en el txt</param>
        /// <returns>retornara true si los pudo guardar, false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathTxt = Path.Combine(pathEscritorio, "patentes.txt");
            if (!File.Exists(pathTxt))
            {
                using (FileStream fileStream = File.Create(pathTxt))
                {
                    fileStream.Close();
                }
            }

            try
            {
                using(StreamWriter sw = new StreamWriter(pathTxt))
                {
                    foreach (Patente patente in datos)
                    {
                        Patente patenteValida = PatenteStringExtension.ValidarPatente(patente.ToString());
                        if(patenteValida != null)
                        {
                            sw.WriteLine(patente.ToString() + $" {patente.TipoCodigo}");
                        }
                    }   
                }
            }
            catch (PatenteInvalidaException)
            {
                return false;
            }
            catch(Exception) 
            {
                return false;
            }
            return true;
            }
        /// <summary>
        /// Metodo que lee un archivo txt y retorna la lista de patentes que tiene dentro
        /// </summary>
        /// <returns>retornara la lista de patentes si todo salio bien o una lita vacia en caso contrario</returns>
        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();
            string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathTxt = Path.Combine(pathEscritorio, "patentes.txt");

            try
            {
                using (StreamReader sr = new StreamReader(pathTxt))
                {
                    string linea;
                    while((linea = sr.ReadLine()) != null) 
                    { 
                        string[] lineaDividida = linea.Split(' ');

                        if (lineaDividida.Length == 2)
                        {
                            Patente patenteValida = PatenteStringExtension.ValidarPatente(lineaDividida[0]);
                            if(patenteValida != null)
                            {
                                if (lineaDividida[1] == Tipo.Vieja.ToString())
                                {
                                    Patente patente = new Patente(lineaDividida[0], Tipo.Vieja);
                                    patentes.Add(patente);
                                }
                                else
                                {
                                    Patente patente = new Patente(lineaDividida[0], Tipo.Mercosur);
                                    patentes.Add(patente);
                                }
                            }

                        }
                    }
                    
                }
            }
            catch (Exception)
            {
            
            }
            return patentes;

        }
        #endregion
    }
}
