using Google.Cloud.Diagnostics.AspNetCore3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.ServiceCalls;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IZalbaRepository, ZalbaRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ZalbaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZalbaDB")));

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
    setup.SwaggerDoc("ZalbaServiceOpenApiSpecification",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Zalba API",
            Version = "v1",
            Description = "Pomocu ovog API-ja moze da se vrsi dodavanje, modifikacija i brisanje zalbe, kao i pregled svih kreiranih zalbi.",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Luka Marinkovic",
                Email = "marinkovic.it20.2019@uns.ac.rs",
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

builder.Services.AddGoogleDiagnosticsForAspNetCore("zalbaservicelog", "ZalbaService", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ZalbaContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(setup =>
    {
        setup.Run(async setupRun =>
        {
            setupRun.Response.StatusCode = 500;
            await setupRun.Response.WriteAsync("Došlo je do neoèekivane greške. Molimo vas pokušajte kasnije.");
        });
    });

    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/ZalbaServiceOpenApiSpecification/swagger.json", "Zalba API");
        setup.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
