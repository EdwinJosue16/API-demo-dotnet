using System.Configuration;
using System.Data.SqlClient; // Sql Server Connection Namespace
using SqlKata.Execution;
using SqlKata.Compilers;

namespace TestForJob.Controllers
{
    public class DataBaseHandler
    {
        //These are some elements for establishing connection with SQL Server
        protected SqlConnection connection;
        protected SqlServerCompiler compiler;
        protected QueryFactory factory;
        protected string connectionString;

        //This is a constant value, the name is the same that the name in WebConfig
        protected const string CONNECTION_NAME = "TestForJobConnection";

        public DataBaseHandler()
        {
            initializeComponents();
        }

        private void initializeConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_NAME].ToString();
            connection = new SqlConnection(connectionString);
        }

        private void initializeQueryFactory()
        {
            compiler = new SqlServerCompiler();
            factory = new QueryFactory(connection, compiler);
        }

        protected void initializeComponents()
        {
            initializeConnectionString();
            initializeQueryFactory();
        }
    }
}