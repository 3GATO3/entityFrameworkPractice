using entityFrameworkPractice.Services;
using entityFrameworkPractice.src.Application.Interfaces;
using entityFrameworkPractice.src.Application.Services;
using entityFrameworkPractice.src.infraestructure.Repository;
using entityFrameworkPractice.src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace entityFrameworkPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options=> 
            {
                options.JsonSerializerOptions.ReferenceHandler = 
                ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer("name=DefaultConnection"));
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped(typeof(Repository<>));
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
           // builder.Services.AddScoped<ILogger>();
            //builder.Services.AddScoped(typeof(ActorRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseDeveloperExceptionPage();

            app.MapControllers();

            app.Run();
        }
    }
}