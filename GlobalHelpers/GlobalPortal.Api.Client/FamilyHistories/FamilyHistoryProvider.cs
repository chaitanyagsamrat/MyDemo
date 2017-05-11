using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.FamilyHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.FamilyHistories
{
    public static class FamilyHistoryProvider
    {
        private const string ControllerName = "familyhistories";

        public static bool Save(IServerAuthentication restClientAuthenticator, FamilyHistoryModel model)
        {
            return ApiClientGenericObject<FamilyHistoryModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<FamilyHistoryModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
