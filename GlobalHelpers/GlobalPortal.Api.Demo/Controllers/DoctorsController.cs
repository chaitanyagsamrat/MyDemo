using GlobalPortal.Api.Client.Doctors;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class DoctorsController : Controller
    {
        // GET: Doctors/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<DoctorModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: Doctors/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<DoctorModel>();

            try
            {
                var data = DoctorProvider.Get(Helpers.GetAuthenticator(), id);

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

        // POST: Doctors/Send
        [HttpPost]
        public ActionResult Send(GenericModel<DoctorModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DoctorProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        
        // POST: Doctors/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<DoctorModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = DoctorProvider.Delete(Helpers.GetAuthenticator(), id);

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