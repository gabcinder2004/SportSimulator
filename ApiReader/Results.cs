using System.Collections.Generic;
using System.Linq;

namespace ApiReader
{
    public class Results
    {
        public string Name { get; set; }
        public List<string> Headers { get; set; }
        public List<List<object>> RowSet { get; set; }

        public Dictionary<string, object> Data { get; set; }

        public void Organize()
        {
            Data = new Dictionary<string, object>();

            for (var i = 0; i < Headers.Count; i++)
            {
                Data.Add(Headers[i], RowSet.First()[i]);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}