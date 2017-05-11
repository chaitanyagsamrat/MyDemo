using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.PortalPatients;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.PortalPatients
{
    public static class PortalPatientProvider
    {
        private const string ControllerName = "portalpatients";
        private const string PortalPatientUpdateControllerName = "portalpatientupdate";
        public static ListModel<PortalPatientModel> Search(
            IServerAuthentication restClientAuthenticator,
            string firstName = "",
            string lastName = "",
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();
            criteria.Add("firstName", firstName);
            criteria.Add("lastName", lastName);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<PortalPatientModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static PortalPatientModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PortalPatientModel>.Get(restClientAuthenticator, ControllerName, ID, "id");
        }

        public static bool Update(IServerAuthentication restClientAuthenticator, PortalPatientUpdateModel model)
        {
            return ApiClientGenericObject<PortalPatientUpdateModel>.Save(restClientAuthenticator, PortalPatientUpdateControllerName, model);
        }
    }
}
