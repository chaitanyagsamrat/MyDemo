using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Client.MarkAsReceived;
using GlobalPortal.Api.Models.MarkAsReceived;
using GlobalPortal.Api.Models.PatientCommunications;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.PatientCommunications
{
    public static class PatientCommunicationProvider
    {
        private const string ControllerName = "patientCommunications";
        private const string MarkAsSentControllerName = "communicationupdatessent";

        public static ListModel<PatientCommunicationModel> Search(
         IServerAuthentication restClientAuthenticator,
         bool? alreadySent = null,
         string creationDateOperator = "",
         DateTime? utcCreationDate1 = null,
         DateTime? utcCreationDate2 = null,
         string patientExternalId = "",
         string appointmentExternalId = "",
         bool? outgoing = null,
         int page = 1,
         int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("creationDateOperator", creationDateOperator);
            criteria.Add("utcCreationDate1", utcCreationDate1.ToString());
            criteria.Add("utcCreationDate2", utcCreationDate2.ToString());
            criteria.Add("alreadySent", alreadySent.ToString());
            criteria.Add("patientExternalId", patientExternalId);
            criteria.Add("appointmentExternalId", appointmentExternalId);
            criteria.Add("outgoing", outgoing.ToString());
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<PatientCommunicationModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model)
        {
            return MarkAsReceivedProvider.MarkAsReceived(restClientAuthenticator, model, MarkAsSentControllerName);
        }
    }
}
