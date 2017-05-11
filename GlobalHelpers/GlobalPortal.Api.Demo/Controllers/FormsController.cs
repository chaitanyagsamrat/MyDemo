using System;
using System.Linq;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Forms;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Forms;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class FormsController : Controller
    {
        public ActionResult Index(
            string formStatus,
            DateTime? utcCreationDate1 = null,
            DateTime? utcCreationDate2 = null,
            DateTime? utcCompletedDate1 = null,
            DateTime? utcCompletedDate2 = null,
            DateTime? utcClosedDate1 = null,
            DateTime? utcClosedDate2 = null,
            string patientFirstName = "",
            string patientLastName = "",
            bool? FormLayoutActive = null,
            int page = 1,
            int itemsPerPage = 10,
            string patientId = "",
            bool onlyProfileForms = false)
        {
            var betweenOperador = "between";

            var viewModel = new GenericModel<FormModel>();

            utcCreationDate1 = utcCreationDate1 ?? DateTime.MinValue;
            utcCreationDate2 = utcCreationDate2 ?? DateTime.MaxValue;

            viewModel.Criteria.Add("UtcCreationDate1", utcCreationDate1.ToString());
            viewModel.Criteria.Add("UtcCreationDate2", utcCreationDate2.ToString());
            viewModel.Criteria.Add("FormStatus", formStatus);
            viewModel.Criteria.Add("PatientId", patientId);

            try
            {
                viewModel.SearchResults = FormProvider.Search(Helpers.GetAuthenticator(),
                    formStatus,
                    betweenOperador, utcCreationDate1, utcCreationDate2,
                    betweenOperador, utcCompletedDate1, utcCompletedDate2,
                    betweenOperador, utcClosedDate1, utcClosedDate2,
                    patientFirstName, patientLastName, FormLayoutActive, patientId);

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