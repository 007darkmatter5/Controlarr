using System.Text.Json;

namespace API.Services.RadarrService
{
	public class RadarrService : IRadarrService
	{
		private readonly HttpClient _httpClient;
		private readonly INodeService _nodeService;

		public RadarrService(HttpClient httpClient, INodeService nodeService)
		{
			var apiKey = "2005d28c25b540afbf87e022c95f52d6";
			var baseUrl = "https://movies.lv426.cloud";

			_httpClient = httpClient;
			_nodeService = nodeService;

			_httpClient.BaseAddress = new Uri(baseUrl);
			_httpClient.DefaultRequestHeaders.Clear();
			_httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetAll()
		{
			var response = new ServiceResponse<List<RadarrMovie>>();

			try
			{
				var httpResponse = await _httpClient.GetAsync("api/v3/movie");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch movies. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<List<RadarrMovie>>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new List<RadarrMovie>();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<RadarrMovie?>> GetById(int id)
		{
			var response = new ServiceResponse<RadarrMovie?>();

			try
			{
				var httpResponse = await _httpClient.GetAsync($"api/v3/movie/{id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch movie with ID {id}. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movie = JsonSerializer.Deserialize<RadarrMovie>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				if (movie == null)
				{
					response.Success = false;
					response.Message = "Movie not found or response was empty.";
					return response;
				}

				response.Data = movie;
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<RadarrSystemStatus>> GetStatus()
		{
			var response = new ServiceResponse<RadarrSystemStatus>();

			try
			{
				var httpResponse = await _httpClient.GetAsync("api/v3/system/status");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch status. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var status = JsonSerializer.Deserialize<RadarrSystemStatus>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = status ?? new RadarrSystemStatus();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookup(string term)
		{
			var response = new ServiceResponse<List<RadarrMovie>>();

			try
			{
				var httpResponse = await _httpClient.GetAsync($"api/v3/movie/lookup?term={term}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<List<RadarrMovie>>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new List<RadarrMovie>();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookupImdb(string imdbid)
		{
			var response = new ServiceResponse<List<RadarrMovie>>();

			try
			{
				var httpResponse = await _httpClient.GetAsync($"api/v3/movie/lookup/imdb?imdbid={imdbid}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<List<RadarrMovie>>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new List<RadarrMovie>();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookupTmdb(string tmdbid)
		{
			var response = new ServiceResponse<List<RadarrMovie>>();

			try
			{
				var httpResponse = await _httpClient.GetAsync($"api/v3/movie/lookup/tmdb?tmdbid={tmdbid}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<List<RadarrMovie>>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new List<RadarrMovie>();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<List<RadarrMovie>>> GetWantedMissing()
		{
			var response = new ServiceResponse<List<RadarrMovie>>();

			try
			{
				var httpResponse = await _httpClient.GetAsync("api/v3/wanted/missing");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<List<RadarrMovie>>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new List<RadarrMovie>();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<NamingConfig>> GetNamingConfig()
		{
			var response = new ServiceResponse<NamingConfig>();

			try
			{
				var httpResponse = await _httpClient.GetAsync("api/v3/config/naming");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<NamingConfig>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new NamingConfig();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		}

		public async Task<ServiceResponse<NamingConfig>> GetNamingConfigById(int id)
		{
			var response = new ServiceResponse<NamingConfig>();

			try
			{
				var httpResponse = await _httpClient.GetAsync($"api/v3/config/naming?id={id}");

				if (!httpResponse.IsSuccessStatusCode)
				{
					response.Success = false;
					response.Message = $"Failed to fetch results. Status: {httpResponse.StatusCode}";
					return response;
				}

				var json = await httpResponse.Content.ReadAsStringAsync();
				var movies = JsonSerializer.Deserialize<NamingConfig>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

				response.Data = movies ?? new NamingConfig();
			}
			catch (Exception ex)
			{
				response.Success = false;
				response.Message = $"Exception: {ex.Message}";
			}

			return response;
		} // no need
	}
}
