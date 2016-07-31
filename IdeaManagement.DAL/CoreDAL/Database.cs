using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace IdeaManagement.DAL.CoreDAL
{
    /// <summary>
    /// <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The con
        /// </summary>
        private SqlConnection con;
        /// <summary>
        /// </summary>
        private SqlCommand cmd;
        /// <summary>
        /// The string connection
        /// </summary>
        private String strConn;

        /// <summary>
        /// The object trace
        /// </summary>
        private HttpContext objTrace = HttpContext.Current;

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public SqlConnection Conn
        {
            get { return con; }
            set { con = value; }
        }

        //constructor which assigns the connection string, as passed in the argument
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            this.strConn = ConfigurationManager.AppSettings["connectionString"];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        /// <param name="strConn">The string connection.</param>
        public Database(string strConn)
        {
            this.strConn = strConn;
        }

        //return the connection string
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get con string </para>
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public string GetConString()
        {
            return strConn;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select qry </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// SQL data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlDataReader SelectQry(string strSql)
        {
            SqlDataReader dataReader;
            con = new SqlConnection(strConn);

            try
            {
                con.Open();
                cmd = new SqlCommand(strSql, con);
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dataReader;
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select qry </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// SQL data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlDataReader SelectQry(string sqlStr, SqlParameter[] commandParameters)
        {
            SqlDataReader dataReader = null;
            con = new SqlConnection(strConn);

            try
            {
                con.Open();
                cmd = new SqlCommand(sqlStr, con);
                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }
                dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
            }
            catch (Exception err)
            {
                cmd.Parameters.Clear();
                CloseConnection();
                HttpContext.Current.Trace.Warn(err.Message + err.Source);

            }
            return dataReader;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select qry </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// SQL data reader
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlDataReader SelectQry(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            SqlDataReader dataReader = null;

            try
            {
                cmdParam.Connection = con;
                con.Open();

                dataReader = cmdParam.ExecuteReader(CommandBehavior.CloseConnection);
                //cmdParam.Parameters.Clear();
            }
            catch (Exception err)
            {
                cmdParam.Parameters.Clear();
                CloseConnection();
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            return dataReader;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapt qry </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public DataSet SelectAdaptQry(string strSql)
        {
            DataSet dataSet = new DataSet();
            con = new SqlConnection(strConn);

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(strSql, con);
                adapter.Fill(dataSet);
            }
            catch (Exception err)
            {
                CloseConnection();
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                CloseConnection();
            }
            return dataSet;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapt qry </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public DataSet SelectAdaptQry(string sqlStr, SqlParameter[] commandParameters)
        {
            DataSet dataSet = new DataSet();
            con = new SqlConnection(strConn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                adapter.SelectCommand = new SqlCommand(sqlStr, con);

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    adapter.SelectCommand.Parameters.Add(p);
                }
                adapter.Fill(dataSet);
                adapter.SelectCommand.Parameters.Clear();
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                adapter.SelectCommand.Parameters.Clear();
                CloseConnection();
            }
            return dataSet;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapt qry </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public DataSet SelectAdaptQry(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                cmdParam.Connection = con;
                //con.Open();
                adapter.SelectCommand = cmdParam;
                adapter.Fill(dataSet);
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmdParam.Parameters.Clear();
                adapter.SelectCommand.Parameters.Clear();
                CloseConnection();
            }
            return dataSet;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Close connection </para>
        /// </summary>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public void CloseConnection()
        {
            try
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    objTrace.Trace.Warn("database:CloseConnection:Connection is closed successfully.");
                    con.Close();
                }
            }
            catch (Exception)
            {
                //do nothing
                //HttpContext.Current.Trace.Warn(err.Message + err.Source);
            }

        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert qry </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool InsertQry(string strSql)
        {
            int intRetRows;
            con = new SqlConnection(strConn);
            bool result;
            try
            {
                cmd = new SqlCommand(strSql, con);
                con.Open();

                intRetRows = cmd.ExecuteNonQuery();
                if (intRetRows > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert qry </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool InsertQry(string sqlStr, SqlParameter[] commandParameters)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmd = new SqlCommand(sqlStr, con);
                con.Open();

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }

                int retval = cmd.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);



            }
            finally
            {
                cmd.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Insert qry </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool InsertQry(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmdParam.Connection = con;
                con.Open();

                int retval = cmdParam.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmdParam.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update qry </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool UpdateQry(string strSql)
        {
            int intRetRows;
            con = new SqlConnection(strConn);
            bool result;
            try
            {
                cmd = new SqlCommand(strSql, con);
                con.Open();
                intRetRows = cmd.ExecuteNonQuery();

                if (intRetRows > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update qry </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool UpdateQry(string sqlStr, SqlParameter[] commandParameters)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmd = new SqlCommand(sqlStr, con);
                con.Open();

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }

                int retval = cmd.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;


            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmd.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update qry </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool UpdateQry(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmdParam.Connection = con;
                con.Open();

                int retval = cmdParam.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmdParam.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update qry ret rows </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public int UpdateQryRetRows(string strSql)
        {
            int intRetRows = 0;
            con = new SqlConnection(strConn);

            try
            {
                cmd = new SqlCommand(strSql, con);
                con.Open();

                intRetRows = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                CloseConnection();
            }
            return intRetRows;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Update qry ret rows </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public int UpdateQryRetRows(string sqlStr, SqlParameter[] commandParameters)
        {
            con = new SqlConnection(strConn);
            int intRetRows = 0;

            try
            {
                cmd = new SqlCommand(sqlStr, con);
                con.Open();

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }

                intRetRows = cmd.ExecuteNonQuery();

            }
            catch (Exception err)
            {

                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmd.Parameters.Clear();
                CloseConnection();
            }
            return intRetRows;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Delete qry </para>
        /// </summary>
        /// <param name="strSql">The string SQL.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool DeleteQry(string strSql)
        {
            bool result;
            int intRetRows;
            con = new SqlConnection(strConn);
            try
            {
                cmd = new SqlCommand(strSql, con);
                con.Open();

                intRetRows = cmd.ExecuteNonQuery();
                if (intRetRows > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

            return result;

        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Delete qry </para>
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool DeleteQry(string sqlStr, SqlParameter[] commandParameters)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmd = new SqlCommand(sqlStr, con);
                con.Open();

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }

                int retval = cmd.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;


            }
            catch (Exception err)
            {

                HttpContext.Current.Trace.Warn(err.Message + err.Source);



            }
            finally
            {
                cmd.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Delete qry </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool DeleteQry(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            bool result = false;

            try
            {
                cmdParam.Connection = con;
                con.Open();

                int retval = cmdParam.ExecuteNonQuery();

                if (retval > 0)
                    result = true;
                else
                    result = false;
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                cmdParam.Parameters.Clear();
                CloseConnection();
            }
            return result;
        }

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
        public string ExecuteScalar(string strSql)
        {
            string val = "";

            SqlConnection con;
            SqlCommand cmd;

            Database db = new Database();
            string conStr = db.GetConString();

            con = new SqlConnection(conStr);

            try
            {
                con.Open();
                cmd = new SqlCommand(strSql, con);
                val = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);


            }
            finally
            {
                CloseConnection();
            }
            return val;
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
        public string ExecuteScalar(string strSql, SqlParameter[] commandParameters)
        {
            string val = "";
            con = new SqlConnection(strConn);

            try
            {
                cmd = new SqlCommand(strSql, con);
                con.Open();

                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                        p.Value = DBNull.Value;

                    cmd.Parameters.Add(p);
                }
                val = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);



            }
            finally
            {
                cmd.Parameters.Clear();
                CloseConnection();
            }
            return val;
        }
        /// <summary>
        /// Created By Surendra to create extra overloade function
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public string ExecuteScalar(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            string val = "";

            try
            {
                cmdParam.Connection = con;
                con.Open();
                val = Convert.ToString(cmdParam.ExecuteScalar());
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);

            }
            finally
            {
                HttpContext.Current.Trace.Warn("in DB finnally: " + val);
                cmdParam.Parameters.Clear();
                CloseConnection();
            }
            return val;
        }

        //using sqlCommand
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get in clause value </para>
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="cmd">The command.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public string GetInClauseValue(string input, string fieldName, SqlCommand cmd)
        {
            string[] inputArr = input.Split(',');
            string[] parameters = new string[inputArr.Length];
            try
            {
                for (int i = 0; i < inputArr.Length; i++)
                {
                    cmd.Parameters.Add("@" + fieldName + i, SqlDbType.VarChar, inputArr[i].Length).Value = inputArr[i].ToString();
                    parameters[i] = "@" + fieldName + i;
                }
            }
            catch (Exception err)
            {

                HttpContext.Current.Trace.Warn("GetCommandValue: " + err.Message + err.Source + ":GetCommandValue");


            }
            return string.Join(",", parameters);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get in clause value </para>
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns>
        /// string
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public string GetInClauseValue(string input, string fieldName, out SqlParameter[] commandParameters)
        {
            string[] inputArr = input.Split(',');
            string[] parameters = new string[inputArr.Length];
            commandParameters = null;
            try
            {
                commandParameters = new SqlParameter[inputArr.Length];

                for (int i = 0; i < inputArr.Length; i++)
                {
                    parameters[i] = "@" + fieldName + i;
                    commandParameters[i] = new SqlParameter(parameters[i], inputArr[i]);
                    HttpContext.Current.Trace.Warn(parameters[i].ToString() + " : " + inputArr[i].ToString());
                }

                HttpContext.Current.Trace.Warn(commandParameters.Length.ToString());
            }
            catch (Exception err)
            {

                HttpContext.Current.Trace.Warn("GetInClauseValue: " + err.Message + err.Source + ":GetInClauseValue");



            }

            return string.Join(",", parameters);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Concatenate parameters </para>
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <returns>
        /// SQL parameter[]
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlParameter[] ConcatenateParams(SqlParameter[] param1, SqlParameter[] param2)
        {
            SqlParameter[] param = null;

            if (param1 != null && param2 != null)
            {
                param = new SqlParameter[param1.Length + param2.Length];

                for (int i = 0; i < param1.Length; i++)
                {
                    param[i] = param1[i];
                }

                for (int i = param1.Length; i < param.Length; i++)
                {
                    param[i] = param2[i - param1.Length];
                }

                for (int i = 0; i < param.Length; i++)
                {
                    HttpContext.Current.Trace.Warn("Param : " + i.ToString() + " : " + param[i]);
                }
            }
            else if (param1 != null)
                param = param1;
            else if (param2 != null)
                param = param2;

            return param;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Concatenate parameters </para>
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="param3">The param3.</param>
        /// <returns>
        /// SQL parameter[]
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlParameter[] ConcatenateParams(SqlParameter[] param1, SqlParameter[] param2, SqlParameter[] param3)
        {
            //first join the first 2 params
            SqlParameter[] paramRes1 = ConcatenateParams(param1, param2);
            return ConcatenateParams(paramRes1, param3);
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Concatenate parameters </para>
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="param3">The param3.</param>
        /// <param name="param4">The param4.</param>
        /// <returns>
        /// SQL parameter[]
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public SqlParameter[] ConcatenateParams(SqlParameter[] param1, SqlParameter[] param2, SqlParameter[] param3,
                                                                    SqlParameter[] param4)
        {
            //first join the first 2 params
            SqlParameter[] paramRes1 = ConcatenateParams(param1, param2, param3);
            return ConcatenateParams(paramRes1, param4);
        }

        //select data from database with parameter
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Select adapt qry parameter nc </para>
        /// </summary>
        /// <param name="cmdParam">The command parameter.</param>
        /// <returns>
        /// data set
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public DataSet SelectAdaptQryParamNC(SqlCommand cmdParam)
        {
            con = new SqlConnection(strConn);
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            try
            {
                cmdParam.Connection = con;
                //con.Open();
                adapter.SelectCommand = cmdParam;
                adapter.Fill(dataSet);
            }
            catch (SqlException exSql)
            {
                dataSet = null;
                HttpContext.Current.Trace.Warn(exSql.Message + exSql.Source);
            }
            catch (Exception err)
            {
                HttpContext.Current.Trace.Warn(err.Message + err.Source);

            }
            finally
            {
                CloseConnection();
            }
            return dataSet;
        }

    }//class
}//namespace
