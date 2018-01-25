using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.Clients
{
    public class HttpClientWrapperBase : IDisposable
    {
        protected readonly string baseUrl;
        private HttpClient httpClient;
        readonly CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();

        protected HttpClientWrapperBase()
        {
            baseUrl = ConfigurationManager.AppSettings["BaseUrl"] + "api/v1";
            baseUrl = baseUrl.Trim('/');
            httpClient = new HttpClient(customDelegatingHandler);
        }

        protected HttpClient Client()
        {
            if (httpClient == null)
                throw new ObjectDisposedException("HttpClient has been disposed");

            return httpClient;
        }

        protected async Task<T> ExecuteGet<T>(string apiPath)
        {
            var response = await Client().GetStringAsync(baseUrl + "/" + apiPath);
            return JsonConvert.DeserializeObject<T>(response);
        }

        protected async Task<string> ExecuteGet(string apiPath)
        {
            return await Client().GetStringAsync(baseUrl + "/" + apiPath);
        }

        protected async Task<List<T>> ExecuteGetAll<T>(string apiPath)
        {
            var collection = new List<T>();
            var nextLink = string.Empty;
            do
            {
                var response = string.IsNullOrWhiteSpace(nextLink) ? await Client().GetAsync(baseUrl + "/" + apiPath) : await Client().GetAsync(nextLink);
                nextLink = GetNextLink(response);
                collection.AddRange(JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync()));
            }
            while (!string.IsNullOrWhiteSpace(nextLink));

            return collection;
        }

        private string GetNextLink(HttpResponseMessage message)
        {
            if(message.Headers.TryGetValues("Link", out IEnumerable<string> values))
            {
                var links = values.First().Split(',');

                foreach(var relLink in links)
                {
                    var link = relLink.Split(';');
                    if (link[1].Contains("next"))
                    {
                        return link[0].Substring(1, link[0].Length - 2);
                    }
                }
            }
            
            return string.Empty;
        }

        protected async Task<string> ExecutePost(string apiPath, string json)
        {
            Client().DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var errMsg = $"Failed to call the API. HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}";
            throw new Exception(errMsg);
        }

        protected async Task<T> ExecutePost<T>(string apiPath, string json)
        {
            Client().DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = $"Failed to call the API. HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}";
            throw new Exception(errMsg);
        }

        protected async Task<T> ExecutePost<T>(string apiPath, IEnumerable<T> model)
        {
            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }
        protected async Task<T> ExecutePost<T>(string apiPath, IEnumerable<int> model)
        {
            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }

        protected async Task<T> ExecutePut<T>(string apiPath, T model)
        {
            var response = await Client().PutAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }

        protected async Task<bool> ExecuteDelete(string apiPath)
        {
            var response = await Client().DeleteAsync(baseUrl + "/" + apiPath);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString.Contains("true");
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }

        #region Dispose
        ~HttpClientWrapperBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (httpClient != null)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
        }
        #endregion
    }
}
