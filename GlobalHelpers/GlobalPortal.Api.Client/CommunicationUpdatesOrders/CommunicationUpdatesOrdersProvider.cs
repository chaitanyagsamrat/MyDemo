using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Client.MarkAsReceived;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.MarkAsReceived;
using GlobalPortal.Api.Models.OrderUpdates;

namespace GlobalPortal.Api.Client.CommunicationUpdatesOrders
{
    public static class CommunicationUpdatesOrdersProvider
    {
        private const string ControllerName = "communicationupdatesorders";
        private const string MarkAsSentControllerName = "orderupdatessent";

        public static ListModel<OrderUpdateModel> Search(
         IServerAuthentication restClientAuthenticator,
         string orderExternalID = "",
         string method = "",
         bool? alreadySent = null,
         int page = 1,
         int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();
            criteria.Add("orderExternalID", orderExternalID);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());
            criteria.Add("AlreadySent", alreadySent.ToString());
            criteria.Add("method", method);

            return ApiClientGenericObject<OrderUpdateModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        /// Sets the status for the order update to approved or denied. (To do) Triggers an email to inform patient of the results.
        public static MarkAsReceivedModel MarkAsReceived(IServerAuthentication restClientAuthenticator, MarkAsReceivedModel model)
        {
            return MarkAsReceivedProvider.MarkAsReceived(restClientAuthenticator, model, MarkAsSentControllerName);
        }
    }
}
