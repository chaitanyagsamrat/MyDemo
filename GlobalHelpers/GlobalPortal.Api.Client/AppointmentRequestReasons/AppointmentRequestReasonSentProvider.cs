using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.AppointmentRequestReasons;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GlobalPortal.Api.Client.AppointmentRequestReasons
{
    public class AppointmentRequestReasonSentProvider
    {
        private const string controllerName = "appointmentrequestreasonssent";

        /// Sets changed to appointment request reasons, whether it has changed or no.
        public static AppointmentRequestReasonReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, AppointmentRequestReasonReceivedModel model)
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
                    try
                    {
                        var response = restClient.PostAsJsonAsync(string.Format(ApiClientGenericObjectResources.PostRequestUri, controllerName), model).Result;

                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            authorizationToken = restClientAuthenticator.GetToken(true);

                            tries++;
                            keepTrying = tries < 4;
                        }
                        else
                        {
                            keepTrying = false;

                            var additionalInformation = response.Content.ReadAsStringAsync().Result;
                            model = JsonConvert.DeserializeObject<AppointmentRequestReasonReceivedModel>(additionalInformation);

                            return model;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException(ex.GetBaseException().Message);
                    }
                }
                throw new ApplicationException(string.Format(ApiClientGenericObjectResources.UnsuccessfulResponseMessage, HttpStatusCode.Unauthorized.ToString()));
            }
        }
    }
}

