using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Client.MarkAsReceived;
using GlobalPortal.Api.Models.AppointmentCancelRequests;
using GlobalPortal.Api.Models.AppointmentRequestResults;
using GlobalPortal.Api.Models.MarkAsReceived;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.AppointmentCancelRequests
{
    public static class AppointmentCancelRequestProvider
    {
        private const string ControllerName = "appointmentcancelrequests";
        private const string MarkAsSentControllerName = "appointmentcancelrequestssent";

        public static ListModel<AppointmentCancelRequestModel> Search(
            IServerAuthentication restClientAuthenticator,
            bool? alreadySent = null,
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("alreadySent", alreadySent.ToString());
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<AppointmentCancelRequestModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        /// Sets the status for the appointment cancellation request to approved or denied. (To do) Triggers an email to inform patient of the results of the cancellation request.
        public static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model)
        {
            return MarkAsReceivedProvider.MarkAsReceived(restClientAuthenticator, model, MarkAsSentControllerName);
        }

        /// Sets the status for the appointment cancellation request to approved or denied. (To do) Triggers an email to inform patient of the results of the cancellation request.
        public static bool ApplyResult(IServerAuthentication restClientAuthenticator, AppointmentRequestResultModel model)
        {
            return ApiClientGenericObject<AppointmentRequestResultModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
