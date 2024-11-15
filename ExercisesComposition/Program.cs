using ExercisesApplication.Services;
using ExercisesDomain.Stores;
using ExercisesInfrastructure;
using ExercisesInfrastructure.Mappers;
using ExercisesInfrastructure.Stores;
using ExercisesPresentationLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using SharedApplication.Base;
using SharedPresentation.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseInMemoryDatabase("ExerciseServiceDatabase");
});
builder.Services.AddScoped<IExercisesStore, ExercisesStore>();

builder.Services.AddSingleton<IApplicationMapper, ApplicationAutoMapper>();
builder.Services.AddSingleton<IPresentationMapper, PresentationAutoMapper>();

builder.Services.AddScoped<ExerciseService>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ExercisesPresentation.Controllers.ExerciseControllerGRPC>();

app.Run();
