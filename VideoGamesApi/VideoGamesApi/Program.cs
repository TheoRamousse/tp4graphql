using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VideoGamesApi.Data;
using VideoGamesApi.Mutations;
using VideoGamesApi.Repositories;
using Path = System.IO.Path;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register custom services for the superheroes
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IStudioRepository, StudioRepository>();
builder.Services.AddScoped<IEditorRepository, EditorRepository>();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting().AddMutationType<AppMutation>();


// Add Application Db Context options
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    var dbpath = System.IO.Path.Join(path, "game.db");

    options.UseSqlite($"Data Source={dbpath}");
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL(path: "/graphql");
app.UseGraphQLGraphiQL();

app.Run();