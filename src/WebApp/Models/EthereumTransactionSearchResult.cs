using System.Collections.Generic;

namespace WebApp.Models
{
    public class EthereumTransactionSearchResult
    {
        public List<EthereumTransactionDTO> Transactions { get; set; } = new List<EthereumTransactionDTO>();
    }
}