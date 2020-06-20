using System.Collections.Generic;

namespace WebApp.Models
{
    public class EthereumTransactionSearchResult
    {
        public List<EthereumTransactionDto> Transactions { get; set; } = new List<EthereumTransactionDto>();
    }
}