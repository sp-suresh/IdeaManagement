using IdeaManagement.DAL.CoreDAL;
using IdeaManagement.Entites;
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
    public class SuggestionProcessEngine : ISuggestion
    {
        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Save suggestion </para>
        /// </summary>
        /// <param name="objDetails">The object details.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool SaveSuggestion(IdeaBaseDetails objDetails)
        {
            bool isSuccess = false;
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("savesuggestion"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ownerid", DbType.Int32, objDetails.UserId != 0 ? objDetails.UserId : Convert.DBNull));
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_title", DbType.String, !string.IsNullOrEmpty(objDetails.Title) ? objDetails.Title : Convert.DBNull));
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_description", DbType.String, !string.IsNullOrEmpty(objDetails.Description) ? objDetails.Description : Convert.DBNull));
                    isSuccess = MySqlDatabase.InsertQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
    }
}