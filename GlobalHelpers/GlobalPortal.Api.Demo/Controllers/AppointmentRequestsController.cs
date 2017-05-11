using GlobalPortal.Api.Client.AppointmentRequests;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentRequestsController : Controller
    {
        public ActionResult Index(bool? alreadySent = null)
        {
            var viewModel = new GenericModel<PatientAppointmentRequestModel>();

            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());

            try
            {
                viewModel.SearchResults = AppointmentRequestProvider.Search(Helpers.GetAuthenticator(), alreadySent);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
                
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            return View(viewModel);
        }
    }
}