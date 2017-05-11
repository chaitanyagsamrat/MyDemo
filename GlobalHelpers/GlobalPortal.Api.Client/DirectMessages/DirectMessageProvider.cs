using System;
using System.Collections.Generic;
using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.DirectMessages;

namespace GlobalPortal.Api.Client.DirectMessages
{
    public static class DirectMessageProvider
    {
        private const string ControllerName = "directmessages";

        public static List<DirectMessageModel> Search(IServerAuthentication restClientAuthenticator, int page = 1, int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();

            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<DirectMessageModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static DirectMessageModel Get(IServerAuthentication restClientAuthenticator, Guid id)
        {
            return ApiClientGenericObject<DirectMessageModel>.Get(restClientAuthenticator, ControllerName, id.ToString());
        }
    }
}
