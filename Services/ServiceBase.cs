using System.Net;

namespace BlazorApp1.Services
{
    public class ServiceBase
    {
        private static readonly HttpClient Client;
        static ServiceBase()
        {
            Client = new HttpClient();
        }
        private HttpClient GetHttpClient()
        {
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            return Client;
        }
        private HttpRequestMessage GetRequestMessage(string uri, HttpMethod method, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, uri) { Content = content };
            return request;
        }
        public string CreateApiUrl(string serviceName)
        {
            return $"https://localhost:7242/api/{serviceName}";
        }
        protected T? GetJson<T>(string uri)
        {            
            var response = GetHttpClient().SendAsync(GetRequestMessage(uri, HttpMethod.Get)).GetAwaiter().GetResult();
            if (CheckResponse(response) && ValidateJsonContent(response.Content))
            {
                return response.Content.ReadFromJsonAsync<T>().Result;
            }

            return default;
        }
        protected TResult? PutJson<TValue, TResult>(string uri, TValue value)
        {           
            var response = GetHttpClient().SendAsync(GetRequestMessage(uri, HttpMethod.Put, JsonContent.Create(value)))
                .GetAwaiter().GetResult();
            if (CheckResponse(response) && ValidateJsonContent(response.Content))
            {
                var result = response.Content.ReadFromJsonAsync<TResult>().Result;
                return result;
            }

            return default;
        }
        protected TResult? PostJson<TValue, TResult>(string uri, TValue value)
        {            
            HttpRequestMessage request;
            if (value is MultipartFormDataContent data)
            {
                request = GetRequestMessage(uri, HttpMethod.Post, data);
            }
            else
            {
                request = GetRequestMessage(uri, HttpMethod.Post, JsonContent.Create(value));
            }



            var response = GetHttpClient().SendAsync(request)
                .GetAwaiter().GetResult();
            if (CheckResponse(response) && ValidateJsonContent(response.Content))
            {
                var result = response.Content.ReadFromJsonAsync<TResult>().Result;
                return result;
            }



            return default;
        }
        protected bool Delete(string uri)
        {
            var response = GetHttpClient().SendAsync(GetRequestMessage(uri, HttpMethod.Delete)).GetAwaiter()
                .GetResult();
            return CheckResponse(response);
        }

        private bool CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return true;
            return false;
        }

        private static bool ValidateJsonContent(HttpContent content)
        {
            var mediaType = content?.Headers.ContentType?.MediaType;
            return mediaType != null && mediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase);
        }

    }
}
