using AdminDashboard.API.Middleware;
using AdminDashboard.API.Extenssion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//configure app 
builder.Services.ConfigureDatabaseContext(configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureModelValidation();

//configure web host
builder.WebHost.ResolveServiceEndpoints(configuration);
builder.Services.ConfigureCors();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(configuration);
builder.Services.AddTransport(configuration);
builder.Services.ConfigureRemoteClient(configuration);

//configure api test utils
builder.Services.AddMvc();
builder.Services.AddOpenApi();
builder.Services.ConfigureSwaggerGen();

var app = builder.Build();

app.Services.TryMigrateDatabase(configuration);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<RequestBrokerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();