using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.ExamFieldMappingDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.ExamFieldMappingDetails
{
    public static class ExamFieldMappingDetailProvider
    {
        private const string ControllerName = "examfieldmappingdetails";
        
        public static bool Save(IServerAuthentication restClientAuthenticator, ExamFieldMappingDetailModel model)
        {
            return ApiClientGenericObject<ExamFieldMappingDetailModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ExamFieldMappingDetailModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
