using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Forms;

namespace GlobalPortal.Api.Client.OpenForms
{
    public static class OpenFormProvider
    {
        private const string ControllerName = "openforms";

        public static OpenFormModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<OpenFormModel>.Get(restClientAuthenticator, ControllerName, ID, "internalId");
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, FormToBeClosedModel model)
        {
            return ApiClientGenericObject<FormToBeClosedModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
