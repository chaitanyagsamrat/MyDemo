using GlobalPortal.Api.Client.AccountSettings;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AccountSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AccountSettingsController : Controller
    {
        // GET: AccountSettings/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<AccountSettingsModel>
            {
                Header = Resources.ResultsHeader
            };

            try
            {
                viewModel.Data = AccountSettingProvider.Get(Helpers.GetAuthenticator());
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            return View(viewModel);
        }

        // POST: AccountSettings/Send
        [HttpPost]
        public ActionResult Send(GenericModel<AccountSettingsModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = AccountSettingProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}