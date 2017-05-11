using GlobalPortal.Api.Client.Referrals;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class ReferralsController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new GenericModel<ReferralModel>
            {
                Header = Resources.ResultsHeader
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Send(GenericModel<ReferralModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = ReferralProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<ReferralModel>();
            viewModel.Header = Resources.ResultsHeader;
            try
            {
                var success = ReferralProvider.Delete(Helpers.GetAuthenticator(), id);
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