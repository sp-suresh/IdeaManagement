using IdeaManagement.Entites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdeaManagement.Presentation.home
{
    public class DescribedIdea : Page
    {
        protected Repeater rptComments;
        public IdeaBaseDetails objSummary = null;
        public int ideaId = 0;
        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            base.Load += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ideaId = Convert.ToInt32(Request.QueryString["id"]);
            if (ideaId > 0)
            {
                LoadIdeaDetails(ideaId);
                LoadSuggestionComments(ideaId);
            }
        }

        private void LoadSuggestionComments(int ideaId)
        {
            try
            {
                List<string> objComments = null;
                objComments = AppHttpClient.GetApiResponseSync(ConfigurationManager.AppSettings["ApplicationHostUrl"], "application/json", "api/idea/comments/" + Convert.ToString(ideaId), objComments);
                if (objComments != null)
                {
                    rptComments.DataSource = objComments;
                    rptComments.DataBind();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
        }

        private void LoadIdeaDetails(int ideaId)
        {
            try
            {
                objSummary = AppHttpClient.GetApiResponseSync(ConfigurationManager.AppSettings["ApplicationHostUrl"], "application/json", "api/idea/summary/" + Convert.ToString(ideaId), objSummary);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
        }
    }
}