using GlobalPortal.Api.Client.SynchronizationUsers;
using GlobalPortal.Api.Client.Users;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Doctors;
using GlobalPortal.Api.Models.SynchronizationUsers;
using GlobalPortal.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users/Create
        public ActionResult Index(bool? active = null, string username = "", string firstName = "", string lastName = "")
        {
            var viewModel = new GenericModel<UserModel>();
            viewModel.Criteria.Add("Active", active.ToString());
            viewModel.Criteria.Add("Username", username);
            viewModel.Criteria.Add("FirstName", firstName);
            viewModel.Criteria.Add("LastName", lastName);
           
            try
            {
                viewModel.SearchResults = UserProvider.Search(Helpers.GetAuthenticator(), username, active, firstName, lastName);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Users/Get/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<UserModel>();
            viewModel.Header = Resources.ResultsHeader;

            viewModel.Criteria.Add("Active", "");
            viewModel.Criteria.Add("Username", "");
            viewModel.Criteria.Add("FirstName", "");
            viewModel.Criteria.Add("LastName", "");

            try
            {
                var data = UserProvider.Get(Helpers.GetAuthenticator(), id);

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

        // POST: Users/Send
        [HttpPost]
        public ActionResult Send(GenericModel<UserModel> viewModel)
        {
            viewModel.Header = Resources.ResultsHeader;

            viewModel.Criteria.Add("Active", "");
            viewModel.Criteria.Add("Username", "");
            viewModel.Criteria.Add("FirstName", "");
            viewModel.Criteria.Add("LastName", "");

            try
            {
                var success = UserProvider.Save(Helpers.GetAuthenticator(), viewModel.Data);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // POST: Users/Temporary
        [HttpPost]
        public JsonResult SendTest()
        {
            //We need to test this through PostMan,  call GlobalPortal.Api.Demo.Controllers ->UsersController-> SendTest. Write RequestUri= //localhost/GlobalPortal.Api.Demo/Users/SendTest
            var user = new SynchronizationUserModel();
            user.AccountId = new Guid("69194a71-64f6-4ed7-8640-6f44a31b0a61");

            try
            {
                var success = SynchronizationUserProvider.CreateUser(Helpers.GetAuthenticator(), user);
                return Json(success);
            }
            catch (Exception ex)
            {
                var error = ex.GetBaseException().Message;
                return Json(error);
            }
        }
        
        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<UserModel>();
            viewModel.Header = Resources.ResultsHeader;

            viewModel.Criteria.Add("Active", "");
            viewModel.Criteria.Add("Username", "");
            viewModel.Criteria.Add("FirstName", "");
            viewModel.Criteria.Add("LastName", "");

            try
            {
                var success = UserProvider.Delete(Helpers.GetAuthenticator(), id);

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