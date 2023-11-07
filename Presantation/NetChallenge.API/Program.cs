using Hangfire;
using NetChallenge.Application;
using NetChallenge.Persistence;
using NetChallenge.Persistence.Configurations;
using NetChallenge.Persistence.Services.Jobs;
using NetChallenge.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region IoC ServiceRegistration

builder.Services.AddServiceRegistiration();
builder.Services.AddApplicationServices();
builder.Services.AddSignalRServices();
builder.Services.AddSignalR();

#endregion

#region Add Hangfire services. 


builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(HangfireConfiguration.ConnectionString);
    //RecurringJob.AddOrUpdate<DailyCarrierReports>(d => d.AddDailyCarrierReports(), "*/5 * * * *", TimeZoneInfo.Local);
    RecurringJob.AddOrUpdate<DailyCarrierReports>(d => d.AddDailyCarrierReports(), "0 0 * * *", TimeZoneInfo.Local);

});
    //.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    //.UseSimpleAssemblyNameTypeSerializer()
    //.UseRecommendedSerializerSettings()
    //.UseSqlServerStorage(HangfireConfiguration.ConnectionString));
    //.UseSqlServerStorage(
    //() => new Microsoft.Data.SqlClient.SqlConnection(HangfireConfiguration.ConnectionString))
    //);
builder.Services.AddHangfireServer();



//x.UseSqlServerStorage(HangfireConfiguration.AddHangFireConfiguration);

// Add the processing server as IHostedService
builder.Services.AddMvc();

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


app.UseHangfireDashboard();
app.UseHangfireServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
