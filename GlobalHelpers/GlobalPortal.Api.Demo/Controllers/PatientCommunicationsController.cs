using GlobalPortal.Api.Client.PatientCommunications;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PatientCommunications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PatientCommunicationsController : Controller
    {
        // GET: PatientCommunications/Create
        public ActionResult Index(DateTime? utcCreationDate1 = null, DateTime? utcCreationDate2 = null, bool ? alreadySent = null, string patientCriteriaId = "", string appointmentCriteriaId = "")
        {
            var betweenOperador = "between";
            utcCreationDate1 = utcCreationDate1 ?? DateTime.MinValue;
            utcCreationDate2 = utcCreationDate2 ?? DateTime.MaxValue;

            var viewModel = new GenericModel<PatientCommunicationModel>();
            viewModel.Criteria.Add("AlreadySent", alreadySent.ToString());
            viewModel.Criteria.Add("UtcCreationDate1", utcCreationDate1.ToString());
            viewModel.Criteria.Add("UtcCreationDate2", utcCreationDate2.ToString());
            viewModel.Criteria.Add("PatientCriteriaId", patientCriteriaId);
            viewModel.Criteria.Add("AppointmentCriteriaId", appointmentCriteriaId);

            try
            {
                viewModel.SearchResults = PatientCommunicationProvider.Search(Helpers.GetAuthenticator(), alreadySent, betweenOperador, utcCreationDate1, utcCreationDate2, patientCriteriaId, appointmentCriteriaId);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

    }
}