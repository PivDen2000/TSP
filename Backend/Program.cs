using Backend.Services;
using Backend.Services.Algorithms;
using Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IAlgorithmFactory, AlgorithmFactory>();

builder.Services.AddScoped<AcceleratedGradientAlgorithm>();
builder.Services.AddScoped<CoordinateDescentAlgorithm>();
builder.Services.AddScoped<SerdjukovAlgorithm>();
builder.Services.AddScoped<SerdjukovImprovedAlgorithm>();
builder.Services.AddScoped<BranchAndBoundAlgorithm>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();