namespace GlobalPortal.Api.Client.ClientAuthentication
{
    public interface IServerAuthentication
    {
        /// <summary>
        /// Gets the current token.
        /// </summary>
        /// <returns></returns>
        string GetToken(bool tokenExpired = false);

        /// <summary>
        /// Gets the base address for the requests.
        /// </summary>
        /// <returns></returns>
        string GetBaseAddress();
    }
}
