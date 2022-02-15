using DataAccess.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DIConfiguration
{
    public static class SubscriptionDbConfiguration
    {
        public static void ConfigureSubscriptionDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SubscriptionDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
