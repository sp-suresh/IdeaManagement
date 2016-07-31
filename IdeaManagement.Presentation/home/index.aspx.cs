using IdeaManagement.Entites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IdeaManagement.Presentation.home
{
    public class Index : Page
    {
        protected Repeater rptIdeas;
        private string tabType = string.Empty;
        public int totalSuggestion = 0;
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
            tabType = Request.QueryString["tab"];
            GetTopIdeasBased();
        }
        protected void GetTopIdeasBased()
        {
            try
            {
                IList<IdeaSummary> summaryList = null;
                summaryList = AppHttpClient.GetApiResponseSync(ConfigurationManager.AppSettings["ApplicationHostUrl"], "application/json", "/api/idea/summary", summaryList);
                totalSuggestion = summaryList.Count;
                if (summaryList != null)
                {
                    if (!string.IsNullOrEmpty(tabType))
                    {
                        if (tabType.Equals("new"))
                        {
                            summaryList = (from sl in summaryList orderby sl.PostedDate descending select sl).ToList();
                        }
                        else if (tabType.Equals("votes"))
                        {
                            summaryList = (from sl in summaryList orderby sl.Votes descending select sl).ToList();
                        } 
                    }
                    else
                    {
                        summaryList = (from sl in summaryList orderby sl.Views descending select sl).ToList();
                    }
                    rptIdeas.DataSource = summaryList;
                    rptIdeas.DataBind();
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Warn(ex.ToString());
            }
        }
        public int GetDaysDifference<T>(T value)
        {
            DateTime outValue;

            string strDateValue = value != null ? value.ToString() : string.Empty;

            if (DateTime.TryParse(strDateValue, new CultureInfo("en-IN"), DateTimeStyles.AssumeLocal, out outValue))
                return Convert.ToInt32((DateTime.Now- outValue).TotalDays);
            else
            {
                DateTime.TryParse(Convert.ToString(strDateValue), out outValue);
                return Convert.ToInt32((DateTime.Now - outValue).TotalDays);
            }
        }
    }
}