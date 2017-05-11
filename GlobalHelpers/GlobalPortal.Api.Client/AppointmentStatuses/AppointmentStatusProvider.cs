using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.AppointmentStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.AppointmentStatuses
{
    public static class AppointmentStatusProvider
    {
        private const string ControllerName = "appointmentStatuses";

        public static bool Save(IServerAuthentication restClientAuthenticator, AppointmentStatusModel model)
        {
            return ApiClientGenericObject<AppointmentStatusModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<AppointmentStatusModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
