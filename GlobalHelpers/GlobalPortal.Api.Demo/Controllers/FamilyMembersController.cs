using GlobalPortal.Api.Client.FamilyMembers;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.FamilyMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class FamilyMembersController : Controller
    {
        // GET: FamilyMembers
        public ActionResult Index()
        {
            var viewModel = new GenericModel<FamilyMemberModel>();

            return View(viewModel);
        }

        // POST: FamilyMembers/Send

        [HttpPost]
        public ActionResult Send(GenericModel<FamilyMemberModel> viewModel)
        {
            try
            {
                var success = FamilyMemberProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: FamilyMembers/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<FamilyMemberModel>();

            try
            {
                var success = FamilyMemberProvider.Delete(Helpers.GetAuthenticator(), id);

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