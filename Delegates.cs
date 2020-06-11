using Microsoft.AspNetCore.Mvc.Routing;

namespace apc_bot_api
{
    public class Delegates
    {
        public delegate string UrlAction(UrlActionContext actionContext);
    }
}