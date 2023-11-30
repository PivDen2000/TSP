using Backend.Services;
using Backend.Services.Algorithms;
using Backend.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddScoped<IAlgorithmFactory, AlgorithmFactory>();

builder.Services.AddScoped<AcceleratedGradientAlgorithm>();
builder.Services.AddScoped<BranchAndBoundAlgorithm>();
builder.Services.AddScoped<CoordinateDescentAlgorithm>();
builder.Services.AddScoped<GreedyAlgorithm>();
builder.Services.AddScoped<SerdjukovAlgorithm>();
builder.Services.AddScoped<SerdjukovImprovedAlgorithm>();

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