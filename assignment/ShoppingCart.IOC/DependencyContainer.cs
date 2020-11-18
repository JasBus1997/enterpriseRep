using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.repositories;
using ShoppingCart.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices (IServiceCollection services, String connectionString)
        {
            services.AddDbContext<ShoppingCartDbContext>(options => 
            options.UseSqlServer(connectionString));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductsService, ProductsService>();
        }        
    }
}
