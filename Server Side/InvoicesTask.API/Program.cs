
using InvoicesTask.BL;
using InvoicesTask.DAL;

namespace InvoicesTask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Adding DB Context Service
            builder.Services.AddDbContext<ApplicationDbContext>();
            #endregion

            #region Adding UOF, and Managers Services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IInvoiceHDRManager, IInvoiceHDRManager>();
            builder.Services.AddScoped<IItemsDTLManager, ItemsDTLManager>();
            #endregion

            #region Middlewares
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}