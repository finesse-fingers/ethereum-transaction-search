using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Factories;
using WebApp.Models;

namespace WebApp.Services
{
    public class EthereumService : IEthereumService
    {
        private string RequestUri => _configuration["EthereumServiceConfiguration:Uri"];

        private readonly ILogger<EthereumService> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IInfuraRequestBuilder _requestBuilder;

        public EthereumService(
            ILogger<EthereumService> logger,
            IConfiguration configuration,
            HttpClient httpClient,
            IInfuraRequestBuilder requestBuilder)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
            _requestBuilder = requestBuilder;
        }

        public async Task<IEnumerable<EthereumTransaction>> GetTransactionsByBlockNumberAsync(
            long blockNumber)
        {
            var transactions = new List<EthereumTransaction>();

            // prepare request
            var request = _requestBuilder.MakeGetBlockByNumber(blockNumber, true);

            // submit request and parse response
            var response = await PostAsJsonAsync<InfuraBlockByNumberResult>(request);

            // nothing in the result so return an empty list of transactions
            if ((response?.result?.transactions?.Length ?? 0) == 0)
            {
                return transactions;
            }

            return response.result.transactions;
        }

        /// <summary>
        /// Post the request as a application/json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<T> PostAsJsonAsync<T>(InfuraRequest request)
        {
            var requestAsString = JsonConvert.SerializeObject(request);
            _logger?.LogDebug($"Request content: {requestAsString}");

            var stringContent = new StringContent(requestAsString, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(RequestUri, stringContent);

            var responseBody = await result.Content.ReadAsStringAsync();
            _logger?.LogDebug($"Response content: {responseBody}");

            // force an exception if not successful
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
