using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TestSoft.TaxCalculate.Service
{
    public class TaxCalculateService : ITaxCalculateService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public TaxCalculateService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<double?> GetTaxRate()
        {
            var messageUrl = $"{_configuration["TaxRateApi"]}/v1/taxaJuros";
            Log.Information("Geting tax rate to TAXRATE API: {MessageUrl}", messageUrl);

            using var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(messageUrl);
            var value = await response.Content.ReadAsStringAsync();
            Log.Information("Tax rate status {ResponseCode} and {Value}", response.StatusCode, value);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }
            return Convert.ToDouble(value);
        }
    }
}