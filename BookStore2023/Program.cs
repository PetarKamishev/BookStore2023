using AspNetCore.Identity.MongoDbCore.Models;
using BookStore.BL.BackgroundJobs;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories;
using BookStore.DL.Repositories.Mongo;
using BookStore.Healthchecks;
using BookStore.Models.Configurations;
using BookStore.Models.Models.Configurations;
using BookStore.Models.Models.Configurations.Identity;
using BookStore.Models.Models.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

            Log.Information("Starting web application");


            var jwtSettings = new JwtSettings();
            builder.Configuration.Bind(nameof(jwtSettings));
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(op =>
                {
                    op.SaveToken = true;
                    op.TokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });
            builder.Services.AddHostedService<MyBackgroundService>();
            builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection(nameof(MongoConfiguration)));
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
            builder.Services.AddHostedService<BookConsumerService>();
            // Add services to the container.
            builder.Services
                .AddSingleton<IBookRepository, BookMongoRepository>();
            builder.Services
                .AddSingleton<IBookService, BookService>();
            builder.Services
                .AddSingleton<IAuthorRepository, AuthorMongoRepository>();
            builder.Services
                .AddSingleton<IAuthorService, AuthorService>();
            builder.Services
                .AddSingleton<ILibraryService, LibraryService>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
            builder.Services.AddHealthChecks();
            builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));
            builder.Services.AddScoped<IIdentityService, IdentityService>();

          
            var mongoCfg = builder.Configuration.GetSection(nameof(MongoConfiguration)).Get<MongoConfiguration>();
            builder.Services.AddIdentity<Models.Models.Users.IdentityUser, MongoIdentityRole>().AddMongoDbStores<Models.Models.Users.IdentityUser, MongoIdentityRole, Guid>
                (mongoCfg.ConnectionString, mongoCfg.DatabaseName).AddSignInManager().AddDefaultTokenProviders();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                var security = new Dictionary<string, IEnumerable<string>>
            {
                { "Bearer", Array.Empty<string>() },

            };
                OpenApiSecurityScheme securityDefinition = new()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Secify the authorization token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                };
                x.AddSecurityDefinition("jwt_auth", securityDefinition);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { securityDefinition, new string[] { } }
            });
            });


 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapHealthChecks("/healthz");
            app.Run();
        }
    }
}