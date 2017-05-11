using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Medications
{
   public static class MedicationProvider
    {
        private const string ControllerName = "medications";

        public static bool Save(IServerAuthentication restClientAuthenticator, MedicationModel model)
        {
            return ApiClientGenericObject<MedicationModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<MedicationModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
