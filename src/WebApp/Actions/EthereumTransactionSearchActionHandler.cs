using System.Linq;
using System.Threading.Tasks;
using WebApp.Mapping;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Actions
{
    public class EthereumTransactionSearchActionHandler : IEthereumTransactionSearchActionHandler
    {
        private readonly IEthereumService _ethereumService;
        private readonly IEthereumTransactionMapper<EthereumTransactionDTO> _mapper;

        public EthereumTransactionSearchActionHandler(
            IEthereumService ethereumService, 
            IEthereumTransactionMapper<EthereumTransactionDTO> mapper)
        {
            _ethereumService = ethereumService;
            _mapper = mapper;
        }

        public async Task<EthereumTransactionSearchResult> Search(
            EthereumTransactionSearchRequest searchRequest)
        {
            var result = new EthereumTransactionSearchResult();

            var transactions = await _ethereumService.GetTransactionsByBlockNumberAsync(
                searchRequest.BlockNumberNumerical);

            // filter transactions down if they are associated with an address
            var addressToMatch = searchRequest.Address.Trim();
            transactions = transactions
                .Where(t => t.To == addressToMatch || t.From == addressToMatch);

            // map transactions to DTO model
            foreach (var transaction in transactions)
            {
                var dtoTransaction = _mapper.Map(transaction);
                result.Transactions.Add(dtoTransaction);
            }

            return result;
        }
    }
}
