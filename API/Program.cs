//using API.Factories.NodeClientFactory;

using API.Services.TmdbService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ITmdbService, TmdbService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<IRadarrService, RadarrService>();

//builder.Services.AddHttpClient();

//builder.Services.AddCors(options =>
//{
//	options.AddPolicy("AllowAll", builder =>
//		builder.AllowAnyOrigin()
//			   .AllowAnyMethod()
//			   .AllowAnyHeader());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseCors("AllowAll");

app.Run();
