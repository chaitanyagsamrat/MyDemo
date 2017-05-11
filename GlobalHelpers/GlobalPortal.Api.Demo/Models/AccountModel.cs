using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalPortal.Api.Demo.Models
{
    public class AccountModel
    {
        public string Header { get; set; }
        public string ErrorMessage { get; set; }
        public string ResultMessage { get; set; }
        public string ListEmptyMessage { get; set; }
        public NewAccountModel Data { get; set; }
        public NewAccountResultModel Results { get; set; }
        public Dictionary<string, string> Criteria { get; set; }

        public AccountModel()
        {
            Data = new NewAccountModel();
            Criteria = new Dictionary<string, string>();
            Results = new NewAccountResultModel();
            Header = Resources.ResultsHeader;
            ErrorMessage = string.Empty;
            ResultMessage = string.Empty;
        }
    }
}