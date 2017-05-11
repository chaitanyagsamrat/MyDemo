using System;
using System.Linq;
using System.Web.Mvc;
using GlobalPortal.Api.Client.CommunicationUpdatesPatients;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PatientUpdates;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class CommunicationUpdatesPatientsController : Controller
    {
        public ActionResult Index(string patientExternalID = "", string method = "", bool? alreadySent = null)
        {
            var viewModel = new GenericModel<PatientUpdateModel>();

            try
            {
                viewModel.SearchResults = CommunicationUpdatesPatientsProvider.Search(Helpers.GetAuthenticator(), patientExternalID, method, alreadySent);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
               
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("PatientExternalID", patientExternalID);
            viewModel.Criteria.Add("Method", method);
            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());

            return View(viewModel);
        }
    }
}