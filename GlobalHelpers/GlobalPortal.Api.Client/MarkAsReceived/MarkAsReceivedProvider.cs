using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.MarkAsReceived;

namespace GlobalPortal.Api.Client.MarkAsReceived
{
    internal static class MarkAsReceivedProvider
    {
        internal static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model, string controllerName)
        {
            var baseAddress = restClientAuthenticator.GetBaseAddress();
            var authorizationToken = restClientAuthenticator.GetToken();

            var tries = 0;
            var keepTrying = true;

            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(baseAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                while (keepTrying)
                {
                    restClient.DefaultRequestHeaders.Add("Authorization", authorizationToken);

                    var response = restClient.PostAsJsonAsync<MarkAsReceivedModel>(string.Format(ApiClientGenericObjectResources.PostRequestUri, controllerName), model).Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        authorizationToken = restClientAuthenticator.GetToken(true);

                        tries++;
                        keepTrying = tries < 4;
                    }
                    else
                    {
                        keepTrying = false;

                        if (response.IsSuccessStatusCode)
                        {
                            MarkAsReceivedModel MarkAsReceivedModel = response.Content.ReadAsAsync<MarkAsReceivedModel>().Result;

                            return MarkAsReceivedModel;
                        }
                        else
                        {
                            var additionalInformation = response.Content.ReadAsStringAsync().Result;

                            throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.BadRequest.ToString()), additionalInformation));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }
    }
}
