using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApiPro2.DataAccess.IRepositories;
using WebApiPro2.DataAccess.Repositories;
using WebApiPro2.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ProjectDB2Context>(Options=> Options.UseSqlServer("server=AKHIL\\SQLEXPRESS;Uid=sa;password=123;database=ProjectDB2;Encrypt=false;TrustServerCertificate=true"));
builder.Services.AddDbContext<ProjectDB2Context>(Options=>Options.UseSqlServer(builder.Configuration.GetConnectionString("ConStrLocal")));
builder.Services.AddTransient<ICustRepository,CustRepository>();
//builder.Services.AddScoped<ICustRepository,CustRepository>();
//builder.Services.AddSingleton<ICustRepository,CustRepository>();
builder.Services.AddTransient<IBookingRepository,BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
