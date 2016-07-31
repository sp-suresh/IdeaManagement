using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;

namespace IdeaManagement.DAL.CoreDAL
{
    public static class DbFactory
    {

        static DataBaseType _currentDbtype = DataBaseType.MySql;
        static string _connectionString = ConfigurationManager.AppSettings["mySqlConnectionString"];

        //static DataBaseType _currentDbtype = DataBaseType.MsSqlServer;
        //static string _connectionString = ConfigurationManager.AppSettings["connectionString"];

        internal static DbConnection GetDBConnection()
        {
            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    return string.IsNullOrEmpty(_connectionString) ? new SqlConnection() : new SqlConnection(_connectionString);

                case DataBaseType.MySql:
                    return string.IsNullOrEmpty(_connectionString) ? new MySqlConnection() : new MySqlConnection(_connectionString);
            }

        }

        #region DBCommand
        public static DbCommand GetDBCommand()
        {
            return GetDBCommand(string.Empty);
        }

        public static DbCommand GetDBCommand(string sqlCommandText)
        {
            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    {
                        return string.IsNullOrEmpty(sqlCommandText) ? new SqlCommand() : new SqlCommand(sqlCommandText);
                    }

                case DataBaseType.MySql:
                    {
                        return string.IsNullOrEmpty(sqlCommandText) ? new MySqlCommand() : new MySqlCommand(sqlCommandText);
                    }
            }

        }
        #endregion

        #region DataAdaptor

        public static DbDataAdapter GetDBDataAdaptor()
        {
            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    return new SqlDataAdapter();

                case DataBaseType.MySql:
                    return new MySqlDataAdapter();
            }

        }

        #endregion

        #region DBParameters
        public static DbParameter[] GetDbParamArray(int size)
        {
            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    {
                        return new SqlParameter[size];
                    }

                case DataBaseType.MySql:
                    {
                        return new MySqlParameter[size];
                    }
            }
        }

        public static DbParameter GetDbParam(string parameterName, DbType dbType, object value)
        {
            return GetDbParam(parameterName, dbType, -1,ParameterDirection.Input, value);
        }

        public static DbParameter GetDbParam(string parameterName, DbType dbType, ParameterDirection direction)
        {
            return GetDbParam(parameterName, dbType, -1, direction, null);
        }

        public static DbParameter GetDbParam(string parameterName, DbType dbType, ParameterDirection direction, object value)
        {
            return GetDbParam(parameterName, dbType, -1, direction, value);
        }     

        public static DbParameter GetDbParam(string parameterName, DbType dbType, int size, object value)
        {
            return GetDbParam(parameterName, dbType, size, ParameterDirection.Input, value);
        }

        public static DbParameter GetDbParam(string parameterName, DbType dbType, int size, ParameterDirection direction)
        {
            return GetDbParam(parameterName, dbType, size, direction, null);
        }

        public static DbParameter GetDbParam(string parameterName, DbType dbType, int size, ParameterDirection direction, object value)
        {
            DbParameter dbParameter = null;

            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    {
                        dbParameter = new SqlParameter();

                    }
                    break;

                case DataBaseType.MySql:
                    {
                        dbParameter = new MySqlParameter();
                    }
                    break;
            }

            if (dbParameter != null)
            {
                dbParameter.ParameterName = parameterName;
                dbParameter.Direction = direction;
                dbParameter.DbType = dbType;
                if (size != -1)
                    dbParameter.Size = size;
                if (value != null)
                    dbParameter.Value = value;
            }

            return dbParameter;
        }


        public static DbParameter GetDbParamWithColumnName(string parameterName, DbType dbType, int size, string sourceColName)
        {
            DbParameter dbParameter = null;

            switch (_currentDbtype)
            {
                case DataBaseType.MsSqlServer:
                default:
                    {
                        dbParameter = new SqlParameter();

                    }
                    break;

                case DataBaseType.MySql:
                    {
                        dbParameter = new MySqlParameter();
                    }
                    break;
            }

            if (dbParameter != null)
            {
                dbParameter.ParameterName = parameterName;
                dbParameter.Direction = ParameterDirection.Input;
                dbParameter.DbType = dbType;
                if (size != -1)
                    dbParameter.Size = size;
                dbParameter.SourceColumn = sourceColName;
            }

            return dbParameter;
        }

        #endregion
    }

    enum DataBaseType
    {
        MsSqlServer,
        MySql,
        Oracle,
        Unknown
    }
  
}