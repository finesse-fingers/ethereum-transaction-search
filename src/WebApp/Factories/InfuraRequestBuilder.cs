using WebApp.Models;

namespace WebApp.Factories
{
    public class InfuraRequestBuilder : IInfuraRequestBuilder
    {
        private const string JsonRPC = "2.0";
        private const int Id = 1;

        public InfuraRequest MakeGetBlockByNumber(long blockNumber, bool includeTransactions)
        {
            return new InfuraRequest
            {
                JsonRPC = JsonRPC,
                Id = Id,
                Method = "eth_getBlockByNumber",
                Params = new object[] { $"0x{blockNumber:X}", includeTransactions }
            };
        }
    }
}
