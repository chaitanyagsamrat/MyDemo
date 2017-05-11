using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models.DoctorAvailabilitySlots;

namespace GlobalPortal.Api.Client.DoctorAvailabiltySlots
{
    public class DoctorAvailabiltySlotProvider
    {
        private const string ControllerName = "doctorAvailabiltySlots";

        public static DoctorAvailabilitySlotModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<DoctorAvailabilitySlotModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, DoctorAvailabilitySlotModel model)
        {
            return ApiClientGenericObject<DoctorAvailabilitySlotModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<DoctorAvailabilitySlotModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
