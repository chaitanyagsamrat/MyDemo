using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Allergies;

namespace GlobalPortal.Api.Client.Allergies
{
    public static class AllergyProvider
    {
        private const string ControllerName = "allergies";

        public static AllergyModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<AllergyModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, AllergyModel model)
        {
            return ApiClientGenericObject<AllergyModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<AllergyModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}