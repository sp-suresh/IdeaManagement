using AutoBiz.DAL.CoreDAL;
using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web;

namespace IdeaManagement.DAL.CoreDAL
{
    /// <summary>
    ///   <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    public static class MySqlDatabase
    {
        #region selectQuery
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute reader </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// i data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static IDataReader ExecuteReader(string strSql)
        {
            return ExecuteReader(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute reader </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// i data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static IDataReader ExecuteReader(string strSql, DbParameter[] commandParameters)
        {
            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {
                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }

                return ExecuteReader(cmd);

            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute reader </para>
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// i data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static IDataReader ExecuteReader(DbCommand cmd)
        {
            IDataReader dataReader;
            DbConnection con = DbFactory.GetDBConnection();
            try
            {
                cmd.Connection = con;
                con.Open();
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch (Exception ex)
            {
                con.Close();
                //SendErrorMessageOnException(ex);
                throw ex;
            }

        }

        #endregion

        #region select adapter query

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapter query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DataSet SelectAdapterQuery(string strSql)
        {
            return SelectAdapterQuery(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapter query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DataSet SelectAdapterQuery(string strSql, DbParameter[] commandParameters)
        {

            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {
                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }

                return SelectAdapterQuery(cmd);
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapter query </para>
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DataSet SelectAdapterQuery(DbCommand cmd)
        {
            DataSet dataSet = new DataSet();
            using (DbConnection con = DbFactory.GetDBConnection())
            {
                DbDataAdapter adapter = DbFactory.GetDBDataAdaptor();

                try
                {
                    cmd.Connection = con;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                    con.Close();
                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    con.Close();
                    throw ex;
                }
            }
            return dataSet;
        }

        #endregion

        #region InsertQuery
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool InsertQuery(string strSql)
        {
            return InsertQuery(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool InsertQuery(string strSql, DbParameter[] commandParameters)
        {
            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {
                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }
                return InsertQuery(cmd);
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert query </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool InsertQuery(DbCommand cmdParam)
        {

            using (DbConnection con = DbFactory.GetDBConnection())
            {
                try
                {
                    cmdParam.Connection = con;
                    con.Open();
                    int retval = cmdParam.ExecuteNonQuery();
                    con.Close();
                    return (retval > 0);
                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    con.Close();
                    throw ex;
                }
            }

        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert query via adaptor </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int InsertQueryViaAdaptor(DbCommand cmdParam, DataTable dt)
        {
            if (cmdParam != null)
            {
                using (DbConnection con = DbFactory.GetDBConnection())
                {
                    try
                    {
                        cmdParam.Connection = con;
                        DbDataAdapter adpt = DbFactory.GetDBDataAdaptor();
                        adpt.InsertCommand = cmdParam;
                        adpt.UpdateBatchSize = dt.Rows.Count;

                        con.Open();

                        return adpt.Update(dt);

                    }
                    catch (Exception ex)
                    {
                        //SendErrorMessageOnException(ex);
                        con.Close();
                        throw ex;
                    }
                }
            }
            return 0;
        }


        #endregion

        #region UpdateQuery

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool UpdateQuery(string strSql)
        {
            return UpdateQuery(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool UpdateQuery(string strSql, DbParameter[] commandParameters)
        {
            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {
                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }

                return UpdateQuery(cmd);
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static bool UpdateQuery(DbCommand cmdParam)
        {
            using (DbConnection conn = DbFactory.GetDBConnection())
            {
                try
                {
                    cmdParam.Connection = conn;
                    conn.Open();

                    int retval = cmdParam.ExecuteNonQuery();
                    conn.Close();
                    return (retval > 0);

                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query via adaptor </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int UpdateQueryViaAdaptor(DbCommand cmdParam, DataTable dt)
        {

            using (DbConnection con = DbFactory.GetDBConnection())
            {
                try
                {
                    DbDataAdapter adpt = DbFactory.GetDBDataAdaptor();
                    adpt.UpdateCommand = cmdParam;
                    adpt.UpdateBatchSize = dt.Rows.Count;

                    con.Open();

                    return adpt.Update(dt);

                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    con.Close();
                    throw ex;
                }
            }

        }

        #endregion

        #region UpdateQueryReturnRowCount
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query return row count </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int UpdateQueryReturnRowCount(string strSql)
        {
            return UpdateQueryReturnRowCount(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update query return row count </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int UpdateQueryReturnRowCount(string strSql, DbParameter[] commandParameters)
        {
            int retCount = 0;
            using (DbConnection con = DbFactory.GetDBConnection())
            {
                try
                {
                    using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
                    {
                        cmd.Connection = con;

                        if (commandParameters != null)
                        {
                            foreach (DbParameter p in commandParameters)
                            {
                                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                                    p.Value = DBNull.Value;

                                cmd.Parameters.Add(p);
                            }
                        }
                        con.Open();
                        retCount = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    con.Close();
                    throw ex;

                }
            }
            return retCount;
        }
        #endregion

        #region ExecuteScalar

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute scalar </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static string ExecuteScalar(string strSql)
        {
            return ExecuteScalar(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute scalar </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static string ExecuteScalar(string strSql, DbParameter[] commandParameters)
        {
            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {

                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }
                return ExecuteScalar(cmd);
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute scalar </para>
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static string ExecuteScalar(DbCommand cmd)
        {
            string retVal = string.Empty;
            using (DbConnection con = DbFactory.GetDBConnection())
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    var data = cmd.ExecuteScalar();
                    con.Close();
                    if (data != null)
                        retVal = data.ToString();
                }
                catch (Exception ex)
                {
                    //SendErrorMessageOnException(ex);
                    con.Close();
                    throw ex;
                }
            }
            return retVal;
        }

        #endregion

        #region ExecuteNonQuery
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute non query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int ExecuteNonQuery(string strSql)
        {
            return ExecuteNonQuery(strSql, null);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute non query </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int ExecuteNonQuery(string strSql, DbParameter[] commandParameters)
        {
            using (DbCommand cmd = DbFactory.GetDBCommand(strSql))
            {
                if (commandParameters != null)
                {
                    foreach (DbParameter p in commandParameters)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                            p.Value = DBNull.Value;

                        cmd.Parameters.Add(p);
                    }
                }

                return ExecuteNonQuery(cmd);

            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Execute non query </para>
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static int ExecuteNonQuery(DbCommand cmd)
        {
            using (DbConnection con = DbFactory.GetDBConnection())
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    int retVal = cmd.ExecuteNonQuery();
                    con.Close();
                    return retVal;

                }
                catch (Exception ex)
                {
                    con.Close();
                    ////SendErrorMessageOnException(ex);
                    throw ex;
                }
            }
        }

        #endregion

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Convert data table to string </para>
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static string ConvertDataTableToString(DataTable dt)
        {
            if (dt == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            for (int rowId = 0; rowId < dt.Rows.Count; rowId++)
            {

                for (int colId = 0; colId < dt.Columns.Count; colId++)
                {
                    sb.Append(dt.Rows[rowId][colId].ToString());
                    if (colId < dt.Columns.Count - 1)
                        sb.Append("#c0l#");
                }
                if (rowId < dt.Rows.Count - 1)
                    sb.Append("|r0w|");
            }
            return sb.ToString();
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get commad clone </para>
        /// </summary>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// database command
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DbCommand GetCommadClone(DbCommand cmd)
        {
            if (cmd == null)
                return null;

            DbCommand cloneCmd = DbFactory.GetDBCommand(cmd.CommandText);
            cloneCmd.CommandType = cmd.CommandType;
            cloneCmd.CommandTimeout = cmd.CommandTimeout;
            //cloneCmd.Connection = cmd.Connection; we will not have connection 

            foreach (DbParameter param in cmd.Parameters)
            {
                cloneCmd.Parameters.Add(GetDbParameterClone(param));
            }

            return cloneCmd;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get database parameter clone </para>
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>
        /// database parameter
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public static DbParameter GetDbParameterClone(DbParameter param)
        {
            if (param == null)
                return null;
            DbParameter cloneParam = DbFactory.GetDbParam(param.ParameterName, param.DbType, param.Value);
            cloneParam.Direction = param.Direction;
            cloneParam.Size = param.Size;
            cloneParam.SourceColumn = param.SourceColumn;
            cloneParam.SourceColumnNullMapping = param.SourceColumnNullMapping;
            return cloneParam;
        }
    }//class
}//namespace
