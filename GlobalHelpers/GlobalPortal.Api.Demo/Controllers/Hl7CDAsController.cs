using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Hl7CDAs;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Hl7CDAs;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class Hl7CDAsController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new GenericModel<Hl7CDAModel>
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Send(GenericModel<Hl7CDAModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = Hl7CDAProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

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