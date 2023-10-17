using AllInOneForum.Services;
using AllInOneForum.Contracts.SchemaFilters;
using AllInOneForum.DataAccess;
using AllInOneForum.Extensions;
using AllInOneForum.Utils;

namespace AllInOneForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(a =>
            {
                a.SchemaFilter<OptionalParametersSchemaFilter>();
            });
            builder.Services.RegisterDataAccess();
            builder.Services.RegisterServices();
            builder.Services.RegisterAutoMapping();
            builder.RegisterSerilog();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.RegisterMiddlewares();
            app.UseSerilogRequestLogging();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}