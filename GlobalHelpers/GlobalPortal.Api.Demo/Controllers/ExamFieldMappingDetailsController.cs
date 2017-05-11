using GlobalPortal.Api.Client.ExamFieldMappingDetails;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.ExamFieldMappingDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ExamFieldMappingDetailsController : Controller
    {
        // GET: ExamFieldMappingDetails/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ExamFieldMappingDetailModel>();

            return View(viewModel);
        }

        // POST: ExamFieldMappingDetails/Send
        [HttpPost]
        public ActionResult Send(GenericModel<ExamFieldMappingDetailModel> viewModel)
        {
            try
            {
                var success = ExamFieldMappingDetailProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: ExamFieldMappingDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<ExamFieldMappingDetailModel>();

            try
            {
                var success = ExamFieldMappingDetailProvider.Delete(Helpers.GetAuthenticator(), id);

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