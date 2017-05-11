using GlobalPortal.Api.Client.PortalPatients;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.PortalPatients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PortalPatientsController : Controller
    {
        // GET: PortalPatients
        public ActionResult Index(
           string firstName="",
           string lastName="",
           int page = 1,
           int itemsPerPage = 10)
        {
            var viewModel = new GenericModel<PortalPatientModel>();

            viewModel.Criteria.Add("FirstName", firstName);
            viewModel.Criteria.Add("LastName", lastName);
            viewModel.Criteria.Add("CriteriaID", "");

            try
            {
                viewModel.SearchResults = PortalPatientProvider.Search(Helpers.GetAuthenticator(),firstName,lastName);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ListEmptyMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }

        // GET: PortalPatients/Edit/5
        public ActionResult Get(string id)
        {
            var viewModel = new GenericModel<PortalPatientModel>();

            viewModel.Criteria.Add("FirstName", "");
            viewModel.Criteria.Add("LastName", "");
            viewModel.Criteria.Add("CriteriaID", id);

            try
            {
                var data = PortalPatientProvider.Get(Helpers.GetAuthenticator(), id);

                viewModel.Data = data;

                viewModel.ResultMessage = data != null ? string.Empty : string.Format(Resources.DataNotFound, id);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }
            return View("Index", viewModel);
        }
    }
}