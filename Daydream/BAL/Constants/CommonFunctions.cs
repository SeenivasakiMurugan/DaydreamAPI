using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace Daydream.BAL.Constants
{
    public class CommonFunctions
    {
        public DataSet ExcecuteProcedures(string procedureName, SqlParameter[]? parameters, IConfiguration _configuration)
        {
            DataSet dataSet = new DataSet();
            string? connectionString = _configuration?.GetConnectionString("SQLConnection");
            ServicePointManager.ServerCertificateValidationCallback =
            (sender, certificate, chain, sslPolicyErrors) => true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();

                adapter.Fill(dataSet);
                return dataSet;
            }
        }
    }
}
