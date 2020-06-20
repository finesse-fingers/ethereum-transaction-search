using WebApp.Models;

namespace WebApp.Mapping
{
    /// <summary>
    /// Implement interface to modify the UI view model
    /// </summary>
    public interface IEthereumTransactionMapper<T>
    {
        public T Map(EthereumTransaction source);
    }
}