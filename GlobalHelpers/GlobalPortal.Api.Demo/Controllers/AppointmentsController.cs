using System;
using System.Linq;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Appointments;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentsModel;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentsController : Controller
    {
        // GET: Appointments/Create
        public ActionResult Index(string appointmentExternalId = "",
                                           DateTime? patientBirthday = null,
                                           string status = null,
                                           DateTime? start1 = null,
                                           DateTime? start2 = null,
                                           DateTime? portalCreated1 = null,
                                           DateTime? portalCreated2 = null)
        {
            var betweenOperador = "between";

            start1 = start1 ?? DateTime.MinValue;
            start2 = start2 ?? DateTime.MaxValue;

            portalCreated1 = portalCreated1 ?? DateTime.MinValue;
            portalCreated2 = portalCreated2 ?? DateTime.MaxValue;

            var viewModel = new GenericModel<AppointmentModel>();

            viewModel.Criteria.Add("Start1", start1.ToString());
            viewModel.Criteria.Add("Start2", start2.ToString());
            viewModel.Criteria.Add("PortalCreated1", portalCreated1.ToString());
            viewModel.Criteria.Add("PortalCreated2", portalCreated2.ToString());

            try
            {
                viewModel.SearchResults = AppointmentProvider.Search(Helpers.GetAuthenticator(), appointmentExternalId, patientBirthday, status, betweenOperador, start1, start2, betweenOperador, portalCreated1, portalCreated2);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // GET: Appointments/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<AppointmentModel>();
            viewModel.Criteria.Add("Start1", string.Empty);
            viewModel.Criteria.Add("Start2", string.Empty);
            viewModel.Criteria.Add("PortalCreated1", string.Empty);
            viewModel.Criteria.Add("PortalCreated2", string.Empty);
            try
            {
                var data = AppointmentProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Appointments/Send
        [HttpPost]
        public ActionResult Send(GenericModel<AppointmentModel> viewModel)
        {
            viewModel.Criteria.Add("Start1", string.Empty);
            viewModel.Criteria.Add("Start2", string.Empty);
            viewModel.Criteria.Add("PortalCreated1", string.Empty);
            viewModel.Criteria.Add("PortalCreated2", string.Empty);
            try
            {
                var response = AppointmentProvider.Save(Helpers.GetAuthenticator(), viewModel.Data) != null;

                viewModel.ResultMessage = !response ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Appointments/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<AppointmentModel>();
            viewModel.Criteria.Add("Start1", string.Empty);
            viewModel.Criteria.Add("Start2", string.Empty);
            viewModel.Criteria.Add("PortalCreated1", string.Empty);
            viewModel.Criteria.Add("PortalCreated2", string.Empty);
            try
            {
                var success = AppointmentProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            return View("Index", viewModel);
        }
    }
}
