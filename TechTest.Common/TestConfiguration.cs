namespace TechTest.Common
{
    public class TestConfiguration : ITestConfiguration
    {
        public TestConfiguration(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; set; }
    }
}