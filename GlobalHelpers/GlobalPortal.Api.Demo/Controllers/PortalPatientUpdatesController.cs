using GlobalPortal.Api.Client.PortalPatients;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PortalPatients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PortalPatientUpdatesController : Controller
    {
        // Index
        public ActionResult Index()
        {
            var viewModel = new GenericModel<PortalPatientUpdateModel>();

            return View(viewModel);
        }

        // POST: PortalPatients/Add
        [HttpPost]
        public ActionResult Send(GenericModel<PortalPatientUpdateModel> viewModel)
        {
            try
            {
                var success = PortalPatientProvider.Update(Helpers.GetAuthenticator(), viewModel.Data);

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