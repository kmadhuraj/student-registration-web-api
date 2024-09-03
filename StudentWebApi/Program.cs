using Student.Infrastructure;
using Student.Application;
using Student.Application.Abstractions;
using Student.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Student.Domain.Entities;
using StudentWebApi.MappingProfiles;
namespace StudentWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<IStudentInterface,StudentRepository>();
            //for configuring the  AutoMapper
            builder.Services.AddAutoMapper(typeof(Profiles));
            //builder.Services.AddScoped<IRepository<StudentDetails>,EntityFrameworkRepository<StudentDetails>>();
            //builder.Services.AddScoped<IRepository<IUnitOfWork>,EntityFrameworkRepository<IUnitOfWork>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWorkRepository>();
            builder.Services.AddDbContext<ApplicationDbContext>(options=>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });
            var app = builder.Build();

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
        }
    }
}
