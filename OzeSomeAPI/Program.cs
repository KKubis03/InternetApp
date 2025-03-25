
using Microsoft.EntityFrameworkCore;
using OzeSome.Data.Models.Contexts;
using OzeSomeAPI.Services;

namespace OzeSomeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"));
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<AddressService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<NoteService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<MeetingService>();
            builder.Services.AddScoped<DocumentService>();
            builder.Services.AddScoped<ContractService>();

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
