using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Doctors
{
    public static class DoctorProvider
    {
        private const string ControllerName = "doctors";

        public static DoctorModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<DoctorModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, DoctorModel model)
        {
            return ApiClientGenericObject<DoctorModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<DoctorModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
