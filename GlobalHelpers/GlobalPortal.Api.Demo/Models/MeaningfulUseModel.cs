using GlobalPortal.Api.Demo.Properties;
using GlobalPortal.Api.Models.MeaningfulUses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalPortal.Api.Demo.Models
{
    public class MeaningfulUseModel
    {
        public string Header { get; set; }
        public string ErrorMessage { get; set; }
        public string ResultMessage { get; set; }
        public string ListEmptyMessage { get; set; }
        public MeaningfulUseCoreMeasureModel Data { get; set; }
        public List<MeaningfulUseCoreMeasureResultModel> SearchResults { get; set; }
        public Dictionary<string, string> Criteria { get; set; }

        public MeaningfulUseModel()
        {
            Data = new MeaningfulUseCoreMeasureModel();
            Criteria = new Dictionary<string, string>();
            SearchResults = new List<MeaningfulUseCoreMeasureResultModel>();
            Header = Resources.ResultsHeader;
            ErrorMessage = string.Empty;
            ResultMessage = string.Empty;
        }
    }
}