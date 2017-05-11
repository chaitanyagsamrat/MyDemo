using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Forms
{
    public static class FormProvider
    {
        private const string controllerName = "forms";

        public static ListModel<FormModel> Search(
            IServerAuthentication restClientAuthenticator,
            string formStatus = "",
            string creationDateOperator = "",
            DateTime? utcCreationDate1 = null,
            DateTime? utcCreationDate2 = null,
            string completedDateOperator = "",
            DateTime? utcCompletedDate1 = null,
            DateTime? utcCompletedDate2 = null,
            string closedDateOperator = "",
            DateTime? utcClosedDate1 = null,
            DateTime? utcClosedDate2 = null,
            string patientFirstName = "",
            string patientLastName = "",
            bool? FormLayoutActive = null,
            string patientExternalId = "",
            int page = 1,
            int itemsPerPage = 10,
            bool onlyProfileForms = false)
        {
            var criteria = new SearchCriteria();

            criteria.Add("formStatus", formStatus);
            criteria.Add("creationDateOperator", creationDateOperator);
            criteria.Add("utcCreationDate1", utcCreationDate1.ToString());
            criteria.Add("utcCreationDate2", utcCreationDate2.ToString());
            criteria.Add("completedDateOperator", completedDateOperator);
            criteria.Add("utcCompletedDate1", utcCompletedDate1.ToString());
            criteria.Add("utcCompletedDate2", utcCompletedDate2.ToString());
            criteria.Add("dateClosedOperator", closedDateOperator);
            criteria.Add("utcClosedDate1", utcClosedDate1.ToString());
            criteria.Add("utcClosedDate2", utcClosedDate2.ToString());
            criteria.Add("patientFirstName", patientFirstName);
            criteria.Add("patientLastName", patientLastName);
            criteria.Add("FormLayoutActive", FormLayoutActive.ToString());
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());
            criteria.Add("patientExternalId", patientExternalId);
            criteria.Add("onlyProfileForms", onlyProfileForms.ToString());

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
                    HttpResponseMessage response = restClient.GetAsync(string.Format(ApiClientGenericObjectResources.SearchRequestUri, controllerName, "/search?", criteria.GetAsUrlParameters())).Result;

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
                            ListModel<FormModel> formModelList = response.Content.ReadAsAsync<ListModel<FormModel>>().Result;

                            return formModelList;
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
    }
}
