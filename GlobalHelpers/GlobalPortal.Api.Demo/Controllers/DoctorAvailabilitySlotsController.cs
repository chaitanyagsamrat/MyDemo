using GlobalPortal.Api.Client.DoctorAvailabiltySlots;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.DoctorAvailabilitySlots;
using System;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class DoctorAvailabilitySlotsController : Controller
    {
        // GET: DoctorAvailabilitySlots/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<DoctorAvailabilitySlotModel>
            {
                Header = Resources.ResultsHeader
            };

            viewModel.Data.DoctorAvailabilityDates.Add(new DoctorAvailabilitySlotModel.DoctorAvailabilityDate());
            return View(viewModel);
        }

        // GET: DoctorAvailabilitySlots/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<DoctorAvailabilitySlotModel>();

            try
            {
                var data = DoctorAvailabiltySlotProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: DoctorAvailabilitySlots/Send
        [HttpPost]
        public ActionResult Send(GenericModel<DoctorAvailabilitySlotModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DoctorAvailabiltySlotProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: DoctorAvailabilitySlots/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<DoctorAvailabilitySlotModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DoctorAvailabiltySlotProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Data.DoctorAvailabilityDates.Add(new DoctorAvailabilitySlotModel.DoctorAvailabilityDate());
            return View("Index", viewModel);
        }
    }
}