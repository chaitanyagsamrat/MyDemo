using System.Collections.Generic;
using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models;

namespace GlobalPortal.Api.Demo.Models
{
    public class GenericModel<T> where T : class, new()
    {
        public string Header { get; set; }
        public string ErrorMessage { get; set; }
        public string ResultMessage { get; set; }
        public string ListEmptyMessage { get; set; }
        public T Data { get; set; }
        public ListModel<T> SearchResults { get; set; }
        public Dictionary<string, string> Criteria { get; set; }

        public GenericModel()
        {
            Data = new T();
            Criteria = new Dictionary<string, string>();
            SearchResults = new ListModel<T>();
            Header = Resources.ResultsHeader;
            ErrorMessage = string.Empty;
            ResultMessage = string.Empty;
        }
    }
}