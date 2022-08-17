using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OrdersOrganiser.Models;
using OrdersOrganiser.BusinessLayer;
using OrdersOrganiser.BusinessLayer.Commands;
using OrdersOrganiser.BusinessLayer.StrategyResolver;
using OrdersOrganiser.BusinessLayer.PostcodeValidation;
using OrdersOrganiser.BusinessLayer.TaxCalculator;
using OrdersOrganiser.BusinessLayer.TaxCalculator.TaxResolver;

namespace OrdersOrganiser
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase("OrderList"));
            services.AddScoped<ICreateOrderCommand, CreateOrderCommand>();
            services.AddScoped<IValidatePostcodeCommand, ValidatePostcodeCommand>();
            services.AddScoped<ICheckOrderItem, CheckOrderItem>();
            services.AddScoped<ICreateAddressCommand, CreateAddressCommand>();
            services.AddScoped<ICreateAccountCommand, CreateAccountCommand>();
            services.AddScoped<IDeleteResolver, DeleteResolver>();
            services.AddScoped<IDeleteCommand, DeleteAccountCommand>();
            services.AddScoped<IDeleteCommand, DeleteOrderCommand>();
            services.AddScoped<IPostcodeApiService, PostcodeApiService>();
            services.AddScoped<IPostcodeApiClient, PostcodeApiClient>();
            services.AddScoped<ISendVerificationEmailCommand, SendVerificationEmailCommand>();
            services.AddScoped<ISendEmailCommand, SendEmailCommand>();
            services.AddScoped<HttpClient, HttpClient>();
            services.AddScoped<ITaxCalculator, UkTaxCalculator>();
            services.AddScoped<ITaxCalculator, IrelandTaxCalculator>();
            services.AddScoped<ITaxResolver, TaxResolver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
