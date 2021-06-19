using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Configuration;


namespace SecureClient
{
    public class AuthConfig
    {
        public String Instance { get; set; }
        public String TenantId { get; set; }
        public String ClientId { get; set; }
        public String Authority { 
            get 
            {
                return String.Format(CultureInfo.InvariantCulture, Instance, TenantId);
            } 
        }
        public String ClientSecret { get; set; }
        public String BaseAddress { get; set; }
        public String ResourceId { get; set; }

        public static AuthConfig ReadJsonFromFile(String path)
        {
            Console.WriteLine("Directory: " + Directory.GetCurrentDirectory());
            IConfiguration Configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath("C:\\Users\\denis\\Desktop\\Dev\\.NET\\SecureClient")//.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path);
            Configuration = builder.Build();
            return Configuration.Get<AuthConfig>();
        }
    }
}
