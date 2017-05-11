using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.HealthReviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.HealthReviews
{
    public static class HealthReviewProvider
    {
        private const string ControllerName = "healthReviews";

        public static HealthReviewModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<HealthReviewModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, HealthReviewModel model)
        {
            return ApiClientGenericObject<HealthReviewModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<HealthReviewModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
