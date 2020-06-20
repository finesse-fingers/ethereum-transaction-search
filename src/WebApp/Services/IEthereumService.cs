using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IEthereumService
    {
        Task<IEnumerable<EthereumTransaction>> GetTransactionsByBlockNumberAsync(
            long blockNumber);
    }
}