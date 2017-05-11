using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Referrals
{
    public static class ReferralProvider
    {
        private const string ControllerName = "referrals";

        public static bool Save(IServerAuthentication restClientAuthenticator, ReferralModel model)
        {
            return ApiClientGenericObject<ReferralModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ReferralModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
