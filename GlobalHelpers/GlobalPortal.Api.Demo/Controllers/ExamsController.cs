using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Exams;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Exams;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ExamsController : Controller
    {
        // GET: Exams/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ExamModel>();

            return View(viewModel);
        }

        // GET: Exams/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<ExamModel>();

            try
            {
                var data = ExamProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Exams/Add
        [HttpPost]
        public ActionResult Send(GenericModel<ExamModel> viewModel)
        {
            try
            {
                var success = ExamProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.SuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Exams/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<ExamModel>();

            try
            {
                var success = ExamProvider.Delete(Helpers.GetAuthenticator(), id);

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