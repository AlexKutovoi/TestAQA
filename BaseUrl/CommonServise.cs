using Microsoft.Extensions.Configuration;

namespace TestAQA.BaseUrl
{
    public class CommonService
    {        
        private static string _baseUrl;

        /// <summary>
        /// Базовый адрес сайта. 
        /// Берется из appsettings.json
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public static string BaseUrl
        {
            get
            {
                string url = Environment.GetEnvironmentVariable("url");
                switch (url)
                {                    
                    default: _baseUrl = Configuration["BaseUrl"]; break;
                }
                return _baseUrl;
            }
        }

        private static IConfiguration _configuration;

        public static IConfiguration Configuration
        {
            get
            {
                return _configuration ??= GetConfiguration();
            }
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }
    }

}

       

