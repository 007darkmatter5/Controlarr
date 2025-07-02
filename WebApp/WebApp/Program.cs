using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

AddBlazorise(builder.Services);

builder.Services.AddHttpClient("LocalApi", client =>
{
	client.BaseAddress = new Uri("https://localhost:7234");
	client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<IRadarrService, RadarrService>();
builder.Services.AddScoped<ITmdbService, TmdbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


void AddBlazorise(IServiceCollection services)
{
    services
        .AddBlazorise();
    services
        .AddBootstrapProviders()
        .AddFontAwesomeIcons();
}
