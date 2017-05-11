using System;
using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Orders;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Client.Orders
{
    public static class OrderProvider
    {
        private const string ControllerName = "orders";

        public static ListModel<OrderModel> Search(
            IServerAuthentication restClientAuthenticator,
            string patientID = null,
            string locationID = null,
            string ID = "",
            DateTime? utcCreationDate = null,
            DateTime? utcPickupDate = null,
            decimal? patientBalance = null,
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();
            criteria.Add("patientExternalId", patientID);
            criteria.Add("locationExternalId", locationID);
            criteria.Add("externalId", ID);
            criteria.Add("creationDate", utcCreationDate.ToString());
            criteria.Add("pickupDate", utcPickupDate.ToString());
            criteria.Add("patientBalance", patientBalance.ToString());
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<OrderModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static OrderModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<OrderModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, OrderModel model)
        {
            return ApiClientGenericObject<OrderModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<OrderModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
