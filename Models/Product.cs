using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public class Product : Entity
    {
        public string NomeProduto { get; set; }


        public long CustomerId { get; set; }
    }
}
