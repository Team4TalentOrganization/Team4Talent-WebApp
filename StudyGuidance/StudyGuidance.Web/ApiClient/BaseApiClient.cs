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

		protected async Task<T> GetJsonAsync<T>(string endpoint)
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
	}
}


