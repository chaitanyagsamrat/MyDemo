using GlobalPortal.Api.Client.Patients;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Contacts;
using GlobalPortal.Api.Models.Locations;
using GlobalPortal.Api.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class PatientsController : Controller
    {
        public ActionResult Index(string fullName = "", DateTime? birthday = null, bool? active = null)
        {
            var viewModel = new GenericModel<PatientModel>();

            try
            {
                viewModel.SearchResults = PatientProvider.Search(Helpers.GetAuthenticator(), fullName, birthday, active);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("FullName", fullName);
            viewModel.Criteria.Add("Birthday", birthday.ToString());
            viewModel.Criteria.Add("Active", active.ToString());

            return View(viewModel);
        }

        public ActionResult Get(string criteriaID)
        {
            var viewModel = new GenericModel<PatientModel>();

            try
            {
                viewModel.Data = PatientProvider.Get(Helpers.GetAuthenticator(), criteriaID);

                viewModel.ResultMessage = viewModel.Data != null ? string.Empty : string.Format(Resources.DataNotFound, criteriaID);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("FullName", string.Empty);
            viewModel.Criteria.Add("Birthday", string.Empty);
            viewModel.Criteria.Add("Active", string.Empty);

            return View("Index", viewModel);
        }
        [HttpGet]
        public ActionResult Send()
        {
            PatientModel viewModel = new PatientModel();
            viewModel.Username = "changalap";
            viewModel.Password = "medflow#1";
            viewModel.Birthday = Convert.ToDateTime("2017-04-07");
            viewModel.Active = true;
            viewModel.InvitedToPortal = true;
            viewModel.LanguageName = "English";
            var _lstString = new List<string>();
            var _lstMainLocations = new List<LocationModel>();
            var _locations = new LocationModel();
            for (int i = 30; i < 31; i++)
            {
                _locations.ExternalId = i.ToString();
                _lstMainLocations.Add(_locations);
            }
            foreach (var _locitem in _lstMainLocations)
            {
                _lstString.Add(_locations.ExternalId);
            }
            viewModel.Locations = _lstString;
            viewModel.Contact = new ContactModel();
            viewModel.Contact.Id = Guid.NewGuid();
            viewModel.Contact.FirstName = "changala";
            viewModel.Contact.MiddleName = "e";
            viewModel.Contact.LastName = "Prabhakar";
            viewModel.Contact.Suffix = "suf";
            viewModel.Contact.Prefix = "pre";
            viewModel.Contact.FullName = "changala prabhakar";
            viewModel.Contact.CompanyName = "sample string 8";
            viewModel.Contact.JobTitle = "se";
            viewModel.Contact.Notes = "intellegent";
            viewModel.Contact.EmailAddresses = new List<EmailAddressModel>();
            var _emaillist = new EmailAddressModel();
            _emaillist.Id = Guid.NewGuid();
            _emaillist.Address = "changalap@eliindia.com";
            _emaillist.Default = true;
            viewModel.Contact.EmailAddresses.Add(_emaillist);

            viewModel.Last4SSN = "1234";
            viewModel.ExternalId = "49";
            try
            {
                var success = PatientProvider.Save(Helpers.GetAuthenticator(), viewModel);

                //viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                //viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            //viewModel.Criteria.Add("FullName", string.Empty);
            //viewModel.Criteria.Add("Birthday", string.Empty);
            //viewModel.Criteria.Add("Active", string.Empty);

            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<PatientModel>();

            try
            {
                var success = PatientProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("FullName", string.Empty);
            viewModel.Criteria.Add("Birthday", string.Empty);
            viewModel.Criteria.Add("Active", string.Empty);

            return View("Index", viewModel);
        }
    }
}