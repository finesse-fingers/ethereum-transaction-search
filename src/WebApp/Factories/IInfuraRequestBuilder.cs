using WebApp.Models;

namespace WebApp.Factories
{
    public interface IInfuraRequestBuilder
    {
        /// <summary>
        /// Make eth_getBlockByNumber request
        /// </summary>
        /// <param name="blockNumber"></param>
        /// <param name="includeTransactions"></param>
        /// <returns></returns>
        InfuraRequest MakeGetBlockByNumber(long blockNumber, bool includeTransactions);
    }
}