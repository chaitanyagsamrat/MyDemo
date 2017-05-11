using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.DosageForms;

namespace GlobalPortal.Api.Client.DosageForms
{
    public static class DosageFormProvider
    {
        private const string ControllerName = "dosageforms";

        public static bool Save(IServerAuthentication restClientAuthenticator, DosageFormModel model)
        {
            return ApiClientGenericObject<DosageFormModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<DosageFormModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
