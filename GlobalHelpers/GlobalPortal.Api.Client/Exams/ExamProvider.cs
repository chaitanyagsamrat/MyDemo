using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Exams;

namespace GlobalPortal.Api.Client.Exams
{
   public static class ExamProvider
    {
        private const string ControllerName = "exams";

        public static ExamModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ExamModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, ExamModel model)
        {
            return ApiClientGenericObject<ExamModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<ExamModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
