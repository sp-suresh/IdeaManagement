<%@ Application %>
<%@ Import NameSpace="System.Web" %>
<%@ Import NameSpace="System.Web.SessionState" %>
<%@ Import NameSpace="System.Web.Security" %>
<%@ Import NameSpace="System.Security.Principal" %>
<%@ Import NameSpace="System.Data" %>
<%@ Import NameSpace="System.Data.SqlClient" %>
<%@ Import NameSpace="System.Web.Http" %>
<%@ Import Namespace="IdeaManagement.Presentation"%>
<script language="c#" runat="server">


    void Application_Error( object sender, EventArgs e )
	{
		//CommonOpn op = new CommonOpn();
		Exception err = Server.GetLastError().GetBaseException();
		
		string subject = " Unhandled Exception : " + HttpContext.Current.Request.Url.ToString();
   	}

	protected void Application_Start()
    {
        //AutoBiz.Services.WebApiConfig.Register(GlobalConfiguration.Configuration);
        GlobalConfiguration.Configure(WebApiConfig.Register);
    }
</script>
