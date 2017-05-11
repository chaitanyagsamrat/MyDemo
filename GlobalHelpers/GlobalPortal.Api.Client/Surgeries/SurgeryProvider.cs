using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Surgeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Surgeries
{
    public static class SurgeryProvider
    {
        private const string ControllerName = "surgeries";

        public static SurgeryModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SurgeryModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, SurgeryModel model)
        {
            return ApiClientGenericObject<SurgeryModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SurgeryModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
