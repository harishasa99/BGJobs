using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Projekat2;
using Projekat2.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server = DESKTOP-KTVP4UP\\SQLEXPRESS; Database = HangfireDB; Trusted_Connection = True; TrustServerCertificate=True"));


// Add services to the container.
builder.Services.AddHangfire(config => config.UseSqlServerStorage("Server=DESKTOP-KTVP4UP\\SQLEXPRESS;Database=HangfireDB;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddHangfireServer();


builder.Services.AddScoped<CleanInactiveUsersService>();


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

app.UseHangfireDashboard();

app.Run();
