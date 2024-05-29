using BookStore.Models.Models.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookStore.BL.BackgroundJobs
{
    public class MyBackgroundService : BackgroundService
    {
        IOptions<AppSettings> _appSettings;

        public MyBackgroundService(IOptions<AppSettings> appSettings)
        {
            _appSettings= appSettings;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"{nameof(MyBackgroundService)}-{DateTime.Now}");
                await Task.Delay(_appSettings.Value.DelayInterval, stoppingToken); 
            }          
        } 
    }
}
