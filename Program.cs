using CountryDropDownAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CountryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryDropDownaAPI")));


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigins");

app.MapControllers();

app.Run();
