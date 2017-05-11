namespace GlobalPortal.Api.Client.ClientAuthentication
{
    public static class GlobalPortalRestClient
    {
        public static IServerAuthentication GetAuthenticator(string username, string password)
        {
            var restClientAuthenticator = RestClientAuthenticator.Instance;

            restClientAuthenticator.SetCredentials(username, password);

            return restClientAuthenticator;
        }

        public static IServerAuthentication GetAuthenticator(string username, string password, string url)
        {
            var restClientAuthenticator = RestClientAuthenticator.Instance;

            restClientAuthenticator.SetCredentials(username, password, url);

            return restClientAuthenticator;
        }
    }
}
