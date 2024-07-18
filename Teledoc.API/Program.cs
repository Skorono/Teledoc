using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Teledoc.Core.Repositories;
using Teledoc.Core.Services;
using Teledoc.DAL.Context;
using Teledoc.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Teledoc", Version = "v1", Description = "Simple teledoc api" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddTransient<EntityRepository<Founder>, FounderRepository>();
builder.Services.AddTransient<EntityRepository<Client>, ClientsRepository>();
builder.Services.AddTransient<ServiceBase<Client>, ClientService>();
builder.Services.AddTransient<ServiceBase<Founder>, FounderService>();

builder.Services.AddDbContext<DbContext, TeledocContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
    options.EnableDetailedErrors();
});

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
;

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();