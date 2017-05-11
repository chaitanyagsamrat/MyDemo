using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.AppointmentRequestReasons;

namespace GlobalPortal.Api.Client.AppointmentRequestReasons
{
    public static class AppointmentRequestReasonProvider
    {
        private const string ControllerName = "appointmentrequestreasons";

        public static ListModel<AppointmentRequestReasonModel> Search(
            IServerAuthentication restClientAuthenticator,
            bool? changed = null,
            bool? isDeleted = null,
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();
            criteria.Add("changed", changed.ToString());
            criteria.Add("isDeleted", isDeleted.ToString());

            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<AppointmentRequestReasonModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, AppointmentRequestReasonModel model)
        {
            return ApiClientGenericObject<AppointmentRequestReasonModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
