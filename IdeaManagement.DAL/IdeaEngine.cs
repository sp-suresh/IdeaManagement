using IdeaManagement.DAL.CoreDAL;
using IdeaManagement.Entites;
using IdeaManagement.Inteface;
using System;
using System.Collections;
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
    /// <seealso cref="IdeaManagement.Inteface.IIdeaRepository" />
    public class IdeaEngine : IIdeaRepository
    {
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get idea summary </para>
        /// </summary>
        /// <returns>
        /// i list
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public IList<IdeaSummary> GetIdeaSummary()
        {
            List<IdeaSummary> objIdeaSummary = null;
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("getideasummary"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (IDataReader dr = MySqlDatabase.ExecuteReader(cmd))
                    {
                        objIdeaSummary = new List<IdeaSummary>();
                        while (dr.Read())
                        {
                            objIdeaSummary.Add(new IdeaSummary { CommentsCount = CustomParser.ParseIntObject(dr["commentcount"]), IdeaId = CustomParser.ParseIntObject(dr["ideadetailsid"]), PostedDate = CustomParser.ParseDateObject(dr["entrydate"]), RequestedUser = Convert.ToString(dr["name"]), Title = Convert.ToString(dr["ideatitle"]), Views = CustomParser.ParseIntObject(dr["viewcount"]), Votes = CustomParser.ParseIntObject(dr["votecount"]), Description = Convert.ToString(dr["description"]) });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objIdeaSummary;
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get single idea details </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// idea base details
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public IdeaBaseDetails GetSingleIdeaDetails(int ideaId)
        {
            IdeaBaseDetails objIdeaDetails = null;
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("getideadetails"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ideaid", DbType.Int32, ideaId != 0 ? ideaId : Convert.DBNull));
                    using (IDataReader dr = MySqlDatabase.ExecuteReader(cmd))
                    {
                        if(dr.Read())
                        {
                            objIdeaDetails = new IdeaBaseDetails { RequestedUser = Convert.ToString(dr["name"]), Title = Convert.ToString(dr["ideatitle"]), Description = Convert.ToString(dr["description"]) };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objIdeaDetails;
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get suggestion comments </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// i list
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public IList<string> GetSuggestionComments(int ideaId)
        {
            IList<string> objComments = null;
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("getsuggestioncomments"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ideaid", DbType.Int32, ideaId != 0 ? ideaId : Convert.DBNull));
                    using (IDataReader dr = MySqlDatabase.ExecuteReader(cmd))
                    {
                        objComments = new List<string>();
                        while (dr.Read())
                        {
                            objComments.Add(Convert.ToString(dr["comments"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objComments;
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Increase view count </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool IncreaseViewCount(int ideaId)
        {
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("increaseviewcount"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ideaid", DbType.Int32, ideaId != 0 ? ideaId : Convert.DBNull));
                    return MySqlDatabase.UpdateQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Save suggestion comment </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <param name="comments">The comments.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool SaveSuggestionComments(int ideaId, string comments)
        {
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("savesuggestioncomments"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ideaid", DbType.Int32, ideaId != 0 ? ideaId : Convert.DBNull));
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_comments", DbType.String, !string.IsNullOrEmpty(comments) ? comments : Convert.DBNull));
                    return MySqlDatabase.InsertQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Save suggestion votes </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <param name="typeId">The type identifier.</param>
        /// <returns>
        /// boolean
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        public bool SaveSuggestionVotes(int ideaId, int typeId)
        {
            try
            {
                using (DbCommand cmd = DbFactory.GetDBCommand("savesuggestionvotes"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_ideadetailsid", DbType.Int32, ideaId != 0 ? ideaId : Convert.DBNull));
                    cmd.Parameters.Add(DbFactory.GetDbParam("par_votetype", DbType.Byte, typeId != 0 ? typeId : Convert.DBNull));
                    return MySqlDatabase.UpdateQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
