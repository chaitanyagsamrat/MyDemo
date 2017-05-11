using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.PatientCommunications;

namespace GlobalPortal.Api.Client.OneOffMessages
{
    public static class OneOffMessageProvider
    {
        private const string ControllerName = "oneOffMessages";

        public static bool Save(IServerAuthentication restClientAuthenticator, OneOffMessageModel model)
        {
            return ApiClientGenericObject<OneOffMessageModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
