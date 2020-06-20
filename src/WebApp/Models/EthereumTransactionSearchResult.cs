using System.Collections.Generic;

namespace WebApp.Models
{
    public class EthereumTransactionSearchResult
    {
        public bool TransientError { get; set; } = false;
        public List<EthereumTransactionDto> Transactions { get; set; } = new List<EthereumTransactionDto>();
    }
}