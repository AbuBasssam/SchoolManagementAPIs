using ApplicationLayer.Comman.Behaviors;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using ApplicationLayer.Profiles;
using ApplicationLayer.Resources;
using ApplicationLayer.Services;
using DomainLayer.Helper_Classes;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;




namespace ApplicationLayer.Dependencies
{
    public static class ApplicationDependenciesRegistration
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration cfg)
        {
            // Configuration for Automapper
            services.AddAutoMapper(typeof(AutoMappersProfile).Assembly);


            // Configuration for MediaR
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });

            services.AddTransient<ResponseHandler>();

            services.AddLocalization(); // If you're using localization

            services.AddTransient<IStringLocalizer<SharedResoruces>, StringLocalizer<SharedResoruces>>();


            // Configuration for FluentValidator
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            // Configuration for Services
            services.AddTransient<IPersonExistsService, StudentService>();
            services.AddTransient<IPersonExistsService, TeacherService>();
            services.AddTransient<IEmploymentDetailsService, EmploymentDetailsService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IClassServices, ClassServices>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IMedicalConditioService, MedicalCondtionServices>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<ISectionService, SectionService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IPersonExistsService, TeacherService>();
            services.AddTransient<IPersonExistsService, StudentService>();
            services.AddTransient<IsExistsTeacherSrevice, TeacherService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IAuthService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGeneralUserService, UserService>();
            services.AddTransient<IAddUserService, UserService>();
            services.AddTransient<IGeneralUserService, UserService>();
            services.AddTransient<IEnrollmentServices, EnrollmentService>();



            //JWT Authentication
            services.Configure<JwtSettings>(cfg.GetSection("JwtSettings"));
            var JwtSettings = new JwtSettings();
            cfg.GetSection(nameof(JwtSettings)).Bind(JwtSettings);
            services.AddSingleton(JwtSettings);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { JwtSettings.Issuer },

                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidAudience = JwtSettings.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddSwaggerGen(g =>
            {
                g.SwaggerDoc("v1", new OpenApiInfo { Title = "School API", Version = "v1" });
                g.EnableAnnotations();

                g.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer schema (e.g. Bearer 212555dfef)",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                });

                g.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme // Should match the scheme name
                        },
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header
                    },
                    new List<string>() // This is a list of scopes, which is empty in this case
                }
            });
            });

            return services;
        }
    }
}