using ApiSincinaty.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




////agregar el db cotext al proyecto con la conexion a la base de datos
//builder.Services.AddDbContext<ContextDb>(options => options.UseMySql
//    (builder.Configuration.GetConnectionString("ConnectionString"),
//    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnectionString"))));


var connectionString = Environment.GetEnvironmentVariable("MYSQLCONN")
    ?? builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<ContextDb>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
