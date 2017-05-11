using GlobalPortal.Api.Client.SocialHistoryAlcohols;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.SocialHistoryAlcohols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class SocialHistoryAlcoholsController : Controller
    {
       // GET: SocialHistoryAlcohols/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<SocialHistoryAlcoholModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: SocialHistoryAlcohols/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<SocialHistoryAlcoholModel>();

            try
            {
                var data = SocialHistoryAlcoholProvider.Get(Helpers.GetAuthenticator(), id);

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

        // POST: SocialHistoryAlcohols/Send
        [HttpPost]
        public ActionResult Send(GenericModel<SocialHistoryAlcoholModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SocialHistoryAlcoholProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: SocialHistoryAlcohols/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<SocialHistoryAlcoholModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SocialHistoryAlcoholProvider.Delete(Helpers.GetAuthenticator(), id);

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