using BookStore2023.DL.Interfaces;
using BookStore2023.DL.Repositories;
using BookStore2023.BL.Services;
using BookStore2023.BL.Interfaces;
using FluentValidation.AspNetCore;
using FluentValidation;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IBookRepository, BookRepository>();
        builder.Services.AddSingleton<IBookService, BookService>();
        builder.Services.AddSingleton<IAuthorRepository, AuthorRepository>();
        builder.Services.AddSingleton<IAuthorService, AuthorService>();
        builder.Services.AddSingleton<ILibraryService, LibraryService>();
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
        builder.Services.AddHealthChecks();
        builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        

       
            
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapHealthChecks("/healthz");

        app.Run();
    }
}