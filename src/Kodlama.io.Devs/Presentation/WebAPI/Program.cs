using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceInfrastructurer(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD:src/Kodlama.io.Devs/Presentation/WebAPI/Program.cs
app.UseHttpsRedirection();
app.ConfigureCustomExceptionMiddleware();
=======
//if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

>>>>>>> 3b5c75bcdc6288bfa55e34a5d216d6258e6d7f26:src/demoProjects/rentACar/WebAPI/Program.cs
app.UseAuthorization();

app.MapControllers();

app.Run();
