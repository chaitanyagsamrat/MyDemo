using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalPortal.Api.Models.SynchronizationUsers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace GlobalPortal.Api.Client.SynchronizationUsers
{
    public class SynchronizationUserProvider
    {
        private const string controllerName = "synchronizationuser";

        public static SynchronizationUserModel CreateUser(IServerAuthentication restClientAuthenticator, SynchronizationUserModel model)
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

                    var response = restClient.PostAsJsonAsync<SynchronizationUserModel>(string.Format(ApiClientGenericObjectResources.PostRequestUri, controllerName), model).Result;

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
                            return response.Content.ReadAsAsync<SynchronizationUserModel>().Result;
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
