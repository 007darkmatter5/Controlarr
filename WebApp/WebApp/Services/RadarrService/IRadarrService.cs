namespace WebApp.Services.RadarrService
{
	public interface IRadarrService
	{
		//event Action? OnChange;
		List<RadarrMovie> Movies { get; set; }
		List<RadarrMovie> LookupResults { get; set; }
		Task GetAll();
		Task<ServiceResponse<RadarrMovie>> GetById(int id);
		Task<ServiceResponse<List<RadarrMovie>>> GetMovieLookup(string term);
		Task<ServiceResponse<RadarrMovie>> GetMovieLookupImdb(string imdbid);
		Task<ServiceResponse<RadarrMovie>> GetMovieLookupTmdb(string tmdbid);
	}
}
