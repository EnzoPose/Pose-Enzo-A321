using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patente
    {
        #region Atributos
        private string _codigoPatente;
        private Tipo _tipoCodigo;
        #endregion
        #region Propiedades
        /// <summary>
        /// Porpiedad publica de escritura y lectura del atributo _codigoPatente
        /// </summary>
        public string CodigoPatente
        {
            get { return _codigoPatente;}
            set { _codigoPatente = value;}
        }
        /// <summary>
        /// Porpiedad publica de escritura y lectura del atributo _tipoCodigo
        /// </summary>
        public Tipo TipoCodigo
        {
            get { return _tipoCodigo;}
            set { _tipoCodigo = value;}
        }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Patente
        /// </summary>
        public Patente() { }

        /// <summary>
        /// Constructor de instancia de la clase Patente, recibe 2 parametros. codigoPatente y tipoCodigo que iniciaran sus respectivos atributos 
        /// </summary>
        /// <param name="codigoPatente">Codigo de la patentte</param>
        /// <param name="tipoCodigo">Tipo de codigo</param>
        public Patente(string codigoPatente, Tipo tipoCodigo)
        {
            _codigoPatente = codigoPatente;
            _tipoCodigo = tipoCodigo;
        }
        #endregion

        #region Sobreescritura
        /// <summary>
        /// Sobrecarga del metodo ToString, retornara el codigo de la patente
        /// </summary>
        /// <returns>retornara el codigo de la patente</returns>
        public override string ToString()
        {
            return $"{_codigoPatente}";
        }
        #endregion
    }
}
