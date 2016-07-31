using IdeaManagement.DAL.CoreDAL;
using IdeaManagement.Inteface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace IdeaManagement.DAL
{
    /// <summary>
    /// <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    /// <seealso cref="IdeaManagement.Inteface.IUser" />
    public class UserEngine : IUser
    {
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get user identifier </para>
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// int32
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public int GetUserId(string name)
        {
            int userId = 0;
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("getuseridbyname"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_name", DbType.String, !string.IsNullOrEmpty(name) ? name: Convert.DBNull));
                    using (IDataReader dr = MySqlDatabase.ExecuteReader(cmd))
                    {
                        if (dr.Read())
                        {
                            userId = CustomParser.ParseIntObject(dr["userid"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userId;
        }
    }
}