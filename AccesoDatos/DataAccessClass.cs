using System;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    public class DataAccessClass
    {
        #region Variables
        private string cadena = string.Empty;

        public SqlConnection oConnection { get; set; }

        public SqlCommand oCommand { get; set; }

        public IDataReader Lector { get; set; }
        #endregion

        #region Constructores
        public DataAccessClass()
        {
            cadena = "Data Source=SERVIDOR01\\SQLEXPRESS; Integrated Security = True; Initial Catalog = Northwind";
            oConnection = new SqlConnection();
            oCommand = new SqlCommand();
        }

        #endregion

        #region Metodos
        public void Open()
        {
            if (oConnection.State == ConnectionState.Open)
            {
                return;
            }

            oConnection.ConnectionString = cadena;

            try
            {
                oConnection.Open();
            }
            catch
            {
                throw;
            }

        }

        public void Close()
        {
            if(oConnection.State == ConnectionState.Closed)
            {
                return;
            }

            oConnection.Close();
        }

        // Metodo para Insertar o Actualizar
        public Int32 ExecuteNonQuery(CommandType tipoComando, String consulta)
        {
            oCommand.Connection = oConnection;
            oCommand.CommandType = tipoComando;
            oCommand.CommandText = consulta;
            int retorno = 0;

            try
            {
                retorno = oCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }

        // Metodo para seleccionar Datos
        public IDataReader ExecuteReader(CommandType tipoComando, String consulta)
        {
            Lector = null;
            oCommand.Connection = oConnection;
            oCommand.CommandType = tipoComando;
            oCommand.CommandText = consulta;

            try
            {
                Lector = oCommand.ExecuteReader();
            }
            catch (Exception)
            {

                throw;
            }

            return Lector;
        }
        #endregion
    }
}
