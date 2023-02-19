using KupacService.Data;
using KupacService.Entities;
using KupacService.ServiceCalls;
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

builder.Services.AddScoped<IKupacRepository, KupacRepository>();
builder.Services.AddScoped<ILiceService, LiceService>();
builder.Services.AddScoped<IOvlascenoLiceService, OvlascenoLiceService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<KupacContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KupacDB")));


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
    setup.SwaggerDoc("KupacServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Kupac API",
            Version = "v1",
            Description = "Pomocu ovog API-ja moze da se vrsi dodavanje, modifikacija i brisanje lica, kao i pregled svih kreiranih lica.",
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

builder.Services.AddGoogleDiagnosticsForAspNetCore("kupacservicelog", "KupacService", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<KupacContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/KupacServiceOpenApiSpecification/swagger.json", "Kupac API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();