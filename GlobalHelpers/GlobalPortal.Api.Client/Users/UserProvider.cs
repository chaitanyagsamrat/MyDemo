using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.Users
{
    public static class UserProvider
    {
        private const string ControllerName = "users";

        public static ListModel<UserModel> Search(
            IServerAuthentication restClientAuthenticator,
            string username = "",
            bool? active = null,
            string firstName = "", 
            string lastName = "", 
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("username", username);
            criteria.Add("active", active.ToString());
            criteria.Add("firstName", firstName);
            criteria.Add("lastname", lastName);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<UserModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static UserModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<UserModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, UserModel model)
        {
            return ApiClientGenericObject<UserModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<UserModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
