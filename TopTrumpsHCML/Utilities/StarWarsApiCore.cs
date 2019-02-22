using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using TopTrumpsHCML.Entities;
using TopTrumpsHCML.Utilities;
using static TopTrumpsHCML.Utilities.Constants;

namespace TopTrumpsHCML.Utilities
{
    public class StarWarsApiCore : IDisposable
    {
        private HttpClient client;

        public StarWarsApiCore()
        {
            client = new HttpClient();
        }


        private string Request(string url)
        {
            client.BaseAddress = new Uri(StarWarsApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string allStarShips = string.Empty; 

            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                allStarShips = response.Content.ReadAsStringAsync().Result;
            }
            return allStarShips;
        }

        private SharpEntityResults<T> GetAllPaginated<T>(string entityName, string pageNumber = "1") where T : SharpEntity
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("page", pageNumber);

            SharpEntityResults<T> result = GetMultiple<T>(entityName, parameters);

            result.nextPageNo = String.IsNullOrEmpty(result.next) ? null : GetQueryParameters(result.next)["page"];
            result.previousPageNo = String.IsNullOrEmpty(result.previous) ? null : GetQueryParameters(result.previous)["page"];

            return result;
        }

        private NameValueCollection GetQueryParameters(string dataWithQuery)
        {
            NameValueCollection result = new NameValueCollection();
            string[] parts = dataWithQuery.Split('?');
            if (parts.Length > 0)
            {
                string QueryParameter = parts.Length > 1 ? parts[1] : parts[0];
                if (!string.IsNullOrEmpty(QueryParameter))
                {
                    string[] p = QueryParameter.Split('&');
                    foreach (string s in p)
                    {
                        if (s.IndexOf('=') > -1)
                        {
                            string[] temp = s.Split('=');
                            result.Add(temp[0], temp[1]);
                        }
                        else
                        {
                            result.Add(s, string.Empty);
                        }
                    }
                }
            }
            return result;
        }


        private SharpEntityResults<T> GetMultiple<T>(string endpoint, Dictionary<string, string> parameters) where T : SharpEntity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "?" + SerializeDictionary(parameters);
            }

            string json = Request(string.Format("{0}{1}", endpoint, serializedParameters));
            SharpEntityResults<T> swapiResponse = JsonConvert.DeserializeObject<SharpEntityResults<T>>(json);
            return swapiResponse;
        }


        private string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }


        #region Public API Requests 


        public SharpEntityResults<Starship> GetAllStarships(string pageNumber = "1")
        {
            SharpEntityResults<Starship> result = GetAllPaginated<Starship>(AllStarShips, pageNumber);
            return result;
        }


        // People
        //public People GetPeople(string id)
        //{
        //    return GetSingle<People>("/people/" + id);
        //}

        #endregion


        public void Dispose()
        {
            client.Dispose();
        }
    }
}
