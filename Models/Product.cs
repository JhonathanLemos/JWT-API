using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public class Product : Entity
    {
        public string NomeProduto { get; set; }
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
    }
}
