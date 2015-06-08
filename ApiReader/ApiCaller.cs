using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ApiReader
{
    public class ApiCaller
    {
        public static T ExecuteCall<T>(string url, List<Parameter> parameters)
        {
            var client = new RestClient(url);

            var req = new RestRequest(Method.GET);
            req.AddHeader("content-type", "application/json");
            parameters.ForEach(param => req.AddQueryParameter(param.Name, param.Value));

            var response = client.Execute(req);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Status code not okay");
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static async Task<Response> ExecuteCallAsync(string url, List<Parameter> parameters) 
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            parameters.ForEach(param => request.AddQueryParameter(param.Name, param.Value));
            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
            var deserializedResponse = JsonConvert.DeserializeObject<Response>(response.Content);
            deserializedResponse.OrganizeResults();
            return deserializedResponse;
        }
    }
}