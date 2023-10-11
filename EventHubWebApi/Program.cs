global using EventHubWebApi.Models;
using EventHubWebApi.Data;
using EventHubWebApi.Services.AuthService;
using EventHubWebApi.Services.EventCategoryService;
using EventHubWebApi.Services.EventService;
using EventHubWebApi.Services.UserService;
using EventHubWebApi.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    { 
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEventCategoryService, EventCteoryService>();
builder.Services.AddScoped<IUserService, UserServes>();
builder.Services.AddScoped<IEventServicecs, EventService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add CORS middleware
app.UseCors(builder => 
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
