using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Library.App_Start
{
    public class DbConnection
    {
        private static DbConnection _dbConnectionInstance = null;
        private string _connectionString;

        private DbConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Library"].ConnectionString;
        }

        public static DbConnection GetDbConnectionInstance()
        {
            if (_dbConnectionInstance == null)
            {
                _dbConnectionInstance = new DbConnection();
            }

            return _dbConnectionInstance;
        }
        // singleton

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
    }
}