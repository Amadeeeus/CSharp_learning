using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Npgsql;
using System.Text;
using Kravchenko_AdvancedServer;
using Kravchenko_AdvancedServer.Mapping;
using Kravchenko_AdvancedServer.Repositories;
using Kravchenko_AdvancedServer.Services;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(opt =>
{
    opt.SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
    opt.ExpiresHours = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRES_HOURS"));
});

DotNetEnv.Env.Load();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<JwtProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
    options.TokenValidationParameters = new()
    {
        
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
    };
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "v1" });

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
