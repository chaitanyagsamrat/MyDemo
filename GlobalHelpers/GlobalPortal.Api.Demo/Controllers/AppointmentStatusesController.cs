using GlobalPortal.Api.Client.AppointmentStatuses;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.AppointmentStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class AppointmentStatusesController : Controller
    {
        // GET: AppointmentStatuses/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<AppointmentStatusModel>();

            return View(viewModel);
        }

        // POST: AppointmentStatuses/Send
        [HttpPost]
        public ActionResult Send(GenericModel<AppointmentStatusModel> viewModel)
        {
            try
            {
                var success = AppointmentStatusProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: AppointmentStatuses/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<AppointmentStatusModel>();

            try
            {
                var success = AppointmentStatusProvider.Delete(Helpers.GetAuthenticator(), id);

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
