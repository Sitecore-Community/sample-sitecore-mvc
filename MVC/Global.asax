<%@Application Language='C#' Inherits="Sitecore.Web.Application" %>

<script runat="server">
  public void Application_Start() {
  }

  public void Application_End() {
  }

  public void Application_Error(object sender, EventArgs args) {
  }

  public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
  {
    string frameworkVersion = this.GetFrameworkVersion();
    if (!string.IsNullOrEmpty(frameworkVersion) && frameworkVersion.StartsWith("v4.", StringComparison.InvariantCultureIgnoreCase))
    {
      args.User = Sitecore.Context.User;
    }
  }

  string GetFrameworkVersion()
  {
    try
    {
      return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
    }
    catch(Exception ex)
    {
      Sitecore.Diagnostics.Log.Error("Cannot get framework version", ex, this);
      return string.Empty;
    }
  }

</script>
