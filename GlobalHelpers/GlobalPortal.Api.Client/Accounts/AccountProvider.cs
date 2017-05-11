using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Accounts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GlobalPortal.Api.Client.Accounts
{
    public static class AccountProvider
    {
        private const string ControllerName = "accounts";

        public static NewAccountResultModel Save(string webApiAddress, NewAccountModel model)
        {
            using (var restClient = new HttpClient())
            {
                restClient.BaseAddress = new Uri(webApiAddress);
                restClient.DefaultRequestHeaders.Accept.Clear();
                restClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = restClient.PostAsJsonAsync<NewAccountModel>(string.Format(ApiClientGenericObjectResources.PostRequestUri, ControllerName), model).Result;

                if (response.IsSuccessStatusCode)
                {
                    var newAccountResultModel = response.Content.ReadAsAsync<NewAccountResultModel>().Result;

                    return newAccountResultModel;
                }
                else
                {
                    var additionalInformation = response.Content.ReadAsStringAsync().Result;

                    throw new ApplicationException(string.Format("{0}{1}", string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, response.StatusCode.ToString()), additionalInformation));
                }
            }
        }
    }
}
