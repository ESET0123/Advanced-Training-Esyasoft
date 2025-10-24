
using collage_app.Mylogger;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CollegeDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
            });
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ICollegeRepo<Student>, ICollegeRepo<Student>>();
            builder.Services.AddScoped<ICollegeRepo<Course>, ICollegeRepo<Course>>();

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMylogger, LogtoFile>();


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
            //app.CollegeController();

            app.Run();
        }
    }
}
