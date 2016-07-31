using IdeaManagement.BAL;
using IdeaManagement.DAL;
using IdeaManagement.Entites;
using IdeaManagement.Inteface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IdeaManagement.Services.Controllers.Idea
{
    /// <summary>
    /// <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class IdeaController : ApiController
    {
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get idea summary </para>
        /// </summary>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/summary"),HttpGet]
        public IHttpActionResult GetIdeaSummary()
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().GetIdeaSummary());
            }
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Save idea summary </para>
        /// </summary>
        /// <param name="objDetails">The object details.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/summary/"), HttpPost]
        public IHttpActionResult SaveIdeaSummary([FromBody] IdeaBaseDetails objDetails)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<ISuggestion, SuggestionProcessLogic>().Resolve<ISuggestion>().SaveSuggestion(objDetails));
            }
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get idea summary </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/summary/{ideaId}"), HttpGet]
        public IHttpActionResult GetIdeaSummary(string ideaId)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().GetSingleIdeaDetails(Convert.ToInt32(ideaId)));
            }
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get suggestion comments </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/comments/{ideaId}"), HttpGet]
        public IHttpActionResult GetSuggestionComments(string ideaId)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().GetSuggestionComments(Convert.ToInt32(ideaId)));
            }
        }
        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Get suggestion comments </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <param name="comments">The comments.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/comments/"), HttpPost]
        public IHttpActionResult SaveSuggestionComments(string ideaId,string comments)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().SaveSuggestionComments(Convert.ToInt32(ideaId),comments));
            }
        }

        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Increase viewed </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/view/{ideaId}/"), HttpPost]
        public IHttpActionResult IncreaseViewed(string ideaId)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().IncreaseViewCount(Convert.ToInt32(ideaId)));
            }
        }

        /// <summary>
        ///   <para> Added By     : Suresh Prajapati </para>
        /// <para> Created On   : 24-Jul-2016 </para>
        /// <para> Descriprtion : This method is used to Save suggestion votings </para>
        /// </summary>
        /// <param name="ideaId">The idea identifier.</param>
        /// <param name="voteType">Type of the vote.</param>
        /// <returns>
        /// i HTTP action result
        /// </returns>
        /// <author>
        /// Suresh Prajapati
        /// </author>
        [Route("api/idea/votes/"), HttpPost]
        public IHttpActionResult SaveSuggestionVotings(string ideaId,string voteType)
        {
            using (IUnityContainer container = new UnityContainer())
            {
                return Ok(container.RegisterType<IIdeaRepository, IdeaEngine>().Resolve<IIdeaRepository>().SaveSuggestionVotes(Convert.ToInt32(ideaId), Convert.ToInt32(voteType)));
            }
        }
    }
}
