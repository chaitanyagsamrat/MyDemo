using GlobalPortal.Api.Client.AppointmentCancelRequests;
using GlobalPortal.Api.Client.AppointmentRequests;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentRequestResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ApplyRequestResultsController : Controller
    {
        // GET: ApplyRequestResults
        public ActionResult Index()
        {
            var viewModel = new AppointmentRequestResultModel();

            return View(viewModel);
        }

        // POST: MarkAsReceiveds/Send
        [HttpPost]
        public ActionResult Send(AppointmentRequestResultModel viewModel)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(viewModel.InternalIDString))
                {
                    viewModel.InternalID = new Guid(viewModel.InternalIDString);
                }
                else {
                    viewModel.ErrorMessage = "Please provide a valid ID.";
                    return View("Index", viewModel);
                }

                switch (viewModel.ObjectType)
                {
                    case "Appointment cancel request":
                        var success1 = AppointmentCancelRequestProvider.ApplyResult(Helpers.GetAuthenticator(), viewModel);
                        viewModel.ResultMessage = !success1 ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
                        break;
                    case "Appointment request":
                        var success2 = AppointmentRequestProvider.ApplyResult(Helpers.GetAuthenticator(), viewModel);
                        viewModel.ResultMessage = !success2 ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
                        break;
                   default:
                        viewModel.ErrorMessage = "Please select an object type.";
                        break;
                }
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}