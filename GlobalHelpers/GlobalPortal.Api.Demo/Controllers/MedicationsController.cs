using GlobalPortal.Api.Client.Medications;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class MedicationsController : Controller
    {
        // GET: Medications
        public ActionResult Index()
        {
            var viewModel = new GenericModel<MedicationModel>();

            return View(viewModel);
        }

        // POST: Medications/Send
        [HttpPost]
        public ActionResult Send(GenericModel<MedicationModel> viewModel)
        {
            try
            {
                var success = MedicationProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Medications/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<MedicationModel>();

            try
            {
                var success = MedicationProvider.Delete(Helpers.GetAuthenticator(), id);

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