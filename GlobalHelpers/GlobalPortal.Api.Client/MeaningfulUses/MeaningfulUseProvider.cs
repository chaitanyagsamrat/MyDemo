using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.MeaningfulUses;

namespace GlobalPortal.Api.Client.MeaningfulUses
{
    public static class MeaningfulUseProvider
    {
        private const string ControllerName = "meaningfulUses";

        public static List<MeaningfulUseCoreMeasureResultModel> Save(IServerAuthentication restClientAuthenticator, MeaningfulUseCoreMeasureModel model)
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

                    var response = restClient.PostAsJsonAsync<MeaningfulUseCoreMeasureModel>(string.Format(ApiClientGenericObjectResources.PostRequestUri, ControllerName), model).Result;

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
                            var meaningfulUseCoreMeasureResults = response.Content.ReadAsAsync<List<MeaningfulUseCoreMeasureResultModel>>().Result;

                            return meaningfulUseCoreMeasureResults;
                        }
                        else
                        {
                            var additionalInformation = response.Content.ReadAsStringAsync().Result;

                            throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()), additionalInformation));
                        }
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }
    }
}
