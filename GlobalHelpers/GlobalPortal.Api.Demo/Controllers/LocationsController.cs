using System;
using System.Linq;
using System.Web.Mvc;
using GlobalPortal.Api.Client.Locations;
using GlobalPortal.Api.Demo.Models;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Locations;

namespace GlobalPortal.Api.Demo.Controllers
{
    public class LocationsController : Controller
    {
        public ActionResult Index(string name = "")
        {
            var viewModel = new GenericModel<LocationModel>();

            try
            {
                viewModel.SearchResults = LocationProvider.Search(Helpers.GetAuthenticator(), name);

                viewModel.Header = Resources.ResultsHeader;

                viewModel.ErrorMessage = viewModel.SearchResults != null && viewModel.SearchResults.Rows.Count() > 0 ? string.Empty : Resources.ListEmptyMessage;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", string.Empty);
            viewModel.Criteria.Add("name", name);

            return View(viewModel);
        }

        public ActionResult Get(string criteriaID)
        {
            var viewModel = new GenericModel<LocationModel>();

            try
            {
                viewModel.Data = LocationProvider.Get(Helpers.GetAuthenticator(), criteriaID);

                viewModel.ResultMessage = viewModel.Data != null ? string.Empty : string.Format(Resources.DataNotFound, criteriaID);
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", criteriaID);
            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);
        }

        [HttpGet]
        public ActionResult Send()
        {
            GenericModel<LocationModel> viewModel = new GenericModel<LocationModel>();
            LocationModel locmodel = new LocationModel();
            locmodel.Name = "Hyderabad";
            locmodel.Active = true;
            locmodel.Notes = "sample string 3";
            locmodel.SundayClosed = true;
            locmodel.SundayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.SundayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.MondayClosed = true;
            locmodel.MondayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.MondayTo =  TimeSpan.Parse("18:00:00.1234567"); ;
            locmodel.TuesdayClosed = true;
            locmodel.TuesdayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.TuesdayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.WednesdayClosed = true;
            locmodel.WednesdayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.WednesdayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.ThursdayClosed = true;
            locmodel.ThursdayFrom =  TimeSpan.Parse("10:00:00.1234567"); 
            locmodel.ThursdayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.FridayClosed = true;
            locmodel.FridayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.FridayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.SaturdayClosed = true;
            locmodel.SaturdayFrom =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.SaturdayTo =  TimeSpan.Parse("18:00:00.1234567");
            locmodel.RequestFormLayoutAfterOnlineAppointment = true;
            locmodel.CommunicationSendingFromHour =  TimeSpan.Parse("10:00:00.1234567");
            locmodel.CommunicationSendingToHour = TimeSpan.Parse("18:00:00.1234567");
            locmodel.LinkedInUrl = "https://in.linkedin.com/";
            locmodel.FacebookUrl = "https://www.facebook.com/";
            locmodel.GooglePlusUrl = "https://plus.google.com/";
            locmodel.YahooUrl = "https://in.yahoo.com/";
            locmodel.TimeZoneId = "Pacific Standard Time";
            //locmodel.TimeZoneDisplayName = "HyderabadIndia";
            locmodel.Contact.Id = new Guid();
            locmodel.Contact.FirstName = "prabhakar";
            locmodel.Contact.MiddleName = "babu";
            locmodel.Contact.LastName = "changala";
            locmodel.Contact.Suffix = "mr";
            locmodel.Contact.Prefix = "sse";
            locmodel.Contact.FullName = "changala p";
            locmodel.Contact.CompanyName = "eli";
            locmodel.Contact.JobTitle = "sse";
            locmodel.ExternalId = "30";

            try
            {
                var success = LocationProvider.Save(Helpers.GetAuthenticator(), locmodel);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullySaved : Resources.SuccesfullySaved;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", string.Empty);
            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);

        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var viewModel = new GenericModel<LocationModel>();

            try
            {
                var success = LocationProvider.Delete(Helpers.GetAuthenticator(), id);

                viewModel.ResultMessage = !success ? Resources.UnsuccesfullyDeleted : Resources.SuccesfullyDeleted;
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = ex.GetBaseException().Message;
            }

            viewModel.Criteria.Add("criteriaId", id);
            viewModel.Criteria.Add("name", string.Empty);

            return View("Index", viewModel);
        }
    }
}