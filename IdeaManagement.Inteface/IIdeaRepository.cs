using IdeaManagement.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagement.Inteface
{
    /// <summary>
    /// <para>Authtor : Suresh Prajapati </para>
    /// <para>Created On : 24-Jul-2016 </para>
    /// <para>Description : This interface contains method decleration related to </para>
    /// </summary>
    public interface IIdeaRepository
    {
        IList<IdeaSummary> GetIdeaSummary();
        IList<string> GetSuggestionComments(int ideaId);
        IdeaBaseDetails GetSingleIdeaDetails(int ideaId);
        bool IncreaseViewCount(int ideaId);
        bool SaveSuggestionComments(int ideaId, string comments);
        bool SaveSuggestionVotes(int ideaId, int typeId);
    }
}
