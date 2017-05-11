using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.AppointmentsModel;

namespace GlobalPortal.Api.Client.Appointments
{
    public static class AppointmentProvider
    {
        private const string ControllerName = "appointments";

        public static ListModel<AppointmentModel> Search(IServerAuthentication restClientAuthenticator, string appointmentExternalId = "",
            DateTime? patientBirthday = null, string status = "", string startDateOperator = "", DateTime? start1 = null,
            DateTime? start2 = null, string portalCreatedOperator = "", DateTime? portalCreated1 = null, DateTime? portalCreated2 = null,
            int page = 1, int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("appointmentExternalId", appointmentExternalId);
            criteria.Add("patientBirthday", patientBirthday.ToString());
            criteria.Add("status", status);
            criteria.Add("startDateOperator", startDateOperator);
            criteria.Add("start1", start1.ToString());
            criteria.Add("start2", start2.ToString());
            criteria.Add("portalCreatedOperator", portalCreatedOperator);
            criteria.Add("portalCreated1", portalCreated1.ToString());
            criteria.Add("portalCreated2", portalCreated2.ToString());

            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<AppointmentModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static AppointmentModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<AppointmentModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static AppointmentModel Save(IServerAuthentication restClientAuthenticator, AppointmentModel model)
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

                    var response = restClient.PostAsJsonAsync<AppointmentModel>(string.Format(ApiClientGenericObjectResources.PostRequestUri, ControllerName), model).Result;

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
                            return response.Content.ReadAsAsync<AppointmentModel>().Result;
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

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<AppointmentModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
