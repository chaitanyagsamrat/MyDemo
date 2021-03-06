﻿using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.SocialHistoryDrugs;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.SocialHistoryDrugs;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class SocialHistoryDrugsController : Controller
    {
        // GET: Allergies/Create
        public ActionResult Index()
        {
            var viewModel = new GenericModel<SocialHistoryDrugModel>
            {
                Header = Resources.ResultsHeader
            };

            return View(viewModel);
        }

        // GET: Allergies/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<SocialHistoryDrugModel>();

            try
            {
                var data = SocialHistoryDrugProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Allergies/Add
        [HttpPost]
        public ActionResult Send(GenericModel<SocialHistoryDrugModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SocialHistoryDrugProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }


        // POST: Allergies/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<SocialHistoryDrugModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = SocialHistoryDrugProvider.Delete(Helpers.GetAuthenticator(), id);

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