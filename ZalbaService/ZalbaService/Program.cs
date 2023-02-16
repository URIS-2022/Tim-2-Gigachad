using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ZalbaService.Data;
using ZalbaService.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IZalbaRepository, ZalbaRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ZalbaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZalbaDB")));

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
    var context = services.GetRequiredService<ZalbaContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
