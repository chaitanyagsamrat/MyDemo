using GlobalPortal.Api.Client.Prefixes;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Prefixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PrefixesController : Controller
    {
        // GET: Prefixes/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<PrefixModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // POST: Prefixes/Send
        [HttpPost]
        public ActionResult Send(GenericModel<PrefixModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = PrefixProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
        
        // POST: Prefixes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<PrefixModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = PrefixProvider.Delete(Helpers.GetAuthenticator(), id);

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
