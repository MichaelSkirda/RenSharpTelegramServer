using BLL.Repositories;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RenSharpTelegram
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration config)
        {
            InjectDatabase(services, config);
            InjectServices(services);
            InjectRepositories(services);
        }

        private static void InjectDatabase(IServiceCollection services, IConfiguration config)
        {
            string connection = config.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException(nameof(config));

            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ICodeService, CodeService>();
            services.AddScoped<IUserTelegramService, UserTelegramService>();
            services.AddScoped<IUserTelegramVerificationService, UserTelegramVerificationService>();
            services.AddScoped<ITelegramService, TelegramService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<ICodeRepository, CodeRepository>();
            services.AddScoped<IUserTelegramRepository, UserTelegramRepository>();
        }
    }
}
