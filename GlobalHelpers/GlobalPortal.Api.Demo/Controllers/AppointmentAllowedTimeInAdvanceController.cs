using GlobalPortal.Api.Client.AppointmentsAllowedTimeInAdvance;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentAllowedTimeInAdvance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentAllowedTimeInAdvanceController : Controller
    {
        
        public ActionResult Index()
        {
            var viewModel = new GenericModel<AppointmentAllowedTimeInAdvanceModel>
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }
        
        [HttpPost]
        public ActionResult Send(GenericModel<AppointmentAllowedTimeInAdvanceModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = AppointmentAllowedTimeInAdvanceProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

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