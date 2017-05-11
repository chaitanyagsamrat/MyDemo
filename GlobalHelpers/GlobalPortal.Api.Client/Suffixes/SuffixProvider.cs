using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Suffixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Suffixes
{
   public static class SuffixProvider
    {
        private const string ControllerName = "suffixes";

        public static bool Save(IServerAuthentication restClientAuthenticator, SuffixModel model)
        {
            return ApiClientGenericObject<SuffixModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SuffixModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
