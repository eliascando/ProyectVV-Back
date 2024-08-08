using MatriculasBack.Config;
using Infraestructure.Security.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// add jwt
builder.Services.AddJwtAuthentication(builder.Configuration);

// policies
builder.Services.AddJwtPolicies(builder.Configuration);

// add services
builder.Services.InjectDependencies(builder.Configuration);


// build app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
