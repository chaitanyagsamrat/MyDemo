using GlobalPortal.Api.Client.ClientAuthentication;
using GlobalPortal.Api.Client.GenericObject;
using GlobalPortal.Api.Models;
using GlobalPortal.Api.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalPortal.Api.Client.Patients
{
    public static class PatientProvider
    {
        private const string ControllerName = "patients";

        public static ListModel<PatientModel> Search(
            IServerAuthentication restClientAuthenticator,
           
            string fullName = "",
            DateTime? birthday = null,
           
            bool? active = null,
            int page = 1,
            int itemsPerPage = 10)
        {
            var criteria = new SearchCriteria();
            
            criteria.Add("FullName", fullName);
            criteria.Add("Birthday", birthday.ToString());
            criteria.Add("Active", active.ToString());
            criteria.Add("page", page.ToString());
            criteria.Add("itemsPerPage", itemsPerPage.ToString());

            return ApiClientGenericObject<PatientModel>.Search(restClientAuthenticator, ControllerName, criteria);
        }

        public static PatientModel Get(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PatientModel>.Get(restClientAuthenticator, ControllerName, ID);
        }

        public static bool Save(IServerAuthentication restClientAuthenticator, PatientModel model)
        {
            return ApiClientGenericObject<PatientModel>.Save(restClientAuthenticator, ControllerName, model);
        }

        public static bool Delete(IServerAuthentication restClientAuthenticator, string ID)
        {
            return ApiClientGenericObject<PatientModel>.Delete(restClientAuthenticator, ControllerName, ID);
        }
    }
}
