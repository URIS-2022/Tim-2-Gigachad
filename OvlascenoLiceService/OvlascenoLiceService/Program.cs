using OvlascenoLiceService.Data;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.ServiceCalls;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using Google.Cloud.Diagnostics.AspNetCore3;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFizickoLiceRepository, FizickoLiceRepository>();
builder.Services.AddScoped<IOvlascenoLiceRepository, OvlascenoLiceRepository>();
builder.Services.AddScoped<IAdresaService, AdresaService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<OvlascenoLiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OvlascenoLiceDB")));

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
    setup.SwaggerDoc("OvlascenoLiceServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "OvlascenoLice API",
            Version = "v1",
            Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje lica, kao i pregled svih kreiranih lica.",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Vasilije Mucibabic",
                Email = "mucibabic.it23.2019@uns.ac.rs",
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

builder.Services.AddGoogleDiagnosticsForAspNetCore("ovlascenoliceservice", "OvlascenoLiceService", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<OvlascenoLiceContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/OvlascenoLiceServiceOpenApiSpecification/swagger.json", "OvlascenoLice API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
