using GlobalPortal.Api.Client.ExamFieldMappings;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.ExamFieldMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ExamFieldMappingsController : Controller
    {
        // GET: ExamFieldMappings/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ExamFieldMappingModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: ExamFieldMappings/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<ExamFieldMappingModel>();

            try
            {
                var data = ExamFieldMappingProvider.Get(Helpers.GetAuthenticator(), id);

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

        // POST: ExamFieldMappings/Send
        [HttpPost]
        public ActionResult Send(GenericModel<ExamFieldMappingModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = ExamFieldMappingProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }


        // POST: ExamFieldMappings/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<ExamFieldMappingModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = ExamFieldMappingProvider.Delete(Helpers.GetAuthenticator(), id);

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