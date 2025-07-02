namespace API.Services.SonarrService
{
	public interface ISonarrService
	{
		Task<ServiceResponse<List<SonarrShow>>> GetAll();
		Task<ServiceResponse<SonarrShow?>> GetById(int id);
		Task<ServiceResponse<SonarrSystemStatus>> GetStatus();
		Task<ServiceResponse<List<SonarrShow>>> MovieLookup(string term);
		Task<ServiceResponse<List<SonarrShow>>> MovieLookupImdb(string imdbid);
		Task<ServiceResponse<List<SonarrShow>>> MovieLookupTmdb(string tmdbid);
		Task<ServiceResponse<List<SonarrShow>>> WantedMissing();
	}
}
