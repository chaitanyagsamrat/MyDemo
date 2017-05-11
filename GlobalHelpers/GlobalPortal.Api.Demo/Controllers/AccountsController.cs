using GlobalPortal.Api.Client.Accounts;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts/Create
        public ActionResult Index()
        {
            var viewModel = new AccountModel
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        // POST: Accounts/Send
        [HttpPost]
        public ActionResult Send(AccountModel viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;
            try
            {
                var webApiAddress = ConfigurationManager.AppSettings["WebApiAddress"];

                viewModel.Results = AccountProvider.Save(webApiAddress, viewModel.Data);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}