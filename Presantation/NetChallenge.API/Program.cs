using NetChallenge.Persistence;
using NetChallenge.Application;
using NetChallenge.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Service  Registration

builder.Services.AddServiceRegistiration();
builder.Services.AddApplicationServices();
builder.Services.AddSignalRServices();
builder.Services.AddSignalR();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
