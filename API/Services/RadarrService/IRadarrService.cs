using Shared.Entities.Radarr;

namespace API.Services.RadarrService
{
	public interface IRadarrService
	{
		Task<ServiceResponse<List<RadarrMovie>>> GetAll();
		Task<ServiceResponse<RadarrMovie?>> GetById(int id);
		Task<ServiceResponse<RadarrSystemStatus>> GetStatus();
		Task<ServiceResponse<List<RadarrMovie>>> MovieLookup(string term);
		Task<ServiceResponse<List<RadarrMovie>>> MovieLookupImdb(string imdbid);
		Task<ServiceResponse<List<RadarrMovie>>> MovieLookupTmdb(string tmdbid);
		Task<ServiceResponse<List<RadarrMovie>>> WantedMissing();
	}
}
