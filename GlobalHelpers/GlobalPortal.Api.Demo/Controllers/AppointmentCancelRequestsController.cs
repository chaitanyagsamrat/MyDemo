using System;
using System.Linq;
using System.Web.Mvc;
using GlobalPortal.Api.Client.AppointmentCancelRequests;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentCancelRequests;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentCancelRequestsController : Controller
    {
        public ActionResult Index(bool? alreadySent = null)
        {
            var viewModel = new GenericModel<AppointmentCancelRequestModel>();

            try
            {
                viewModel.SearchResults = AppointmentCancelRequestProvider.Search(Helpers.GetAuthenticator(), alreadySent);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());

            return View("Index", viewModel);
        }
    }
}
