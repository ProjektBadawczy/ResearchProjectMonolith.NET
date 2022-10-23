using ResearchProjectMonolith.NET.Repositories;
using ResearchProjectMonolith.NET.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<GraphRepository>();
builder.Services.AddScoped<IGraphService, GraphService>();
builder.Services.AddScoped<IBfSservice, BfSservice>();
builder.Services.AddScoped<IEdmondsKarpService, EdmondsKarpService>();
builder.Services.AddScoped<IPushRelabelService, PushRelabelService>();

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

app.Run();