<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        //Exception objErr = Server.GetLastError().GetBaseException();
        //string err = "<br><b>Error in: </b>" + Request.Url.ToString() +
        //"<br><b>Error Message: </b><br>" + objErr.Message.ToString() +
        //"<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString();
        //string mailresponse = SendEmail(err);

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
