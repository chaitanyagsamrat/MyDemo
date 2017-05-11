using GlobalPortal.Api.Client.Insurances;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Insurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class InsurancesController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new GenericModel<InsuranceModel>
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Send(GenericModel<InsuranceModel> viewModel)
        {
            try
            {
                var success = InsuranceProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);
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
            var viewModel = new GenericModel<InsuranceModel>();
            viewModel.Header = Resources.ResultsHeader;
            try
            {
                var success = InsuranceProvider.Delete(Helpers.GetAuthenticator(), id);
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