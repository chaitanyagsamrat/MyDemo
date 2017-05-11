using GlobalPortal.Api.Client.FamilyHistories;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class FamilyHistoriesController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new GenericModel<FamilyHistoryModel>
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Send(GenericModel<FamilyHistoryModel> viewModel)
        {
            try
            {
                var success = FamilyHistoryProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);
                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<FamilyHistoryModel>();
            viewModel.Header = Resources.ResultsHeader;
            try
            {
                var success = FamilyHistoryProvider.Delete(Helpers.GetAuthenticator(), id);
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