using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.FamilyRelationships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.FamilyRelationships
{
   public static class FamilyRelationshipProvider
    {
        private const string ControllerName = "familyrelationships";
        
        public static bool Save(IServerAuthentication restClientAuthenticator, FamilyRelationshipModel model)
        {
            return ApiClientGenericObject<FamilyRelationshipModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<FamilyRelationshipModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
