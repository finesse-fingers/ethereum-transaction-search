using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EthereumTransactionSearchRequest
    {
        [Required]
        public string BlockNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public long BlockNumberNumerical
        {
            get
            {
                try
                {
                    return long.Parse(BlockNumber.Trim());
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}
