using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Insurances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Insurances
{
   public static class InsuranceProvider
    {
        private const string ControllerName = "insurances";

        public static bool Save(IServerAuthentication restClientAuthenticator, InsuranceModel model)
        {
            return ApiClientGenericObject<InsuranceModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<InsuranceModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
