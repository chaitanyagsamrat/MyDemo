using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.FamilyMembers;

namespace GlobalPortal.Api.Client.FamilyMembers
{
    public static class FamilyMemberProvider
    {
        private const string ControllerName = "familymembers";

        public static bool Save(IServerAuthentication restClientAuthenticator, FamilyMemberModel model)
        {
            return ApiClientGenericObject<FamilyMemberModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<FamilyMemberModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
