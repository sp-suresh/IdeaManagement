using IdeaManagement.DAL;
using IdeaManagement.Entites;
using IdeaManagement.Inteface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaManagement.BAL
{
    public class SuggestionProcessLogic : ISuggestion
    {
        private readonly IUser _userRepository = null;
        private readonly ISuggestion _suggestionRepository = null;
        public SuggestionProcessLogic()
        {
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<IUser, UserEngine>();
                container.RegisterType<ISuggestion, SuggestionProcessEngine>();
                _userRepository = container.Resolve<IUser>();
                _suggestionRepository = container.Resolve<ISuggestion>();
            }
        }

        /// <summary>
        /// <para> Added By     : Suresh Prajapati </para>
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
            objDetails.UserId = _userRepository.GetUserId(objDetails.RequestedUser);
            return _suggestionRepository.SaveSuggestion(objDetails);
        }
    }
}