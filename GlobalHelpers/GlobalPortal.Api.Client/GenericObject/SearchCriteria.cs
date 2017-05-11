using System.Collections.Generic;

namespace GlobalPortal.Api.Client.GenericObject
{
    public class SearchCriteria : IUrlParameters
    {
        private List<KeyValuePair<string, string>> criteria { get; set; }

        public void Add(string parameterName, string parameterValue)
        {
            criteria.Add(new KeyValuePair<string, string>(parameterName, parameterValue));
        }

        public string GetAsUrlParameters()
        {
            string UrlParameters = string.Empty;

            foreach (var item in criteria)
            {
                var parameter = string.Format("{0}{1}{2}", item.Key, "=", item.Value);

                if (UrlParameters.Length > 0)
                    UrlParameters = string.Format("{0}{1}{2}", UrlParameters, "&", parameter);
                else
                    UrlParameters = string.Format("{0}{1}{2}", UrlParameters, string.Empty, parameter);
            }

            return UrlParameters;
        }

        public override string ToString()
        {
            return GetAsUrlParameters();
        }

        public SearchCriteria()
        {
            criteria = new List<KeyValuePair<string, string>>();
        }
    }
}
