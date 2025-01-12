using FuelChampion.Api.Data;
using FuelChampion.Api.Repositories;
using FuelChampion.Api.Services;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace FuelChampion.Api;

public static class DependencyInjection
{
    public const string DEFAULT_POLICY = "AllowBlazor";
    public const string COOKIES = "Cookies";


    public static IServiceCollection Configuration(this IServiceCollection services, string connectionString)
    {
        services.AddSwagger();
        services.AddContext(connectionString);
        services.ConfigureIdentity();
        services.AddRepositories();
        services.ConfigureCors();
        services.ConfigureMappingProfiles();
        services.AddServices();
        return services;
    }

    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
         {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "FuelChampion", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
         });
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    //private static IServiceCollection AddAuth(this IServiceCollection services)
    //{
    //    services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    //    services.AddAuthentication(options =>
    //    {
    //        options.DefaultAuthenticateScheme =
    //        options.DefaultChallengeScheme =
    //        options.DefaultForbidScheme =
    //        options.DefaultScheme =
    //        options.DefaultSignInScheme =
    //        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
    //    }).AddJwtBearer(options =>
    //    {
    //        options.TokenValidationParameters = new TokenValidationParameters
    //        {
    //            ValidateIssuer = true,
    //            ValidIssuer = configurationManager.Configuration["JWT:Issuer"],
    //            ValidateAudience = true,
    //            ValidAudience = configurationManager.Configuration["JWT:Audience"],
    //            IssuerSigningKey = new SymmetricSecurityKey(
    //                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
    //        };
    //    });
    //                    //services.AddAuthentication(COOKIES).AddCookie();
    //                    //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    //                    //{
    //                    //    options.Cookie.Name = "auth_token";
    //                    //    options.LoginPath = "/login";
    //                    //    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    //                    //    options.AccessDeniedPath = "/access-denied";
    //                    //});
    //                    //services.AddCascadingAuthenticationState();
    //    services.AddAuthorization();
    //    services.AddAuthorizationBuilder();
    //    return services;
    //}

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICarRepository, CarRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddTransient<IGasStationRepository, GasStationRepository>();

        return services;
    }

    private static IServiceCollection AddContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString)
                                                           .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
        return services;
    }

    private static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(DEFAULT_POLICY, policy =>
            {
                policy.WithOrigins("https://localhost:7026", "http://localhost:5065").AllowAnyHeader().AllowAnyMethod().WithHeaders(HeaderNames.ContentType);
            });
        });

        return services;
    }

    private static IServiceCollection ConfigureMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }

    private static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
#if DEBUG
        services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DBContext>().AddApiEndpoints();
#else
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 7;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireDigit = true;
        })
        .AddEntityFrameworkStores<DBContext>().AddApiEndpoints();
#endif

        return services;
    }
}
