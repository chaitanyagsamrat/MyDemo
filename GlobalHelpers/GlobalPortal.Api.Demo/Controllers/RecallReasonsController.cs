using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.RecallReasons;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.RecallReasons;
using System.Linq;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class RecallReasonsController : Controller
    {
        // GET: Allergies/Create
        public ActionResult Index(string name = "")
        {
            var viewModel = new GenericModel<RecallReasonModel>();

            try
            {
                viewModel.SearchResults = RecallReasonProvider.Search(Helpers.GetAuthenticator(), name);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaID", string.Empty);
            viewModel.Criteria.Add("name", name);

            return View(viewModel);
        }

        // GET: Allergies/Edit/5
        public ActionResult Get(string criteriaID)
        {
            var viewModel = new GenericModel<RecallReasonModel>();

            try
            {
                var data = RecallReasonProvider.Get(Helpers.GetAuthenticator(), criteriaID);

                viewModel.Data = data;

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, criteriaID);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaID", criteriaID);
            viewModel.Criteria.Add("name", string.Empty);
            return View("Index", viewModel);
        }

        // POST: Allergies/Add
        [HttpPost]
        public ActionResult Send(GenericModel<RecallReasonModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = RecallReasonProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaID", string.Empty);
            viewModel.Criteria.Add("name", string.Empty);
            return View("Index", viewModel);
        }

        // POST: Allergies/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<RecallReasonModel>();
            viewModel.Header = Resources.ResultsHeader;

            try
            {
                var success = RecallReasonProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaID", id);
            viewModel.Criteria.Add("name", string.Empty);
            return View("Index", viewModel);
        }
    }
}