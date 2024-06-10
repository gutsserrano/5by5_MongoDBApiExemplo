using Microsoft.Extensions.Options;
using MongoDBApiExemplo.Services;
using MongoDBApiExemplo.Utils;

namespace MongoDBApiExemplo
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

            // Using configuration file

            builder.Services.Configure<MongoDBApiDataBaseSettings>(
                           builder.Configuration.GetSection(nameof(MongoDBApiDataBaseSettings)));

            builder.Services.AddSingleton<IMongoDBApiDataBaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDBApiDataBaseSettings>>().Value);

            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<AddressService>();

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
