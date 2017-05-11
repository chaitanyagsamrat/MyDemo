using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.AppointmentCancelRequests;
using GlobalPortal.Api.Client.AppointmentRequests;
using GlobalPortal.Api.Client.PatientCommunications;
using GlobalPortal.Api.Client.CommunicationUpdatesAppointments;
using GlobalPortal.Api.Client.CommunicationUpdatesOrders;
using GlobalPortal.Api.Client.CommunicationUpdatesPatients;
using GlobalPortal.Api.Demo.Models;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class MarkAsReceivedController : Controller
    {
        // Index
        public ActionResult Index()
        {
            var viewModel = new MarkAsReceivedModel();

            return View(viewModel);
        }

        // POST: MarkAsReceiveds/Send
        [HttpPost]
        public ActionResult Send(MarkAsReceivedModel viewModel)
        {
            viewModel.ResultMessage = string.Empty;

            Guid markAsReceivedID;
            if (!Guid.TryParse(viewModel.MarkAsReceivedID, out markAsReceivedID))
            {
                viewModel.Success = false;
                viewModel.ResultMessage = "Please provide a valid ID.";
                return View("Index", viewModel);
            }

            Api.Models.MarkAsReceived.MarkAsReceivedModel result;
           
            try
            {

                switch (viewModel.ObjectType)
                {
                    case "Appointment cancel request":
                        result = AppointmentCancelRequestProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    case "Appointment request":
                        result = AppointmentRequestProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    case "Appointment update":
                        result = CommunicationUpdatesAppointmentsProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    case "Communication update":
                        result = PatientCommunicationProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    case "Patient update":
                        result = CommunicationUpdatesPatientsProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    case "Order update":
                        result = CommunicationUpdatesOrdersProvider.MarkAsReceived(Helpers.GetAuthenticator(), new Api.Models.MarkAsReceived.MarkAsReceivedModel { InternalID = markAsReceivedID });
                        viewModel.ResultMessage = result.ResultMessage;
                        viewModel.Success = result.Success;
                        break;
                    default:
                        viewModel.Success = false;
                        viewModel.ResultMessage = "Please select an object type.";
                        break;
                }
            }
            catch (Exception ex)
            {
                viewModel.ResultMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}