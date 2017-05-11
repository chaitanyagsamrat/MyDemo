using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.SocialHistoryDrugs;

namespace GlobalPortal.Api.Client.SocialHistoryDrugs
{
    public static class SocialHistoryDrugProvider
    {
        private const string ControllerName = "socialhistorydrugs";

        public static SocialHistoryDrugModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SocialHistoryDrugModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, SocialHistoryDrugModel model)
        {
            return ApiClientGenericObject<SocialHistoryDrugModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SocialHistoryDrugModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
