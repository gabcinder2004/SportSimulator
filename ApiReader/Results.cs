using System.Collections.Generic;
using System.Linq;

namespace ApiReader
{
    public class Results
    {
        public string Name { get; set; }
        public List<string> Headers { get; set; }
        public List<List<object>> RowSet { get; set; }

        public List<Data> Data { get; set; }

        public void Organize()
        {
            Data = new List<Data>();

            foreach (var rowset in RowSet)
            {
                var dataDict = new Dictionary<string, string>();

                for (var i = 0; i < Headers.Count; i++)
                {
                    if (rowset[i] == null)
                    {
                        rowset[i] = string.Empty;
                    }

                     dataDict.Add(Headers[i], rowset[i].ToString());   
                }

                Data.Add(new Data() { Mapping = dataDict });
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Data
    {
        public Dictionary<string, string> Mapping { get; set; }
    }
}