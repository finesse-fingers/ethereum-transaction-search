using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Actions
{
    public interface IEthereumTransactionSearchActionHandler
    {
        /// <summary>
        /// Search for ethereum transactions
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        Task<EthereumTransactionSearchResult> Search(EthereumTransactionSearchRequest searchRequest);
    }
}