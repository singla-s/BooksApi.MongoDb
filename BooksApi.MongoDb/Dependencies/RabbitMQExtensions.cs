using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BooksApi.MongoDb.Dependencies
{
    public static class RabbitMQExtensions
    {
        public static MyRabbitMQListener _QListener { get; set; }   
        public static IApplicationBuilder UseRabbitMQListener(this IApplicationBuilder app)
        {
            _QListener = app.ApplicationServices.GetRequiredService<MyRabbitMQListener>();

            var appLifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            //add event handlers
            appLifeTime.ApplicationStarted.Register(OnStarted);
            appLifeTime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            _QListener.Register();
        }

        private static void OnStopping()
        {
            _QListener.UnRegister();
        }
    }
}
