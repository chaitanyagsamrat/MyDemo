using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.Locations;

namespace GlobalPortal.Api.Client.Locations
{
    public static class LocationProvider
    {
        private const string ControllerName = "locations";

        public static ListModel<LocationModel> Search(
            IServerAuthentication restClientAuthenticator,
            string name = "",
            string ID = "",
            bool? active = null,
            string city = "",
            string state = "",
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("name", name);
            criteria.Add("externalId", ID);
            criteria.Add("active", active.ToString());
            criteria.Add("city", city);
            criteria.Add("state", state);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<LocationModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static LocationModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<LocationModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, LocationModel model)
        {
            return ApiClientGenericObject<LocationModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<LocationModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
