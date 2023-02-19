using Google.Cloud.Diagnostics.AspNetCore3;
using LiceService.Data;
using LiceService.Entities;
using LiceService.ServiceCalls;
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

builder.Services.AddScoped<IFizickoLiceRepository, FizickoLiceRepository>();
builder.Services.AddScoped<IKontaktOsobaRepository, KontaktOsobaRepository>();
builder.Services.AddScoped<IPravnoLiceRepository, PravnoLiceRepository>();
builder.Services.AddScoped<ILiceRepository, LiceRepository>();
builder.Services.AddScoped<IAdresaService, AdresaService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<LiceContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("LiceDB")));

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
			Title = "Lice API",
			Version = "v1",
			Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje lica, kao i pregled svih kreiranih lica.",
			Contact = new Microsoft.OpenApi.Models.OpenApiContact
			{
				Name = "Petar Rakić",
				Email = "rakic.it19.2019@uns.ac.rs",
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

builder.Services.AddGoogleDiagnosticsForAspNetCore("liceservicelog", "LiceService", "1.0.0");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<LiceContext>();
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
		setup.SwaggerEndpoint("/swagger/LiceServiceOpenApiSpecification/swagger.json", "Lice API");
		setup.RoutePrefix = "";
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
