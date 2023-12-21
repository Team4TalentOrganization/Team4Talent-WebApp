using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace StudyGuidance.Web.ApiClient
{
	public abstract class BaseApiClient
	{
		protected readonly HttpClient HttpClient;
		protected readonly ILogger<BaseApiClient> Logger;

		protected BaseApiClient(HttpClient httpClient, ILogger<BaseApiClient> logger)
		{
			HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<T> GetJsonAsync<T>(string endpoint)
		{
			try
			{
				return await HttpClient.GetFromJsonAsync<T>(endpoint);
			}
			catch (Exception ex)
			{
				Logger.LogError(ex, $"An error occurred while making a GET request to {endpoint}.");
			}

			return default;
		}

        protected async Task<T> PostJsonAsync<T>(string endpoint, object data)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"An error occurred while making a POST request to {endpoint}.");
            }

            return default;
        }

        protected async Task<T> PutJsonAsync<T>(string endpoint, object data)
        {
            try
            {
                var response = await HttpClient.PutAsJsonAsync(endpoint, data);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"An error occurred while making a PUT request to {endpoint}.");
            }

            return default;
        }

        protected async Task<bool> DeleteJsonAsync(string endpoint)
        {
            try
            {
                var response = await HttpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"An error occurred while making a DELETE request to {endpoint}.");
                return false;
            }
        }
    }
}


