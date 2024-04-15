using RenSharpTelegram;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration config = builder.Configuration;



services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.InjectDependencies(config);

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
