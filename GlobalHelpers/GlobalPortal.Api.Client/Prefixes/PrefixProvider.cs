using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Prefixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Prefixes
{
   public static class PrefixProvider
    {
        private const string ControllerName = "prefixes";

        public static PrefixModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PrefixModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, PrefixModel model)
        {
            return ApiClientGenericObject<PrefixModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PrefixModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
