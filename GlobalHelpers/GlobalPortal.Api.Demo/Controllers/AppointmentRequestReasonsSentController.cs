using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.AppointmentRequestReasons;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Models.AppointmentRequestReasons;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentRequestReasonsSentController : Controller
    {
        // GET: AppointmentRequestReasonsSent
        public ActionResult Index()
        {
            var viewModel = new GenericModel<AppointmentRequestReasonReceivedModel>();
            return View(viewModel);
        }

        // POST: MarkAsReceiveds/Send
        [HttpPost]
        public ActionResult Send(GenericModel<AppointmentRequestReasonReceivedModel> viewModel)
        {
            try
            {
                if (viewModel.Data.InternalID == Guid.Empty)
                {
                    viewModel.Data.Success = false;
                    viewModel.Data.ResultMessage = "Please provide a valid ID.";
                    return View("Index", viewModel);
                }
                var response= AppointmentRequestReasonSentProvider.MarkAsReceived(Helpers.GetAuthenticator(), viewModel.Data);
                viewModel.Data.Success = response.Success;
                viewModel.Data.ResultMessage = !viewModel.Data.Success ? AppointmentRequestReasonsSentResources.MarkAsSentConcurrency : AppointmentRequestReasonsSentResources.MarkAsSentSuccess;
            }
            catch (Exception ex)
            {
                viewModel.Data.ResultMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}