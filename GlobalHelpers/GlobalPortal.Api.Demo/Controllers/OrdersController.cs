using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Orders;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Orders;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index(string criteriaId = "")
        {
            var viewModel = new GenericModel<OrderModel>();

            try
            {
                var data = OrderProvider.Search(Helpers.GetAuthenticator(), null, null, criteriaId);

                viewModel.SearchResults = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, criteriaId);

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", criteriaId);

            return View(viewModel);
        }

        public ActionResult Get(string criteriaId)
        {
            var viewModel = new GenericModel<OrderModel>();

            try
            {
                var data = OrderProvider.Get(Helpers.GetAuthenticator(), criteriaId);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, criteriaId);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", criteriaId);

            return View("Index", viewModel);
        }

        // POST: Orders/Add
        [HttpPost]
        public ActionResult Send(GenericModel<OrderModel> viewModel)
        {
            try
            {
                var success = OrderProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", string.Empty);

            return View("Index", viewModel);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<OrderModel>();

            try
            {
                var success = OrderProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", id);

            return View("Index", viewModel);
        }
    }
}