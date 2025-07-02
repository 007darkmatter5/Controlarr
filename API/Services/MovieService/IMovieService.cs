namespace API.Services.MovieService
{
	public interface IMovieService
	{
		Task<Movie?> GetMovieByIdAsync(int movieId);
	}
}
