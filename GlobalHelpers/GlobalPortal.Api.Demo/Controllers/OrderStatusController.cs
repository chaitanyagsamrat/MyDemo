using System;
using System.Web.Mvc;
using GlobalPortal.Api.Client.OrderStatuses;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.OrderStatuses;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class OrderStatusController : Controller
    {
        public ActionResult Index(string name = "")
        {
            var viewModel = new GenericModel<OrderStatusModel>();

            try
            {
                var data = OrderStatusProvider.Search(Helpers.GetAuthenticator(),null,name);

                viewModel.SearchResults = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, name);

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("name", name);

            return View(viewModel);
        }

        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<OrderStatusModel>();

            try
            {
                var data = OrderStatusProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);
        }

        // POST: Orders/Add
        [HttpPost]
        public ActionResult Send(GenericModel<OrderStatusModel> viewModel)
        {
            try
            {
                var success = OrderStatusProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<OrderStatusModel>();

            try
            {
                var success = OrderStatusProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);
        }
    }
}