using Shared.Entities.Radarr;

namespace API.Services.RadarrService
{
	public class RadarrService : IRadarrService
	{
		public Task<ServiceResponse<List<RadarrMovie>>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<RadarrMovie?>> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<RadarrSystemStatus>> GetStatus()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookup(string term)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookupImdb(string imdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> MovieLookupTmdb(string tmdbid)
		{
			throw new NotImplementedException();
		}

		public Task<ServiceResponse<List<RadarrMovie>>> WantedMissing()
		{
			throw new NotImplementedException();
		}
	}
}
