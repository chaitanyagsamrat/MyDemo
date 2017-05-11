using GlobalPortal.Api.Client.ServiceTypeDurations;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.ServicesTypeDuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ServiceTypeDurationsController : Controller
    {
        // GET: ServiceTypeDurations/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ServiceTypeDurationModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: ServiceTypeDurations/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<ServiceTypeDurationModel>();

            Guid patientServiceTypeId;
            if (!Guid.TryParse(id, out patientServiceTypeId))
            {
                viewModel.ResultMessage = string.Empty;
                viewModel.ErrorMessage = "Please provide a valid ID.";
                return View("Index", viewModel);
            }

            try
            {
                var data = ServiceTypeDurationProvider.Get(Helpers.GetAuthenticator(), patientServiceTypeId);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, patientServiceTypeId.ToString());
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: ServiceTypeDurations/Send
        [HttpPost]
        public ActionResult Send(GenericModel<ServiceTypeDurationModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = ServiceTypeDurationProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

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