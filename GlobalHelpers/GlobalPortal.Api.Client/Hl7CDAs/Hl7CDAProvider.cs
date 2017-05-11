using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Hl7CDAs;

namespace GlobalPortal.Api.Client.Hl7CDAs
{
    public static class Hl7CDAProvider
    {
        private const string ControllerName = "Hl7CDAs";

        public static bool Save(IServerAuthentication restClientAuthenticator, Hl7CDAModel model)
        {
            return ApiClientGenericObject<Hl7CDAModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
