using GlobalPortal.Api.Client.Surgeries;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Surgeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class SurgeriesController : Controller
    {
        // GET: Surgeries/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<SurgeryModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: Surgeries/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<SurgeryModel>();

            try
            {
                var data = SurgeryProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Surgeries/Send
        [HttpPost]
        public ActionResult Send(GenericModel<SurgeryModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SurgeryProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Surgeries/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<SurgeryModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SurgeryProvider.Delete(Helpers.GetAuthenticator(), id);

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