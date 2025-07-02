namespace API.Services.RadarrService
{
	public interface IRadarrService
	{
		Task<ServiceResponse<List<RadarrMovie>>> GetAll();
		Task<ServiceResponse<RadarrMovie?>> GetById(int id);
		Task<ServiceResponse<RadarrSystemStatus>> GetStatus();
		Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookup(string term);
		Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookupImdb(string imdbid);
		Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookupTmdb(string tmdbid);
		Task<ServiceResponse<List<RadarrMovie>>> GetWantedMissing();
		Task<ServiceResponse<NamingConfig>> GetNamingConfig();
		Task<ServiceResponse<NamingConfig>> GetNamingConfigById(int  id); //no need
	}
}
