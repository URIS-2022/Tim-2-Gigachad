using UgovorOZakupuService.Data;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.ServiceCalls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Google.Cloud.Diagnostics.AspNetCore3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddScoped<IUgovorOZakupuRepository, UgovorOZakupuRepository>();
builder.Services.AddScoped<IDokumentiService, DokumentiService>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IDeoParceleService, DeoParceleService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UgovorOZakupuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UgovorOZakupuDB")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("UgovorOZakupuServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Dokument API",
            Version = "v1",
            Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje dokumenata, kao i pregled svih dokumenata.",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Milan Maglov",
                Email = "maglov.it75.2019@uns.ac.rs",
                Url = new Uri(builder.Configuration["Services:FTN"])
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "FTN licence",
                Url = new Uri(builder.Configuration["Services:FTN"])
            },
            TermsOfService = new Uri(builder.Configuration["Services:FTN"])
        });

    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    setup.IncludeXmlComments(xmlCommentsPath);
});
builder.Services.AddGoogleDiagnosticsForAspNetCore("ugovorozakupuservicelog", "UgovorOZakupuService", "1.0.0");
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UgovorOZakupuContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/UgovorOZakupuServiceOpenApiSpecification/swagger.json", "Dokument API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();