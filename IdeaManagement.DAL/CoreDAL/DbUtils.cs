using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace IdeaManagement.DAL.CoreDAL
{
    /// <summary>
    /// Author      : Chetan avin
    /// Created On  : 3rd May 2016
    /// Description : This class contains utility methods
    /// </summary>
    public static class DbUtils
    {
        public static string GetInClauseValue(string input, string fieldName,DbCommand cmd)
        {
            string[] inputArr = input.Split(',');
            string[] parameters = new string[inputArr.Length];
            
            try
            {
                cmd = DbFactory.GetDBCommand();
                for (int i = 0; i < inputArr.Length; i++)
                {
                    cmd.Parameters.Add(DbFactory.GetDbParam("@" + fieldName + i, DbType.String, inputArr[i].ToString()));
                    //cmd.Parameters.Add("v_" + fieldName + i, MySqlDbType.String, inputArr[i].Length).Value = inputArr[i].ToString();
                    parameters[i] = "@" + fieldName + i;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            return string.Join(",", parameters);
        }

        public static string GetInClauseValue(string input, string fieldName, out DbParameter[] commandParameters)
        {
            string[] inputArr = input.Split(',');
            string[] parameters = new string[inputArr.Length];
            commandParameters = null;
            try
            {
                commandParameters = DbFactory.GetDbParamArray(inputArr.Length);

                for (int i = 0; i < inputArr.Length; i++)
                {
                    parameters[i] = "@" + fieldName + i;
                    commandParameters[i] = DbFactory.GetDbParam(parameters[i], DbType.String, inputArr[i].ToString());
                    HttpContext.Current.Trace.Warn(parameters[i].ToString() + " : " + inputArr[i].ToString());
                }

                HttpContext.Current.Trace.Warn(commandParameters.Length.ToString());
            }
            catch (Exception err)
            {
                throw err;
            }
            return string.Join(",", parameters);
        }
    }
}