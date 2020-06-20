using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class EhthereumTransactionSearchRequest
    {
        [Required]
        public string Block { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
