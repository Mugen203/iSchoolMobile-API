using System.Net;
using System.Text;
using iSchool_Solution.Data;
using iSchool_Solution.Entities;
using iSchool_Solution.Entities.ErrorModel;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Shared.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace iSchool_Solution.Helper;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    }

    // TODO: IIS COnfiguration
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => { });
    }

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApiUser, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequiredLength = 10;
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredUniqueChars = 1;
                opts.SignIn.RequireConfirmedAccount = true;
                opts.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                opts.Lockout.AllowedForNewUsers = true;
                opts.Lockout.MaxFailedAccessAttempts = 5;
                opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        // TODO: Change secretKey to .env variable
        var secretKey = Encoding.ASCII.GetBytes(jwtSettings["Secret"] ?? throw new InvalidOperationException());

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // The issuer is the actual server that created the token
                ValidateIssuer = true,

                // The receiver of the token is a valid recipient
                ValidateAudience = true,

                // The token has not expired
                ValidateLifetime = true,

                // The signing key is valid and is trusted by the server
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(secretKey)
            };
        });
    }

    public static void ConfigureEmail(this IServiceCollection services, IConfiguration configuration)
    {
        var emailSettings = configuration.GetSection("EmailConfiguration");
        var emailConfig = new EmailConfiguration();
        emailSettings.Bind(emailConfig);

        services.AddSingleton(emailConfig);
    }
    
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var errorDetails = new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error."
                    };

                    // Customize error message based on exception type 
                    if (contextFeature.Error is KeyNotFoundException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorDetails.StatusCode = context.Response.StatusCode;
                        errorDetails.Message = contextFeature.Error.Message; // Or a more generic message if you prefer
                    }
                    else if (contextFeature.Error is ArgumentException or InvalidOperationException or ScheduleConflictException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorDetails.StatusCode = context.Response.StatusCode;
                        errorDetails.Message = contextFeature.Error.Message;
                    }

                    await context.Response.WriteAsync(errorDetails.ToString());
                }
            });
        });
    }
}