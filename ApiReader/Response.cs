using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiReader
{
    public class Response
    {
        public string Resource { get; set; }

        [JsonProperty("resultSets")]
        public List<Results> ResultSets { get; set; }

        public void OrganizeResults()
        {
            foreach (var resultSet in ResultSets)
            {
                resultSet.Organize();
            }
        }
    }
}