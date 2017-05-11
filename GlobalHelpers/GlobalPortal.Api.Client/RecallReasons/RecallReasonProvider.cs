using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.RecallReasons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.RecallReasons
{
    public static class RecallReasonProvider
    {
        private const string ControllerName = "recallreasons";

        public static ListModel<RecallReasonModel> Search(
            IServerAuthentication restClientAuthenticator,
            string name = "",
            string ID = "",
            int page = 1,
            int itemsPerPage = 10
            )
        {
            var criteria = new SearchCriteria();

            criteria.Add("externalId", ID);
            criteria.Add("name", name);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<RecallReasonModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static RecallReasonModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<RecallReasonModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, RecallReasonModel model)
        {
            return ApiClientGenericObject<RecallReasonModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<RecallReasonModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
