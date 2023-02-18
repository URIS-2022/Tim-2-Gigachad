using DeoParceleService.Data;
using DeoParceleService.Entities;
using DeoParceleService.ServiceCalls;
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

builder.Services.AddScoped<IParcelaRepository, ParcelaRepository>();
builder.Services.AddScoped<IDeoParceleRepository, DeoParceleRepository>();
builder.Services.AddScoped<IKupacService, KupacService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DeoParceleContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DeoParceleDB")));

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
	setup.SwaggerDoc("DeoParceleServiceOpenApiSpecification",
		new Microsoft.OpenApi.Models.OpenApiInfo()
		{
			Title = "DeoParcele API",
			Version = "v1",
			Description = "Pomoću ovog API-ja može da se vrši dodavanje, modifikacija i brisanje dela parcele, kao i pregled svih kreiranih delova parcele.",
			Contact = new Microsoft.OpenApi.Models.OpenApiContact
			{
				Name = "Petar Rakić",
				Email = "rakic.it19.2019@uns.ac.rs",
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
	var context = services.GetRequiredService<DeoParceleContext>();
	context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(setup =>
	{
		setup.SwaggerEndpoint("/swagger/DeoParceleServiceOpenApiSpecification/swagger.json", "Lice API");
		setup.RoutePrefix = "";
	});
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
