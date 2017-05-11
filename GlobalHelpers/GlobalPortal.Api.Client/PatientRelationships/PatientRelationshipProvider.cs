using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.PatientRelationships;

namespace GlobalPortal.Api.Client.PatientRelationships
{
    public static class PatientRelationshipProvider
    {
        private const string ControllerName = "patientrelationships";

        public static PatientRelationshipModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PatientRelationshipModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, PatientRelationshipModel model)
        {
            return ApiClientGenericObject<PatientRelationshipModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PatientRelationshipModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
