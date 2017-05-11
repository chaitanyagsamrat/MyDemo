using GlobalPortal.Api.Client.CommunicationUpdatesAppointments;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentUpdates;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class CommunicationUpdatesAppointmentsController : Controller
    {
        // GET: CommunicationUpdatesAppointments/Create
        public ActionResult Index(string appointmentExternalID = "", string method ="", bool? alreadySent = null)
        {
            var viewModel = new GenericModel<AppointmentUpdateModel>();

            try
            {
                viewModel.SearchResults = CommunicationUpdatesAppointmentsProvider.Search(Helpers.GetAuthenticator(), appointmentExternalID, method, alreadySent);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("AppointmentExternalID", appointmentExternalID);
            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());
            viewModel.Criteria.Add("Method", method);

            return View("Index", viewModel);
        }
    }
}