using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.DB_Interfaces;
using ApplicationLayer.Services;
using DomainLayer.Entities;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repositories.Basic;
using InfrastructureLayer.Repositories.ReadOnly;
using InfrastructureLayer.Repositories.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer.Implementations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
            (
                options =>
                options.UseSqlServer
                (
                    configuration.GetConnectionString("DefaultConnection")
                )
            );


            //services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityCore<User>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.AllowedUserNameCharacters =
                "0123456789-._@+\r\n\r\n";
                options.User.RequireUniqueEmail = true;
                //options.SignIn.RequireConfirmedEmail = false;
            })
            .AddUserManager<UserManager<User>>()
            .AddRoles<Role>()
            .AddRoleManager<RoleManager<Role>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();




            //services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 8;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 5;
            //}
            //).AddEntityFrameworkStores<ApplicationDbContext>()
            // .AddUserManager<UserManager<User>>()
            // .AddRoles<Role>()
            // .AddRoleManager<RoleManager<Role>>();




            //services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonRepository, PeopleRepository>();
            services.AddTransient<IEmploymentDetailsRepository, EmployementDetailsRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IMedicalConditionRepository, MedicalConditionRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ITeacherRepository, TeacherRepository>();


            services.AddTransient<IPersonExistsService, TeacherRepository>();
            services.AddTransient<IPersonExistsService, StudentRepository>();
            services.AddTransient<IPersonExistsService, PeopleRepository>();
            services.AddTransient<IClassValidation, ClassRepository>();





            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IStaticGenericRepository<>), typeof(StaticGenericRepository<>));
            services.AddTransient<ITeacherExistsService, TeacherRepository>();

            services.AddTransient<ICommanCourseValidation, CourseRepository>();

            services.AddTransient<IAddCourseValidation, CourseRepository>();
            services.AddTransient<ICommanSectionValidation, SectionRepository>();

            services.AddTransient<ISectionValidation, SectionRepository>();

            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();


            //services.AddScoped<ICourseService, CourseService>();
            //services.AddScoped<IMedicalConditioService, MedicalCondtionServices>();
            //services.AddScoped<IScheduleService, ScheduleService>();
            //services.AddScoped<ISectionService, SectionService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ITeacherService, TeacherService>();
            //services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
