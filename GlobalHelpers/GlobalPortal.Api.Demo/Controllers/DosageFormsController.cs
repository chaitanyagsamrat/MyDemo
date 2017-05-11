using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.DosageForms;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.DosageForms;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class DosageFormsController : Controller
    {
        // GET: DosageForms/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<DosageFormModel>();
            
            return View(viewModel);
        }

        // POST: DosageForms/Add
        [HttpPost]
        public ActionResult Send(GenericModel<DosageFormModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DosageFormProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: DosageForms/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<DosageFormModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DosageFormProvider.Delete(Helpers.GetAuthenticator(), id);

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