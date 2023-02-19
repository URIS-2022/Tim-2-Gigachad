using Google.Cloud.Diagnostics.AspNetCore3;
using KorisnikService.Data;
using KorisnikService.Entities;
using KorisnikService.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IKorisnikRepository, KorisnikRepository>();
builder.Services.AddScoped<IAutentifikacijaRepository, AutentifikacijaRepository>();
builder.Services.AddScoped<IAutentifikacijaHelper, AutentifikacijaHelper>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<KorisnikContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("KorisnikDB")));

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
	setup.SwaggerDoc("KorisnikServiceOpenApiSpecification",
		new Microsoft.OpenApi.Models.OpenApiInfo()
		{
			Title = "Korisnik API",
			Version = "v1",
			Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje korisnika, kao i pregled svih kreiranih korisnika.",
			Contact = new Microsoft.OpenApi.Models.OpenApiContact
			{
				Name = "Aleksandar Perić",
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

builder.Services.AddGoogleDiagnosticsForAspNetCore("korisnikservicelog", "KorisnikServiceLog", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<KorisnikContext>();
	context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
	app.UseExceptionHandler(setup =>
	{
		setup.Run(async setupRun =>
		{
			setupRun.Response.StatusCode = 500;
			await setupRun.Response.WriteAsync("Došlo je do neočekivane greške. Molimo vas pokušajte kasnije.");
		});
	});
	app.UseSwagger();
	app.UseSwaggerUI(setup =>
	{
		setup.SwaggerEndpoint("/swagger/KorisnikServiceOpenApiSpecification/swagger.json", "Korisnik API");
		setup.RoutePrefix = "";
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
