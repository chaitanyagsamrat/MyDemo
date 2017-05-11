using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.PatientRelationships;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PatientRelationships;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PatientRelationshipsController : Controller
    {
        // GET: PatientRelationships/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<PatientRelationshipModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: PatientRelationships/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<PatientRelationshipModel>();

            try
            {
                var data = PatientRelationshipProvider.Get(Helpers.GetAuthenticator(), id);

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

        // POST: PatientRelationships/Send
        [HttpPost]
        public ActionResult Send(GenericModel<PatientRelationshipModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = PatientRelationshipProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: PatientRelationships/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<PatientRelationshipModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = PatientRelationshipProvider.Delete(Helpers.GetAuthenticator(), id);

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