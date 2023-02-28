using MySql.Data.MySqlClient;
using System.Data;
using SistemaVendas.Models;
using System.Data.SqlClient;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SistemaVendas.Uteis
{
    //Data Access Layer
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "sistema_venda";
        private static string User = "root";
        private static string Password = "";
        private static string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;Charset=utf8;";
        private static string SqlConnectionString = @"server=localhost; database=SistemaVendas; Trusted_Connection=True; TrustServerCertificate=True;";
        private static MySqlConnection Connection;
        private static SqlConnection SqlConnection;

        public DAL()
        {
            //Conexão MySql
            //Connection = new MySqlConnection(ConnectionString);
            //Connection.Open();

            //Conexão SqlServer
            SqlConnection = new SqlConnection(SqlConnectionString);
            SqlConnection.Open();
                // Do work here; connection closed on following line.
        }

        //Espera um parâmetro do tipo string 
        //contendo um comando SQL do tipo SELECT
        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            SqlCommand Command = new SqlCommand(sql, SqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            da.Fill(data);
            return data;
        }

        public DataTable RetDataTable(SqlCommand Command)
        {
            DataTable data = new DataTable();
            Command.Connection = SqlConnection;
            SqlDataAdapter da = new SqlDataAdapter(Command);
            da.Fill(data);
            return data;
        }

        //Espera um parâmetro do tipo string 
        //contendo um comando SQL do tipo INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, SqlConnection);
            Command.ExecuteNonQuery();
        }
    }
}
