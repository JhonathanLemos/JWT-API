using System.ComponentModel.DataAnnotations;

namespace NetCoreAPI.Models
{
    public class Customer : Entity
    {
        public string NomeCliente { get; set; }

        public IEnumerable<Product> Produtos { get; set; }
    }
}
