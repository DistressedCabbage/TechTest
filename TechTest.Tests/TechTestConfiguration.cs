using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TechTest.Common;

namespace TechTest.Tests
{
    public static class TechTestConfiguration
    {

        public static ITestConfiguration GetTestConfiguration()
        {
            var config = InitaliseConfiguration();
            return new TestConfiguration(
                config["BaseUrl"]
                );
        }

        private static IConfiguration InitaliseConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();

            return config;
        }
    }
}