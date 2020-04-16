using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Unleash;

namespace Infrastructure.Unleash
{
    public class FeatureFlagService : IFeatureFlagService, IDisposable
    {
        private UnleashSettings _unleaseSettings;
        private DefaultUnleash _unleash;
        private readonly IWebHostEnvironment _environment;
        public FeatureFlagService(IWebHostEnvironment environment)
        {
            _environment = environment;
            _unleaseSettings = new UnleashSettings()
            {   
                AppName = _environment.EnvironmentName,
                InstanceTag = "MD9f55SXVcAoxEVMpauf",
                UnleashApi = new Uri("https://gitlab.com/api/v4/feature_flags/unleash/18002736")
                
            };
        }

        public void Dispose()
        {
           _unleash.Dispose();
        }

        public bool IsEnabled(string feature)
        {
             _unleash = new DefaultUnleash(_unleaseSettings);

            if (string.IsNullOrWhiteSpace(feature))
            {
                return false;
            }
            if (_unleash.IsEnabled(feature))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}