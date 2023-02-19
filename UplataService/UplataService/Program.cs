using Google.Cloud.Diagnostics.AspNetCore3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UplataService.Data;
using UplataService.Entities;
using UplataService.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUplataRepository, UplataRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();
builder.Services.AddScoped<IJavnoNadmetanjeService, JavnoNadmetanjeService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<UplataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UplataDB")));

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
    setup.SwaggerDoc("UplataServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Uplata API",
            Version = "v1",
            Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje uplata, kao i pregled svih kreiranih uplata.",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Aleksandar Peric",
                Email = "peric.it30.2019@uns.ac.rs",
                Url = new Uri("http://www.ftn.uns.ac.rs/")
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "FTN licence",
                Url = new Uri("http://www.ftn.uns.ac.rs/")
            },
            TermsOfService = new Uri("http://www.ftn.uns.ac.rs/")
        });
    var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);
    setup.IncludeXmlComments(xmlCommentsPath);
});

builder.Services.AddGoogleDiagnosticsForAspNetCore("uplatalog", "UplataServiceLog", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UplataContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/UplataServiceOpenApiSpecification/swagger.json", "Uplata API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
