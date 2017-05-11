using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.OneOffMessages;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PatientCommunications;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class OneOffMessagesController : Controller
    {
        // GET: OneOffMessages/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<OneOffMessageModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // POST: OneOffMessages/Add
        [HttpPost]
        public ActionResult Send(GenericModel<OneOffMessageModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = OneOffMessageProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

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