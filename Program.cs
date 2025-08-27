using System.Text;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Hubs;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Validations;
using TaskManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Configuração da autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
})
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("e2a1c7b8f9d34a1e8b7c2d9f4a6b3c1d")),
            ClockSkew = TimeSpan.Zero
        };
    });
    
    
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var serviceAssembly = Assembly.GetExecutingAssembly();
builder.Services.Scan(scan => scan
    .FromAssemblies(serviceAssembly)
    .AddClasses(classes => classes.InNamespaceOf<ProjetoService>())
    .AsSelfWithInterfaces()
    .WithScopedLifetime()
    .AddClasses(classes => classes.InNamespaceOf<ProjetoValidator>())
    .AsSelfWithInterfaces()
    .WithScopedLifetime()
);

var rabbitConfig = builder.Configuration.GetSection("RabbitMq").Get<RabbitMqConfig>() ?? new RabbitMqConfig();
builder.Services.AddSingleton(rabbitConfig);
builder.Services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificacaoHub>("/hubNotificacao");

app.Run();
