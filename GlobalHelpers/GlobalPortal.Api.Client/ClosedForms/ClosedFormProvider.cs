using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Models.Forms;
using GlobalPortal.Api.Client.GenericObject;

namespace GlobalPortal.Api.Client.ClosedForms
{
    public static class ClosedFormProvider
    {
        private const string ControllerName = "closedforms";

        public static ClosedFormModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ClosedFormModel>.Get(restClientAuthenticator, ControllerName, ID, "internalId");
        }
    }
}
