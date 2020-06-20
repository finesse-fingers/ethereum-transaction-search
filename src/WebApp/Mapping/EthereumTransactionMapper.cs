using WebApp.Models;

namespace WebApp.Mapping
{
    public class EthereumTransactionMapper : IEthereumTransactionMapper<EthereumTransactionDTO>
    {
        public EthereumTransactionDTO Map(EthereumTransaction source) 
        {
            var result = new EthereumTransactionDTO();

            if (source == null)
            {
                return result;
            }

            result.BlockHash = source.BlockHash;
            result.BlockNumber = source.BlockNumber;
            result.Gas = source.Gas;
            result.Hash = source.Hash;
            result.From = source.From;
            result.To = source.To;
            //result.Value = Convert.ToInt64(source.Value, 16);
            result.Value = source.Value;

            return result;
        }
    }
}
