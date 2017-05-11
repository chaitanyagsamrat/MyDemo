using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.ServicesTypeDuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.ServiceTypeDurations
{
    public static class ServiceTypeDurationProvider
    {
        private const string ControllerName = "serviceTypeDurations";

        public static ServiceTypeDurationModel Get(IServerAuthentication restClientAuthenticator, Guid Id)
        {
            return ApiClientGenericObject<ServiceTypeDurationModel>.Get(restClientAuthenticator, ControllerName, Id.ToString(), "patientServiceTypeId");
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, ServiceTypeDurationModel model)
        {
            return ApiClientGenericObject<ServiceTypeDurationModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
