using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.SocialHistoryAlcohols;

namespace GlobalPortal.Api.Client.SocialHistoryAlcohols
{
    public static class SocialHistoryAlcoholProvider
    {
        private const string ControllerName = "socialhistoryalcohols";

        public static SocialHistoryAlcoholModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SocialHistoryAlcoholModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, SocialHistoryAlcoholModel model)
        {
            return ApiClientGenericObject<SocialHistoryAlcoholModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<SocialHistoryAlcoholModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
