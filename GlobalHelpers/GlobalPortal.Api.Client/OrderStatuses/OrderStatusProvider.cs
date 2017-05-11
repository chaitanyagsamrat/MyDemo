using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.OrderStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.OrderStatuses
{
    public static class OrderStatusProvider
    {
        private const string ControllerName = "orderStatuses";

        public static ListModel<OrderStatusModel> Search(
            IServerAuthentication restClientAuthenticator,
            string ID = "",
            string name = "",
            int page = 1,
            int itemsPerPage = 10
           )
        {
            var criteria = new SearchCriteria();
            criteria.Add("name", name);
            criteria.Add("externalId", ID);
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<OrderStatusModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static OrderStatusModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<OrderStatusModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, OrderStatusModel model)
        {
            return ApiClientGenericObject<OrderStatusModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<OrderStatusModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
