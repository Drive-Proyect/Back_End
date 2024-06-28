using Microsoft.EntityFrameworkCore;
using Drive.Data;
using Drive.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Drive.Models;
using Drive.Services.Auth;

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
//registro de las interfaces al contenedor de dependencias
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//Jwt
builder.Services.AddAuthentication(item =>
    {
        item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(item =>
    {
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gSI=eFk4G3ZRy`(Kg£+<X(1VI4)5=RKw")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew=TimeSpan.Zero
    };
});
var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsettings);

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
