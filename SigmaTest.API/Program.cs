using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var CorsAllowedOrigins = "_CORSAllowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsAllowedOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

var dbconnection = builder.Configuration.GetConnectionString("AppDbContext");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(dbconnection, builder => builder.EnableRetryOnFailure()));

builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationCore();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(CorsAllowedOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
