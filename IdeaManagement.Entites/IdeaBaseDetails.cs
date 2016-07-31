using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeaManagement.Entites
{
    /// <summary>
    ///   <para> Author      : Suresh Prajapati </para>
    /// <para> Created On  : 24-Jul-2016 </para>
    /// <para> Description : This class contains </para>
    /// </summary>
    public class IdeaBaseDetails
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the requested user.
        /// </summary>
        /// <value>
        /// The requested user.
        /// </value>
        [JsonProperty("requestedUser")]
        public string RequestedUser { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}