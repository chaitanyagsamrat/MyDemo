using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.AppointmentAllowedTimeInAdvance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.AppointmentsAllowedTimeInAdvance
{
    public static class AppointmentAllowedTimeInAdvanceProvider
    {
        private const string ControllerName = "appointmentAllowedTimeInAdvance";

        public static bool Save(IServerAuthentication restClientAuthenticator, AppointmentAllowedTimeInAdvanceModel model)
        {
            return ApiClientGenericObject<AppointmentAllowedTimeInAdvanceModel>.Save(restClientAuthenticator, ControllerName, model);
        }
    }
}
