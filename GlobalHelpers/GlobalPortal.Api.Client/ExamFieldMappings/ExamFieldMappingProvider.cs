using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.ExamFieldMappings;
using GlobalPortal.Api.Models.PatientCommunications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.ExamFieldMappings
{
    public static class ExamFieldMappingProvider
    {
        private const string ControllerName = "examFieldMappings";

        public static ExamFieldMappingModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ExamFieldMappingModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, ExamFieldMappingModel model)
        {
            return ApiClientGenericObject<ExamFieldMappingModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ExamFieldMappingModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
