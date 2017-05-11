using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.PatientUpdates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalPortal.Api.Models.MarkAsReceived;
using GlobalPortal.Api.Client.MarkAsReceived;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.CommunicationUpdatesPatients
{
    public static class CommunicationUpdatesPatientsProvider
    {
        private const string ControllerName = "communicationUpdatesPatients";
        private const string MarkAsSentControllerName = "patientupdatessent";

        public static ListModel<PatientUpdateModel> Search(
           IServerAuthentication restClientAuthenticator,
           string patientExternalID = "",
           string method = "",
           bool? alreadySent = null,
           int page = 1,
           int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());
            criteria.Add("patientExternalID", patientExternalID);
            criteria.Add("method", method);
            criteria.Add("AlreadySent", alreadySent.ToString());

            return ApiClientGenericObject<PatientUpdateModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        /// Sets the status for the patient update to approved or denied. (To do) Triggers an email to inform patient of the results.
        public static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model)
        {
            return MarkAsReceivedProvider.MarkAsReceived(restClientAuthenticator, model, MarkAsSentControllerName);
        }
    }
}
