using ApplicationLayer.Dependencies;
using InfrastructureLayer.Implementations;
using PresentationLayer.Middleware;



var builder = WebApplication.CreateBuilder(args);


//var jwtSettings = builder.Configuration.GetSection("Jwt").Get<Jwt>();

// Register the JwtSettings object as a singleton for dependency injection

//builder.Services.AddSingleton(jwtSettings);






// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//builder.Services.AddLogging(); // Add logging services


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.RegisterApplicationDependencies(builder.Configuration);


var presentationAssembly = typeof(AssemblyReference).Assembly;

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);



//builder.Services.RegisterApplicationDependencies(builder.Configuration);
//var applicationAssembly = typeof(ApplicationLayer.AssemblyReference).Assembly;

//var presentationAssembly = typeof(PresentationLayer.AssemblyReference).Assembly;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
