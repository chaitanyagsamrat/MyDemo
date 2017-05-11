using System.Configuration;
using GlobalPortal.Api.Client.ClientAuthentication;

namespace GlobalPortal.Api.Demo
{
    public static class Helpers
    {
        public static IServerAuthentication GetAuthenticator()
        {
            var username = ConfigurationManager.AppSettings["SyncUsername"];
            var password = ConfigurationManager.AppSettings["SyncPassword"];

            return GlobalPortalRestClient.GetAuthenticator(username, password);
        }

        public static IServerAuthentication GetAuthenticator(string url)
        {
            var username = ConfigurationManager.AppSettings["SyncUsername"];
            var password = ConfigurationManager.AppSettings["SyncPassword"];

            return GlobalPortalRestClient.GetAuthenticator(username, password, url);
        }

        public static IServerAuthentication GetAuthenticator(string username, string password)
        {
            return GlobalPortalRestClient.GetAuthenticator(username, password);
        }

        public static IServerAuthentication GetAuthenticator(string username, string password, string url)
        {
            return GlobalPortalRestClient.GetAuthenticator(username, password, url);
        }
    }
}