using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoDatos
{
    public class Consulta
    {

        DataAccessClass oAccesDatos = new DataAccessClass();

        public String GetDato()
        {
            IDataReader reader = null;
            String valor = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("Select ");
            sb.Append("FirstName ");
            sb.Append("From Employees ");
            sb.Append("Where ");
            sb.Append("EmployeeID = '1' ");

            try
            {
                oAccesDatos.Open();
                reader = oAccesDatos.ExecuteReader(CommandType.Text,sb.ToString());

                while (reader.Read())
                {
                    valor = reader["FirstName"].ToString();
                }
                reader.Close();
                return valor;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oAccesDatos.Close();
            }

        }

    }
}

