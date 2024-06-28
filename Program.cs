using Microsoft.EntityFrameworkCore;
using Drive.Data;
using Drive.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<DriveContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DriveConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"))
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMailerSendRepository, MailerSendRepository>();


builder.Services.AddHttpClient();
var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Permisos para el JWT del dataConection
app.UseAuthentication();
app.UseAuthorization();

// Para enviar el correo
app.UseHttpsRedirection();

// Middlewares
app.MapControllers();

app.Run();
