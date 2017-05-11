using GlobalPortal.Api.Client.AppointmentRequestReasons;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentRequestReasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentRequestReasonsController : Controller
    {
        // GET: AppointmentRequestReasons
        public ActionResult Index(bool? changed = null, bool? isDeleted = null)
        {
            var viewModel = new GenericModel<AppointmentRequestReasonModel>();

            try
            {
                viewModel.SearchResults = AppointmentRequestReasonProvider.Search(Helpers.GetAuthenticator(), changed, isDeleted);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("changed", changed.ToString());
            viewModel.Criteria.Add("isDeleted", isDeleted.ToString());

            return View(viewModel);
        }

        // POST: AppointmentRequestReasons/Send
        [HttpPost]
        public ActionResult Send(GenericModel<AppointmentRequestReasonModel> viewModel)
        {
            try
            {
                if (viewModel.Data.InternalId == Guid.Empty)
                {
                    viewModel.ErrorMessage = "Please provide a valid ID.";
                    return View("Index", viewModel);
                }

                var success = AppointmentRequestReasonProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("changed", string.Empty);
            viewModel.Criteria.Add("isDeleted", string.Empty);
            return View("Index", viewModel);
        }
    }
}