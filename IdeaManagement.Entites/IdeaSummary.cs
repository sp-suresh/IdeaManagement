using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///   <author>Suresh Prajapati </author>
/// </summary>
namespace IdeaManagement.Entites
{
    /// <summary>
    ///   <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    /// <seealso cref="IdeaManagement.Entites.IdeaBaseDetails" />
    public class IdeaSummary : IdeaBaseDetails
    {
        /// <summary>
        /// Gets or sets the idea identifier.
        /// </summary>
        /// <value>
        /// The idea identifier.
        /// </value>
        public int IdeaId { get; set; }
        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>
        /// The votes.
        /// </value>
        public int Votes { get; set; }
        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        /// <value>
        /// The views.
        /// </value>
        public int Views { get; set; }
        /// <summary>
        /// Gets or sets the comments count.
        /// </summary>
        /// <value>
        /// The comments count.
        /// </value>
        public int CommentsCount { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }
    }
}