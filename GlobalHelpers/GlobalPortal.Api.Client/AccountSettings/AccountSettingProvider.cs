using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.AccountSettings;

namespace GlobalPortal.Api.Client.AccountSettings
{
    public static class AccountSettingProvider
    {
        private const string ControllerName = "accountSettings";

        public static AccountSettingsModel Get(IServerAuthentication restClientAuthenticator)
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

                    HttpResponseMessage response = restClient.GetAsync(string.Format("api/{0}", ControllerName)).Result;

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
                            AccountSettingsModel accountSettingsModel = response.Content.ReadAsAsync<AccountSettingsModel>().Result;

                            return accountSettingsModel;
                        }
                        else
                        {
                            throw new HttpRequestException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()));
                        }
                    }
                }
                throw new HttpRequestException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, AccountSettingsModel model)
        {
            return ApiClientGenericObject<AccountSettingsModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
