using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archivo
{
    public class Sql : IArchivo
    {
        #region Atributos 
        private SqlCommand _comando;
        private SqlConnection _conexion;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Sql, inicializara los atributos privados de la clase
        /// </summary>
        public Sql()
        {
            string conexionString = "Data Source=DESKTOP-JP7CUHO\\SQLEXPRESS;Initial Catalog=lab_sp;Integrated Security=True";
            _conexion = new SqlConnection(conexionString);
            _comando = new SqlCommand();
            _comando.Connection = _conexion;
            _comando.CommandType= CommandType.Text;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que guarda los datos de una lista de patentes en la base de datos "patentes"
        /// </summary>
        /// <param name="datos">Datos que se ingresaran a la base de datos</param>
        /// <returns>Retornara true si se pudieron agregar o false en caso contrario</returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                using (_conexion)
                {
                    _conexion.Open();
                    foreach (Patente patente in datos)
                    {
                        using (_comando)
                        {
                            string query = "INSERT INTO patentes (patente, tipo) VALUES (@patente, @tipo)";
                            _comando.CommandText = query;
                            _comando.Parameters.AddWithValue("@patente", patente.CodigoPatente);
                            _comando.Parameters.AddWithValue("@tipo", patente.TipoCodigo.ToString());
                            _comando.ExecuteNonQuery();
                            _comando.Parameters.Clear();
                        }
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                _conexion.Close();
            }
        }
        /// <summary>
        /// Metodo que leera la base de datos y devolvera la lista de patentes que tiene
        /// </summary>
        /// <returns>Retornara una lista de patentes con los datos de la bbdd</returns>
        public List<Patente> Leer()
        {
            List<Patente> patentes = new List<Patente>();
            try
            {
                using (_comando)
                {
                    string query = "SELECT patente, tipo FROM patentes";
                    _conexion.Open();
                    _comando.CommandText = query;

                    using(SqlDataReader sqlRead = _comando.ExecuteReader())
                    {
                        while(sqlRead.Read())
                        {
                            Tipo tipo = (Tipo)Enum.Parse(typeof(Tipo), sqlRead["tipo"].ToString());
                            patentes.Add(new Patente(sqlRead["patente"].ToString(), tipo));
                        }
                        return patentes;
                    }
                }
            }
            catch(Exception)
            {
                return patentes;
            }
            finally
            {
                _conexion.Close();
            }
        }
        #endregion
    }
}
