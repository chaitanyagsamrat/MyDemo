using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.CommunicationUpdatesOrders;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.OrderUpdates;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class CommunicationUpdatesOrdersController : Controller
    {
        public ActionResult Index(string orderExternalID = "", string method = "", bool? alreadySent = null)
        {
            var viewModel = new GenericModel<OrderUpdateModel>();

            try
            {
                viewModel.SearchResults = CommunicationUpdatesOrdersProvider.Search(Helpers.GetAuthenticator(), orderExternalID, method, alreadySent);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count > 0 ? string.Empty : Resources.ListEmptyMessage;

            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("OrderExternalID", orderExternalID);
            viewModel.Criteria.Add("Method", method);
            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());

            return View(viewModel);
        }
    }
}