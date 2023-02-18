using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Entities;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJavnoNadmetanjeRepository, JavnoNadmetanjeRepository>();
builder.Services.AddScoped<ILicitacijaRepository, LicitacijaRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<JavnoNadmetanjeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JavnoNadmetanjeDB")));

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
    setup.SwaggerDoc("LiceServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Adresa API",
            Version = "v1",
            Description = "Pomocu ovog API-ja moze da se vrsi dodavanje, modifikacija i brisanje javnih nadmetanja, kao i pregled svih kreiranih javnih nadmetanja.",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Elena Dejanovic",
                Email = "dejanovic.it42.2019@uns.ac.rs",
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

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<JavnoNadmetanjeContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/JavnoNadmetanjeServiceOpenApiSpecification/swagger.json", "Javno Nadmetanje API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
