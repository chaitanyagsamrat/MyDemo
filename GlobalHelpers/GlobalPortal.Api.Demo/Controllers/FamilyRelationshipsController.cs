using GlobalPortal.Api.Client.FamilyRelationships;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.FamilyRelationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class FamilyRelationshipsController : Controller
    {
        // GET: FamilyRelationships/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<FamilyRelationshipModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // POST: FamilyRelationships/Add
        [HttpPost]
        public ActionResult Send(GenericModel<FamilyRelationshipModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = FamilyRelationshipProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
       
        // POST: FamilyRelationships/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<FamilyRelationshipModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = FamilyRelationshipProvider.Delete(Helpers.GetAuthenticator(), id);

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