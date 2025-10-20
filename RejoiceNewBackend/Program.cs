using Microsoft.EntityFrameworkCore;
using RejoiceNewBackend.Data;
using RejoiceNewBackend.Repo;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 註冊 EF Core + SQLite
builder.Services.AddDbContext<TestDBContext>(options =>
    options.UseSqlite("Data Source=myapp.db"));

builder.Services.AddScoped<RepoPerson>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 建立資料庫（若不存在）
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TestDBContext>();
    db.Database.EnsureCreated();
}

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
