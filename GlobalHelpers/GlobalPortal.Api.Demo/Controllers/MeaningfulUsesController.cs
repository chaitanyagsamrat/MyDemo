using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GlobalPortal.Api.Client.MeaningfulUses;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.MeaningfulUses;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class MeaningfulUsesController : Controller
    {
        // GET: MeaningfulUses/Create
        public ActionResult Index()
        {
            var viewModel = new MeaningfulUseModel
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        // POST: MeaningfulUses/Send
        [HttpPost]
        public ActionResult Send(MeaningfulUseModel viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;
            viewModel.SearchResults = new List<MeaningfulUseCoreMeasureResultModel>();
            try
            {
                viewModel.SearchResults = MeaningfulUseProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}