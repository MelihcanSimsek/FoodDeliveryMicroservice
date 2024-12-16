using Menu.Application;
using Menu.Application.Exceptions;
using Menu.Persistence;
using Menu.Infrastructure;
using Menu.Api.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddApplicationRegistration();
builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddInfrastructureRegistration(builder.Configuration);

builder.Services.AddAuthenticationRegistration(builder.Configuration);
builder.Services.AddConsulRegistration(builder.Configuration);
builder.Services.AddSwaggerRegistration();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureCustomExceptionMiddleware();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
