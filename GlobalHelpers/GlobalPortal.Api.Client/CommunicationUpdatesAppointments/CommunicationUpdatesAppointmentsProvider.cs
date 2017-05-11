using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Client.MarkAsReceived;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.AppointmentUpdates;
using GlobalPortal.Api.Models.MarkAsReceived;

namespace GlobalPortal.Api.Client.CommunicationUpdatesAppointments
{
    public static class CommunicationUpdatesAppointmentsProvider
    {
        private const string ControllerName = "communicationUpdatesAppointments";
        private const string MarkAsSentControllerName = "appointmentupdatessent";

        public static ListModel<AppointmentUpdateModel> Search(
          IServerAuthentication restClientAuthenticator,
          string appointmentExternalID = "",
          string method = "",
          bool? alreadySent = null,
          int page = 1,
          int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());
            criteria.Add("AppointmentExternalID", appointmentExternalID);
            criteria.Add("AlreadySent", alreadySent.ToString());
            criteria.Add("Method", method);

            return ApiClientGenericObject<AppointmentUpdateModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        /// Sets the status for the order update to approved or denied. (To do) Triggers an email to inform patient of the results.
        public static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model)
        {
            return MarkAsReceivedProvider.MarkAsReceived(restClientAuthenticator, model, MarkAsSentControllerName);
        }
    }
}
